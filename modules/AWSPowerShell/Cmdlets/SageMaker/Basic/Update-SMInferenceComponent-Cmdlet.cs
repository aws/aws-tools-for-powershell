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
    /// Updates an inference component.
    /// </summary>
    [Cmdlet("Update", "SMInferenceComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateInferenceComponent API operation.", Operation = new[] {"UpdateInferenceComponent"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateInferenceComponentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateInferenceComponentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateInferenceComponentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMInferenceComponentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoRollbackConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>List of CloudWatch alarms in your account that are configured to monitor metrics on
        /// an endpoint. If any alarms are tripped during a deployment, SageMaker rolls back the
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_AutoRollbackConfiguration_Alarms")]
        public Amazon.SageMaker.Model.Alarm[] AutoRollbackConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter Container_ArtifactUrl
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path where the model artifacts, which result from model training, are
        /// stored. This path must point to a single gzip compressed tar archive (.tar.gz suffix).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_Container_ArtifactUrl")]
        public System.String Container_ArtifactUrl { get; set; }
        #endregion
        
        #region Parameter Specification_BaseInferenceComponentName
        /// <summary>
        /// <para>
        /// <para>The name of an existing inference component that is to contain the inference component
        /// that you're creating with your request.</para><para>Specify this parameter only if your request is meant to create an adapter inference
        /// component. An adapter inference component contains the path to an adapter model. The
        /// purpose of the adapter model is to tailor the inference output of a base foundation
        /// model, which is hosted by the base inference component. The adapter inference component
        /// uses the compute resources that you assigned to the base inference component.</para><para>When you create an adapter inference component, use the <c>Container</c> parameter
        /// to specify the location of the adapter artifacts. In the parameter value, use the
        /// <c>ArtifactUrl</c> parameter of the <c>InferenceComponentContainerSpecification</c>
        /// data type.</para><para>Before you can create an adapter inference component, you must have an existing inference
        /// component that contains the foundation model that you want to adapt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Specification_BaseInferenceComponentName { get; set; }
        #endregion
        
        #region Parameter StartupParameters_ContainerStartupHealthCheckTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The timeout value, in seconds, for your inference container to pass health check by
        /// Amazon S3 Hosting. For more information about health check, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/your-algorithms-inference-code.html#your-algorithms-inference-algo-ping-requests">How
        /// Your Container Should Respond to Health Check (Ping) Requests</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_StartupParameters_ContainerStartupHealthCheckTimeoutInSeconds")]
        public System.Int32? StartupParameters_ContainerStartupHealthCheckTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter RuntimeConfig_CopyCount
        /// <summary>
        /// <para>
        /// <para>The number of runtime copies of the model container to deploy with the inference component.
        /// Each copy can serve inference requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RuntimeConfig_CopyCount { get; set; }
        #endregion
        
        #region Parameter DataCacheConfig_EnableCaching
        /// <summary>
        /// <para>
        /// <para>Sets whether the endpoint that hosts the inference component caches the model artifacts
        /// and container image.</para><para>With caching enabled, the endpoint caches this data in each instance that it provisions
        /// for the inference component. That way, the inference component deploys faster during
        /// the auto scaling process. If caching isn't enabled, the inference component takes
        /// longer to deploy because of the time it spends downloading the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_DataCacheConfig_EnableCaching")]
        public System.Boolean? DataCacheConfig_EnableCaching { get; set; }
        #endregion
        
        #region Parameter Container_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container. Each key and value in the
        /// Environment string-to-string map can have length of up to 1024. We support up to 16
        /// entries in the map.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_Container_Environment")]
        public System.Collections.Hashtable Container_Environment { get; set; }
        #endregion
        
        #region Parameter Container_Image
        /// <summary>
        /// <para>
        /// <para>The Amazon Elastic Container Registry (Amazon ECR) path where the Docker image for
        /// the model is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_Container_Image")]
        public System.String Container_Image { get; set; }
        #endregion
        
        #region Parameter InferenceComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the inference component.</para>
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
        public System.String InferenceComponentName { get; set; }
        #endregion
        
        #region Parameter RollingUpdatePolicy_MaximumExecutionTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The time limit for the total deployment. Exceeding this limit causes a timeout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumExecutionTimeoutInSeconds")]
        public System.Int32? RollingUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter ComputeResourceRequirements_MaxMemoryRequiredInMb
        /// <summary>
        /// <para>
        /// <para>The maximum MB of memory to allocate to run a model that you assign to an inference
        /// component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_ComputeResourceRequirements_MaxMemoryRequiredInMb")]
        public System.Int32? ComputeResourceRequirements_MaxMemoryRequiredInMb { get; set; }
        #endregion
        
        #region Parameter ComputeResourceRequirements_MinMemoryRequiredInMb
        /// <summary>
        /// <para>
        /// <para>The minimum MB of memory to allocate to run a model that you assign to an inference
        /// component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_ComputeResourceRequirements_MinMemoryRequiredInMb")]
        public System.Int32? ComputeResourceRequirements_MinMemoryRequiredInMb { get; set; }
        #endregion
        
        #region Parameter StartupParameters_ModelDataDownloadTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The timeout value, in seconds, to download and extract the model that you want to
        /// host from Amazon S3 to the individual inference instance associated with this inference
        /// component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_StartupParameters_ModelDataDownloadTimeoutInSeconds")]
        public System.Int32? StartupParameters_ModelDataDownloadTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Specification_ModelName
        /// <summary>
        /// <para>
        /// <para>The name of an existing SageMaker AI model object in your account that you want to
        /// deploy with the inference component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Specification_ModelName { get; set; }
        #endregion
        
        #region Parameter ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired
        /// <summary>
        /// <para>
        /// <para>The number of accelerators to allocate to run a model that you assign to an inference
        /// component. Accelerators include GPUs and Amazon Web Services Inferentia.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired")]
        public System.Single? ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired { get; set; }
        #endregion
        
        #region Parameter ComputeResourceRequirements_NumberOfCpuCoresRequired
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores to allocate to run a model that you assign to an inference
        /// component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Specification_ComputeResourceRequirements_NumberOfCpuCoresRequired")]
        public System.Single? ComputeResourceRequirements_NumberOfCpuCoresRequired { get; set; }
        #endregion
        
        #region Parameter MaximumBatchSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><dl><dt>COPY_COUNT</dt><dd><para>The endpoint activates based on the number of inference component copies.</para></dd><dt>CAPACITY_PERCENT</dt><dd><para>The endpoint activates based on the specified percentage of capacity.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumBatchSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.InferenceComponentCapacitySizeType")]
        public Amazon.SageMaker.InferenceComponentCapacitySizeType MaximumBatchSize_Type { get; set; }
        #endregion
        
        #region Parameter RollbackMaximumBatchSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><dl><dt>COPY_COUNT</dt><dd><para>The endpoint activates based on the number of inference component copies.</para></dd><dt>CAPACITY_PERCENT</dt><dd><para>The endpoint activates based on the specified percentage of capacity.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.InferenceComponentCapacitySizeType")]
        public Amazon.SageMaker.InferenceComponentCapacitySizeType RollbackMaximumBatchSize_Type { get; set; }
        #endregion
        
        #region Parameter MaximumBatchSize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of inference component copies or a capacity
        /// percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumBatchSize_Value")]
        public System.Int32? MaximumBatchSize_Value { get; set; }
        #endregion
        
        #region Parameter RollbackMaximumBatchSize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of inference component copies or a capacity
        /// percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_Value")]
        public System.Int32? RollbackMaximumBatchSize_Value { get; set; }
        #endregion
        
        #region Parameter RollingUpdatePolicy_WaitIntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The length of the baking period, during which SageMaker AI monitors alarms for each
        /// batch on the new fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_WaitIntervalInSeconds")]
        public System.Int32? RollingUpdatePolicy_WaitIntervalInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InferenceComponentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateInferenceComponentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateInferenceComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InferenceComponentArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InferenceComponentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InferenceComponentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InferenceComponentName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InferenceComponentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMInferenceComponent (UpdateInferenceComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateInferenceComponentResponse, UpdateSMInferenceComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InferenceComponentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AutoRollbackConfiguration_Alarm != null)
            {
                context.AutoRollbackConfiguration_Alarm = new List<Amazon.SageMaker.Model.Alarm>(this.AutoRollbackConfiguration_Alarm);
            }
            context.MaximumBatchSize_Type = this.MaximumBatchSize_Type;
            context.MaximumBatchSize_Value = this.MaximumBatchSize_Value;
            context.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond = this.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond;
            context.RollbackMaximumBatchSize_Type = this.RollbackMaximumBatchSize_Type;
            context.RollbackMaximumBatchSize_Value = this.RollbackMaximumBatchSize_Value;
            context.RollingUpdatePolicy_WaitIntervalInSecond = this.RollingUpdatePolicy_WaitIntervalInSecond;
            context.InferenceComponentName = this.InferenceComponentName;
            #if MODULAR
            if (this.InferenceComponentName == null && ParameterWasBound(nameof(this.InferenceComponentName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceComponentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeConfig_CopyCount = this.RuntimeConfig_CopyCount;
            context.Specification_BaseInferenceComponentName = this.Specification_BaseInferenceComponentName;
            context.ComputeResourceRequirements_MaxMemoryRequiredInMb = this.ComputeResourceRequirements_MaxMemoryRequiredInMb;
            context.ComputeResourceRequirements_MinMemoryRequiredInMb = this.ComputeResourceRequirements_MinMemoryRequiredInMb;
            context.ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired = this.ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired;
            context.ComputeResourceRequirements_NumberOfCpuCoresRequired = this.ComputeResourceRequirements_NumberOfCpuCoresRequired;
            context.Container_ArtifactUrl = this.Container_ArtifactUrl;
            if (this.Container_Environment != null)
            {
                context.Container_Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Container_Environment.Keys)
                {
                    context.Container_Environment.Add((String)hashKey, (System.String)(this.Container_Environment[hashKey]));
                }
            }
            context.Container_Image = this.Container_Image;
            context.DataCacheConfig_EnableCaching = this.DataCacheConfig_EnableCaching;
            context.Specification_ModelName = this.Specification_ModelName;
            context.StartupParameters_ContainerStartupHealthCheckTimeoutInSecond = this.StartupParameters_ContainerStartupHealthCheckTimeoutInSecond;
            context.StartupParameters_ModelDataDownloadTimeoutInSecond = this.StartupParameters_ModelDataDownloadTimeoutInSecond;
            
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
            var request = new Amazon.SageMaker.Model.UpdateInferenceComponentRequest();
            
            
             // populate DeploymentConfig
            var requestDeploymentConfigIsNull = true;
            request.DeploymentConfig = new Amazon.SageMaker.Model.InferenceComponentDeploymentConfig();
            Amazon.SageMaker.Model.AutoRollbackConfig requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            
             // populate AutoRollbackConfiguration
            var requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull = true;
            requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = new Amazon.SageMaker.Model.AutoRollbackConfig();
            List<Amazon.SageMaker.Model.Alarm> requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm = null;
            if (cmdletContext.AutoRollbackConfiguration_Alarm != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm = cmdletContext.AutoRollbackConfiguration_Alarm;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration.Alarms = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm;
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration should be set to null
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration != null)
            {
                request.DeploymentConfig.AutoRollbackConfiguration = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration;
                requestDeploymentConfigIsNull = false;
            }
            Amazon.SageMaker.Model.InferenceComponentRollingUpdatePolicy requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = null;
            
             // populate RollingUpdatePolicy
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = new Amazon.SageMaker.Model.InferenceComponentRollingUpdatePolicy();
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond = null;
            if (cmdletContext.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond = cmdletContext.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.MaximumExecutionTimeoutInSeconds = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond = null;
            if (cmdletContext.RollingUpdatePolicy_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond = cmdletContext.RollingUpdatePolicy_WaitIntervalInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.WaitIntervalInSeconds = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
            Amazon.SageMaker.Model.InferenceComponentCapacitySize requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = null;
            
             // populate MaximumBatchSize
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = new Amazon.SageMaker.Model.InferenceComponentCapacitySize();
            Amazon.SageMaker.InferenceComponentCapacitySizeType requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type = null;
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
            Amazon.SageMaker.Model.InferenceComponentCapacitySize requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = null;
            
             // populate RollbackMaximumBatchSize
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = new Amazon.SageMaker.Model.InferenceComponentCapacitySize();
            Amazon.SageMaker.InferenceComponentCapacitySizeType requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type = null;
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
            if (cmdletContext.InferenceComponentName != null)
            {
                request.InferenceComponentName = cmdletContext.InferenceComponentName;
            }
            
             // populate RuntimeConfig
            var requestRuntimeConfigIsNull = true;
            request.RuntimeConfig = new Amazon.SageMaker.Model.InferenceComponentRuntimeConfig();
            System.Int32? requestRuntimeConfig_runtimeConfig_CopyCount = null;
            if (cmdletContext.RuntimeConfig_CopyCount != null)
            {
                requestRuntimeConfig_runtimeConfig_CopyCount = cmdletContext.RuntimeConfig_CopyCount.Value;
            }
            if (requestRuntimeConfig_runtimeConfig_CopyCount != null)
            {
                request.RuntimeConfig.CopyCount = requestRuntimeConfig_runtimeConfig_CopyCount.Value;
                requestRuntimeConfigIsNull = false;
            }
             // determine if request.RuntimeConfig should be set to null
            if (requestRuntimeConfigIsNull)
            {
                request.RuntimeConfig = null;
            }
            
             // populate Specification
            var requestSpecificationIsNull = true;
            request.Specification = new Amazon.SageMaker.Model.InferenceComponentSpecification();
            System.String requestSpecification_specification_BaseInferenceComponentName = null;
            if (cmdletContext.Specification_BaseInferenceComponentName != null)
            {
                requestSpecification_specification_BaseInferenceComponentName = cmdletContext.Specification_BaseInferenceComponentName;
            }
            if (requestSpecification_specification_BaseInferenceComponentName != null)
            {
                request.Specification.BaseInferenceComponentName = requestSpecification_specification_BaseInferenceComponentName;
                requestSpecificationIsNull = false;
            }
            System.String requestSpecification_specification_ModelName = null;
            if (cmdletContext.Specification_ModelName != null)
            {
                requestSpecification_specification_ModelName = cmdletContext.Specification_ModelName;
            }
            if (requestSpecification_specification_ModelName != null)
            {
                request.Specification.ModelName = requestSpecification_specification_ModelName;
                requestSpecificationIsNull = false;
            }
            Amazon.SageMaker.Model.InferenceComponentDataCacheConfig requestSpecification_specification_DataCacheConfig = null;
            
             // populate DataCacheConfig
            var requestSpecification_specification_DataCacheConfigIsNull = true;
            requestSpecification_specification_DataCacheConfig = new Amazon.SageMaker.Model.InferenceComponentDataCacheConfig();
            System.Boolean? requestSpecification_specification_DataCacheConfig_dataCacheConfig_EnableCaching = null;
            if (cmdletContext.DataCacheConfig_EnableCaching != null)
            {
                requestSpecification_specification_DataCacheConfig_dataCacheConfig_EnableCaching = cmdletContext.DataCacheConfig_EnableCaching.Value;
            }
            if (requestSpecification_specification_DataCacheConfig_dataCacheConfig_EnableCaching != null)
            {
                requestSpecification_specification_DataCacheConfig.EnableCaching = requestSpecification_specification_DataCacheConfig_dataCacheConfig_EnableCaching.Value;
                requestSpecification_specification_DataCacheConfigIsNull = false;
            }
             // determine if requestSpecification_specification_DataCacheConfig should be set to null
            if (requestSpecification_specification_DataCacheConfigIsNull)
            {
                requestSpecification_specification_DataCacheConfig = null;
            }
            if (requestSpecification_specification_DataCacheConfig != null)
            {
                request.Specification.DataCacheConfig = requestSpecification_specification_DataCacheConfig;
                requestSpecificationIsNull = false;
            }
            Amazon.SageMaker.Model.InferenceComponentStartupParameters requestSpecification_specification_StartupParameters = null;
            
             // populate StartupParameters
            var requestSpecification_specification_StartupParametersIsNull = true;
            requestSpecification_specification_StartupParameters = new Amazon.SageMaker.Model.InferenceComponentStartupParameters();
            System.Int32? requestSpecification_specification_StartupParameters_startupParameters_ContainerStartupHealthCheckTimeoutInSecond = null;
            if (cmdletContext.StartupParameters_ContainerStartupHealthCheckTimeoutInSecond != null)
            {
                requestSpecification_specification_StartupParameters_startupParameters_ContainerStartupHealthCheckTimeoutInSecond = cmdletContext.StartupParameters_ContainerStartupHealthCheckTimeoutInSecond.Value;
            }
            if (requestSpecification_specification_StartupParameters_startupParameters_ContainerStartupHealthCheckTimeoutInSecond != null)
            {
                requestSpecification_specification_StartupParameters.ContainerStartupHealthCheckTimeoutInSeconds = requestSpecification_specification_StartupParameters_startupParameters_ContainerStartupHealthCheckTimeoutInSecond.Value;
                requestSpecification_specification_StartupParametersIsNull = false;
            }
            System.Int32? requestSpecification_specification_StartupParameters_startupParameters_ModelDataDownloadTimeoutInSecond = null;
            if (cmdletContext.StartupParameters_ModelDataDownloadTimeoutInSecond != null)
            {
                requestSpecification_specification_StartupParameters_startupParameters_ModelDataDownloadTimeoutInSecond = cmdletContext.StartupParameters_ModelDataDownloadTimeoutInSecond.Value;
            }
            if (requestSpecification_specification_StartupParameters_startupParameters_ModelDataDownloadTimeoutInSecond != null)
            {
                requestSpecification_specification_StartupParameters.ModelDataDownloadTimeoutInSeconds = requestSpecification_specification_StartupParameters_startupParameters_ModelDataDownloadTimeoutInSecond.Value;
                requestSpecification_specification_StartupParametersIsNull = false;
            }
             // determine if requestSpecification_specification_StartupParameters should be set to null
            if (requestSpecification_specification_StartupParametersIsNull)
            {
                requestSpecification_specification_StartupParameters = null;
            }
            if (requestSpecification_specification_StartupParameters != null)
            {
                request.Specification.StartupParameters = requestSpecification_specification_StartupParameters;
                requestSpecificationIsNull = false;
            }
            Amazon.SageMaker.Model.InferenceComponentContainerSpecification requestSpecification_specification_Container = null;
            
             // populate Container
            var requestSpecification_specification_ContainerIsNull = true;
            requestSpecification_specification_Container = new Amazon.SageMaker.Model.InferenceComponentContainerSpecification();
            System.String requestSpecification_specification_Container_container_ArtifactUrl = null;
            if (cmdletContext.Container_ArtifactUrl != null)
            {
                requestSpecification_specification_Container_container_ArtifactUrl = cmdletContext.Container_ArtifactUrl;
            }
            if (requestSpecification_specification_Container_container_ArtifactUrl != null)
            {
                requestSpecification_specification_Container.ArtifactUrl = requestSpecification_specification_Container_container_ArtifactUrl;
                requestSpecification_specification_ContainerIsNull = false;
            }
            Dictionary<System.String, System.String> requestSpecification_specification_Container_container_Environment = null;
            if (cmdletContext.Container_Environment != null)
            {
                requestSpecification_specification_Container_container_Environment = cmdletContext.Container_Environment;
            }
            if (requestSpecification_specification_Container_container_Environment != null)
            {
                requestSpecification_specification_Container.Environment = requestSpecification_specification_Container_container_Environment;
                requestSpecification_specification_ContainerIsNull = false;
            }
            System.String requestSpecification_specification_Container_container_Image = null;
            if (cmdletContext.Container_Image != null)
            {
                requestSpecification_specification_Container_container_Image = cmdletContext.Container_Image;
            }
            if (requestSpecification_specification_Container_container_Image != null)
            {
                requestSpecification_specification_Container.Image = requestSpecification_specification_Container_container_Image;
                requestSpecification_specification_ContainerIsNull = false;
            }
             // determine if requestSpecification_specification_Container should be set to null
            if (requestSpecification_specification_ContainerIsNull)
            {
                requestSpecification_specification_Container = null;
            }
            if (requestSpecification_specification_Container != null)
            {
                request.Specification.Container = requestSpecification_specification_Container;
                requestSpecificationIsNull = false;
            }
            Amazon.SageMaker.Model.InferenceComponentComputeResourceRequirements requestSpecification_specification_ComputeResourceRequirements = null;
            
             // populate ComputeResourceRequirements
            var requestSpecification_specification_ComputeResourceRequirementsIsNull = true;
            requestSpecification_specification_ComputeResourceRequirements = new Amazon.SageMaker.Model.InferenceComponentComputeResourceRequirements();
            System.Int32? requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MaxMemoryRequiredInMb = null;
            if (cmdletContext.ComputeResourceRequirements_MaxMemoryRequiredInMb != null)
            {
                requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MaxMemoryRequiredInMb = cmdletContext.ComputeResourceRequirements_MaxMemoryRequiredInMb.Value;
            }
            if (requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MaxMemoryRequiredInMb != null)
            {
                requestSpecification_specification_ComputeResourceRequirements.MaxMemoryRequiredInMb = requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MaxMemoryRequiredInMb.Value;
                requestSpecification_specification_ComputeResourceRequirementsIsNull = false;
            }
            System.Int32? requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MinMemoryRequiredInMb = null;
            if (cmdletContext.ComputeResourceRequirements_MinMemoryRequiredInMb != null)
            {
                requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MinMemoryRequiredInMb = cmdletContext.ComputeResourceRequirements_MinMemoryRequiredInMb.Value;
            }
            if (requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MinMemoryRequiredInMb != null)
            {
                requestSpecification_specification_ComputeResourceRequirements.MinMemoryRequiredInMb = requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_MinMemoryRequiredInMb.Value;
                requestSpecification_specification_ComputeResourceRequirementsIsNull = false;
            }
            System.Single? requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfAcceleratorDevicesRequired = null;
            if (cmdletContext.ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired != null)
            {
                requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfAcceleratorDevicesRequired = cmdletContext.ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired.Value;
            }
            if (requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfAcceleratorDevicesRequired != null)
            {
                requestSpecification_specification_ComputeResourceRequirements.NumberOfAcceleratorDevicesRequired = requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfAcceleratorDevicesRequired.Value;
                requestSpecification_specification_ComputeResourceRequirementsIsNull = false;
            }
            System.Single? requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfCpuCoresRequired = null;
            if (cmdletContext.ComputeResourceRequirements_NumberOfCpuCoresRequired != null)
            {
                requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfCpuCoresRequired = cmdletContext.ComputeResourceRequirements_NumberOfCpuCoresRequired.Value;
            }
            if (requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfCpuCoresRequired != null)
            {
                requestSpecification_specification_ComputeResourceRequirements.NumberOfCpuCoresRequired = requestSpecification_specification_ComputeResourceRequirements_computeResourceRequirements_NumberOfCpuCoresRequired.Value;
                requestSpecification_specification_ComputeResourceRequirementsIsNull = false;
            }
             // determine if requestSpecification_specification_ComputeResourceRequirements should be set to null
            if (requestSpecification_specification_ComputeResourceRequirementsIsNull)
            {
                requestSpecification_specification_ComputeResourceRequirements = null;
            }
            if (requestSpecification_specification_ComputeResourceRequirements != null)
            {
                request.Specification.ComputeResourceRequirements = requestSpecification_specification_ComputeResourceRequirements;
                requestSpecificationIsNull = false;
            }
             // determine if request.Specification should be set to null
            if (requestSpecificationIsNull)
            {
                request.Specification = null;
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
        
        private Amazon.SageMaker.Model.UpdateInferenceComponentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateInferenceComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateInferenceComponent");
            try
            {
                #if DESKTOP
                return client.UpdateInferenceComponent(request);
                #elif CORECLR
                return client.UpdateInferenceComponentAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.Alarm> AutoRollbackConfiguration_Alarm { get; set; }
            public Amazon.SageMaker.InferenceComponentCapacitySizeType MaximumBatchSize_Type { get; set; }
            public System.Int32? MaximumBatchSize_Value { get; set; }
            public System.Int32? RollingUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
            public Amazon.SageMaker.InferenceComponentCapacitySizeType RollbackMaximumBatchSize_Type { get; set; }
            public System.Int32? RollbackMaximumBatchSize_Value { get; set; }
            public System.Int32? RollingUpdatePolicy_WaitIntervalInSecond { get; set; }
            public System.String InferenceComponentName { get; set; }
            public System.Int32? RuntimeConfig_CopyCount { get; set; }
            public System.String Specification_BaseInferenceComponentName { get; set; }
            public System.Int32? ComputeResourceRequirements_MaxMemoryRequiredInMb { get; set; }
            public System.Int32? ComputeResourceRequirements_MinMemoryRequiredInMb { get; set; }
            public System.Single? ComputeResourceRequirements_NumberOfAcceleratorDevicesRequired { get; set; }
            public System.Single? ComputeResourceRequirements_NumberOfCpuCoresRequired { get; set; }
            public System.String Container_ArtifactUrl { get; set; }
            public Dictionary<System.String, System.String> Container_Environment { get; set; }
            public System.String Container_Image { get; set; }
            public System.Boolean? DataCacheConfig_EnableCaching { get; set; }
            public System.String Specification_ModelName { get; set; }
            public System.Int32? StartupParameters_ContainerStartupHealthCheckTimeoutInSecond { get; set; }
            public System.Int32? StartupParameters_ModelDataDownloadTimeoutInSecond { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateInferenceComponentResponse, UpdateSMInferenceComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InferenceComponentArn;
        }
        
    }
}
