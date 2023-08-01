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
    /// Creates the definition for a model explainability job.
    /// </summary>
    [Cmdlet("New", "SMModelExplainabilityJobDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModelExplainabilityJobDefinition API operation.", Operation = new[] {"CreateModelExplainabilityJobDefinition"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMModelExplainabilityJobDefinitionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ModelExplainabilityBaselineConfig_BaseliningJobName
        /// <summary>
        /// <para>
        /// <para>The name of the baseline model explainability job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelExplainabilityBaselineConfig_BaseliningJobName { get; set; }
        #endregion
        
        #region Parameter ModelExplainabilityAppSpecification_ConfigUri
        /// <summary>
        /// <para>
        /// <para>JSON formatted S3 file that defines explainability parameters. For more information
        /// on this JSON configuration file, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-config-json-monitor-model-explainability-parameters.html">Configure
        /// model explainability parameters</a>.</para>
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
        public System.String ModelExplainabilityAppSpecification_ConfigUri { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_DataCapturedDestinationS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location being used to capture the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_DataCapturedDestinationS3Uri")]
        public System.String BatchTransformInput_DataCapturedDestinationS3Uri { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_EndpointName")]
        public System.String EndpointInput_EndpointName { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_EndTimeOffset
        /// <summary>
        /// <para>
        /// <para>If specified, monitoring jobs subtract this time from the end time. For information
        /// about using offsets for scheduling monitoring jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor-model-quality-schedule.html">Schedule
        /// Model Quality Monitoring Jobs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_EndTimeOffset")]
        public System.String BatchTransformInput_EndTimeOffset { get; set; }
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
        [Alias("ModelExplainabilityJobInput_EndpointInput_EndTimeOffset")]
        public System.String EndpointInput_EndTimeOffset { get; set; }
        #endregion
        
        #region Parameter ModelExplainabilityAppSpecification_Environment
        /// <summary>
        /// <para>
        /// <para>Sets the environment variables in the Docker container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ModelExplainabilityAppSpecification_Environment { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_FeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data that are the input features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_FeaturesAttribute")]
        public System.String BatchTransformInput_FeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_FeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data that are the input features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_FeaturesAttribute")]
        public System.String EndpointInput_FeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter Csv_Header
        /// <summary>
        /// <para>
        /// <para>Indicates if the CSV data has a header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv_Header")]
        public System.Boolean? Csv_Header { get; set; }
        #endregion
        
        #region Parameter ModelExplainabilityAppSpecification_ImageUri
        /// <summary>
        /// <para>
        /// <para>The container image to be run by the model explainability job.</para>
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
        public System.String ModelExplainabilityAppSpecification_ImageUri { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_InferenceAttribute
        /// <summary>
        /// <para>
        /// <para>The attribute of the input data that represents the ground truth label.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_InferenceAttribute")]
        public System.String BatchTransformInput_InferenceAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_InferenceAttribute
        /// <summary>
        /// <para>
        /// <para>The attribute of the input data that represents the ground truth label.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_InferenceAttribute")]
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
        /// <para> The name of the model explainability job definition. The name must be unique within
        /// an Amazon Web Services Region in the Amazon Web Services account.</para>
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
        
        #region Parameter ModelExplainabilityJobOutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt the model artifacts at rest using Amazon S3 server-side
        /// encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelExplainabilityJobOutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Json_Line
        /// <summary>
        /// <para>
        /// <para>Indicates if the file should be read as a json object per line. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json_Line")]
        public System.Boolean? Json_Line { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to the filesystem where the batch transform data is available to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_LocalPath")]
        public System.String BatchTransformInput_LocalPath { get; set; }
        #endregion
        
        #region Parameter EndpointInput_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to the filesystem where the endpoint data is available to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_LocalPath")]
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
        
        #region Parameter ModelExplainabilityJobOutputConfig_MonitoringOutput
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
        [Alias("ModelExplainabilityJobOutputConfig_MonitoringOutputs")]
        public Amazon.SageMaker.Model.MonitoringOutput[] ModelExplainabilityJobOutputConfig_MonitoringOutput { get; set; }
        #endregion
        
        #region Parameter DatasetFormat_Parquet
        /// <summary>
        /// <para>
        /// <para>The Parquet dataset used in the monitoring job</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Parquet")]
        public Amazon.SageMaker.Model.MonitoringParquetDatasetFormat DatasetFormat_Parquet { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_ProbabilityAttribute
        /// <summary>
        /// <para>
        /// <para>In a classification problem, the attribute that represents the class probability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_ProbabilityAttribute")]
        public System.String BatchTransformInput_ProbabilityAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ProbabilityAttribute
        /// <summary>
        /// <para>
        /// <para>In a classification problem, the attribute that represents the class probability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_ProbabilityAttribute")]
        public System.String EndpointInput_ProbabilityAttribute { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_ProbabilityThresholdAttribute
        /// <summary>
        /// <para>
        /// <para>The threshold for the class probability to be evaluated as a positive result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_ProbabilityThresholdAttribute")]
        public System.Double? BatchTransformInput_ProbabilityThresholdAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ProbabilityThresholdAttribute
        /// <summary>
        /// <para>
        /// <para>The threshold for the class probability to be evaluated as a positive result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_ProbabilityThresholdAttribute")]
        public System.Double? EndpointInput_ProbabilityThresholdAttribute { get; set; }
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
        
        #region Parameter BatchTransformInput_S3DataDistributionType
        /// <summary>
        /// <para>
        /// <para>Whether input data distributed in Amazon S3 is fully replicated or sharded by an S3
        /// key. Defaults to <code>FullyReplicated</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_S3DataDistributionType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3DataDistributionType")]
        public Amazon.SageMaker.ProcessingS3DataDistributionType BatchTransformInput_S3DataDistributionType { get; set; }
        #endregion
        
        #region Parameter EndpointInput_S3DataDistributionType
        /// <summary>
        /// <para>
        /// <para>Whether input data distributed in Amazon S3 is fully replicated or sharded by an S3
        /// key. Defaults to <code>FullyReplicated</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_S3DataDistributionType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3DataDistributionType")]
        public Amazon.SageMaker.ProcessingS3DataDistributionType EndpointInput_S3DataDistributionType { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_S3InputMode
        /// <summary>
        /// <para>
        /// <para>Whether the <code>Pipe</code> or <code>File</code> is used as the input mode for transferring
        /// data for the monitoring job. <code>Pipe</code> mode is recommended for large datasets.
        /// <code>File</code> mode is useful for small files that fit in memory. Defaults to <code>File</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_S3InputMode")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3InputMode")]
        public Amazon.SageMaker.ProcessingS3InputMode BatchTransformInput_S3InputMode { get; set; }
        #endregion
        
        #region Parameter EndpointInput_S3InputMode
        /// <summary>
        /// <para>
        /// <para>Whether the <code>Pipe</code> or <code>File</code> is used as the input mode for transferring
        /// data for the monitoring job. <code>Pipe</code> mode is recommended for large datasets.
        /// <code>File</code> mode is useful for small files that fit in memory. Defaults to <code>File</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_EndpointInput_S3InputMode")]
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
        [Alias("ModelExplainabilityBaselineConfig_ConstraintsResource_S3Uri")]
        public System.String ConstraintsResource_S3Uri { get; set; }
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
        
        #region Parameter BatchTransformInput_StartTimeOffset
        /// <summary>
        /// <para>
        /// <para>If specified, monitoring jobs substract this time from the start time. For information
        /// about using offsets for scheduling monitoring jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor-model-quality-schedule.html">Schedule
        /// Model Quality Monitoring Jobs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelExplainabilityJobInput_BatchTransformInput_StartTimeOffset")]
        public System.String BatchTransformInput_StartTimeOffset { get; set; }
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
        [Alias("ModelExplainabilityJobInput_EndpointInput_StartTimeOffset")]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobDefinitionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModelExplainabilityJobDefinition (CreateModelExplainabilityJobDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse, NewSMModelExplainabilityJobDefinitionCmdlet>(Select) ??
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
            context.ModelExplainabilityAppSpecification_ConfigUri = this.ModelExplainabilityAppSpecification_ConfigUri;
            #if MODULAR
            if (this.ModelExplainabilityAppSpecification_ConfigUri == null && ParameterWasBound(nameof(this.ModelExplainabilityAppSpecification_ConfigUri)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelExplainabilityAppSpecification_ConfigUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ModelExplainabilityAppSpecification_Environment != null)
            {
                context.ModelExplainabilityAppSpecification_Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ModelExplainabilityAppSpecification_Environment.Keys)
                {
                    context.ModelExplainabilityAppSpecification_Environment.Add((String)hashKey, (String)(this.ModelExplainabilityAppSpecification_Environment[hashKey]));
                }
            }
            context.ModelExplainabilityAppSpecification_ImageUri = this.ModelExplainabilityAppSpecification_ImageUri;
            #if MODULAR
            if (this.ModelExplainabilityAppSpecification_ImageUri == null && ParameterWasBound(nameof(this.ModelExplainabilityAppSpecification_ImageUri)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelExplainabilityAppSpecification_ImageUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelExplainabilityBaselineConfig_BaseliningJobName = this.ModelExplainabilityBaselineConfig_BaseliningJobName;
            context.ConstraintsResource_S3Uri = this.ConstraintsResource_S3Uri;
            context.BatchTransformInput_DataCapturedDestinationS3Uri = this.BatchTransformInput_DataCapturedDestinationS3Uri;
            context.Csv_Header = this.Csv_Header;
            context.Json_Line = this.Json_Line;
            context.DatasetFormat_Parquet = this.DatasetFormat_Parquet;
            context.BatchTransformInput_EndTimeOffset = this.BatchTransformInput_EndTimeOffset;
            context.BatchTransformInput_FeaturesAttribute = this.BatchTransformInput_FeaturesAttribute;
            context.BatchTransformInput_InferenceAttribute = this.BatchTransformInput_InferenceAttribute;
            context.BatchTransformInput_LocalPath = this.BatchTransformInput_LocalPath;
            context.BatchTransformInput_ProbabilityAttribute = this.BatchTransformInput_ProbabilityAttribute;
            context.BatchTransformInput_ProbabilityThresholdAttribute = this.BatchTransformInput_ProbabilityThresholdAttribute;
            context.BatchTransformInput_S3DataDistributionType = this.BatchTransformInput_S3DataDistributionType;
            context.BatchTransformInput_S3InputMode = this.BatchTransformInput_S3InputMode;
            context.BatchTransformInput_StartTimeOffset = this.BatchTransformInput_StartTimeOffset;
            context.EndpointInput_EndpointName = this.EndpointInput_EndpointName;
            context.EndpointInput_EndTimeOffset = this.EndpointInput_EndTimeOffset;
            context.EndpointInput_FeaturesAttribute = this.EndpointInput_FeaturesAttribute;
            context.EndpointInput_InferenceAttribute = this.EndpointInput_InferenceAttribute;
            context.EndpointInput_LocalPath = this.EndpointInput_LocalPath;
            context.EndpointInput_ProbabilityAttribute = this.EndpointInput_ProbabilityAttribute;
            context.EndpointInput_ProbabilityThresholdAttribute = this.EndpointInput_ProbabilityThresholdAttribute;
            context.EndpointInput_S3DataDistributionType = this.EndpointInput_S3DataDistributionType;
            context.EndpointInput_S3InputMode = this.EndpointInput_S3InputMode;
            context.EndpointInput_StartTimeOffset = this.EndpointInput_StartTimeOffset;
            context.ModelExplainabilityJobOutputConfig_KmsKeyId = this.ModelExplainabilityJobOutputConfig_KmsKeyId;
            if (this.ModelExplainabilityJobOutputConfig_MonitoringOutput != null)
            {
                context.ModelExplainabilityJobOutputConfig_MonitoringOutput = new List<Amazon.SageMaker.Model.MonitoringOutput>(this.ModelExplainabilityJobOutputConfig_MonitoringOutput);
            }
            #if MODULAR
            if (this.ModelExplainabilityJobOutputConfig_MonitoringOutput == null && ParameterWasBound(nameof(this.ModelExplainabilityJobOutputConfig_MonitoringOutput)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelExplainabilityJobOutputConfig_MonitoringOutput which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionRequest();
            
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
            
             // populate ModelExplainabilityAppSpecification
            var requestModelExplainabilityAppSpecificationIsNull = true;
            request.ModelExplainabilityAppSpecification = new Amazon.SageMaker.Model.ModelExplainabilityAppSpecification();
            System.String requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ConfigUri = null;
            if (cmdletContext.ModelExplainabilityAppSpecification_ConfigUri != null)
            {
                requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ConfigUri = cmdletContext.ModelExplainabilityAppSpecification_ConfigUri;
            }
            if (requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ConfigUri != null)
            {
                request.ModelExplainabilityAppSpecification.ConfigUri = requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ConfigUri;
                requestModelExplainabilityAppSpecificationIsNull = false;
            }
            Dictionary<System.String, System.String> requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_Environment = null;
            if (cmdletContext.ModelExplainabilityAppSpecification_Environment != null)
            {
                requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_Environment = cmdletContext.ModelExplainabilityAppSpecification_Environment;
            }
            if (requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_Environment != null)
            {
                request.ModelExplainabilityAppSpecification.Environment = requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_Environment;
                requestModelExplainabilityAppSpecificationIsNull = false;
            }
            System.String requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ImageUri = null;
            if (cmdletContext.ModelExplainabilityAppSpecification_ImageUri != null)
            {
                requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ImageUri = cmdletContext.ModelExplainabilityAppSpecification_ImageUri;
            }
            if (requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ImageUri != null)
            {
                request.ModelExplainabilityAppSpecification.ImageUri = requestModelExplainabilityAppSpecification_modelExplainabilityAppSpecification_ImageUri;
                requestModelExplainabilityAppSpecificationIsNull = false;
            }
             // determine if request.ModelExplainabilityAppSpecification should be set to null
            if (requestModelExplainabilityAppSpecificationIsNull)
            {
                request.ModelExplainabilityAppSpecification = null;
            }
            
             // populate ModelExplainabilityBaselineConfig
            var requestModelExplainabilityBaselineConfigIsNull = true;
            request.ModelExplainabilityBaselineConfig = new Amazon.SageMaker.Model.ModelExplainabilityBaselineConfig();
            System.String requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_BaseliningJobName = null;
            if (cmdletContext.ModelExplainabilityBaselineConfig_BaseliningJobName != null)
            {
                requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_BaseliningJobName = cmdletContext.ModelExplainabilityBaselineConfig_BaseliningJobName;
            }
            if (requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_BaseliningJobName != null)
            {
                request.ModelExplainabilityBaselineConfig.BaseliningJobName = requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_BaseliningJobName;
                requestModelExplainabilityBaselineConfigIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringConstraintsResource requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource = null;
            
             // populate ConstraintsResource
            var requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResourceIsNull = true;
            requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource = new Amazon.SageMaker.Model.MonitoringConstraintsResource();
            System.String requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri = null;
            if (cmdletContext.ConstraintsResource_S3Uri != null)
            {
                requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri = cmdletContext.ConstraintsResource_S3Uri;
            }
            if (requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri != null)
            {
                requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource.S3Uri = requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri;
                requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResourceIsNull = false;
            }
             // determine if requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource should be set to null
            if (requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResourceIsNull)
            {
                requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource = null;
            }
            if (requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource != null)
            {
                request.ModelExplainabilityBaselineConfig.ConstraintsResource = requestModelExplainabilityBaselineConfig_modelExplainabilityBaselineConfig_ConstraintsResource;
                requestModelExplainabilityBaselineConfigIsNull = false;
            }
             // determine if request.ModelExplainabilityBaselineConfig should be set to null
            if (requestModelExplainabilityBaselineConfigIsNull)
            {
                request.ModelExplainabilityBaselineConfig = null;
            }
            
             // populate ModelExplainabilityJobInput
            var requestModelExplainabilityJobInputIsNull = true;
            request.ModelExplainabilityJobInput = new Amazon.SageMaker.Model.ModelExplainabilityJobInput();
            Amazon.SageMaker.Model.EndpointInput requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput = null;
            
             // populate EndpointInput
            var requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = true;
            requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput = new Amazon.SageMaker.Model.EndpointInput();
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndpointName = null;
            if (cmdletContext.EndpointInput_EndpointName != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndpointName = cmdletContext.EndpointInput_EndpointName;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndpointName != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.EndpointName = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndpointName;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndTimeOffset = null;
            if (cmdletContext.EndpointInput_EndTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndTimeOffset = cmdletContext.EndpointInput_EndTimeOffset;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.EndTimeOffset = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_EndTimeOffset;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_FeaturesAttribute = null;
            if (cmdletContext.EndpointInput_FeaturesAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_FeaturesAttribute = cmdletContext.EndpointInput_FeaturesAttribute;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_FeaturesAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.FeaturesAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_FeaturesAttribute;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_InferenceAttribute = null;
            if (cmdletContext.EndpointInput_InferenceAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_InferenceAttribute = cmdletContext.EndpointInput_InferenceAttribute;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_InferenceAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.InferenceAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_InferenceAttribute;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_LocalPath = null;
            if (cmdletContext.EndpointInput_LocalPath != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_LocalPath = cmdletContext.EndpointInput_LocalPath;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_LocalPath != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.LocalPath = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_LocalPath;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityAttribute = null;
            if (cmdletContext.EndpointInput_ProbabilityAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityAttribute = cmdletContext.EndpointInput_ProbabilityAttribute;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.ProbabilityAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityAttribute;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.Double? requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute = null;
            if (cmdletContext.EndpointInput_ProbabilityThresholdAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute = cmdletContext.EndpointInput_ProbabilityThresholdAttribute.Value;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.ProbabilityThresholdAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute.Value;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3DataDistributionType requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3DataDistributionType = null;
            if (cmdletContext.EndpointInput_S3DataDistributionType != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3DataDistributionType = cmdletContext.EndpointInput_S3DataDistributionType;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3DataDistributionType != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.S3DataDistributionType = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3DataDistributionType;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3InputMode requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3InputMode = null;
            if (cmdletContext.EndpointInput_S3InputMode != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3InputMode = cmdletContext.EndpointInput_S3InputMode;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3InputMode != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.S3InputMode = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_S3InputMode;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_StartTimeOffset = null;
            if (cmdletContext.EndpointInput_StartTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_StartTimeOffset = cmdletContext.EndpointInput_StartTimeOffset;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_StartTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput.StartTimeOffset = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput_endpointInput_StartTimeOffset;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull = false;
            }
             // determine if requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput should be set to null
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInputIsNull)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput = null;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput != null)
            {
                request.ModelExplainabilityJobInput.EndpointInput = requestModelExplainabilityJobInput_modelExplainabilityJobInput_EndpointInput;
                requestModelExplainabilityJobInputIsNull = false;
            }
            Amazon.SageMaker.Model.BatchTransformInput requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput = null;
            
             // populate BatchTransformInput
            var requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = true;
            requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput = new Amazon.SageMaker.Model.BatchTransformInput();
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri = null;
            if (cmdletContext.BatchTransformInput_DataCapturedDestinationS3Uri != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri = cmdletContext.BatchTransformInput_DataCapturedDestinationS3Uri;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.DataCapturedDestinationS3Uri = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset = null;
            if (cmdletContext.BatchTransformInput_EndTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset = cmdletContext.BatchTransformInput_EndTimeOffset;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.EndTimeOffset = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute = null;
            if (cmdletContext.BatchTransformInput_FeaturesAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute = cmdletContext.BatchTransformInput_FeaturesAttribute;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.FeaturesAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute = null;
            if (cmdletContext.BatchTransformInput_InferenceAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute = cmdletContext.BatchTransformInput_InferenceAttribute;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.InferenceAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_LocalPath = null;
            if (cmdletContext.BatchTransformInput_LocalPath != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_LocalPath = cmdletContext.BatchTransformInput_LocalPath;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_LocalPath != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.LocalPath = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_LocalPath;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute = null;
            if (cmdletContext.BatchTransformInput_ProbabilityAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute = cmdletContext.BatchTransformInput_ProbabilityAttribute;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.ProbabilityAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.Double? requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute = null;
            if (cmdletContext.BatchTransformInput_ProbabilityThresholdAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute = cmdletContext.BatchTransformInput_ProbabilityThresholdAttribute.Value;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.ProbabilityThresholdAttribute = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute.Value;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3DataDistributionType requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType = null;
            if (cmdletContext.BatchTransformInput_S3DataDistributionType != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType = cmdletContext.BatchTransformInput_S3DataDistributionType;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.S3DataDistributionType = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3InputMode requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3InputMode = null;
            if (cmdletContext.BatchTransformInput_S3InputMode != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3InputMode = cmdletContext.BatchTransformInput_S3InputMode;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3InputMode != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.S3InputMode = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_S3InputMode;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset = null;
            if (cmdletContext.BatchTransformInput_StartTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset = cmdletContext.BatchTransformInput_StartTimeOffset;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.StartTimeOffset = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringDatasetFormat requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat = null;
            
             // populate DatasetFormat
            var requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormatIsNull = true;
            requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat = new Amazon.SageMaker.Model.MonitoringDatasetFormat();
            Amazon.SageMaker.Model.MonitoringParquetDatasetFormat requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet = null;
            if (cmdletContext.DatasetFormat_Parquet != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet = cmdletContext.DatasetFormat_Parquet;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat.Parquet = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormatIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringCsvDatasetFormat requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv = null;
            
             // populate Csv
            var requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_CsvIsNull = true;
            requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv = new Amazon.SageMaker.Model.MonitoringCsvDatasetFormat();
            System.Boolean? requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header = null;
            if (cmdletContext.Csv_Header != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header = cmdletContext.Csv_Header.Value;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv.Header = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header.Value;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_CsvIsNull = false;
            }
             // determine if requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv should be set to null
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_CsvIsNull)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv = null;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat.Csv = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Csv;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormatIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringJsonDatasetFormat requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json = null;
            
             // populate Json
            var requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_JsonIsNull = true;
            requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json = new Amazon.SageMaker.Model.MonitoringJsonDatasetFormat();
            System.Boolean? requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line = null;
            if (cmdletContext.Json_Line != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line = cmdletContext.Json_Line.Value;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json.Line = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line.Value;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_JsonIsNull = false;
            }
             // determine if requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json should be set to null
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_JsonIsNull)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json = null;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat.Json = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat_Json;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormatIsNull = false;
            }
             // determine if requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat should be set to null
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormatIsNull)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat = null;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat != null)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput.DatasetFormat = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput_modelExplainabilityJobInput_BatchTransformInput_DatasetFormat;
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull = false;
            }
             // determine if requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput should be set to null
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInputIsNull)
            {
                requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput = null;
            }
            if (requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput != null)
            {
                request.ModelExplainabilityJobInput.BatchTransformInput = requestModelExplainabilityJobInput_modelExplainabilityJobInput_BatchTransformInput;
                requestModelExplainabilityJobInputIsNull = false;
            }
             // determine if request.ModelExplainabilityJobInput should be set to null
            if (requestModelExplainabilityJobInputIsNull)
            {
                request.ModelExplainabilityJobInput = null;
            }
            
             // populate ModelExplainabilityJobOutputConfig
            var requestModelExplainabilityJobOutputConfigIsNull = true;
            request.ModelExplainabilityJobOutputConfig = new Amazon.SageMaker.Model.MonitoringOutputConfig();
            System.String requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_KmsKeyId = null;
            if (cmdletContext.ModelExplainabilityJobOutputConfig_KmsKeyId != null)
            {
                requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_KmsKeyId = cmdletContext.ModelExplainabilityJobOutputConfig_KmsKeyId;
            }
            if (requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_KmsKeyId != null)
            {
                request.ModelExplainabilityJobOutputConfig.KmsKeyId = requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_KmsKeyId;
                requestModelExplainabilityJobOutputConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.MonitoringOutput> requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_MonitoringOutput = null;
            if (cmdletContext.ModelExplainabilityJobOutputConfig_MonitoringOutput != null)
            {
                requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_MonitoringOutput = cmdletContext.ModelExplainabilityJobOutputConfig_MonitoringOutput;
            }
            if (requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_MonitoringOutput != null)
            {
                request.ModelExplainabilityJobOutputConfig.MonitoringOutputs = requestModelExplainabilityJobOutputConfig_modelExplainabilityJobOutputConfig_MonitoringOutput;
                requestModelExplainabilityJobOutputConfigIsNull = false;
            }
             // determine if request.ModelExplainabilityJobOutputConfig should be set to null
            if (requestModelExplainabilityJobOutputConfigIsNull)
            {
                request.ModelExplainabilityJobOutputConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateModelExplainabilityJobDefinition");
            try
            {
                #if DESKTOP
                return client.CreateModelExplainabilityJobDefinition(request);
                #elif CORECLR
                return client.CreateModelExplainabilityJobDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String ModelExplainabilityAppSpecification_ConfigUri { get; set; }
            public Dictionary<System.String, System.String> ModelExplainabilityAppSpecification_Environment { get; set; }
            public System.String ModelExplainabilityAppSpecification_ImageUri { get; set; }
            public System.String ModelExplainabilityBaselineConfig_BaseliningJobName { get; set; }
            public System.String ConstraintsResource_S3Uri { get; set; }
            public System.String BatchTransformInput_DataCapturedDestinationS3Uri { get; set; }
            public System.Boolean? Csv_Header { get; set; }
            public System.Boolean? Json_Line { get; set; }
            public Amazon.SageMaker.Model.MonitoringParquetDatasetFormat DatasetFormat_Parquet { get; set; }
            public System.String BatchTransformInput_EndTimeOffset { get; set; }
            public System.String BatchTransformInput_FeaturesAttribute { get; set; }
            public System.String BatchTransformInput_InferenceAttribute { get; set; }
            public System.String BatchTransformInput_LocalPath { get; set; }
            public System.String BatchTransformInput_ProbabilityAttribute { get; set; }
            public System.Double? BatchTransformInput_ProbabilityThresholdAttribute { get; set; }
            public Amazon.SageMaker.ProcessingS3DataDistributionType BatchTransformInput_S3DataDistributionType { get; set; }
            public Amazon.SageMaker.ProcessingS3InputMode BatchTransformInput_S3InputMode { get; set; }
            public System.String BatchTransformInput_StartTimeOffset { get; set; }
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
            public System.String ModelExplainabilityJobOutputConfig_KmsKeyId { get; set; }
            public List<Amazon.SageMaker.Model.MonitoringOutput> ModelExplainabilityJobOutputConfig_MonitoringOutput { get; set; }
            public System.Boolean? NetworkConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.Boolean? NetworkConfig_EnableNetworkIsolation { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateModelExplainabilityJobDefinitionResponse, NewSMModelExplainabilityJobDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobDefinitionArn;
        }
        
    }
}
