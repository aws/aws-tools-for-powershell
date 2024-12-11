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
    /// Creates a definition for a job that monitors data quality and drift. For information
    /// about model monitor, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor.html">Amazon
    /// SageMaker Model Monitor</a>.
    /// </summary>
    [Cmdlet("New", "SMDataQualityJobDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateDataQualityJobDefinition API operation.", Operation = new[] {"CreateDataQualityJobDefinition"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMDataQualityJobDefinitionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataQualityBaselineConfig_BaseliningJobName
        /// <summary>
        /// <para>
        /// <para>The name of the job that performs baselining for the data quality monitoring job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualityBaselineConfig_BaseliningJobName { get; set; }
        #endregion
        
        #region Parameter DataQualityAppSpecification_ContainerArgument
        /// <summary>
        /// <para>
        /// <para>The arguments to send to the container that the monitoring job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityAppSpecification_ContainerArguments")]
        public System.String[] DataQualityAppSpecification_ContainerArgument { get; set; }
        #endregion
        
        #region Parameter DataQualityAppSpecification_ContainerEntrypoint
        /// <summary>
        /// <para>
        /// <para>The entrypoint for a container used to run a monitoring job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DataQualityAppSpecification_ContainerEntrypoint { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_DataCapturedDestinationS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location being used to capture the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_DataCapturedDestinationS3Uri")]
        public System.String BatchTransformInput_DataCapturedDestinationS3Uri { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>Whether to encrypt all communications between the instances used for the monitoring
        /// jobs. Choose <c>True</c> to encrypt communications. Encryption provides greater security
        /// for distributed jobs, but the processing might take longer.</para>
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
        /// <para>An endpoint in customer's account which has enabled <c>DataCaptureConfig</c> enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_EndpointName")]
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
        [Alias("DataQualityJobInput_BatchTransformInput_EndTimeOffset")]
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
        [Alias("DataQualityJobInput_EndpointInput_EndTimeOffset")]
        public System.String EndpointInput_EndTimeOffset { get; set; }
        #endregion
        
        #region Parameter DataQualityAppSpecification_Environment
        /// <summary>
        /// <para>
        /// <para>Sets the environment variables in the container that the monitoring job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DataQualityAppSpecification_Environment { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_ExcludeFeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data to exclude from the analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_ExcludeFeaturesAttribute")]
        public System.String BatchTransformInput_ExcludeFeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ExcludeFeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data to exclude from the analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_ExcludeFeaturesAttribute")]
        public System.String EndpointInput_ExcludeFeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_FeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data that are the input features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_FeaturesAttribute")]
        public System.String BatchTransformInput_FeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_FeaturesAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the input data that are the input features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_FeaturesAttribute")]
        public System.String EndpointInput_FeaturesAttribute { get; set; }
        #endregion
        
        #region Parameter Csv_Header
        /// <summary>
        /// <para>
        /// <para>Indicates if the CSV data has a header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_DatasetFormat_Csv_Header")]
        public System.Boolean? Csv_Header { get; set; }
        #endregion
        
        #region Parameter DataQualityAppSpecification_ImageUri
        /// <summary>
        /// <para>
        /// <para>The container image that the data quality monitoring job runs.</para>
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
        public System.String DataQualityAppSpecification_ImageUri { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_InferenceAttribute
        /// <summary>
        /// <para>
        /// <para>The attribute of the input data that represents the ground truth label.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_InferenceAttribute")]
        public System.String BatchTransformInput_InferenceAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_InferenceAttribute
        /// <summary>
        /// <para>
        /// <para>The attribute of the input data that represents the ground truth label.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_InferenceAttribute")]
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
        /// <para>The name for the monitoring job definition.</para>
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
        
        #region Parameter DataQualityJobOutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) key that Amazon SageMaker uses to encrypt the model
        /// artifacts at rest using Amazon S3 server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualityJobOutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Json_Line
        /// <summary>
        /// <para>
        /// <para>Indicates if the file should be read as a JSON object per line. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_DatasetFormat_Json_Line")]
        public System.Boolean? Json_Line { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to the filesystem where the batch transform data is available to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_LocalPath")]
        public System.String BatchTransformInput_LocalPath { get; set; }
        #endregion
        
        #region Parameter EndpointInput_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to the filesystem where the endpoint data is available to the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_LocalPath")]
        public System.String EndpointInput_LocalPath { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime allowed in seconds.</para><note><para>The <c>MaxRuntimeInSeconds</c> cannot exceed the frequency of the job. For data quality
        /// and model explainability, this can be up to 3600 seconds for an hourly schedule. For
        /// model bias and model quality hourly schedules, this can be up to 1800 seconds.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter DataQualityJobOutputConfig_MonitoringOutput
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
        [Alias("DataQualityJobOutputConfig_MonitoringOutputs")]
        public Amazon.SageMaker.Model.MonitoringOutput[] DataQualityJobOutputConfig_MonitoringOutput { get; set; }
        #endregion
        
        #region Parameter DatasetFormat_Parquet
        /// <summary>
        /// <para>
        /// <para>The Parquet dataset used in the monitoring job</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_DatasetFormat_Parquet")]
        public Amazon.SageMaker.Model.MonitoringParquetDatasetFormat DatasetFormat_Parquet { get; set; }
        #endregion
        
        #region Parameter DataQualityAppSpecification_PostAnalyticsProcessorSourceUri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI to a script that is called after analysis has been performed. Applicable
        /// only for the built-in (first party) containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualityAppSpecification_PostAnalyticsProcessorSourceUri { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_ProbabilityAttribute
        /// <summary>
        /// <para>
        /// <para>In a classification problem, the attribute that represents the class probability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_ProbabilityAttribute")]
        public System.String BatchTransformInput_ProbabilityAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ProbabilityAttribute
        /// <summary>
        /// <para>
        /// <para>In a classification problem, the attribute that represents the class probability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_ProbabilityAttribute")]
        public System.String EndpointInput_ProbabilityAttribute { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_ProbabilityThresholdAttribute
        /// <summary>
        /// <para>
        /// <para>The threshold for the class probability to be evaluated as a positive result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_ProbabilityThresholdAttribute")]
        public System.Double? BatchTransformInput_ProbabilityThresholdAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointInput_ProbabilityThresholdAttribute
        /// <summary>
        /// <para>
        /// <para>The threshold for the class probability to be evaluated as a positive result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_ProbabilityThresholdAttribute")]
        public System.Double? EndpointInput_ProbabilityThresholdAttribute { get; set; }
        #endregion
        
        #region Parameter DataQualityAppSpecification_RecordPreprocessorSourceUri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI to a script that is called per row prior to running analysis. It
        /// can base64 decode the payload and convert it into a flattened JSON so that the built-in
        /// container can use the converted data. Applicable only for the built-in (first party)
        /// containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualityAppSpecification_RecordPreprocessorSourceUri { get; set; }
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
        /// key. Defaults to <c>FullyReplicated</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_S3DataDistributionType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3DataDistributionType")]
        public Amazon.SageMaker.ProcessingS3DataDistributionType BatchTransformInput_S3DataDistributionType { get; set; }
        #endregion
        
        #region Parameter EndpointInput_S3DataDistributionType
        /// <summary>
        /// <para>
        /// <para>Whether input data distributed in Amazon S3 is fully replicated or sharded by an Amazon
        /// S3 key. Defaults to <c>FullyReplicated</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_S3DataDistributionType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3DataDistributionType")]
        public Amazon.SageMaker.ProcessingS3DataDistributionType EndpointInput_S3DataDistributionType { get; set; }
        #endregion
        
        #region Parameter BatchTransformInput_S3InputMode
        /// <summary>
        /// <para>
        /// <para>Whether the <c>Pipe</c> or <c>File</c> is used as the input mode for transferring
        /// data for the monitoring job. <c>Pipe</c> mode is recommended for large datasets. <c>File</c>
        /// mode is useful for small files that fit in memory. Defaults to <c>File</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_S3InputMode")]
        [AWSConstantClassSource("Amazon.SageMaker.ProcessingS3InputMode")]
        public Amazon.SageMaker.ProcessingS3InputMode BatchTransformInput_S3InputMode { get; set; }
        #endregion
        
        #region Parameter EndpointInput_S3InputMode
        /// <summary>
        /// <para>
        /// <para>Whether the <c>Pipe</c> or <c>File</c> is used as the input mode for transferring
        /// data for the monitoring job. <c>Pipe</c> mode is recommended for large datasets. <c>File</c>
        /// mode is useful for small files that fit in memory. Defaults to <c>File</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_EndpointInput_S3InputMode")]
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
        [Alias("DataQualityBaselineConfig_ConstraintsResource_S3Uri")]
        public System.String ConstraintsResource_S3Uri { get; set; }
        #endregion
        
        #region Parameter StatisticsResource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the statistics resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityBaselineConfig_StatisticsResource_S3Uri")]
        public System.String StatisticsResource_S3Uri { get; set; }
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
        
        #region Parameter BatchTransformInput_StartTimeOffset
        /// <summary>
        /// <para>
        /// <para>If specified, monitoring jobs substract this time from the start time. For information
        /// about using offsets for scheduling monitoring jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor-model-quality-schedule.html">Schedule
        /// Model Quality Monitoring Jobs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataQualityJobInput_BatchTransformInput_StartTimeOffset")]
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
        [Alias("DataQualityJobInput_EndpointInput_StartTimeOffset")]
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
        /// <para>(Optional) An array of key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-whatURL">
        /// Using Cost Allocation Tags</a> in the <i>Amazon Web Services Billing and Cost Management
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
        /// <para>The Key Management Service (KMS) key that Amazon SageMaker uses to encrypt data on
        /// the storage volume attached to the ML compute instance(s) that run the model monitoring
        /// job.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobDefinitionArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMDataQualityJobDefinition (CreateDataQualityJobDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse, NewSMDataQualityJobDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DataQualityAppSpecification_ContainerArgument != null)
            {
                context.DataQualityAppSpecification_ContainerArgument = new List<System.String>(this.DataQualityAppSpecification_ContainerArgument);
            }
            if (this.DataQualityAppSpecification_ContainerEntrypoint != null)
            {
                context.DataQualityAppSpecification_ContainerEntrypoint = new List<System.String>(this.DataQualityAppSpecification_ContainerEntrypoint);
            }
            if (this.DataQualityAppSpecification_Environment != null)
            {
                context.DataQualityAppSpecification_Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DataQualityAppSpecification_Environment.Keys)
                {
                    context.DataQualityAppSpecification_Environment.Add((String)hashKey, (System.String)(this.DataQualityAppSpecification_Environment[hashKey]));
                }
            }
            context.DataQualityAppSpecification_ImageUri = this.DataQualityAppSpecification_ImageUri;
            #if MODULAR
            if (this.DataQualityAppSpecification_ImageUri == null && ParameterWasBound(nameof(this.DataQualityAppSpecification_ImageUri)))
            {
                WriteWarning("You are passing $null as a value for parameter DataQualityAppSpecification_ImageUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataQualityAppSpecification_PostAnalyticsProcessorSourceUri = this.DataQualityAppSpecification_PostAnalyticsProcessorSourceUri;
            context.DataQualityAppSpecification_RecordPreprocessorSourceUri = this.DataQualityAppSpecification_RecordPreprocessorSourceUri;
            context.DataQualityBaselineConfig_BaseliningJobName = this.DataQualityBaselineConfig_BaseliningJobName;
            context.ConstraintsResource_S3Uri = this.ConstraintsResource_S3Uri;
            context.StatisticsResource_S3Uri = this.StatisticsResource_S3Uri;
            context.BatchTransformInput_DataCapturedDestinationS3Uri = this.BatchTransformInput_DataCapturedDestinationS3Uri;
            context.Csv_Header = this.Csv_Header;
            context.Json_Line = this.Json_Line;
            context.DatasetFormat_Parquet = this.DatasetFormat_Parquet;
            context.BatchTransformInput_EndTimeOffset = this.BatchTransformInput_EndTimeOffset;
            context.BatchTransformInput_ExcludeFeaturesAttribute = this.BatchTransformInput_ExcludeFeaturesAttribute;
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
            context.EndpointInput_ExcludeFeaturesAttribute = this.EndpointInput_ExcludeFeaturesAttribute;
            context.EndpointInput_FeaturesAttribute = this.EndpointInput_FeaturesAttribute;
            context.EndpointInput_InferenceAttribute = this.EndpointInput_InferenceAttribute;
            context.EndpointInput_LocalPath = this.EndpointInput_LocalPath;
            context.EndpointInput_ProbabilityAttribute = this.EndpointInput_ProbabilityAttribute;
            context.EndpointInput_ProbabilityThresholdAttribute = this.EndpointInput_ProbabilityThresholdAttribute;
            context.EndpointInput_S3DataDistributionType = this.EndpointInput_S3DataDistributionType;
            context.EndpointInput_S3InputMode = this.EndpointInput_S3InputMode;
            context.EndpointInput_StartTimeOffset = this.EndpointInput_StartTimeOffset;
            context.DataQualityJobOutputConfig_KmsKeyId = this.DataQualityJobOutputConfig_KmsKeyId;
            if (this.DataQualityJobOutputConfig_MonitoringOutput != null)
            {
                context.DataQualityJobOutputConfig_MonitoringOutput = new List<Amazon.SageMaker.Model.MonitoringOutput>(this.DataQualityJobOutputConfig_MonitoringOutput);
            }
            #if MODULAR
            if (this.DataQualityJobOutputConfig_MonitoringOutput == null && ParameterWasBound(nameof(this.DataQualityJobOutputConfig_MonitoringOutput)))
            {
                WriteWarning("You are passing $null as a value for parameter DataQualityJobOutputConfig_MonitoringOutput which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMaker.Model.CreateDataQualityJobDefinitionRequest();
            
            
             // populate DataQualityAppSpecification
            var requestDataQualityAppSpecificationIsNull = true;
            request.DataQualityAppSpecification = new Amazon.SageMaker.Model.DataQualityAppSpecification();
            List<System.String> requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerArgument = null;
            if (cmdletContext.DataQualityAppSpecification_ContainerArgument != null)
            {
                requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerArgument = cmdletContext.DataQualityAppSpecification_ContainerArgument;
            }
            if (requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerArgument != null)
            {
                request.DataQualityAppSpecification.ContainerArguments = requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerArgument;
                requestDataQualityAppSpecificationIsNull = false;
            }
            List<System.String> requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerEntrypoint = null;
            if (cmdletContext.DataQualityAppSpecification_ContainerEntrypoint != null)
            {
                requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerEntrypoint = cmdletContext.DataQualityAppSpecification_ContainerEntrypoint;
            }
            if (requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerEntrypoint != null)
            {
                request.DataQualityAppSpecification.ContainerEntrypoint = requestDataQualityAppSpecification_dataQualityAppSpecification_ContainerEntrypoint;
                requestDataQualityAppSpecificationIsNull = false;
            }
            Dictionary<System.String, System.String> requestDataQualityAppSpecification_dataQualityAppSpecification_Environment = null;
            if (cmdletContext.DataQualityAppSpecification_Environment != null)
            {
                requestDataQualityAppSpecification_dataQualityAppSpecification_Environment = cmdletContext.DataQualityAppSpecification_Environment;
            }
            if (requestDataQualityAppSpecification_dataQualityAppSpecification_Environment != null)
            {
                request.DataQualityAppSpecification.Environment = requestDataQualityAppSpecification_dataQualityAppSpecification_Environment;
                requestDataQualityAppSpecificationIsNull = false;
            }
            System.String requestDataQualityAppSpecification_dataQualityAppSpecification_ImageUri = null;
            if (cmdletContext.DataQualityAppSpecification_ImageUri != null)
            {
                requestDataQualityAppSpecification_dataQualityAppSpecification_ImageUri = cmdletContext.DataQualityAppSpecification_ImageUri;
            }
            if (requestDataQualityAppSpecification_dataQualityAppSpecification_ImageUri != null)
            {
                request.DataQualityAppSpecification.ImageUri = requestDataQualityAppSpecification_dataQualityAppSpecification_ImageUri;
                requestDataQualityAppSpecificationIsNull = false;
            }
            System.String requestDataQualityAppSpecification_dataQualityAppSpecification_PostAnalyticsProcessorSourceUri = null;
            if (cmdletContext.DataQualityAppSpecification_PostAnalyticsProcessorSourceUri != null)
            {
                requestDataQualityAppSpecification_dataQualityAppSpecification_PostAnalyticsProcessorSourceUri = cmdletContext.DataQualityAppSpecification_PostAnalyticsProcessorSourceUri;
            }
            if (requestDataQualityAppSpecification_dataQualityAppSpecification_PostAnalyticsProcessorSourceUri != null)
            {
                request.DataQualityAppSpecification.PostAnalyticsProcessorSourceUri = requestDataQualityAppSpecification_dataQualityAppSpecification_PostAnalyticsProcessorSourceUri;
                requestDataQualityAppSpecificationIsNull = false;
            }
            System.String requestDataQualityAppSpecification_dataQualityAppSpecification_RecordPreprocessorSourceUri = null;
            if (cmdletContext.DataQualityAppSpecification_RecordPreprocessorSourceUri != null)
            {
                requestDataQualityAppSpecification_dataQualityAppSpecification_RecordPreprocessorSourceUri = cmdletContext.DataQualityAppSpecification_RecordPreprocessorSourceUri;
            }
            if (requestDataQualityAppSpecification_dataQualityAppSpecification_RecordPreprocessorSourceUri != null)
            {
                request.DataQualityAppSpecification.RecordPreprocessorSourceUri = requestDataQualityAppSpecification_dataQualityAppSpecification_RecordPreprocessorSourceUri;
                requestDataQualityAppSpecificationIsNull = false;
            }
             // determine if request.DataQualityAppSpecification should be set to null
            if (requestDataQualityAppSpecificationIsNull)
            {
                request.DataQualityAppSpecification = null;
            }
            
             // populate DataQualityBaselineConfig
            var requestDataQualityBaselineConfigIsNull = true;
            request.DataQualityBaselineConfig = new Amazon.SageMaker.Model.DataQualityBaselineConfig();
            System.String requestDataQualityBaselineConfig_dataQualityBaselineConfig_BaseliningJobName = null;
            if (cmdletContext.DataQualityBaselineConfig_BaseliningJobName != null)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_BaseliningJobName = cmdletContext.DataQualityBaselineConfig_BaseliningJobName;
            }
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_BaseliningJobName != null)
            {
                request.DataQualityBaselineConfig.BaseliningJobName = requestDataQualityBaselineConfig_dataQualityBaselineConfig_BaseliningJobName;
                requestDataQualityBaselineConfigIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringConstraintsResource requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource = null;
            
             // populate ConstraintsResource
            var requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResourceIsNull = true;
            requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource = new Amazon.SageMaker.Model.MonitoringConstraintsResource();
            System.String requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri = null;
            if (cmdletContext.ConstraintsResource_S3Uri != null)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri = cmdletContext.ConstraintsResource_S3Uri;
            }
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri != null)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource.S3Uri = requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource_constraintsResource_S3Uri;
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResourceIsNull = false;
            }
             // determine if requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource should be set to null
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResourceIsNull)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource = null;
            }
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource != null)
            {
                request.DataQualityBaselineConfig.ConstraintsResource = requestDataQualityBaselineConfig_dataQualityBaselineConfig_ConstraintsResource;
                requestDataQualityBaselineConfigIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringStatisticsResource requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource = null;
            
             // populate StatisticsResource
            var requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResourceIsNull = true;
            requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource = new Amazon.SageMaker.Model.MonitoringStatisticsResource();
            System.String requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource_statisticsResource_S3Uri = null;
            if (cmdletContext.StatisticsResource_S3Uri != null)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource_statisticsResource_S3Uri = cmdletContext.StatisticsResource_S3Uri;
            }
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource_statisticsResource_S3Uri != null)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource.S3Uri = requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource_statisticsResource_S3Uri;
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResourceIsNull = false;
            }
             // determine if requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource should be set to null
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResourceIsNull)
            {
                requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource = null;
            }
            if (requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource != null)
            {
                request.DataQualityBaselineConfig.StatisticsResource = requestDataQualityBaselineConfig_dataQualityBaselineConfig_StatisticsResource;
                requestDataQualityBaselineConfigIsNull = false;
            }
             // determine if request.DataQualityBaselineConfig should be set to null
            if (requestDataQualityBaselineConfigIsNull)
            {
                request.DataQualityBaselineConfig = null;
            }
            
             // populate DataQualityJobInput
            var requestDataQualityJobInputIsNull = true;
            request.DataQualityJobInput = new Amazon.SageMaker.Model.DataQualityJobInput();
            Amazon.SageMaker.Model.EndpointInput requestDataQualityJobInput_dataQualityJobInput_EndpointInput = null;
            
             // populate EndpointInput
            var requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = true;
            requestDataQualityJobInput_dataQualityJobInput_EndpointInput = new Amazon.SageMaker.Model.EndpointInput();
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndpointName = null;
            if (cmdletContext.EndpointInput_EndpointName != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndpointName = cmdletContext.EndpointInput_EndpointName;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndpointName != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.EndpointName = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndpointName;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndTimeOffset = null;
            if (cmdletContext.EndpointInput_EndTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndTimeOffset = cmdletContext.EndpointInput_EndTimeOffset;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.EndTimeOffset = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_EndTimeOffset;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ExcludeFeaturesAttribute = null;
            if (cmdletContext.EndpointInput_ExcludeFeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ExcludeFeaturesAttribute = cmdletContext.EndpointInput_ExcludeFeaturesAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ExcludeFeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.ExcludeFeaturesAttribute = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ExcludeFeaturesAttribute;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute = null;
            if (cmdletContext.EndpointInput_FeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute = cmdletContext.EndpointInput_FeaturesAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.FeaturesAttribute = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_FeaturesAttribute;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_InferenceAttribute = null;
            if (cmdletContext.EndpointInput_InferenceAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_InferenceAttribute = cmdletContext.EndpointInput_InferenceAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_InferenceAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.InferenceAttribute = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_InferenceAttribute;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_LocalPath = null;
            if (cmdletContext.EndpointInput_LocalPath != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_LocalPath = cmdletContext.EndpointInput_LocalPath;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_LocalPath != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.LocalPath = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_LocalPath;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute = null;
            if (cmdletContext.EndpointInput_ProbabilityAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute = cmdletContext.EndpointInput_ProbabilityAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.ProbabilityAttribute = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityAttribute;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.Double? requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute = null;
            if (cmdletContext.EndpointInput_ProbabilityThresholdAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute = cmdletContext.EndpointInput_ProbabilityThresholdAttribute.Value;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.ProbabilityThresholdAttribute = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_ProbabilityThresholdAttribute.Value;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3DataDistributionType requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType = null;
            if (cmdletContext.EndpointInput_S3DataDistributionType != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType = cmdletContext.EndpointInput_S3DataDistributionType;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.S3DataDistributionType = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3DataDistributionType;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3InputMode requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3InputMode = null;
            if (cmdletContext.EndpointInput_S3InputMode != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3InputMode = cmdletContext.EndpointInput_S3InputMode;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3InputMode != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.S3InputMode = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_S3InputMode;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_StartTimeOffset = null;
            if (cmdletContext.EndpointInput_StartTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_StartTimeOffset = cmdletContext.EndpointInput_StartTimeOffset;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_StartTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput.StartTimeOffset = requestDataQualityJobInput_dataQualityJobInput_EndpointInput_endpointInput_StartTimeOffset;
                requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull = false;
            }
             // determine if requestDataQualityJobInput_dataQualityJobInput_EndpointInput should be set to null
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInputIsNull)
            {
                requestDataQualityJobInput_dataQualityJobInput_EndpointInput = null;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_EndpointInput != null)
            {
                request.DataQualityJobInput.EndpointInput = requestDataQualityJobInput_dataQualityJobInput_EndpointInput;
                requestDataQualityJobInputIsNull = false;
            }
            Amazon.SageMaker.Model.BatchTransformInput requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput = null;
            
             // populate BatchTransformInput
            var requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = true;
            requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput = new Amazon.SageMaker.Model.BatchTransformInput();
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri = null;
            if (cmdletContext.BatchTransformInput_DataCapturedDestinationS3Uri != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri = cmdletContext.BatchTransformInput_DataCapturedDestinationS3Uri;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.DataCapturedDestinationS3Uri = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_DataCapturedDestinationS3Uri;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset = null;
            if (cmdletContext.BatchTransformInput_EndTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset = cmdletContext.BatchTransformInput_EndTimeOffset;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.EndTimeOffset = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_EndTimeOffset;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ExcludeFeaturesAttribute = null;
            if (cmdletContext.BatchTransformInput_ExcludeFeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ExcludeFeaturesAttribute = cmdletContext.BatchTransformInput_ExcludeFeaturesAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ExcludeFeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.ExcludeFeaturesAttribute = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ExcludeFeaturesAttribute;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute = null;
            if (cmdletContext.BatchTransformInput_FeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute = cmdletContext.BatchTransformInput_FeaturesAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.FeaturesAttribute = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_FeaturesAttribute;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute = null;
            if (cmdletContext.BatchTransformInput_InferenceAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute = cmdletContext.BatchTransformInput_InferenceAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.InferenceAttribute = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_InferenceAttribute;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_LocalPath = null;
            if (cmdletContext.BatchTransformInput_LocalPath != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_LocalPath = cmdletContext.BatchTransformInput_LocalPath;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_LocalPath != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.LocalPath = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_LocalPath;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute = null;
            if (cmdletContext.BatchTransformInput_ProbabilityAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute = cmdletContext.BatchTransformInput_ProbabilityAttribute;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.ProbabilityAttribute = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityAttribute;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.Double? requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute = null;
            if (cmdletContext.BatchTransformInput_ProbabilityThresholdAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute = cmdletContext.BatchTransformInput_ProbabilityThresholdAttribute.Value;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.ProbabilityThresholdAttribute = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_ProbabilityThresholdAttribute.Value;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3DataDistributionType requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType = null;
            if (cmdletContext.BatchTransformInput_S3DataDistributionType != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType = cmdletContext.BatchTransformInput_S3DataDistributionType;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.S3DataDistributionType = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3DataDistributionType;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            Amazon.SageMaker.ProcessingS3InputMode requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3InputMode = null;
            if (cmdletContext.BatchTransformInput_S3InputMode != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3InputMode = cmdletContext.BatchTransformInput_S3InputMode;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3InputMode != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.S3InputMode = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_S3InputMode;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            System.String requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset = null;
            if (cmdletContext.BatchTransformInput_StartTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset = cmdletContext.BatchTransformInput_StartTimeOffset;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.StartTimeOffset = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_batchTransformInput_StartTimeOffset;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringDatasetFormat requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat = null;
            
             // populate DatasetFormat
            var requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormatIsNull = true;
            requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat = new Amazon.SageMaker.Model.MonitoringDatasetFormat();
            Amazon.SageMaker.Model.MonitoringParquetDatasetFormat requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet = null;
            if (cmdletContext.DatasetFormat_Parquet != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet = cmdletContext.DatasetFormat_Parquet;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat.Parquet = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_datasetFormat_Parquet;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormatIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringCsvDatasetFormat requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv = null;
            
             // populate Csv
            var requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_CsvIsNull = true;
            requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv = new Amazon.SageMaker.Model.MonitoringCsvDatasetFormat();
            System.Boolean? requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header = null;
            if (cmdletContext.Csv_Header != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header = cmdletContext.Csv_Header.Value;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv.Header = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv_csv_Header.Value;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_CsvIsNull = false;
            }
             // determine if requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv should be set to null
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_CsvIsNull)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv = null;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat.Csv = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Csv;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormatIsNull = false;
            }
            Amazon.SageMaker.Model.MonitoringJsonDatasetFormat requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json = null;
            
             // populate Json
            var requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_JsonIsNull = true;
            requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json = new Amazon.SageMaker.Model.MonitoringJsonDatasetFormat();
            System.Boolean? requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line = null;
            if (cmdletContext.Json_Line != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line = cmdletContext.Json_Line.Value;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json.Line = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json_json_Line.Value;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_JsonIsNull = false;
            }
             // determine if requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json should be set to null
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_JsonIsNull)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json = null;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat.Json = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat_dataQualityJobInput_BatchTransformInput_DatasetFormat_Json;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormatIsNull = false;
            }
             // determine if requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat should be set to null
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormatIsNull)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat = null;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat != null)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput.DatasetFormat = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput_dataQualityJobInput_BatchTransformInput_DatasetFormat;
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull = false;
            }
             // determine if requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput should be set to null
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInputIsNull)
            {
                requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput = null;
            }
            if (requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput != null)
            {
                request.DataQualityJobInput.BatchTransformInput = requestDataQualityJobInput_dataQualityJobInput_BatchTransformInput;
                requestDataQualityJobInputIsNull = false;
            }
             // determine if request.DataQualityJobInput should be set to null
            if (requestDataQualityJobInputIsNull)
            {
                request.DataQualityJobInput = null;
            }
            
             // populate DataQualityJobOutputConfig
            var requestDataQualityJobOutputConfigIsNull = true;
            request.DataQualityJobOutputConfig = new Amazon.SageMaker.Model.MonitoringOutputConfig();
            System.String requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_KmsKeyId = null;
            if (cmdletContext.DataQualityJobOutputConfig_KmsKeyId != null)
            {
                requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_KmsKeyId = cmdletContext.DataQualityJobOutputConfig_KmsKeyId;
            }
            if (requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_KmsKeyId != null)
            {
                request.DataQualityJobOutputConfig.KmsKeyId = requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_KmsKeyId;
                requestDataQualityJobOutputConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.MonitoringOutput> requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_MonitoringOutput = null;
            if (cmdletContext.DataQualityJobOutputConfig_MonitoringOutput != null)
            {
                requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_MonitoringOutput = cmdletContext.DataQualityJobOutputConfig_MonitoringOutput;
            }
            if (requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_MonitoringOutput != null)
            {
                request.DataQualityJobOutputConfig.MonitoringOutputs = requestDataQualityJobOutputConfig_dataQualityJobOutputConfig_MonitoringOutput;
                requestDataQualityJobOutputConfigIsNull = false;
            }
             // determine if request.DataQualityJobOutputConfig should be set to null
            if (requestDataQualityJobOutputConfigIsNull)
            {
                request.DataQualityJobOutputConfig = null;
            }
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
        
        private Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateDataQualityJobDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateDataQualityJobDefinition");
            try
            {
                #if DESKTOP
                return client.CreateDataQualityJobDefinition(request);
                #elif CORECLR
                return client.CreateDataQualityJobDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DataQualityAppSpecification_ContainerArgument { get; set; }
            public List<System.String> DataQualityAppSpecification_ContainerEntrypoint { get; set; }
            public Dictionary<System.String, System.String> DataQualityAppSpecification_Environment { get; set; }
            public System.String DataQualityAppSpecification_ImageUri { get; set; }
            public System.String DataQualityAppSpecification_PostAnalyticsProcessorSourceUri { get; set; }
            public System.String DataQualityAppSpecification_RecordPreprocessorSourceUri { get; set; }
            public System.String DataQualityBaselineConfig_BaseliningJobName { get; set; }
            public System.String ConstraintsResource_S3Uri { get; set; }
            public System.String StatisticsResource_S3Uri { get; set; }
            public System.String BatchTransformInput_DataCapturedDestinationS3Uri { get; set; }
            public System.Boolean? Csv_Header { get; set; }
            public System.Boolean? Json_Line { get; set; }
            public Amazon.SageMaker.Model.MonitoringParquetDatasetFormat DatasetFormat_Parquet { get; set; }
            public System.String BatchTransformInput_EndTimeOffset { get; set; }
            public System.String BatchTransformInput_ExcludeFeaturesAttribute { get; set; }
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
            public System.String EndpointInput_ExcludeFeaturesAttribute { get; set; }
            public System.String EndpointInput_FeaturesAttribute { get; set; }
            public System.String EndpointInput_InferenceAttribute { get; set; }
            public System.String EndpointInput_LocalPath { get; set; }
            public System.String EndpointInput_ProbabilityAttribute { get; set; }
            public System.Double? EndpointInput_ProbabilityThresholdAttribute { get; set; }
            public Amazon.SageMaker.ProcessingS3DataDistributionType EndpointInput_S3DataDistributionType { get; set; }
            public Amazon.SageMaker.ProcessingS3InputMode EndpointInput_S3InputMode { get; set; }
            public System.String EndpointInput_StartTimeOffset { get; set; }
            public System.String DataQualityJobOutputConfig_KmsKeyId { get; set; }
            public List<Amazon.SageMaker.Model.MonitoringOutput> DataQualityJobOutputConfig_MonitoringOutput { get; set; }
            public System.String JobDefinitionName { get; set; }
            public System.Int32? ClusterConfig_InstanceCount { get; set; }
            public Amazon.SageMaker.ProcessingInstanceType ClusterConfig_InstanceType { get; set; }
            public System.String ClusterConfig_VolumeKmsKeyId { get; set; }
            public System.Int32? ClusterConfig_VolumeSizeInGB { get; set; }
            public System.Boolean? NetworkConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.Boolean? NetworkConfig_EnableNetworkIsolation { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateDataQualityJobDefinitionResponse, NewSMDataQualityJobDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobDefinitionArn;
        }
        
    }
}
