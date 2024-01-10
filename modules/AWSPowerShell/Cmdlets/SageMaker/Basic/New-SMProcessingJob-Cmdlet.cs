/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a processing job.
    /// </summary>
    [Cmdlet("New", "SMProcessingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateProcessingJob API operation.", Operation = new[] {"CreateProcessingJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateProcessingJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateProcessingJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateProcessingJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMProcessingJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppSpecification_ContainerArgument
        /// <summary>
        /// <para>
        /// <para>The arguments for a container used to run a processing job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppSpecification_ContainerArguments")]
        public System.String[] AppSpecification_ContainerArgument { get; set; }
        #endregion
        
        #region Parameter AppSpecification_ContainerEntrypoint
        /// <summary>
        /// <para>
        /// <para>The entrypoint for a container used to run a processing job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AppSpecification_ContainerEntrypoint { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>Whether to encrypt all communications between distributed processing jobs. Choose
        /// <c>True</c> to encrypt communications. Encryption provides greater security for distributed
        /// processing jobs, but the processing might take longer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkConfig_EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_EnableNetworkIsolation
        /// <summary>
        /// <para>
        /// <para>Whether to allow inbound and outbound network calls to and from the containers used
        /// for the processing job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkConfig_EnableNetworkIsolation { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container. Up to 100 key and values
        /// entries in the map are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Environment { get; set; }
        #endregion
        
        #region Parameter ExperimentConfig_ExperimentName
        /// <summary>
        /// <para>
        /// <para>The name of an existing experiment to associate with the trial component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentConfig_ExperimentName { get; set; }
        #endregion
        
        #region Parameter AppSpecification_ImageUri
        /// <summary>
        /// <para>
        /// <para>The container image to be run by the processing job.</para>
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
        public System.String AppSpecification_ImageUri { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of ML compute instances to use in the processing job. For distributed processing
        /// jobs, specify a value greater than 1. The default value is 1.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ProcessingResources_ClusterConfig_InstanceCount")]
        public System.Int32? ClusterConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>The ML compute instance type for the processing job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ProcessingResources_ClusterConfig_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingInstanceType")]
        public Amazon.SageMaker.ProcessingInstanceType ClusterConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter ProcessingOutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt the processing job output. <c>KmsKeyId</c> can be
        /// an ID of a KMS key, ARN of a KMS key, alias of a KMS key, or alias of a KMS key. The
        /// <c>KmsKeyId</c> is applied to all outputs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProcessingOutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum runtime in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter ProcessingOutputConfig_Output
        /// <summary>
        /// <para>
        /// <para>An array of outputs configuring the data to upload from the processing container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProcessingOutputConfig_Outputs")]
        public Amazon.SageMaker.Model.ProcessingOutput[] ProcessingOutputConfig_Output { get; set; }
        #endregion
        
        #region Parameter ProcessingInput
        /// <summary>
        /// <para>
        /// <para>An array of inputs configuring the data to download into the processing container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProcessingInputs")]
        public Amazon.SageMaker.Model.ProcessingInput[] ProcessingInput { get; set; }
        #endregion
        
        #region Parameter ProcessingJobName
        /// <summary>
        /// <para>
        /// <para> The name of the processing job. The name must be unique within an Amazon Web Services
        /// Region in the Amazon Web Services account.</para>
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
        public System.String ProcessingJobName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that Amazon SageMaker can assume to
        /// perform tasks on your behalf.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ExperimentConfig_RunName
        /// <summary>
        /// <para>
        /// <para>The name of the experiment run to associate with the trial component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentConfig_RunName { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model. For information about the availability of specific instance types, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/instance-types-az.html">Supported
        /// Instance Types and Availability Zones</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>(Optional) An array of key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-whatURL">Using
        /// Cost Allocation Tags</a> in the <i>Amazon Web Services Billing and Cost Management
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ExperimentConfig_TrialComponentDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name for the trial component. If this key isn't specified, the display
        /// name is the trial component name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentConfig_TrialComponentDisplayName { get; set; }
        #endregion
        
        #region Parameter ExperimentConfig_TrialName
        /// <summary>
        /// <para>
        /// <para>The name of an existing trial to associate the trial component with. If not specified,
        /// a new trial is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentConfig_TrialName { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt data on the storage volume attached to the ML compute
        /// instance(s) that run the processing job. </para><note><para>Certain Nitro-based instances include local storage, dependent on the instance type.
        /// Local storage volumes are encrypted using a hardware module on the instance. You can't
        /// request a <c>VolumeKmsKeyId</c> when using an instance type with local storage.</para><para>For a list of instance types that support local instance storage, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html#instance-store-volumes">Instance
        /// Store Volumes</a>.</para><para>For more information about local instance storage encryption, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ssd-instance-store.html">SSD
        /// Instance Store Volumes</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProcessingResources_ClusterConfig_VolumeKmsKeyId")]
        public System.String ClusterConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_VolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The size of the ML storage volume in gigabytes that you want to provision. You must
        /// specify sufficient ML storage for your scenario.</para><note><para>Certain Nitro-based instances include local storage with a fixed total size, dependent
        /// on the instance type. When using these instances for processing, Amazon SageMaker
        /// mounts the local instance storage instead of Amazon EBS gp2 storage. You can't request
        /// a <c>VolumeSizeInGB</c> greater than the total size of the local instance storage.</para><para>For a list of instance types that support local instance storage, including the total
        /// size per instance type, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html#instance-store-volumes">Instance
        /// Store Volumes</a>.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ProcessingResources_ClusterConfig_VolumeSizeInGB")]
        public System.Int32? ClusterConfig_VolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProcessingJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateProcessingJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateProcessingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProcessingJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProcessingJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProcessingJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProcessingJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProcessingJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMProcessingJob (CreateProcessingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateProcessingJobResponse, NewSMProcessingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProcessingJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AppSpecification_ContainerArgument != null)
            {
                context.AppSpecification_ContainerArgument = new List<System.String>(this.AppSpecification_ContainerArgument);
            }
            if (this.AppSpecification_ContainerEntrypoint != null)
            {
                context.AppSpecification_ContainerEntrypoint = new List<System.String>(this.AppSpecification_ContainerEntrypoint);
            }
            context.AppSpecification_ImageUri = this.AppSpecification_ImageUri;
            #if MODULAR
            if (this.AppSpecification_ImageUri == null && ParameterWasBound(nameof(this.AppSpecification_ImageUri)))
            {
                WriteWarning("You are passing $null as a value for parameter AppSpecification_ImageUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Environment != null)
            {
                context.Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment.Keys)
                {
                    context.Environment.Add((String)hashKey, (String)(this.Environment[hashKey]));
                }
            }
            context.ExperimentConfig_ExperimentName = this.ExperimentConfig_ExperimentName;
            context.ExperimentConfig_RunName = this.ExperimentConfig_RunName;
            context.ExperimentConfig_TrialComponentDisplayName = this.ExperimentConfig_TrialComponentDisplayName;
            context.ExperimentConfig_TrialName = this.ExperimentConfig_TrialName;
            context.NetworkConfig_EnableInterContainerTrafficEncryption = this.NetworkConfig_EnableInterContainerTrafficEncryption;
            context.NetworkConfig_EnableNetworkIsolation = this.NetworkConfig_EnableNetworkIsolation;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            if (this.ProcessingInput != null)
            {
                context.ProcessingInput = new List<Amazon.SageMaker.Model.ProcessingInput>(this.ProcessingInput);
            }
            context.ProcessingJobName = this.ProcessingJobName;
            #if MODULAR
            if (this.ProcessingJobName == null && ParameterWasBound(nameof(this.ProcessingJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProcessingJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProcessingOutputConfig_KmsKeyId = this.ProcessingOutputConfig_KmsKeyId;
            if (this.ProcessingOutputConfig_Output != null)
            {
                context.ProcessingOutputConfig_Output = new List<Amazon.SageMaker.Model.ProcessingOutput>(this.ProcessingOutputConfig_Output);
            }
            context.ClusterConfig_InstanceCount = this.ClusterConfig_InstanceCount;
            #if MODULAR
            if (this.ClusterConfig_InstanceCount == null && ParameterWasBound(nameof(this.ClusterConfig_InstanceCount)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterConfig_InstanceCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterConfig_InstanceType = this.ClusterConfig_InstanceType;
            #if MODULAR
            if (this.ClusterConfig_InstanceType == null && ParameterWasBound(nameof(this.ClusterConfig_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterConfig_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterConfig_VolumeKmsKeyId = this.ClusterConfig_VolumeKmsKeyId;
            context.ClusterConfig_VolumeSizeInGB = this.ClusterConfig_VolumeSizeInGB;
            #if MODULAR
            if (this.ClusterConfig_VolumeSizeInGB == null && ParameterWasBound(nameof(this.ClusterConfig_VolumeSizeInGB)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterConfig_VolumeSizeInGB which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateProcessingJobRequest();
            
            
             // populate AppSpecification
            var requestAppSpecificationIsNull = true;
            request.AppSpecification = new Amazon.SageMaker.Model.AppSpecification();
            List<System.String> requestAppSpecification_appSpecification_ContainerArgument = null;
            if (cmdletContext.AppSpecification_ContainerArgument != null)
            {
                requestAppSpecification_appSpecification_ContainerArgument = cmdletContext.AppSpecification_ContainerArgument;
            }
            if (requestAppSpecification_appSpecification_ContainerArgument != null)
            {
                request.AppSpecification.ContainerArguments = requestAppSpecification_appSpecification_ContainerArgument;
                requestAppSpecificationIsNull = false;
            }
            List<System.String> requestAppSpecification_appSpecification_ContainerEntrypoint = null;
            if (cmdletContext.AppSpecification_ContainerEntrypoint != null)
            {
                requestAppSpecification_appSpecification_ContainerEntrypoint = cmdletContext.AppSpecification_ContainerEntrypoint;
            }
            if (requestAppSpecification_appSpecification_ContainerEntrypoint != null)
            {
                request.AppSpecification.ContainerEntrypoint = requestAppSpecification_appSpecification_ContainerEntrypoint;
                requestAppSpecificationIsNull = false;
            }
            System.String requestAppSpecification_appSpecification_ImageUri = null;
            if (cmdletContext.AppSpecification_ImageUri != null)
            {
                requestAppSpecification_appSpecification_ImageUri = cmdletContext.AppSpecification_ImageUri;
            }
            if (requestAppSpecification_appSpecification_ImageUri != null)
            {
                request.AppSpecification.ImageUri = requestAppSpecification_appSpecification_ImageUri;
                requestAppSpecificationIsNull = false;
            }
             // determine if request.AppSpecification should be set to null
            if (requestAppSpecificationIsNull)
            {
                request.AppSpecification = null;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            
             // populate ExperimentConfig
            var requestExperimentConfigIsNull = true;
            request.ExperimentConfig = new Amazon.SageMaker.Model.ExperimentConfig();
            System.String requestExperimentConfig_experimentConfig_ExperimentName = null;
            if (cmdletContext.ExperimentConfig_ExperimentName != null)
            {
                requestExperimentConfig_experimentConfig_ExperimentName = cmdletContext.ExperimentConfig_ExperimentName;
            }
            if (requestExperimentConfig_experimentConfig_ExperimentName != null)
            {
                request.ExperimentConfig.ExperimentName = requestExperimentConfig_experimentConfig_ExperimentName;
                requestExperimentConfigIsNull = false;
            }
            System.String requestExperimentConfig_experimentConfig_RunName = null;
            if (cmdletContext.ExperimentConfig_RunName != null)
            {
                requestExperimentConfig_experimentConfig_RunName = cmdletContext.ExperimentConfig_RunName;
            }
            if (requestExperimentConfig_experimentConfig_RunName != null)
            {
                request.ExperimentConfig.RunName = requestExperimentConfig_experimentConfig_RunName;
                requestExperimentConfigIsNull = false;
            }
            System.String requestExperimentConfig_experimentConfig_TrialComponentDisplayName = null;
            if (cmdletContext.ExperimentConfig_TrialComponentDisplayName != null)
            {
                requestExperimentConfig_experimentConfig_TrialComponentDisplayName = cmdletContext.ExperimentConfig_TrialComponentDisplayName;
            }
            if (requestExperimentConfig_experimentConfig_TrialComponentDisplayName != null)
            {
                request.ExperimentConfig.TrialComponentDisplayName = requestExperimentConfig_experimentConfig_TrialComponentDisplayName;
                requestExperimentConfigIsNull = false;
            }
            System.String requestExperimentConfig_experimentConfig_TrialName = null;
            if (cmdletContext.ExperimentConfig_TrialName != null)
            {
                requestExperimentConfig_experimentConfig_TrialName = cmdletContext.ExperimentConfig_TrialName;
            }
            if (requestExperimentConfig_experimentConfig_TrialName != null)
            {
                request.ExperimentConfig.TrialName = requestExperimentConfig_experimentConfig_TrialName;
                requestExperimentConfigIsNull = false;
            }
             // determine if request.ExperimentConfig should be set to null
            if (requestExperimentConfigIsNull)
            {
                request.ExperimentConfig = null;
            }
            
             // populate NetworkConfig
            var requestNetworkConfigIsNull = true;
            request.NetworkConfig = new Amazon.SageMaker.Model.NetworkConfig();
            System.Boolean? requestNetworkConfig_networkConfig_EnableInterContainerTrafficEncryption = null;
            if (cmdletContext.NetworkConfig_EnableInterContainerTrafficEncryption != null)
            {
                requestNetworkConfig_networkConfig_EnableInterContainerTrafficEncryption = cmdletContext.NetworkConfig_EnableInterContainerTrafficEncryption.Value;
            }
            if (requestNetworkConfig_networkConfig_EnableInterContainerTrafficEncryption != null)
            {
                request.NetworkConfig.EnableInterContainerTrafficEncryption = requestNetworkConfig_networkConfig_EnableInterContainerTrafficEncryption.Value;
                requestNetworkConfigIsNull = false;
            }
            System.Boolean? requestNetworkConfig_networkConfig_EnableNetworkIsolation = null;
            if (cmdletContext.NetworkConfig_EnableNetworkIsolation != null)
            {
                requestNetworkConfig_networkConfig_EnableNetworkIsolation = cmdletContext.NetworkConfig_EnableNetworkIsolation.Value;
            }
            if (requestNetworkConfig_networkConfig_EnableNetworkIsolation != null)
            {
                request.NetworkConfig.EnableNetworkIsolation = requestNetworkConfig_networkConfig_EnableNetworkIsolation.Value;
                requestNetworkConfigIsNull = false;
            }
            Amazon.SageMaker.Model.VpcConfig requestNetworkConfig_networkConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestNetworkConfig_networkConfig_VpcConfigIsNull = true;
            requestNetworkConfig_networkConfig_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig.SecurityGroupIds = requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestNetworkConfig_networkConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig.Subnets = requestNetworkConfig_networkConfig_VpcConfig_vpcConfig_Subnet;
                requestNetworkConfig_networkConfig_VpcConfigIsNull = false;
            }
             // determine if requestNetworkConfig_networkConfig_VpcConfig should be set to null
            if (requestNetworkConfig_networkConfig_VpcConfigIsNull)
            {
                requestNetworkConfig_networkConfig_VpcConfig = null;
            }
            if (requestNetworkConfig_networkConfig_VpcConfig != null)
            {
                request.NetworkConfig.VpcConfig = requestNetworkConfig_networkConfig_VpcConfig;
                requestNetworkConfigIsNull = false;
            }
             // determine if request.NetworkConfig should be set to null
            if (requestNetworkConfigIsNull)
            {
                request.NetworkConfig = null;
            }
            if (cmdletContext.ProcessingInput != null)
            {
                request.ProcessingInputs = cmdletContext.ProcessingInput;
            }
            if (cmdletContext.ProcessingJobName != null)
            {
                request.ProcessingJobName = cmdletContext.ProcessingJobName;
            }
            
             // populate ProcessingOutputConfig
            var requestProcessingOutputConfigIsNull = true;
            request.ProcessingOutputConfig = new Amazon.SageMaker.Model.ProcessingOutputConfig();
            System.String requestProcessingOutputConfig_processingOutputConfig_KmsKeyId = null;
            if (cmdletContext.ProcessingOutputConfig_KmsKeyId != null)
            {
                requestProcessingOutputConfig_processingOutputConfig_KmsKeyId = cmdletContext.ProcessingOutputConfig_KmsKeyId;
            }
            if (requestProcessingOutputConfig_processingOutputConfig_KmsKeyId != null)
            {
                request.ProcessingOutputConfig.KmsKeyId = requestProcessingOutputConfig_processingOutputConfig_KmsKeyId;
                requestProcessingOutputConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.ProcessingOutput> requestProcessingOutputConfig_processingOutputConfig_Output = null;
            if (cmdletContext.ProcessingOutputConfig_Output != null)
            {
                requestProcessingOutputConfig_processingOutputConfig_Output = cmdletContext.ProcessingOutputConfig_Output;
            }
            if (requestProcessingOutputConfig_processingOutputConfig_Output != null)
            {
                request.ProcessingOutputConfig.Outputs = requestProcessingOutputConfig_processingOutputConfig_Output;
                requestProcessingOutputConfigIsNull = false;
            }
             // determine if request.ProcessingOutputConfig should be set to null
            if (requestProcessingOutputConfigIsNull)
            {
                request.ProcessingOutputConfig = null;
            }
            
             // populate ProcessingResources
            var requestProcessingResourcesIsNull = true;
            request.ProcessingResources = new Amazon.SageMaker.Model.ProcessingResources();
            Amazon.SageMaker.Model.ProcessingClusterConfig requestProcessingResources_processingResources_ClusterConfig = null;
            
             // populate ClusterConfig
            var requestProcessingResources_processingResources_ClusterConfigIsNull = true;
            requestProcessingResources_processingResources_ClusterConfig = new Amazon.SageMaker.Model.ProcessingClusterConfig();
            System.Int32? requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceCount = null;
            if (cmdletContext.ClusterConfig_InstanceCount != null)
            {
                requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceCount = cmdletContext.ClusterConfig_InstanceCount.Value;
            }
            if (requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceCount != null)
            {
                requestProcessingResources_processingResources_ClusterConfig.InstanceCount = requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceCount.Value;
                requestProcessingResources_processingResources_ClusterConfigIsNull = false;
            }
            Amazon.SageMaker.ProcessingInstanceType requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceType = null;
            if (cmdletContext.ClusterConfig_InstanceType != null)
            {
                requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceType = cmdletContext.ClusterConfig_InstanceType;
            }
            if (requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceType != null)
            {
                requestProcessingResources_processingResources_ClusterConfig.InstanceType = requestProcessingResources_processingResources_ClusterConfig_clusterConfig_InstanceType;
                requestProcessingResources_processingResources_ClusterConfigIsNull = false;
            }
            System.String requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeKmsKeyId = null;
            if (cmdletContext.ClusterConfig_VolumeKmsKeyId != null)
            {
                requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeKmsKeyId = cmdletContext.ClusterConfig_VolumeKmsKeyId;
            }
            if (requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeKmsKeyId != null)
            {
                requestProcessingResources_processingResources_ClusterConfig.VolumeKmsKeyId = requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeKmsKeyId;
                requestProcessingResources_processingResources_ClusterConfigIsNull = false;
            }
            System.Int32? requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeSizeInGB = null;
            if (cmdletContext.ClusterConfig_VolumeSizeInGB != null)
            {
                requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeSizeInGB = cmdletContext.ClusterConfig_VolumeSizeInGB.Value;
            }
            if (requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeSizeInGB != null)
            {
                requestProcessingResources_processingResources_ClusterConfig.VolumeSizeInGB = requestProcessingResources_processingResources_ClusterConfig_clusterConfig_VolumeSizeInGB.Value;
                requestProcessingResources_processingResources_ClusterConfigIsNull = false;
            }
             // determine if requestProcessingResources_processingResources_ClusterConfig should be set to null
            if (requestProcessingResources_processingResources_ClusterConfigIsNull)
            {
                requestProcessingResources_processingResources_ClusterConfig = null;
            }
            if (requestProcessingResources_processingResources_ClusterConfig != null)
            {
                request.ProcessingResources.ClusterConfig = requestProcessingResources_processingResources_ClusterConfig;
                requestProcessingResourcesIsNull = false;
            }
             // determine if request.ProcessingResources should be set to null
            if (requestProcessingResourcesIsNull)
            {
                request.ProcessingResources = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingCondition
            var requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.SageMaker.Model.ProcessingStoppingCondition();
            System.Int32? requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxRuntimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.StoppingCondition_MaxRuntimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond != null)
            {
                request.StoppingCondition.MaxRuntimeInSeconds = requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond.Value;
                requestStoppingConditionIsNull = false;
            }
             // determine if request.StoppingCondition should be set to null
            if (requestStoppingConditionIsNull)
            {
                request.StoppingCondition = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateProcessingJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateProcessingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateProcessingJob");
            try
            {
                #if DESKTOP
                return client.CreateProcessingJob(request);
                #elif CORECLR
                return client.CreateProcessingJobAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AppSpecification_ContainerArgument { get; set; }
            public List<System.String> AppSpecification_ContainerEntrypoint { get; set; }
            public System.String AppSpecification_ImageUri { get; set; }
            public Dictionary<System.String, System.String> Environment { get; set; }
            public System.String ExperimentConfig_ExperimentName { get; set; }
            public System.String ExperimentConfig_RunName { get; set; }
            public System.String ExperimentConfig_TrialComponentDisplayName { get; set; }
            public System.String ExperimentConfig_TrialName { get; set; }
            public System.Boolean? NetworkConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.Boolean? NetworkConfig_EnableNetworkIsolation { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public List<Amazon.SageMaker.Model.ProcessingInput> ProcessingInput { get; set; }
            public System.String ProcessingJobName { get; set; }
            public System.String ProcessingOutputConfig_KmsKeyId { get; set; }
            public List<Amazon.SageMaker.Model.ProcessingOutput> ProcessingOutputConfig_Output { get; set; }
            public System.Int32? ClusterConfig_InstanceCount { get; set; }
            public Amazon.SageMaker.ProcessingInstanceType ClusterConfig_InstanceType { get; set; }
            public System.String ClusterConfig_VolumeKmsKeyId { get; set; }
            public System.Int32? ClusterConfig_VolumeSizeInGB { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateProcessingJobResponse, NewSMProcessingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProcessingJobArn;
        }
        
    }
}
