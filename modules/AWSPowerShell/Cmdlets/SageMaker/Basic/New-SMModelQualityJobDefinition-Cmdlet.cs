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
    /// Creates a definition for a job that monitors model quality and drift. For information
    /// about model monitor, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor.html">Amazon
    /// SageMaker Model Monitor</a>.
    /// </summary>
    [Cmdlet("New", "SMModelQualityJobDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModelQualityJobDefinition API operation.", Operation = new[] {"CreateModelQualityJobDefinition"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMModelQualityJobDefinitionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ModelQualityBaselineConfig_BaseliningJobName
        /// <summary>
        /// <para>
        /// <para>The name of the job that performs baselining for the monitoring job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelQualityBaselineConfig_BaseliningJobName { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_ContainerArgument
        /// <summary>
        /// <para>
        /// <para>An array of arguments for the container used to run the monitoring job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityAppSpecification_ContainerArguments")]
        public System.String[] ModelQualityAppSpecification_ContainerArgument { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_ContainerEntrypoint
        /// <summary>
        /// <para>
        /// <para>Specifies the entrypoint for a container that the monitoring job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ModelQualityAppSpecification_ContainerEntrypoint { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>Whether to encrypt all communications between the instances used for the monitoring
        /// jobs. Choose <code>True</code> to encrypt communications. Encryption provides greater
        /// security for distributed jobs, but the processing might take longer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkConfig_EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_EnableNetworkIsolation
        /// <summary>
        /// <para>
        /// <para>Whether to allow inbound and outbound network calls to and from the containers used
        /// for the monitoring job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkConfig_EnableNetworkIsolation { get; set; }
        #endregion
        
        #region Parameter EndpointInput_EndpointName
        /// <summary>
        /// <para>
        /// <para>An endpoint in customer's account which has enabled <code>DataCaptureConfig</code>
        /// enabled.</para>
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
        [Alias("ModelQualityJobInput_EndpointInput_EndpointName")]
        public System.String EndpointInput_EndpointName { get; set; }
        #endregion
        
        #region Parameter EndpointInput_EndTimeOffset
        /// <summary>
        /// <para>
        /// <para>If specified, monitoring jobs substract this time from the end time. For information
        /// about using offsets for scheduling monitoring jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor-model-quality-schedule.html">Schedule
        /// Model Quality Monitoring Jobs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_EndTimeOffset")]
        public System.String EndpointInput_EndTimeOffset { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_Environment
        /// <summary>
        /// <para>
        /// <para>Sets the environment variables in the container that the monitoring job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ModelQualityAppSpecification_Environment { get; set; }
        #endregion
        
        #region Parameter EndpointInput_FeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data that are the input features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_FeaturesAttribute")]
        public System.String EndpointInput_FeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_ImageUri
        /// <summary>
        /// <para>
        /// <para>The address of the container image that the monitoring job runs.</para>
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
        public System.String ModelQualityAppSpecification_ImageUri { get; set; }
        #endregion
        
        #region Parameter EndpointInput_InferenceAttribute
        /// <summary>
        /// <para>
        /// <para>The attribute of the input data that represents the ground truth label.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_InferenceAttribute")]
        public System.String EndpointInput_InferenceAttribute { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of ML compute instances to use in the model monitoring job. For distributed
        /// processing jobs, specify a value greater than 1. The default value is 1.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("JobResources_ClusterConfig_InstanceCount")]
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
        [Alias("JobResources_ClusterConfig_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingInstanceType")]
        public Amazon.SageMaker.ProcessingInstanceType ClusterConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter JobDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the monitoring job definition.</para>
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
        public System.String JobDefinitionName { get; set; }
        #endregion
        
        #region Parameter ModelQualityJobOutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt the model artifacts at rest using Amazon S3 server-side
        /// encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelQualityJobOutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter EndpointInput_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to the filesystem where the endpoint data is available to the container.</para>
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
        [Alias("ModelQualityJobInput_EndpointInput_LocalPath")]
        public System.String EndpointInput_LocalPath { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime allowed in seconds.</para><note><para>The <code>MaxRuntimeInSeconds</code> cannot exceed the frequency of the job. For data
        /// quality and model explainability, this can be up to 3600 seconds for an hourly schedule.
        /// For model bias and model quality hourly schedules, this can be up to 1800 seconds.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter ModelQualityJobOutputConfig_MonitoringOutput
        /// <summary>
        /// <para>
        /// <para>Monitoring outputs for monitoring jobs. This is where the output of the periodic monitoring
        /// jobs is uploaded.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ModelQualityJobOutputConfig_MonitoringOutputs")]
        public Amazon.SageMaker.Model.MonitoringOutput[] ModelQualityJobOutputConfig_MonitoringOutput { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI to a script that is called after analysis has been performed. Applicable
        /// only for the built-in (first party) containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ProbabilityAttribute
        /// <summary>
        /// <para>
        /// <para>In a classification problem, the attribute that represents the class probability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_ProbabilityAttribute")]
        public System.String EndpointInput_ProbabilityAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ProbabilityThresholdAttribute
        /// <summary>
        /// <para>
        /// <para>The threshold for the class probability to be evaluated as a positive result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_ProbabilityThresholdAttribute")]
        public System.Double? EndpointInput_ProbabilityThresholdAttribute { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_ProblemType
        /// <summary>
        /// <para>
        /// <para>The machine learning problem type of the model that the monitoring job monitors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.MonitoringProblemType")]
        public Amazon.SageMaker.MonitoringProblemType ModelQualityAppSpecification_ProblemType { get; set; }
        #endregion
        
        #region Parameter ModelQualityAppSpecification_RecordPreprocessorSourceUri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI to a script that is called per row prior to running analysis. It
        /// can base64 decode the payload and convert it into a flatted json so that the built-in
        /// container can use the converted data. Applicable only for the built-in (first party)
        /// containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelQualityAppSpecification_RecordPreprocessorSourceUri { get; set; }
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
        
        #region Parameter EndpointInput_S3DataDistributionType
        /// <summary>
        /// <para>
        /// <para>Whether input data distributed in Amazon S3 is fully replicated or sharded by an S3
        /// key. Defaults to <code>FullyReplicated</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_S3DataDistributionType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3DataDistributionType")]
        public Amazon.SageMaker.ProcessingS3DataDistributionType EndpointInput_S3DataDistributionType { get; set; }
        #endregion
        
        #region Parameter EndpointInput_S3InputMode
        /// <summary>
        /// <para>
        /// <para>Whether the <code>Pipe</code> or <code>File</code> is used as the input mode for transfering
        /// data for the monitoring job. <code>Pipe</code> mode is recommended for large datasets.
        /// <code>File</code> mode is useful for small files that fit in memory. Defaults to <code>File</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_S3InputMode")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3InputMode")]
        public Amazon.SageMaker.ProcessingS3InputMode EndpointInput_S3InputMode { get; set; }
        #endregion
        
        #region Parameter ConstraintsResource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the constraints resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityBaselineConfig_ConstraintsResource_S3Uri")]
        public System.String ConstraintsResource_S3Uri { get; set; }
        #endregion
        
        #region Parameter GroundTruthS3Input_S3Uri
        /// <summary>
        /// <para>
        /// <para>The address of the Amazon S3 location of the ground truth labels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_GroundTruthS3Input_S3Uri")]
        public System.String GroundTruthS3Input_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. Specify the security groups for
        /// the VPC that is specified in the <code>Subnets</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter EndpointInput_StartTimeOffset
        /// <summary>
        /// <para>
        /// <para>If specified, monitoring jobs substract this time from the start time. For information
        /// about using offsets for scheduling monitoring jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor-model-quality-schedule.html">Schedule
        /// Model Quality Monitoring Jobs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelQualityJobInput_EndpointInput_StartTimeOffset")]
        public System.String EndpointInput_StartTimeOffset { get; set; }
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
        
        #region Parameter ClusterConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt data on the storage volume attached to the ML compute
        /// instance(s) that run the model monitoring job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobResources_ClusterConfig_VolumeKmsKeyId")]
        public System.String ClusterConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ClusterConfig_VolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The size of the ML storage volume, in gigabytes, that you want to provision. You must
        /// specify sufficient ML storage for your scenario.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("JobResources_ClusterConfig_VolumeSizeInGB")]
        public System.Int32? ClusterConfig_VolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobDefinitionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobDefinitionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobDefinitionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobDefinitionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobDefinitionName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobDefinitionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModelQualityJobDefinition (CreateModelQualityJobDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse, NewSMModelQualityJobDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobDefinitionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.JobDefinitionName = this.JobDefinitionName;
            #if MODULAR
            if (this.JobDefinitionName == null && ParameterWasBound(nameof(this.JobDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.ModelQualityAppSpecification_ContainerArgument != null)
            {
                context.ModelQualityAppSpecification_ContainerArgument = new List<System.String>(this.ModelQualityAppSpecification_ContainerArgument);
            }
            if (this.ModelQualityAppSpecification_ContainerEntrypoint != null)
            {
                context.ModelQualityAppSpecification_ContainerEntrypoint = new List<System.String>(this.ModelQualityAppSpecification_ContainerEntrypoint);
            }
            if (this.ModelQualityAppSpecification_Environment != null)
            {
                context.ModelQualityAppSpecification_Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ModelQualityAppSpecification_Environment.Keys)
                {
                    context.ModelQualityAppSpecification_Environment.Add((String)hashKey, (String)(this.ModelQualityAppSpecification_Environment[hashKey]));
                }
            }
            context.ModelQualityAppSpecification_ImageUri = this.ModelQualityAppSpecification_ImageUri;
            #if MODULAR
            if (this.ModelQualityAppSpecification_ImageUri == null && ParameterWasBound(nameof(this.ModelQualityAppSpecification_ImageUri)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelQualityAppSpecification_ImageUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri = this.ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri;
            context.ModelQualityAppSpecification_ProblemType = this.ModelQualityAppSpecification_ProblemType;
            context.ModelQualityAppSpecification_RecordPreprocessorSourceUri = this.ModelQualityAppSpecification_RecordPreprocessorSourceUri;
            context.ModelQualityBaselineConfig_BaseliningJobName = this.ModelQualityBaselineConfig_BaseliningJobName;
            context.ConstraintsResource_S3Uri = this.ConstraintsResource_S3Uri;
            context.EndpointInput_EndpointName = this.EndpointInput_EndpointName;
            #if MODULAR
            if (this.EndpointInput_EndpointName == null && ParameterWasBound(nameof(this.EndpointInput_EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointInput_EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointInput_EndTimeOffset = this.EndpointInput_EndTimeOffset;
            context.EndpointInput_FeaturesAttribute = this.EndpointInput_FeaturesAttribute;
            context.EndpointInput_InferenceAttribute = this.EndpointInput_InferenceAttribute;
            context.EndpointInput_LocalPath = this.EndpointInput_LocalPath;
            #if MODULAR
            if (this.EndpointInput_LocalPath == null && ParameterWasBound(nameof(this.EndpointInput_LocalPath)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointInput_LocalPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointInput_ProbabilityAttribute = this.EndpointInput_ProbabilityAttribute;
            context.EndpointInput_ProbabilityThresholdAttribute = this.EndpointInput_ProbabilityThresholdAttribute;
            context.EndpointInput_S3DataDistributionType = this.EndpointInput_S3DataDistributionType;
            context.EndpointInput_S3InputMode = this.EndpointInput_S3InputMode;
            context.EndpointInput_StartTimeOffset = this.EndpointInput_StartTimeOffset;
            context.GroundTruthS3Input_S3Uri = this.GroundTruthS3Input_S3Uri;
            context.ModelQualityJobOutputConfig_KmsKeyId = this.ModelQualityJobOutputConfig_KmsKeyId;
            if (this.ModelQualityJobOutputConfig_MonitoringOutput != null)
            {
                context.ModelQualityJobOutputConfig_MonitoringOutput = new List<Amazon.SageMaker.Model.MonitoringOutput>(this.ModelQualityJobOutputConfig_MonitoringOutput);
            }
            #if MODULAR
            if (this.ModelQualityJobOutputConfig_MonitoringOutput == null && ParameterWasBound(nameof(this.ModelQualityJobOutputConfig_MonitoringOutput)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelQualityJobOutputConfig_MonitoringOutput which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMaker.Model.CreateModelQualityJobDefinitionRequest();
            
            if (cmdletContext.JobDefinitionName != null)
            {
                request.JobDefinitionName = cmdletContext.JobDefinitionName;
            }
            
             // populate JobResources
            var requestJobResourcesIsNull = true;
            request.JobResources = new Amazon.SageMaker.Model.MonitoringResources();
            Amazon.SageMaker.Model.MonitoringClusterConfig requestJobResources_jobResources_ClusterConfig = null;
            
             // populate ClusterConfig
            var requestJobResources_jobResources_ClusterConfigIsNull = true;
            requestJobResources_jobResources_ClusterConfig = new Amazon.SageMaker.Model.MonitoringClusterConfig();
            System.Int32? requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceCount = null;
            if (cmdletContext.ClusterConfig_InstanceCount != null)
            {
                requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceCount = cmdletContext.ClusterConfig_InstanceCount.Value;
            }
            if (requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceCount != null)
            {
                requestJobResources_jobResources_ClusterConfig.InstanceCount = requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceCount.Value;
                requestJobResources_jobResources_ClusterConfigIsNull = false;
            }
            Amazon.SageMaker.ProcessingInstanceType requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceType = null;
            if (cmdletContext.ClusterConfig_InstanceType != null)
            {
                requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceType = cmdletContext.ClusterConfig_InstanceType;
            }
            if (requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceType != null)
            {
                requestJobResources_jobResources_ClusterConfig.InstanceType = requestJobResources_jobResources_ClusterConfig_clusterConfig_InstanceType;
                requestJobResources_jobResources_ClusterConfigIsNull = false;
            }
            System.String requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeKmsKeyId = null;
            if (cmdletContext.ClusterConfig_VolumeKmsKeyId != null)
            {
                requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeKmsKeyId = cmdletContext.ClusterConfig_VolumeKmsKeyId;
            }
            if (requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeKmsKeyId != null)
            {
                requestJobResources_jobResources_ClusterConfig.VolumeKmsKeyId = requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeKmsKeyId;
                requestJobResources_jobResources_ClusterConfigIsNull = false;
            }
            System.Int32? requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeSizeInGB = null;
            if (cmdletContext.ClusterConfig_VolumeSizeInGB != null)
            {
                requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeSizeInGB = cmdletContext.ClusterConfig_VolumeSizeInGB.Value;
            }
            if (requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeSizeInGB != null)
            {
                requestJobResources_jobResources_ClusterConfig.VolumeSizeInGB = requestJobResources_jobResources_ClusterConfig_clusterConfig_VolumeSizeInGB.Value;
                requestJobResources_jobResources_ClusterConfigIsNull = false;
            }
             // determine if requestJobResources_jobResources_ClusterConfig should be set to null
            if (requestJobResources_jobResources_ClusterConfigIsNull)
            {
                requestJobResources_jobResources_ClusterConfig = null;
            }
            if (requestJobResources_jobResources_ClusterConfig != null)
            {
                request.JobResources.ClusterConfig = requestJobResources_jobResources_ClusterConfig;
                requestJobResourcesIsNull = false;
            }
             // determine if request.JobResources should be set to null
            if (requestJobResourcesIsNull)
            {
                request.JobResources = null;
            }
            
             // populate ModelQualityAppSpecification
            var requestModelQualityAppSpecificationIsNull = true;
            request.ModelQualityAppSpecification = new Amazon.SageMaker.Model.ModelQualityAppSpecification();
            List<System.String> requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerArgument = null;
            if (cmdletContext.ModelQualityAppSpecification_ContainerArgument != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerArgument = cmdletContext.ModelQualityAppSpecification_ContainerArgument;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerArgument != null)
            {
                request.ModelQualityAppSpecification.ContainerArguments = requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerArgument;
                requestModelQualityAppSpecificationIsNull = false;
            }
            List<System.String> requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerEntrypoint = null;
            if (cmdletContext.ModelQualityAppSpecification_ContainerEntrypoint != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerEntrypoint = cmdletContext.ModelQualityAppSpecification_ContainerEntrypoint;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerEntrypoint != null)
            {
                request.ModelQualityAppSpecification.ContainerEntrypoint = requestModelQualityAppSpecification_modelQualityAppSpecification_ContainerEntrypoint;
                requestModelQualityAppSpecificationIsNull = false;
            }
            Dictionary<System.String, System.String> requestModelQualityAppSpecification_modelQualityAppSpecification_Environment = null;
            if (cmdletContext.ModelQualityAppSpecification_Environment != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_Environment = cmdletContext.ModelQualityAppSpecification_Environment;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_Environment != null)
            {
                request.ModelQualityAppSpecification.Environment = requestModelQualityAppSpecification_modelQualityAppSpecification_Environment;
                requestModelQualityAppSpecificationIsNull = false;
            }
            System.String requestModelQualityAppSpecification_modelQualityAppSpecification_ImageUri = null;
            if (cmdletContext.ModelQualityAppSpecification_ImageUri != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_ImageUri = cmdletContext.ModelQualityAppSpecification_ImageUri;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_ImageUri != null)
            {
                request.ModelQualityAppSpecification.ImageUri = requestModelQualityAppSpecification_modelQualityAppSpecification_ImageUri;
                requestModelQualityAppSpecificationIsNull = false;
            }
            System.String requestModelQualityAppSpecification_modelQualityAppSpecification_PostAnalyticsProcessorSourceUri = null;
            if (cmdletContext.ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_PostAnalyticsProcessorSourceUri = cmdletContext.ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_PostAnalyticsProcessorSourceUri != null)
            {
                request.ModelQualityAppSpecification.PostAnalyticsProcessorSourceUri = requestModelQualityAppSpecification_modelQualityAppSpecification_PostAnalyticsProcessorSourceUri;
                requestModelQualityAppSpecificationIsNull = false;
            }
            Amazon.SageMaker.MonitoringProblemType requestModelQualityAppSpecification_modelQualityAppSpecification_ProblemType = null;
            if (cmdletContext.ModelQualityAppSpecification_ProblemType != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_ProblemType = cmdletContext.ModelQualityAppSpecification_ProblemType;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_ProblemType != null)
            {
                request.ModelQualityAppSpecification.ProblemType = requestModelQualityAppSpecification_modelQualityAppSpecification_ProblemType;
                requestModelQualityAppSpecificationIsNull = false;
            }
            System.String requestModelQualityAppSpecification_modelQualityAppSpecification_RecordPreprocessorSourceUri = null;
            if (cmdletContext.ModelQualityAppSpecification_RecordPreprocessorSourceUri != null)
            {
                requestModelQualityAppSpecification_modelQualityAppSpecification_RecordPreprocessorSourceUri = cmdletContext.ModelQualityAppSpecification_RecordPreprocessorSourceUri;
            }
            if (requestModelQualityAppSpecification_modelQualityAppSpecification_RecordPreprocessorSourceUri != null)
            {
                request.ModelQualityAppSpecification.RecordPreprocessorSourceUri = requestModelQualityAppSpecification_modelQualityAppSpecification_RecordPreprocessorSourceUri;
                requestModelQualityAppSpecificationIsNull = false;
            }
             // determine if request.ModelQualityAppSpecification should be set to null
            if (requestModelQualityAppSpecificationIsNull)
            {
                request.ModelQualityAppSpecification = null;
            }
            
             // populate ModelQualityBaselineConfig
            var requestModelQualityBaselineConfigIsNull = true;
            request.ModelQualityBaselineConfig = new Amazon.SageMaker.Model.ModelQualityBaselineConfig();
            System.String requestModelQualityBaselineConfig_modelQualityBaselineConfig_BaseliningJobName = null;
            if (cmdletContext.ModelQualityBaselineConfig_BaseliningJobName != null)
            {
                requestModelQualityBaselineConfig_modelQualityBaselineConfig_BaseliningJobName = cmdletContext.ModelQualityBaselineConfig_BaseliningJobName;
            }
            if (requestModelQualityBaselineConfig_modelQualityBaselineConfig_BaseliningJobName != null)
            {
                request.ModelQualityBaselineConfig.BaseliningJobName = requestModelQualityBaselineConfig_modelQualityBaselineConfig_BaseliningJobName;
                requestModelQualityBaselineConfigIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringConstraintsResource requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource = null;
            
             // populate ConstraintsResource
            var requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResourceIsNull = true;
            requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource = new Amazon.SageMaker.Model.MonitoringConstraintsResource();
            System.String requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri = null;
            if (cmdletContext.ConstraintsResource_S3Uri != null)
            {
                requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri = cmdletContext.ConstraintsResource_S3Uri;
            }
            if (requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri != null)
            {
                requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource.S3Uri = requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri;
                requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResourceIsNull = false;
            }
             // determine if requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource should be set to null
            if (requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResourceIsNull)
            {
                requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource = null;
            }
            if (requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource != null)
            {
                request.ModelQualityBaselineConfig.ConstraintsResource = requestModelQualityBaselineConfig_modelQualityBaselineConfig_ConstraintsResource;
                requestModelQualityBaselineConfigIsNull = false;
            }
             // determine if request.ModelQualityBaselineConfig should be set to null
            if (requestModelQualityBaselineConfigIsNull)
            {
                request.ModelQualityBaselineConfig = null;
            }
            
             // populate ModelQualityJobInput
            var requestModelQualityJobInputIsNull = true;
            request.ModelQualityJobInput = new Amazon.SageMaker.Model.ModelQualityJobInput();
            Amazon.SageMaker.Model.MonitoringGroundTruthS3Input requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input = null;
            
             // populate GroundTruthS3Input
            var requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3InputIsNull = true;
            requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input = new Amazon.SageMaker.Model.MonitoringGroundTruthS3Input();
            System.String requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input_groundTruthS3Input_S3Uri = null;
            if (cmdletContext.GroundTruthS3Input_S3Uri != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input_groundTruthS3Input_S3Uri = cmdletContext.GroundTruthS3Input_S3Uri;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input_groundTruthS3Input_S3Uri != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input.S3Uri = requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input_groundTruthS3Input_S3Uri;
                requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3InputIsNull = false;
            }
             // determine if requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input should be set to null
            if (requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3InputIsNull)
            {
                requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input = null;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input != null)
            {
                request.ModelQualityJobInput.GroundTruthS3Input = requestModelQualityJobInput_modelQualityJobInput_GroundTruthS3Input;
                requestModelQualityJobInputIsNull = false;
            }
            Amazon.SageMaker.Model.EndpointInput requestModelQualityJobInput_modelQualityJobInput_EndpointInput = null;
            
             // populate EndpointInput
            var requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = true;
            requestModelQualityJobInput_modelQualityJobInput_EndpointInput = new Amazon.SageMaker.Model.EndpointInput();
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndpointName = null;
            if (cmdletContext.EndpointInput_EndpointName != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndpointName = cmdletContext.EndpointInput_EndpointName;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndpointName != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.EndpointName = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndpointName;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndTimeOffset = null;
            if (cmdletContext.EndpointInput_EndTimeOffset != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndTimeOffset = cmdletContext.EndpointInput_EndTimeOffset;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndTimeOffset != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.EndTimeOffset = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_EndTimeOffset;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute = null;
            if (cmdletContext.EndpointInput_FeaturesAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute = cmdletContext.EndpointInput_FeaturesAttribute;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.FeaturesAttribute = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_InferenceAttribute = null;
            if (cmdletContext.EndpointInput_InferenceAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_InferenceAttribute = cmdletContext.EndpointInput_InferenceAttribute;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_InferenceAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.InferenceAttribute = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_InferenceAttribute;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_LocalPath = null;
            if (cmdletContext.EndpointInput_LocalPath != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_LocalPath = cmdletContext.EndpointInput_LocalPath;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_LocalPath != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.LocalPath = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_LocalPath;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute = null;
            if (cmdletContext.EndpointInput_ProbabilityAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute = cmdletContext.EndpointInput_ProbabilityAttribute;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.ProbabilityAttribute = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.Double? requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute = null;
            if (cmdletContext.EndpointInput_ProbabilityThresholdAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute = cmdletContext.EndpointInput_ProbabilityThresholdAttribute.Value;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.ProbabilityThresholdAttribute = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute.Value;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3DataDistributionType requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType = null;
            if (cmdletContext.EndpointInput_S3DataDistributionType != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType = cmdletContext.EndpointInput_S3DataDistributionType;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.S3DataDistributionType = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3InputMode requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3InputMode = null;
            if (cmdletContext.EndpointInput_S3InputMode != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3InputMode = cmdletContext.EndpointInput_S3InputMode;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3InputMode != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.S3InputMode = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_S3InputMode;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_StartTimeOffset = null;
            if (cmdletContext.EndpointInput_StartTimeOffset != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_StartTimeOffset = cmdletContext.EndpointInput_StartTimeOffset;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_StartTimeOffset != null)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput.StartTimeOffset = requestModelQualityJobInput_modelQualityJobInput_EndpointInput_endpointInput_StartTimeOffset;
                requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull = false;
            }
             // determine if requestModelQualityJobInput_modelQualityJobInput_EndpointInput should be set to null
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInputIsNull)
            {
                requestModelQualityJobInput_modelQualityJobInput_EndpointInput = null;
            }
            if (requestModelQualityJobInput_modelQualityJobInput_EndpointInput != null)
            {
                request.ModelQualityJobInput.EndpointInput = requestModelQualityJobInput_modelQualityJobInput_EndpointInput;
                requestModelQualityJobInputIsNull = false;
            }
             // determine if request.ModelQualityJobInput should be set to null
            if (requestModelQualityJobInputIsNull)
            {
                request.ModelQualityJobInput = null;
            }
            
             // populate ModelQualityJobOutputConfig
            var requestModelQualityJobOutputConfigIsNull = true;
            request.ModelQualityJobOutputConfig = new Amazon.SageMaker.Model.MonitoringOutputConfig();
            System.String requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_KmsKeyId = null;
            if (cmdletContext.ModelQualityJobOutputConfig_KmsKeyId != null)
            {
                requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_KmsKeyId = cmdletContext.ModelQualityJobOutputConfig_KmsKeyId;
            }
            if (requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_KmsKeyId != null)
            {
                request.ModelQualityJobOutputConfig.KmsKeyId = requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_KmsKeyId;
                requestModelQualityJobOutputConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.MonitoringOutput> requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_MonitoringOutput = null;
            if (cmdletContext.ModelQualityJobOutputConfig_MonitoringOutput != null)
            {
                requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_MonitoringOutput = cmdletContext.ModelQualityJobOutputConfig_MonitoringOutput;
            }
            if (requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_MonitoringOutput != null)
            {
                request.ModelQualityJobOutputConfig.MonitoringOutputs = requestModelQualityJobOutputConfig_modelQualityJobOutputConfig_MonitoringOutput;
                requestModelQualityJobOutputConfigIsNull = false;
            }
             // determine if request.ModelQualityJobOutputConfig should be set to null
            if (requestModelQualityJobOutputConfigIsNull)
            {
                request.ModelQualityJobOutputConfig = null;
            }
            
             // populate NetworkConfig
            var requestNetworkConfigIsNull = true;
            request.NetworkConfig = new Amazon.SageMaker.Model.MonitoringNetworkConfig();
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
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingCondition
            var requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.SageMaker.Model.MonitoringStoppingCondition();
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
        
        private Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateModelQualityJobDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateModelQualityJobDefinition");
            try
            {
                #if DESKTOP
                return client.CreateModelQualityJobDefinition(request);
                #elif CORECLR
                return client.CreateModelQualityJobDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String JobDefinitionName { get; set; }
            public System.Int32? ClusterConfig_InstanceCount { get; set; }
            public Amazon.SageMaker.ProcessingInstanceType ClusterConfig_InstanceType { get; set; }
            public System.String ClusterConfig_VolumeKmsKeyId { get; set; }
            public System.Int32? ClusterConfig_VolumeSizeInGB { get; set; }
            public List<System.String> ModelQualityAppSpecification_ContainerArgument { get; set; }
            public List<System.String> ModelQualityAppSpecification_ContainerEntrypoint { get; set; }
            public Dictionary<System.String, System.String> ModelQualityAppSpecification_Environment { get; set; }
            public System.String ModelQualityAppSpecification_ImageUri { get; set; }
            public System.String ModelQualityAppSpecification_PostAnalyticsProcessorSourceUri { get; set; }
            public Amazon.SageMaker.MonitoringProblemType ModelQualityAppSpecification_ProblemType { get; set; }
            public System.String ModelQualityAppSpecification_RecordPreprocessorSourceUri { get; set; }
            public System.String ModelQualityBaselineConfig_BaseliningJobName { get; set; }
            public System.String ConstraintsResource_S3Uri { get; set; }
            public System.String EndpointInput_EndpointName { get; set; }
            public System.String EndpointInput_EndTimeOffset { get; set; }
            public System.String EndpointInput_FeaturesAttribute { get; set; }
            public System.String EndpointInput_InferenceAttribute { get; set; }
            public System.String EndpointInput_LocalPath { get; set; }
            public System.String EndpointInput_ProbabilityAttribute { get; set; }
            public System.Double? EndpointInput_ProbabilityThresholdAttribute { get; set; }
            public Amazon.SageMaker.ProcessingS3DataDistributionType EndpointInput_S3DataDistributionType { get; set; }
            public Amazon.SageMaker.ProcessingS3InputMode EndpointInput_S3InputMode { get; set; }
            public System.String EndpointInput_StartTimeOffset { get; set; }
            public System.String GroundTruthS3Input_S3Uri { get; set; }
            public System.String ModelQualityJobOutputConfig_KmsKeyId { get; set; }
            public List<Amazon.SageMaker.Model.MonitoringOutput> ModelQualityJobOutputConfig_MonitoringOutput { get; set; }
            public System.Boolean? NetworkConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.Boolean? NetworkConfig_EnableNetworkIsolation { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateModelQualityJobDefinitionResponse, NewSMModelQualityJobDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobDefinitionArn;
        }
        
    }
}
