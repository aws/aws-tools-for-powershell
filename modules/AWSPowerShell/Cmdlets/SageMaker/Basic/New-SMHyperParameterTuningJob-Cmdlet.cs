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
    /// Starts a hyperparameter tuning job. A hyperparameter tuning job finds the best version
    /// of a model by running many training jobs on your dataset using the algorithm you choose
    /// and values for hyperparameters within ranges that you specify. It then chooses the
    /// hyperparameter values that result in a model that performs the best, as measured by
    /// an objective metric that you choose.
    /// 
    ///  
    /// <para>
    /// A hyperparameter tuning job automatically creates Amazon SageMaker experiments, trials,
    /// and trial components for each training job that it runs. You can view these entities
    /// in Amazon SageMaker Studio. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/experiments-view-compare.html#experiments-view">View
    /// Experiments, Trials, and Trial Components</a>.
    /// </para><important><para>
    /// Do not include any security-sensitive information including account access IDs, secrets
    /// or tokens in any hyperparameter field. If the use of security-sensitive credentials
    /// are detected, SageMaker will reject your training job request and return an exception
    /// error.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SMHyperParameterTuningJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateHyperParameterTuningJob API operation.", Operation = new[] {"CreateHyperParameterTuningJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMHyperParameterTuningJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AlgorithmSpecification_AlgorithmName
        /// <summary>
        /// <para>
        /// <para>The name of the resource algorithm to use for the hyperparameter tuning job. If you
        /// specify a value for this parameter, do not specify a value for <c>TrainingImage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_AlgorithmName")]
        public System.String AlgorithmSpecification_AlgorithmName { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningResourceConfig_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy that determines the order of preference for resources specified in <c>InstanceConfigs</c>
        /// used in hyperparameter optimization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterTuningResourceConfig_AllocationStrategy")]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningAllocationStrategy")]
        public Amazon.SageMaker.HyperParameterTuningAllocationStrategy HyperParameterTuningResourceConfig_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_AutoParameter
        /// <summary>
        /// <para>
        /// <para>A list containing hyperparameter names and example values to be used by Autotune to
        /// determine optimal ranges for your tuning job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_AutoParameters")]
        public Amazon.SageMaker.Model.AutoParameter[] ParameterRanges_AutoParameter { get; set; }
        #endregion
        
        #region Parameter HyperParameterRanges_AutoParameter
        /// <summary>
        /// <para>
        /// <para>A list containing hyperparameter names and example values to be used by Autotune to
        /// determine optimal ranges for your tuning job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterRanges_AutoParameters")]
        public Amazon.SageMaker.Model.AutoParameter[] HyperParameterRanges_AutoParameter { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_CategoricalParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CategoricalParameterRange.html">CategoricalParameterRange</a>
        /// objects that specify ranges of categorical hyperparameters that a hyperparameter tuning
        /// job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_CategoricalParameterRanges")]
        public Amazon.SageMaker.Model.CategoricalParameterRange[] ParameterRanges_CategoricalParameterRange { get; set; }
        #endregion
        
        #region Parameter HyperParameterRanges_CategoricalParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CategoricalParameterRange.html">CategoricalParameterRange</a>
        /// objects that specify ranges of categorical hyperparameters that a hyperparameter tuning
        /// job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterRanges_CategoricalParameterRanges")]
        public Amazon.SageMaker.Model.CategoricalParameterRange[] HyperParameterRanges_CategoricalParameterRange { get; set; }
        #endregion
        
        #region Parameter ConvergenceDetected_CompleteOnConvergence
        /// <summary>
        /// <para>
        /// <para>A flag to stop a tuning job once AMT has detected that the job has converged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected_CompleteOnConvergence")]
        [AWSConstantClassSource("Amazon.SageMaker.CompleteOnConvergence")]
        public Amazon.SageMaker.CompleteOnConvergence ConvergenceDetected_CompleteOnConvergence { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_ContinuousParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ContinuousParameterRange.html">ContinuousParameterRange</a>
        /// objects that specify ranges of continuous hyperparameters that a hyperparameter tuning
        /// job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_ContinuousParameterRanges")]
        public Amazon.SageMaker.Model.ContinuousParameterRange[] ParameterRanges_ContinuousParameterRange { get; set; }
        #endregion
        
        #region Parameter HyperParameterRanges_ContinuousParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ContinuousParameterRange.html">ContinuousParameterRange</a>
        /// objects that specify ranges of continuous hyperparameters that a hyperparameter tuning
        /// job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterRanges_ContinuousParameterRanges")]
        public Amazon.SageMaker.Model.ContinuousParameterRange[] HyperParameterRanges_ContinuousParameterRange { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_DefinitionName
        /// <summary>
        /// <para>
        /// <para>The job definition name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingJobDefinition_DefinitionName { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>To encrypt all communications between ML compute instances in distributed training,
        /// choose <c>True</c>. Encryption provides greater security for distributed training,
        /// but training might take longer. How long it takes depends on the amount of communication
        /// between compute instances, especially if you use a deep learning algorithm in distributed
        /// training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TrainingJobDefinition_EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_EnableManagedSpotTraining
        /// <summary>
        /// <para>
        /// <para>A Boolean indicating whether managed spot training is enabled (<c>True</c>) or not
        /// (<c>False</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TrainingJobDefinition_EnableManagedSpotTraining { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_EnableNetworkIsolation
        /// <summary>
        /// <para>
        /// <para>Isolates the training container. No inbound or outbound network calls can be made,
        /// except for calls between peers within a training cluster for distributed training.
        /// If network isolation is used for training jobs that are configured to use a VPC, SageMaker
        /// downloads and uploads customer data and model artifacts through the specified VPC,
        /// but the training container does not have network access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TrainingJobDefinition_EnableNetworkIsolation { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_Environment
        /// <summary>
        /// <para>
        /// <para>An environment variable that you can pass into the SageMaker <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateTrainingJob.html">CreateTrainingJob</a>
        /// API. You can use an existing <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateTrainingJob.html#sagemaker-CreateTrainingJob-request-Environment">environment
        /// variable from the training container</a> or use your own. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/automatic-model-tuning-define-metrics-variables.html">Define
        /// metrics and variables</a> for more information.</para><note><para>The maximum number of items specified for <c>Map Entries</c> refers to the maximum
        /// number of environment variables for each <c>TrainingJobDefinition</c> and also the
        /// maximum for the hyperparameter tuning job itself. That is, the sum of the number of
        /// environment variables for all the training job definitions can't exceed the maximum
        /// number specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable TrainingJobDefinition_Environment { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobName
        /// <summary>
        /// <para>
        /// <para>The name of the tuning job. This name is the prefix for the names of all training
        /// jobs that this tuning job launches. The name must be unique within the same Amazon
        /// Web Services account and Amazon Web Services Region. The name must have 1 to 32 characters.
        /// Valid characters are a-z, A-Z, 0-9, and : + = @ _ % - (hyphen). The name is not case
        /// sensitive.</para>
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
        public System.String HyperParameterTuningJobName { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_InputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_Channel.html">Channel</a>
        /// objects that specify the input for the training jobs that the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.Channel[] TrainingJobDefinition_InputDataConfig { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningResourceConfig_InstanceConfig
        /// <summary>
        /// <para>
        /// <para>A list containing the configuration(s) for one or more resources for processing hyperparameter
        /// jobs. These resources include compute instances and storage volumes to use in model
        /// training jobs launched by hyperparameter tuning jobs. The <c>AllocationStrategy</c>
        /// controls the order in which multiple configurations provided in <c>InstanceConfigs</c>
        /// are used.</para><note><para>If you only want to use a single instance configuration inside the <c>HyperParameterTuningResourceConfig</c>
        /// API, do not provide a value for <c>InstanceConfigs</c>. Instead, use <c>InstanceType</c>,
        /// <c>VolumeSizeInGB</c> and <c>InstanceCount</c>. If you use <c>InstanceConfigs</c>,
        /// do not provide values for <c>InstanceType</c>, <c>VolumeSizeInGB</c> or <c>InstanceCount</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterTuningResourceConfig_InstanceConfigs")]
        public Amazon.SageMaker.Model.HyperParameterTuningInstanceConfig[] HyperParameterTuningResourceConfig_InstanceConfig { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningResourceConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of compute instances of type <c>InstanceType</c> to use. For <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/data-parallel-use-api.html">distributed
        /// training</a>, select a value greater than 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterTuningResourceConfig_InstanceCount")]
        public System.Int32? HyperParameterTuningResourceConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningResourceConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type used to run hyperparameter optimization tuning jobs. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/notebooks-available-instance-types.html">
        /// descriptions of instance types</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterTuningResourceConfig_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.TrainingInstanceType")]
        public Amazon.SageMaker.TrainingInstanceType HyperParameterTuningResourceConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_IntegerParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_IntegerParameterRange.html">IntegerParameterRange</a>
        /// objects that specify ranges of integer hyperparameters that a hyperparameter tuning
        /// job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_IntegerParameterRanges")]
        public Amazon.SageMaker.Model.IntegerParameterRange[] ParameterRanges_IntegerParameterRange { get; set; }
        #endregion
        
        #region Parameter HyperParameterRanges_IntegerParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_IntegerParameterRange.html">IntegerParameterRange</a>
        /// objects that specify ranges of integer hyperparameters that a hyperparameter tuning
        /// job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterRanges_IntegerParameterRanges")]
        public Amazon.SageMaker.Model.IntegerParameterRange[] HyperParameterRanges_IntegerParameterRange { get; set; }
        #endregion
        
        #region Parameter CheckpointConfig_LocalPath
        /// <summary>
        /// <para>
        /// <para>(Optional) The local directory where checkpoints are written. The default directory
        /// is <c>/opt/ml/checkpoints/</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_CheckpointConfig_LocalPath")]
        public System.String CheckpointConfig_LocalPath { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>The number of times to retry the job. When the job is retried, it's <c>SecondaryStatus</c>
        /// is changed to <c>STARTING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_RetryStrategy_MaximumRetryAttempts")]
        public System.Int32? RetryStrategy_MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter ResourceLimits_MaxNumberOfTrainingJob
        /// <summary>
        /// <para>
        /// <para>The maximum number of training jobs that a hyperparameter tuning job can launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_ResourceLimits_MaxNumberOfTrainingJobs")]
        public System.Int32? ResourceLimits_MaxNumberOfTrainingJob { get; set; }
        #endregion
        
        #region Parameter BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving
        /// <summary>
        /// <para>
        /// <para>The number of training jobs that have failed to improve model performance by 1% or
        /// greater over prior training jobs as evaluated against an objective function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving")]
        public System.Int32? BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving { get; set; }
        #endregion
        
        #region Parameter ResourceLimits_MaxParallelTrainingJob
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent training jobs that a hyperparameter tuning job can
        /// launch.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("HyperParameterTuningJobConfig_ResourceLimits_MaxParallelTrainingJobs")]
        public System.Int32? ResourceLimits_MaxParallelTrainingJob { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxPendingTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a training or compilation job can be
        /// pending before it is stopped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_StoppingCondition_MaxPendingTimeInSeconds")]
        public System.Int32? StoppingCondition_MaxPendingTimeInSecond { get; set; }
        #endregion
        
        #region Parameter HyperbandStrategyConfig_MaxResource
        /// <summary>
        /// <para>
        /// <para>The maximum number of resources (such as epochs) that can be used by a training job
        /// launched by a hyperparameter tuning job. Once a job reaches the <c>MaxResource</c>
        /// value, it is stopped. If a value for <c>MaxResource</c> is not provided, and <c>Hyperband</c>
        /// is selected as the hyperparameter tuning strategy, <c>HyperbandTraining</c> attempts
        /// to infer <c>MaxResource</c> from the following keys (if present) in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_HyperParameterTrainingJobDefinition.html#sagemaker-Type-HyperParameterTrainingJobDefinition-StaticHyperParameters">StaticsHyperParameters</a>:</para><ul><li><para><c>epochs</c></para></li><li><para><c>numepochs</c></para></li><li><para><c>n-epochs</c></para></li><li><para><c>n_epochs</c></para></li><li><para><c>num_epochs</c></para></li></ul><para>If <c>HyperbandStrategyConfig</c> is unable to infer a value for <c>MaxResource</c>,
        /// it generates a validation error. The maximum value is 20,000 epochs. All metrics that
        /// correspond to an objective metric are used to derive <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/automatic-model-tuning-early-stopping.html">early
        /// stopping decisions</a>. For <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/distributed-training.html">distributed</a>
        /// training jobs, ensure that duplicate metrics are not printed in the logs across the
        /// individual nodes in a training job. If multiple nodes are publishing duplicate or
        /// incorrect metrics, training jobs may make an incorrect stopping decision and stop
        /// the job prematurely. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_MaxResource")]
        public System.Int32? HyperbandStrategyConfig_MaxResource { get; set; }
        #endregion
        
        #region Parameter ResourceLimits_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds that a hyperparameter tuning job can run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_ResourceLimits_MaxRuntimeInSeconds")]
        public System.Int32? ResourceLimits_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a training or compilation job can run
        /// before it is stopped.</para><para>For compilation jobs, if the job does not complete during this time, a <c>TimeOut</c>
        /// error is generated. We recommend starting with 900 seconds and increasing as necessary
        /// based on your model.</para><para>For all other jobs, if the job does not complete during this time, SageMaker ends
        /// the job. When <c>RetryStrategy</c> is specified in the job request, <c>MaxRuntimeInSeconds</c>
        /// specifies the maximum time for all of the attempts in total, not each individual attempt.
        /// The default value is 1 day. The maximum value is 28 days.</para><para>The maximum time that a <c>TrainingJob</c> can run in total, including any time spent
        /// publishing metrics or archiving and uploading models after it has been stopped, is
        /// 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxWaitTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a managed Spot training job has to complete.
        /// It is the amount of time spent waiting for Spot capacity plus the amount of time the
        /// job can run. It must be equal to or greater than <c>MaxRuntimeInSeconds</c>. If the
        /// job does not complete during this time, SageMaker ends the job.</para><para>When <c>RetryStrategy</c> is specified in the job request, <c>MaxWaitTimeInSeconds</c>
        /// specifies the maximum time for all of the attempts in total, not each individual attempt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_StoppingCondition_MaxWaitTimeInSeconds")]
        public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
        #endregion
        
        #region Parameter AlgorithmSpecification_MetricDefinition
        /// <summary>
        /// <para>
        /// <para>An array of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_MetricDefinition.html">MetricDefinition</a>
        /// objects that specify the metrics that the algorithm emits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_MetricDefinitions")]
        public Amazon.SageMaker.Model.MetricDefinition[] AlgorithmSpecification_MetricDefinition { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobObjective_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric to use for the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_MetricName")]
        public System.String HyperParameterTuningJobObjective_MetricName { get; set; }
        #endregion
        
        #region Parameter TuningObjective_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric to use for the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_TuningObjective_MetricName")]
        public System.String TuningObjective_MetricName { get; set; }
        #endregion
        
        #region Parameter HyperbandStrategyConfig_MinResource
        /// <summary>
        /// <para>
        /// <para>The minimum number of resources (such as epochs) that can be used by a training job
        /// launched by a hyperparameter tuning job. If the value for <c>MinResource</c> has not
        /// been reached, the training job is not stopped by <c>Hyperband</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_MinResource")]
        public System.Int32? HyperbandStrategyConfig_MinResource { get; set; }
        #endregion
        
        #region Parameter Autotune_Mode
        /// <summary>
        /// <para>
        /// <para>Set <c>Mode</c> to <c>Enabled</c> if you want to use Autotune.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AutotuneMode")]
        public Amazon.SageMaker.AutotuneMode Autotune_Mode { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_OutputDataConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the path to the Amazon S3 bucket where you store model artifacts from the
        /// training jobs that the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.OutputDataConfig TrainingJobDefinition_OutputDataConfig { get; set; }
        #endregion
        
        #region Parameter WarmStartConfig_ParentHyperParameterTuningJob
        /// <summary>
        /// <para>
        /// <para>An array of hyperparameter tuning jobs that are used as the starting point for the
        /// new hyperparameter tuning job. For more information about warm starting a hyperparameter
        /// tuning job, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/automatic-model-tuning-warm-start.html">Using
        /// a Previous Hyperparameter Tuning Job as a Starting Point</a>.</para><para>Hyperparameter tuning jobs created before October 1, 2018 cannot be used as parent
        /// jobs for warm start tuning jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WarmStartConfig_ParentHyperParameterTuningJobs")]
        public Amazon.SageMaker.Model.ParentHyperParameterTuningJob[] WarmStartConfig_ParentHyperParameterTuningJob { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobConfig_RandomSeed
        /// <summary>
        /// <para>
        /// <para>A value used to initialize a pseudo-random number generator. Setting a random seed
        /// and using the same seed later for the same tuning job will allow hyperparameter optimization
        /// to find more a consistent hyperparameter configuration between the two runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HyperParameterTuningJobConfig_RandomSeed { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_ResourceConfig
        /// <summary>
        /// <para>
        /// <para>The resources, including the compute instances and storage volumes, to use for the
        /// training jobs that the tuning job launches.</para><para>Storage volumes store model artifacts and incremental states. Training algorithms
        /// might also use storage volumes for scratch space. If you want SageMaker to use the
        /// storage volume to store the training data, choose <c>File</c> as the <c>TrainingInputMode</c>
        /// in the algorithm specification. For distributed training algorithms, specify an instance
        /// count greater than 1.</para><note><para>If you want to use hyperparameter optimization with instance type flexibility, use
        /// <c>HyperParameterTuningResourceConfig</c> instead.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.ResourceConfig TrainingJobDefinition_ResourceConfig { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role associated with the training jobs that
        /// the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingJobDefinition_RoleArn { get; set; }
        #endregion
        
        #region Parameter CheckpointConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>Identifies the S3 path where you want SageMaker to store checkpoints. For example,
        /// <c>s3://bucket-name/key-name-prefix</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_CheckpointConfig_S3Uri")]
        public System.String CheckpointConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_StaticHyperParameter
        /// <summary>
        /// <para>
        /// <para>Specifies the values of hyperparameters that do not change for the tuning job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_StaticHyperParameters")]
        public System.Collections.Hashtable TrainingJobDefinition_StaticHyperParameter { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobConfig_Strategy
        /// <summary>
        /// <para>
        /// <para>Specifies how hyperparameter tuning chooses the combinations of hyperparameter values
        /// to use for the training job it launches. For information about search strategies,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/automatic-model-tuning-how-it-works.html">How
        /// Hyperparameter Tuning Works</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningJobStrategyType")]
        public Amazon.SageMaker.HyperParameterTuningJobStrategyType HyperParameterTuningJobConfig_Strategy { get; set; }
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
        [Alias("TrainingJobDefinition_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para><para>Tags that you specify for the tuning job are also added to all training jobs that
        /// the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TuningJobCompletionCriteria_TargetObjectiveMetricValue
        /// <summary>
        /// <para>
        /// <para>The value of the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_TuningJobCompletionCriteria_TargetObjectiveMetricValue")]
        public System.Single? TuningJobCompletionCriteria_TargetObjectiveMetricValue { get; set; }
        #endregion
        
        #region Parameter AlgorithmSpecification_TrainingImage
        /// <summary>
        /// <para>
        /// <para> The registry path of the Docker image that contains the training algorithm. For information
        /// about Docker registry paths for built-in algorithms, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-algo-docker-registry-paths.html">Algorithms
        /// Provided by Amazon SageMaker: Common Parameters</a>. SageMaker supports both <c>registry/repository[:tag]</c>
        /// and <c>registry/repository[@digest]</c> image path formats. For more information,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/your-algorithms.html">Using
        /// Your Own Algorithms with Amazon SageMaker</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_TrainingImage")]
        public System.String AlgorithmSpecification_TrainingImage { get; set; }
        #endregion
        
        #region Parameter AlgorithmSpecification_TrainingInputMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode")]
        [AWSConstantClassSource("Amazon.SageMaker.TrainingInputMode")]
        public Amazon.SageMaker.TrainingInputMode AlgorithmSpecification_TrainingInputMode { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition
        /// <summary>
        /// <para>
        /// <para>A list of the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_HyperParameterTrainingJobDefinition.html">HyperParameterTrainingJobDefinition</a>
        /// objects launched for this tuning job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinitions")]
        public Amazon.SageMaker.Model.HyperParameterTrainingJobDefinition[] TrainingJobDefinition { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use early stopping for training jobs launched by the hyperparameter
        /// tuning job. Because the <c>Hyperband</c> strategy has its own advanced internal early
        /// stopping mechanism, <c>TrainingJobEarlyStoppingType</c> must be <c>OFF</c> to use
        /// <c>Hyperband</c>. This parameter can take on one of the following values (the default
        /// value is <c>OFF</c>):</para><dl><dt>OFF</dt><dd><para>Training jobs launched by the hyperparameter tuning job do not use early stopping.</para></dd><dt>AUTO</dt><dd><para>SageMaker stops training jobs launched by the hyperparameter tuning job when they
        /// are unlikely to perform better than previously completed training jobs. For more information,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/automatic-model-tuning-early-stopping.html">Stop
        /// Training Jobs Early</a>.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.TrainingJobEarlyStoppingType")]
        public Amazon.SageMaker.TrainingJobEarlyStoppingType HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobObjective_Type
        /// <summary>
        /// <para>
        /// <para>Whether to minimize or maximize the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningJobObjectiveType")]
        public Amazon.SageMaker.HyperParameterTuningJobObjectiveType HyperParameterTuningJobObjective_Type { get; set; }
        #endregion
        
        #region Parameter TuningObjective_Type
        /// <summary>
        /// <para>
        /// <para>Whether to minimize or maximize the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_TuningObjective_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningJobObjectiveType")]
        public Amazon.SageMaker.HyperParameterTuningJobObjectiveType TuningObjective_Type { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningResourceConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>A key used by Amazon Web Services Key Management Service to encrypt data on the storage
        /// volume attached to the compute instances used to run the training job. You can use
        /// either of the following formats to specify a key.</para><para>KMS Key ID:</para><para><c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para><para>Amazon Resource Name (ARN) of a KMS key:</para><para><c>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</c></para><para>Some instances use local storage, which use a <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ssd-instance-store.html">hardware
        /// module to encrypt</a> storage volumes. If you choose one of these instance types,
        /// you cannot request a <c>VolumeKmsKeyId</c>. For a list of instance types that use
        /// local storage, see <a href="http://aws.amazon.com/releasenotes/host-instance-storage-volumes-table/">instance
        /// store volumes</a>. For more information about Amazon Web Services Key Management Service,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sms-security-kms-permissions.html">KMS
        /// encryption</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterTuningResourceConfig_VolumeKmsKeyId")]
        public System.String HyperParameterTuningResourceConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningResourceConfig_VolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The volume size in GB for the storage volume to be used in processing hyperparameter
        /// optimization jobs (optional). These volumes store model artifacts, incremental states
        /// and optionally, scratch space for training algorithms. Do not provide a value for
        /// this parameter if a value for <c>InstanceConfigs</c> is also specified.</para><para>Some instance types have a fixed total local storage size. If you select one of these
        /// instances for training, <c>VolumeSizeInGB</c> cannot be greater than this total size.
        /// For a list of instance types with local instance storage and their sizes, see <a href="http://aws.amazon.com/releasenotes/host-instance-storage-volumes-table/">instance
        /// store volumes</a>.</para><note><para>SageMaker supports only the <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-volume-types.html">General
        /// Purpose SSD (gp2)</a> storage volume type.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingJobDefinition_HyperParameterTuningResourceConfig_VolumeSizeInGB")]
        public System.Int32? HyperParameterTuningResourceConfig_VolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter WarmStartConfig_WarmStartType
        /// <summary>
        /// <para>
        /// <para>Specifies one of the following:</para><dl><dt>IDENTICAL_DATA_AND_ALGORITHM</dt><dd><para>The new hyperparameter tuning job uses the same input data and training image as the
        /// parent tuning jobs. You can change the hyperparameter ranges to search and the maximum
        /// number of training jobs that the hyperparameter tuning job launches. You cannot use
        /// a new version of the training algorithm, unless the changes in the new version do
        /// not affect the algorithm itself. For example, changes that improve logging or adding
        /// support for a different data format are allowed. You can also change hyperparameters
        /// from tunable to static, and from static to tunable, but the total number of static
        /// plus tunable hyperparameters must remain the same as it is in all parent jobs. The
        /// objective metric for the new tuning job must be the same as for all parent jobs.</para></dd><dt>TRANSFER_LEARNING</dt><dd><para>The new hyperparameter tuning job can include input data, hyperparameter ranges, maximum
        /// number of concurrent training jobs, and maximum number of training jobs that are different
        /// than those of its parent hyperparameter tuning jobs. The training image can also be
        /// a different version from the version used in the parent hyperparameter tuning job.
        /// You can also change hyperparameters from tunable to static, and from static to tunable,
        /// but the total number of static plus tunable hyperparameters must remain the same as
        /// it is in all parent jobs. The objective metric for the new tuning job must be the
        /// same as for all parent jobs.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningJobWarmStartType")]
        public Amazon.SageMaker.HyperParameterTuningJobWarmStartType WarmStartConfig_WarmStartType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HyperParameterTuningJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HyperParameterTuningJobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HyperParameterTuningJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMHyperParameterTuningJob (CreateHyperParameterTuningJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse, NewSMHyperParameterTuningJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Autotune_Mode = this.Autotune_Mode;
            context.HyperParameterTuningJobObjective_MetricName = this.HyperParameterTuningJobObjective_MetricName;
            context.HyperParameterTuningJobObjective_Type = this.HyperParameterTuningJobObjective_Type;
            if (this.ParameterRanges_AutoParameter != null)
            {
                context.ParameterRanges_AutoParameter = new List<Amazon.SageMaker.Model.AutoParameter>(this.ParameterRanges_AutoParameter);
            }
            if (this.ParameterRanges_CategoricalParameterRange != null)
            {
                context.ParameterRanges_CategoricalParameterRange = new List<Amazon.SageMaker.Model.CategoricalParameterRange>(this.ParameterRanges_CategoricalParameterRange);
            }
            if (this.ParameterRanges_ContinuousParameterRange != null)
            {
                context.ParameterRanges_ContinuousParameterRange = new List<Amazon.SageMaker.Model.ContinuousParameterRange>(this.ParameterRanges_ContinuousParameterRange);
            }
            if (this.ParameterRanges_IntegerParameterRange != null)
            {
                context.ParameterRanges_IntegerParameterRange = new List<Amazon.SageMaker.Model.IntegerParameterRange>(this.ParameterRanges_IntegerParameterRange);
            }
            context.HyperParameterTuningJobConfig_RandomSeed = this.HyperParameterTuningJobConfig_RandomSeed;
            context.ResourceLimits_MaxNumberOfTrainingJob = this.ResourceLimits_MaxNumberOfTrainingJob;
            context.ResourceLimits_MaxParallelTrainingJob = this.ResourceLimits_MaxParallelTrainingJob;
            #if MODULAR
            if (this.ResourceLimits_MaxParallelTrainingJob == null && ParameterWasBound(nameof(this.ResourceLimits_MaxParallelTrainingJob)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceLimits_MaxParallelTrainingJob which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceLimits_MaxRuntimeInSecond = this.ResourceLimits_MaxRuntimeInSecond;
            context.HyperParameterTuningJobConfig_Strategy = this.HyperParameterTuningJobConfig_Strategy;
            #if MODULAR
            if (this.HyperParameterTuningJobConfig_Strategy == null && ParameterWasBound(nameof(this.HyperParameterTuningJobConfig_Strategy)))
            {
                WriteWarning("You are passing $null as a value for parameter HyperParameterTuningJobConfig_Strategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HyperbandStrategyConfig_MaxResource = this.HyperbandStrategyConfig_MaxResource;
            context.HyperbandStrategyConfig_MinResource = this.HyperbandStrategyConfig_MinResource;
            context.HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType = this.HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType;
            context.BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving = this.BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving;
            context.ConvergenceDetected_CompleteOnConvergence = this.ConvergenceDetected_CompleteOnConvergence;
            context.TuningJobCompletionCriteria_TargetObjectiveMetricValue = this.TuningJobCompletionCriteria_TargetObjectiveMetricValue;
            context.HyperParameterTuningJobName = this.HyperParameterTuningJobName;
            #if MODULAR
            if (this.HyperParameterTuningJobName == null && ParameterWasBound(nameof(this.HyperParameterTuningJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter HyperParameterTuningJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.AlgorithmSpecification_AlgorithmName = this.AlgorithmSpecification_AlgorithmName;
            if (this.AlgorithmSpecification_MetricDefinition != null)
            {
                context.AlgorithmSpecification_MetricDefinition = new List<Amazon.SageMaker.Model.MetricDefinition>(this.AlgorithmSpecification_MetricDefinition);
            }
            context.AlgorithmSpecification_TrainingImage = this.AlgorithmSpecification_TrainingImage;
            context.AlgorithmSpecification_TrainingInputMode = this.AlgorithmSpecification_TrainingInputMode;
            context.CheckpointConfig_LocalPath = this.CheckpointConfig_LocalPath;
            context.CheckpointConfig_S3Uri = this.CheckpointConfig_S3Uri;
            context.TrainingJobDefinition_DefinitionName = this.TrainingJobDefinition_DefinitionName;
            context.TrainingJobDefinition_EnableInterContainerTrafficEncryption = this.TrainingJobDefinition_EnableInterContainerTrafficEncryption;
            context.TrainingJobDefinition_EnableManagedSpotTraining = this.TrainingJobDefinition_EnableManagedSpotTraining;
            context.TrainingJobDefinition_EnableNetworkIsolation = this.TrainingJobDefinition_EnableNetworkIsolation;
            if (this.TrainingJobDefinition_Environment != null)
            {
                context.TrainingJobDefinition_Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TrainingJobDefinition_Environment.Keys)
                {
                    context.TrainingJobDefinition_Environment.Add((String)hashKey, (System.String)(this.TrainingJobDefinition_Environment[hashKey]));
                }
            }
            if (this.HyperParameterRanges_AutoParameter != null)
            {
                context.HyperParameterRanges_AutoParameter = new List<Amazon.SageMaker.Model.AutoParameter>(this.HyperParameterRanges_AutoParameter);
            }
            if (this.HyperParameterRanges_CategoricalParameterRange != null)
            {
                context.HyperParameterRanges_CategoricalParameterRange = new List<Amazon.SageMaker.Model.CategoricalParameterRange>(this.HyperParameterRanges_CategoricalParameterRange);
            }
            if (this.HyperParameterRanges_ContinuousParameterRange != null)
            {
                context.HyperParameterRanges_ContinuousParameterRange = new List<Amazon.SageMaker.Model.ContinuousParameterRange>(this.HyperParameterRanges_ContinuousParameterRange);
            }
            if (this.HyperParameterRanges_IntegerParameterRange != null)
            {
                context.HyperParameterRanges_IntegerParameterRange = new List<Amazon.SageMaker.Model.IntegerParameterRange>(this.HyperParameterRanges_IntegerParameterRange);
            }
            context.HyperParameterTuningResourceConfig_AllocationStrategy = this.HyperParameterTuningResourceConfig_AllocationStrategy;
            if (this.HyperParameterTuningResourceConfig_InstanceConfig != null)
            {
                context.HyperParameterTuningResourceConfig_InstanceConfig = new List<Amazon.SageMaker.Model.HyperParameterTuningInstanceConfig>(this.HyperParameterTuningResourceConfig_InstanceConfig);
            }
            context.HyperParameterTuningResourceConfig_InstanceCount = this.HyperParameterTuningResourceConfig_InstanceCount;
            context.HyperParameterTuningResourceConfig_InstanceType = this.HyperParameterTuningResourceConfig_InstanceType;
            context.HyperParameterTuningResourceConfig_VolumeKmsKeyId = this.HyperParameterTuningResourceConfig_VolumeKmsKeyId;
            context.HyperParameterTuningResourceConfig_VolumeSizeInGB = this.HyperParameterTuningResourceConfig_VolumeSizeInGB;
            if (this.TrainingJobDefinition_InputDataConfig != null)
            {
                context.TrainingJobDefinition_InputDataConfig = new List<Amazon.SageMaker.Model.Channel>(this.TrainingJobDefinition_InputDataConfig);
            }
            context.TrainingJobDefinition_OutputDataConfig = this.TrainingJobDefinition_OutputDataConfig;
            context.TrainingJobDefinition_ResourceConfig = this.TrainingJobDefinition_ResourceConfig;
            context.RetryStrategy_MaximumRetryAttempt = this.RetryStrategy_MaximumRetryAttempt;
            context.TrainingJobDefinition_RoleArn = this.TrainingJobDefinition_RoleArn;
            if (this.TrainingJobDefinition_StaticHyperParameter != null)
            {
                context.TrainingJobDefinition_StaticHyperParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TrainingJobDefinition_StaticHyperParameter.Keys)
                {
                    context.TrainingJobDefinition_StaticHyperParameter.Add((String)hashKey, (System.String)(this.TrainingJobDefinition_StaticHyperParameter[hashKey]));
                }
            }
            context.StoppingCondition_MaxPendingTimeInSecond = this.StoppingCondition_MaxPendingTimeInSecond;
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            context.StoppingCondition_MaxWaitTimeInSecond = this.StoppingCondition_MaxWaitTimeInSecond;
            context.TuningObjective_MetricName = this.TuningObjective_MetricName;
            context.TuningObjective_Type = this.TuningObjective_Type;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            if (this.TrainingJobDefinition != null)
            {
                context.TrainingJobDefinition = new List<Amazon.SageMaker.Model.HyperParameterTrainingJobDefinition>(this.TrainingJobDefinition);
            }
            if (this.WarmStartConfig_ParentHyperParameterTuningJob != null)
            {
                context.WarmStartConfig_ParentHyperParameterTuningJob = new List<Amazon.SageMaker.Model.ParentHyperParameterTuningJob>(this.WarmStartConfig_ParentHyperParameterTuningJob);
            }
            context.WarmStartConfig_WarmStartType = this.WarmStartConfig_WarmStartType;
            
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
            var request = new Amazon.SageMaker.Model.CreateHyperParameterTuningJobRequest();
            
            
             // populate Autotune
            var requestAutotuneIsNull = true;
            request.Autotune = new Amazon.SageMaker.Model.Autotune();
            Amazon.SageMaker.AutotuneMode requestAutotune_autotune_Mode = null;
            if (cmdletContext.Autotune_Mode != null)
            {
                requestAutotune_autotune_Mode = cmdletContext.Autotune_Mode;
            }
            if (requestAutotune_autotune_Mode != null)
            {
                request.Autotune.Mode = requestAutotune_autotune_Mode;
                requestAutotuneIsNull = false;
            }
             // determine if request.Autotune should be set to null
            if (requestAutotuneIsNull)
            {
                request.Autotune = null;
            }
            
             // populate HyperParameterTuningJobConfig
            var requestHyperParameterTuningJobConfigIsNull = true;
            request.HyperParameterTuningJobConfig = new Amazon.SageMaker.Model.HyperParameterTuningJobConfig();
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_RandomSeed = null;
            if (cmdletContext.HyperParameterTuningJobConfig_RandomSeed != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_RandomSeed = cmdletContext.HyperParameterTuningJobConfig_RandomSeed.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_RandomSeed != null)
            {
                request.HyperParameterTuningJobConfig.RandomSeed = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_RandomSeed.Value;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.HyperParameterTuningJobStrategyType requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_Strategy = null;
            if (cmdletContext.HyperParameterTuningJobConfig_Strategy != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_Strategy = cmdletContext.HyperParameterTuningJobConfig_Strategy;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_Strategy != null)
            {
                request.HyperParameterTuningJobConfig.Strategy = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_Strategy;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.TrainingJobEarlyStoppingType requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TrainingJobEarlyStoppingType = null;
            if (cmdletContext.HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TrainingJobEarlyStoppingType = cmdletContext.HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TrainingJobEarlyStoppingType != null)
            {
                request.HyperParameterTuningJobConfig.TrainingJobEarlyStoppingType = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TrainingJobEarlyStoppingType;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.HyperParameterTuningJobStrategyConfig requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig = null;
            
             // populate StrategyConfig
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfigIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig = new Amazon.SageMaker.Model.HyperParameterTuningJobStrategyConfig();
            Amazon.SageMaker.Model.HyperbandStrategyConfig requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig = null;
            
             // populate HyperbandStrategyConfig
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfigIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig = new Amazon.SageMaker.Model.HyperbandStrategyConfig();
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MaxResource = null;
            if (cmdletContext.HyperbandStrategyConfig_MaxResource != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MaxResource = cmdletContext.HyperbandStrategyConfig_MaxResource.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MaxResource != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig.MaxResource = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MaxResource.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfigIsNull = false;
            }
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MinResource = null;
            if (cmdletContext.HyperbandStrategyConfig_MinResource != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MinResource = cmdletContext.HyperbandStrategyConfig_MinResource.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MinResource != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig.MinResource = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig_hyperbandStrategyConfig_MinResource.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfigIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfigIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig.HyperbandStrategyConfig = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig_hyperParameterTuningJobConfig_StrategyConfig_HyperbandStrategyConfig;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfigIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfigIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig != null)
            {
                request.HyperParameterTuningJobConfig.StrategyConfig = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_StrategyConfig;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.HyperParameterTuningJobObjective requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective = null;
            
             // populate HyperParameterTuningJobObjective
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjectiveIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective = new Amazon.SageMaker.Model.HyperParameterTuningJobObjective();
            System.String requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName = null;
            if (cmdletContext.HyperParameterTuningJobObjective_MetricName != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName = cmdletContext.HyperParameterTuningJobObjective_MetricName;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective.MetricName = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjectiveIsNull = false;
            }
            Amazon.SageMaker.HyperParameterTuningJobObjectiveType requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_Type = null;
            if (cmdletContext.HyperParameterTuningJobObjective_Type != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_Type = cmdletContext.HyperParameterTuningJobObjective_Type;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_Type != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective.Type = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_Type;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjectiveIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjectiveIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective != null)
            {
                request.HyperParameterTuningJobConfig.HyperParameterTuningJobObjective = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceLimits requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits = null;
            
             // populate ResourceLimits
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits = new Amazon.SageMaker.Model.ResourceLimits();
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob = null;
            if (cmdletContext.ResourceLimits_MaxNumberOfTrainingJob != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob = cmdletContext.ResourceLimits_MaxNumberOfTrainingJob.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits.MaxNumberOfTrainingJobs = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull = false;
            }
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob = null;
            if (cmdletContext.ResourceLimits_MaxParallelTrainingJob != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob = cmdletContext.ResourceLimits_MaxParallelTrainingJob.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits.MaxParallelTrainingJobs = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull = false;
            }
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxRuntimeInSecond = null;
            if (cmdletContext.ResourceLimits_MaxRuntimeInSecond != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxRuntimeInSecond = cmdletContext.ResourceLimits_MaxRuntimeInSecond.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxRuntimeInSecond != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits.MaxRuntimeInSeconds = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxRuntimeInSecond.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits != null)
            {
                request.HyperParameterTuningJobConfig.ResourceLimits = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TuningJobCompletionCriteria requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria = null;
            
             // populate TuningJobCompletionCriteria
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteriaIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria = new Amazon.SageMaker.Model.TuningJobCompletionCriteria();
            System.Single? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_tuningJobCompletionCriteria_TargetObjectiveMetricValue = null;
            if (cmdletContext.TuningJobCompletionCriteria_TargetObjectiveMetricValue != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_tuningJobCompletionCriteria_TargetObjectiveMetricValue = cmdletContext.TuningJobCompletionCriteria_TargetObjectiveMetricValue.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_tuningJobCompletionCriteria_TargetObjectiveMetricValue != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria.TargetObjectiveMetricValue = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_tuningJobCompletionCriteria_TargetObjectiveMetricValue.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteriaIsNull = false;
            }
            Amazon.SageMaker.Model.BestObjectiveNotImproving requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving = null;
            
             // populate BestObjectiveNotImproving
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImprovingIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving = new Amazon.SageMaker.Model.BestObjectiveNotImproving();
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving_bestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving = null;
            if (cmdletContext.BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving_bestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving = cmdletContext.BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving_bestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving.MaxNumberOfTrainingJobsNotImproving = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving_bestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImprovingIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImprovingIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria.BestObjectiveNotImproving = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_BestObjectiveNotImproving;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteriaIsNull = false;
            }
            Amazon.SageMaker.Model.ConvergenceDetected requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected = null;
            
             // populate ConvergenceDetected
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetectedIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected = new Amazon.SageMaker.Model.ConvergenceDetected();
            Amazon.SageMaker.CompleteOnConvergence requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected_convergenceDetected_CompleteOnConvergence = null;
            if (cmdletContext.ConvergenceDetected_CompleteOnConvergence != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected_convergenceDetected_CompleteOnConvergence = cmdletContext.ConvergenceDetected_CompleteOnConvergence;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected_convergenceDetected_CompleteOnConvergence != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected.CompleteOnConvergence = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected_convergenceDetected_CompleteOnConvergence;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetectedIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetectedIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria.ConvergenceDetected = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_hyperParameterTuningJobConfig_TuningJobCompletionCriteria_ConvergenceDetected;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteriaIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteriaIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria != null)
            {
                request.HyperParameterTuningJobConfig.TuningJobCompletionCriteria = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_TuningJobCompletionCriteria;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ParameterRanges requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges = null;
            
             // populate ParameterRanges
            var requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges = new Amazon.SageMaker.Model.ParameterRanges();
            List<Amazon.SageMaker.Model.AutoParameter> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_AutoParameter = null;
            if (cmdletContext.ParameterRanges_AutoParameter != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_AutoParameter = cmdletContext.ParameterRanges_AutoParameter;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_AutoParameter != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges.AutoParameters = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_AutoParameter;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.CategoricalParameterRange> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange = null;
            if (cmdletContext.ParameterRanges_CategoricalParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange = cmdletContext.ParameterRanges_CategoricalParameterRange;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges.CategoricalParameterRanges = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.ContinuousParameterRange> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange = null;
            if (cmdletContext.ParameterRanges_ContinuousParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange = cmdletContext.ParameterRanges_ContinuousParameterRange;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges.ContinuousParameterRanges = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.IntegerParameterRange> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_IntegerParameterRange = null;
            if (cmdletContext.ParameterRanges_IntegerParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_IntegerParameterRange = cmdletContext.ParameterRanges_IntegerParameterRange;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_IntegerParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges.IntegerParameterRanges = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_IntegerParameterRange;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = false;
            }
             // determine if requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges should be set to null
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges = null;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges != null)
            {
                request.HyperParameterTuningJobConfig.ParameterRanges = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges;
                requestHyperParameterTuningJobConfigIsNull = false;
            }
             // determine if request.HyperParameterTuningJobConfig should be set to null
            if (requestHyperParameterTuningJobConfigIsNull)
            {
                request.HyperParameterTuningJobConfig = null;
            }
            if (cmdletContext.HyperParameterTuningJobName != null)
            {
                request.HyperParameterTuningJobName = cmdletContext.HyperParameterTuningJobName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrainingJobDefinition
            var requestTrainingJobDefinitionIsNull = true;
            request.TrainingJobDefinition = new Amazon.SageMaker.Model.HyperParameterTrainingJobDefinition();
            System.String requestTrainingJobDefinition_trainingJobDefinition_DefinitionName = null;
            if (cmdletContext.TrainingJobDefinition_DefinitionName != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_DefinitionName = cmdletContext.TrainingJobDefinition_DefinitionName;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_DefinitionName != null)
            {
                request.TrainingJobDefinition.DefinitionName = requestTrainingJobDefinition_trainingJobDefinition_DefinitionName;
                requestTrainingJobDefinitionIsNull = false;
            }
            System.Boolean? requestTrainingJobDefinition_trainingJobDefinition_EnableInterContainerTrafficEncryption = null;
            if (cmdletContext.TrainingJobDefinition_EnableInterContainerTrafficEncryption != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_EnableInterContainerTrafficEncryption = cmdletContext.TrainingJobDefinition_EnableInterContainerTrafficEncryption.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_EnableInterContainerTrafficEncryption != null)
            {
                request.TrainingJobDefinition.EnableInterContainerTrafficEncryption = requestTrainingJobDefinition_trainingJobDefinition_EnableInterContainerTrafficEncryption.Value;
                requestTrainingJobDefinitionIsNull = false;
            }
            System.Boolean? requestTrainingJobDefinition_trainingJobDefinition_EnableManagedSpotTraining = null;
            if (cmdletContext.TrainingJobDefinition_EnableManagedSpotTraining != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_EnableManagedSpotTraining = cmdletContext.TrainingJobDefinition_EnableManagedSpotTraining.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_EnableManagedSpotTraining != null)
            {
                request.TrainingJobDefinition.EnableManagedSpotTraining = requestTrainingJobDefinition_trainingJobDefinition_EnableManagedSpotTraining.Value;
                requestTrainingJobDefinitionIsNull = false;
            }
            System.Boolean? requestTrainingJobDefinition_trainingJobDefinition_EnableNetworkIsolation = null;
            if (cmdletContext.TrainingJobDefinition_EnableNetworkIsolation != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_EnableNetworkIsolation = cmdletContext.TrainingJobDefinition_EnableNetworkIsolation.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_EnableNetworkIsolation != null)
            {
                request.TrainingJobDefinition.EnableNetworkIsolation = requestTrainingJobDefinition_trainingJobDefinition_EnableNetworkIsolation.Value;
                requestTrainingJobDefinitionIsNull = false;
            }
            Dictionary<System.String, System.String> requestTrainingJobDefinition_trainingJobDefinition_Environment = null;
            if (cmdletContext.TrainingJobDefinition_Environment != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_Environment = cmdletContext.TrainingJobDefinition_Environment;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_Environment != null)
            {
                request.TrainingJobDefinition.Environment = requestTrainingJobDefinition_trainingJobDefinition_Environment;
                requestTrainingJobDefinitionIsNull = false;
            }
            List<Amazon.SageMaker.Model.Channel> requestTrainingJobDefinition_trainingJobDefinition_InputDataConfig = null;
            if (cmdletContext.TrainingJobDefinition_InputDataConfig != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_InputDataConfig = cmdletContext.TrainingJobDefinition_InputDataConfig;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_InputDataConfig != null)
            {
                request.TrainingJobDefinition.InputDataConfig = requestTrainingJobDefinition_trainingJobDefinition_InputDataConfig;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.OutputDataConfig requestTrainingJobDefinition_trainingJobDefinition_OutputDataConfig = null;
            if (cmdletContext.TrainingJobDefinition_OutputDataConfig != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_OutputDataConfig = cmdletContext.TrainingJobDefinition_OutputDataConfig;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_OutputDataConfig != null)
            {
                request.TrainingJobDefinition.OutputDataConfig = requestTrainingJobDefinition_trainingJobDefinition_OutputDataConfig;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceConfig requestTrainingJobDefinition_trainingJobDefinition_ResourceConfig = null;
            if (cmdletContext.TrainingJobDefinition_ResourceConfig != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_ResourceConfig = cmdletContext.TrainingJobDefinition_ResourceConfig;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_ResourceConfig != null)
            {
                request.TrainingJobDefinition.ResourceConfig = requestTrainingJobDefinition_trainingJobDefinition_ResourceConfig;
                requestTrainingJobDefinitionIsNull = false;
            }
            System.String requestTrainingJobDefinition_trainingJobDefinition_RoleArn = null;
            if (cmdletContext.TrainingJobDefinition_RoleArn != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_RoleArn = cmdletContext.TrainingJobDefinition_RoleArn;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_RoleArn != null)
            {
                request.TrainingJobDefinition.RoleArn = requestTrainingJobDefinition_trainingJobDefinition_RoleArn;
                requestTrainingJobDefinitionIsNull = false;
            }
            Dictionary<System.String, System.String> requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter = null;
            if (cmdletContext.TrainingJobDefinition_StaticHyperParameter != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter = cmdletContext.TrainingJobDefinition_StaticHyperParameter;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter != null)
            {
                request.TrainingJobDefinition.StaticHyperParameters = requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.RetryStrategy requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy = null;
            
             // populate RetryStrategy
            var requestTrainingJobDefinition_trainingJobDefinition_RetryStrategyIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy = new Amazon.SageMaker.Model.RetryStrategy();
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy_retryStrategy_MaximumRetryAttempt = null;
            if (cmdletContext.RetryStrategy_MaximumRetryAttempt != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy_retryStrategy_MaximumRetryAttempt = cmdletContext.RetryStrategy_MaximumRetryAttempt.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy_retryStrategy_MaximumRetryAttempt != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy.MaximumRetryAttempts = requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy_retryStrategy_MaximumRetryAttempt.Value;
                requestTrainingJobDefinition_trainingJobDefinition_RetryStrategyIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_RetryStrategyIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy != null)
            {
                request.TrainingJobDefinition.RetryStrategy = requestTrainingJobDefinition_trainingJobDefinition_RetryStrategy;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.CheckpointConfig requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig = null;
            
             // populate CheckpointConfig
            var requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfigIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig = new Amazon.SageMaker.Model.CheckpointConfig();
            System.String requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_LocalPath = null;
            if (cmdletContext.CheckpointConfig_LocalPath != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_LocalPath = cmdletContext.CheckpointConfig_LocalPath;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_LocalPath != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig.LocalPath = requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_LocalPath;
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfigIsNull = false;
            }
            System.String requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_S3Uri = null;
            if (cmdletContext.CheckpointConfig_S3Uri != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_S3Uri = cmdletContext.CheckpointConfig_S3Uri;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_S3Uri != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig.S3Uri = requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig_checkpointConfig_S3Uri;
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfigIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfigIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig != null)
            {
                request.TrainingJobDefinition.CheckpointConfig = requestTrainingJobDefinition_trainingJobDefinition_CheckpointConfig;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.HyperParameterTuningJobObjective requestTrainingJobDefinition_trainingJobDefinition_TuningObjective = null;
            
             // populate TuningObjective
            var requestTrainingJobDefinition_trainingJobDefinition_TuningObjectiveIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_TuningObjective = new Amazon.SageMaker.Model.HyperParameterTuningJobObjective();
            System.String requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_MetricName = null;
            if (cmdletContext.TuningObjective_MetricName != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_MetricName = cmdletContext.TuningObjective_MetricName;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_MetricName != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjective.MetricName = requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_MetricName;
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjectiveIsNull = false;
            }
            Amazon.SageMaker.HyperParameterTuningJobObjectiveType requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_Type = null;
            if (cmdletContext.TuningObjective_Type != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_Type = cmdletContext.TuningObjective_Type;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_Type != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjective.Type = requestTrainingJobDefinition_trainingJobDefinition_TuningObjective_tuningObjective_Type;
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjectiveIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_TuningObjective should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_TuningObjectiveIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_TuningObjective = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_TuningObjective != null)
            {
                request.TrainingJobDefinition.TuningObjective = requestTrainingJobDefinition_trainingJobDefinition_TuningObjective;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.VpcConfig requestTrainingJobDefinition_trainingJobDefinition_VpcConfig = null;
            
             // populate VpcConfig
            var requestTrainingJobDefinition_trainingJobDefinition_VpcConfigIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig.SecurityGroupIds = requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId;
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfigIsNull = false;
            }
            List<System.String> requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_Subnet != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig.Subnets = requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_Subnet;
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfigIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_VpcConfig should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_VpcConfigIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_VpcConfig != null)
            {
                request.TrainingJobDefinition.VpcConfig = requestTrainingJobDefinition_trainingJobDefinition_VpcConfig;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.StoppingCondition requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition = null;
            
             // populate StoppingCondition
            var requestTrainingJobDefinition_trainingJobDefinition_StoppingConditionIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition = new Amazon.SageMaker.Model.StoppingCondition();
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxPendingTimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxPendingTimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxPendingTimeInSecond = cmdletContext.StoppingCondition_MaxPendingTimeInSecond.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxPendingTimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition.MaxPendingTimeInSeconds = requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxPendingTimeInSecond.Value;
                requestTrainingJobDefinition_trainingJobDefinition_StoppingConditionIsNull = false;
            }
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxRuntimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.StoppingCondition_MaxRuntimeInSecond.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition.MaxRuntimeInSeconds = requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond.Value;
                requestTrainingJobDefinition_trainingJobDefinition_StoppingConditionIsNull = false;
            }
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxWaitTimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxWaitTimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxWaitTimeInSecond = cmdletContext.StoppingCondition_MaxWaitTimeInSecond.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxWaitTimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition.MaxWaitTimeInSeconds = requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxWaitTimeInSecond.Value;
                requestTrainingJobDefinition_trainingJobDefinition_StoppingConditionIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_StoppingConditionIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition != null)
            {
                request.TrainingJobDefinition.StoppingCondition = requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.HyperParameterAlgorithmSpecification requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification = null;
            
             // populate AlgorithmSpecification
            var requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification = new Amazon.SageMaker.Model.HyperParameterAlgorithmSpecification();
            System.String requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_AlgorithmName = null;
            if (cmdletContext.AlgorithmSpecification_AlgorithmName != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_AlgorithmName = cmdletContext.AlgorithmSpecification_AlgorithmName;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_AlgorithmName != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification.AlgorithmName = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_AlgorithmName;
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = false;
            }
            List<Amazon.SageMaker.Model.MetricDefinition> requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition = null;
            if (cmdletContext.AlgorithmSpecification_MetricDefinition != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition = cmdletContext.AlgorithmSpecification_MetricDefinition;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification.MetricDefinitions = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition;
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = false;
            }
            System.String requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage = null;
            if (cmdletContext.AlgorithmSpecification_TrainingImage != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage = cmdletContext.AlgorithmSpecification_TrainingImage;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification.TrainingImage = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage;
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = false;
            }
            Amazon.SageMaker.TrainingInputMode requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingInputMode = null;
            if (cmdletContext.AlgorithmSpecification_TrainingInputMode != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingInputMode = cmdletContext.AlgorithmSpecification_TrainingInputMode;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingInputMode != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification.TrainingInputMode = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingInputMode;
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification != null)
            {
                request.TrainingJobDefinition.AlgorithmSpecification = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.ParameterRanges requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges = null;
            
             // populate HyperParameterRanges
            var requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRangesIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges = new Amazon.SageMaker.Model.ParameterRanges();
            List<Amazon.SageMaker.Model.AutoParameter> requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_AutoParameter = null;
            if (cmdletContext.HyperParameterRanges_AutoParameter != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_AutoParameter = cmdletContext.HyperParameterRanges_AutoParameter;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_AutoParameter != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges.AutoParameters = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_AutoParameter;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.CategoricalParameterRange> requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_CategoricalParameterRange = null;
            if (cmdletContext.HyperParameterRanges_CategoricalParameterRange != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_CategoricalParameterRange = cmdletContext.HyperParameterRanges_CategoricalParameterRange;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_CategoricalParameterRange != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges.CategoricalParameterRanges = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_CategoricalParameterRange;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.ContinuousParameterRange> requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_ContinuousParameterRange = null;
            if (cmdletContext.HyperParameterRanges_ContinuousParameterRange != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_ContinuousParameterRange = cmdletContext.HyperParameterRanges_ContinuousParameterRange;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_ContinuousParameterRange != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges.ContinuousParameterRanges = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_ContinuousParameterRange;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.IntegerParameterRange> requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_IntegerParameterRange = null;
            if (cmdletContext.HyperParameterRanges_IntegerParameterRange != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_IntegerParameterRange = cmdletContext.HyperParameterRanges_IntegerParameterRange;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_IntegerParameterRange != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges.IntegerParameterRanges = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges_hyperParameterRanges_IntegerParameterRange;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRangesIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRangesIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges != null)
            {
                request.TrainingJobDefinition.HyperParameterRanges = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterRanges;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.HyperParameterTuningResourceConfig requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig = null;
            
             // populate HyperParameterTuningResourceConfig
            var requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig = new Amazon.SageMaker.Model.HyperParameterTuningResourceConfig();
            Amazon.SageMaker.HyperParameterTuningAllocationStrategy requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_AllocationStrategy = null;
            if (cmdletContext.HyperParameterTuningResourceConfig_AllocationStrategy != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_AllocationStrategy = cmdletContext.HyperParameterTuningResourceConfig_AllocationStrategy;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_AllocationStrategy != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig.AllocationStrategy = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_AllocationStrategy;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.HyperParameterTuningInstanceConfig> requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceConfig = null;
            if (cmdletContext.HyperParameterTuningResourceConfig_InstanceConfig != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceConfig = cmdletContext.HyperParameterTuningResourceConfig_InstanceConfig;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceConfig != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig.InstanceConfigs = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceConfig;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = false;
            }
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceCount = null;
            if (cmdletContext.HyperParameterTuningResourceConfig_InstanceCount != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceCount = cmdletContext.HyperParameterTuningResourceConfig_InstanceCount.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceCount != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig.InstanceCount = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceCount.Value;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = false;
            }
            Amazon.SageMaker.TrainingInstanceType requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceType = null;
            if (cmdletContext.HyperParameterTuningResourceConfig_InstanceType != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceType = cmdletContext.HyperParameterTuningResourceConfig_InstanceType;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceType != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig.InstanceType = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_InstanceType;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = false;
            }
            System.String requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeKmsKeyId = null;
            if (cmdletContext.HyperParameterTuningResourceConfig_VolumeKmsKeyId != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeKmsKeyId = cmdletContext.HyperParameterTuningResourceConfig_VolumeKmsKeyId;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeKmsKeyId != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig.VolumeKmsKeyId = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeKmsKeyId;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = false;
            }
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeSizeInGB = null;
            if (cmdletContext.HyperParameterTuningResourceConfig_VolumeSizeInGB != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeSizeInGB = cmdletContext.HyperParameterTuningResourceConfig_VolumeSizeInGB.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeSizeInGB != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig.VolumeSizeInGB = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig_hyperParameterTuningResourceConfig_VolumeSizeInGB.Value;
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull = false;
            }
             // determine if requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig should be set to null
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfigIsNull)
            {
                requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig = null;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig != null)
            {
                request.TrainingJobDefinition.HyperParameterTuningResourceConfig = requestTrainingJobDefinition_trainingJobDefinition_HyperParameterTuningResourceConfig;
                requestTrainingJobDefinitionIsNull = false;
            }
             // determine if request.TrainingJobDefinition should be set to null
            if (requestTrainingJobDefinitionIsNull)
            {
                request.TrainingJobDefinition = null;
            }
            if (cmdletContext.TrainingJobDefinition != null)
            {
                request.TrainingJobDefinitions = cmdletContext.TrainingJobDefinition;
            }
            
             // populate WarmStartConfig
            var requestWarmStartConfigIsNull = true;
            request.WarmStartConfig = new Amazon.SageMaker.Model.HyperParameterTuningJobWarmStartConfig();
            List<Amazon.SageMaker.Model.ParentHyperParameterTuningJob> requestWarmStartConfig_warmStartConfig_ParentHyperParameterTuningJob = null;
            if (cmdletContext.WarmStartConfig_ParentHyperParameterTuningJob != null)
            {
                requestWarmStartConfig_warmStartConfig_ParentHyperParameterTuningJob = cmdletContext.WarmStartConfig_ParentHyperParameterTuningJob;
            }
            if (requestWarmStartConfig_warmStartConfig_ParentHyperParameterTuningJob != null)
            {
                request.WarmStartConfig.ParentHyperParameterTuningJobs = requestWarmStartConfig_warmStartConfig_ParentHyperParameterTuningJob;
                requestWarmStartConfigIsNull = false;
            }
            Amazon.SageMaker.HyperParameterTuningJobWarmStartType requestWarmStartConfig_warmStartConfig_WarmStartType = null;
            if (cmdletContext.WarmStartConfig_WarmStartType != null)
            {
                requestWarmStartConfig_warmStartConfig_WarmStartType = cmdletContext.WarmStartConfig_WarmStartType;
            }
            if (requestWarmStartConfig_warmStartConfig_WarmStartType != null)
            {
                request.WarmStartConfig.WarmStartType = requestWarmStartConfig_warmStartConfig_WarmStartType;
                requestWarmStartConfigIsNull = false;
            }
             // determine if request.WarmStartConfig should be set to null
            if (requestWarmStartConfigIsNull)
            {
                request.WarmStartConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateHyperParameterTuningJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateHyperParameterTuningJob");
            try
            {
                #if DESKTOP
                return client.CreateHyperParameterTuningJob(request);
                #elif CORECLR
                return client.CreateHyperParameterTuningJobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.AutotuneMode Autotune_Mode { get; set; }
            public System.String HyperParameterTuningJobObjective_MetricName { get; set; }
            public Amazon.SageMaker.HyperParameterTuningJobObjectiveType HyperParameterTuningJobObjective_Type { get; set; }
            public List<Amazon.SageMaker.Model.AutoParameter> ParameterRanges_AutoParameter { get; set; }
            public List<Amazon.SageMaker.Model.CategoricalParameterRange> ParameterRanges_CategoricalParameterRange { get; set; }
            public List<Amazon.SageMaker.Model.ContinuousParameterRange> ParameterRanges_ContinuousParameterRange { get; set; }
            public List<Amazon.SageMaker.Model.IntegerParameterRange> ParameterRanges_IntegerParameterRange { get; set; }
            public System.Int32? HyperParameterTuningJobConfig_RandomSeed { get; set; }
            public System.Int32? ResourceLimits_MaxNumberOfTrainingJob { get; set; }
            public System.Int32? ResourceLimits_MaxParallelTrainingJob { get; set; }
            public System.Int32? ResourceLimits_MaxRuntimeInSecond { get; set; }
            public Amazon.SageMaker.HyperParameterTuningJobStrategyType HyperParameterTuningJobConfig_Strategy { get; set; }
            public System.Int32? HyperbandStrategyConfig_MaxResource { get; set; }
            public System.Int32? HyperbandStrategyConfig_MinResource { get; set; }
            public Amazon.SageMaker.TrainingJobEarlyStoppingType HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType { get; set; }
            public System.Int32? BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving { get; set; }
            public Amazon.SageMaker.CompleteOnConvergence ConvergenceDetected_CompleteOnConvergence { get; set; }
            public System.Single? TuningJobCompletionCriteria_TargetObjectiveMetricValue { get; set; }
            public System.String HyperParameterTuningJobName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String AlgorithmSpecification_AlgorithmName { get; set; }
            public List<Amazon.SageMaker.Model.MetricDefinition> AlgorithmSpecification_MetricDefinition { get; set; }
            public System.String AlgorithmSpecification_TrainingImage { get; set; }
            public Amazon.SageMaker.TrainingInputMode AlgorithmSpecification_TrainingInputMode { get; set; }
            public System.String CheckpointConfig_LocalPath { get; set; }
            public System.String CheckpointConfig_S3Uri { get; set; }
            public System.String TrainingJobDefinition_DefinitionName { get; set; }
            public System.Boolean? TrainingJobDefinition_EnableInterContainerTrafficEncryption { get; set; }
            public System.Boolean? TrainingJobDefinition_EnableManagedSpotTraining { get; set; }
            public System.Boolean? TrainingJobDefinition_EnableNetworkIsolation { get; set; }
            public Dictionary<System.String, System.String> TrainingJobDefinition_Environment { get; set; }
            public List<Amazon.SageMaker.Model.AutoParameter> HyperParameterRanges_AutoParameter { get; set; }
            public List<Amazon.SageMaker.Model.CategoricalParameterRange> HyperParameterRanges_CategoricalParameterRange { get; set; }
            public List<Amazon.SageMaker.Model.ContinuousParameterRange> HyperParameterRanges_ContinuousParameterRange { get; set; }
            public List<Amazon.SageMaker.Model.IntegerParameterRange> HyperParameterRanges_IntegerParameterRange { get; set; }
            public Amazon.SageMaker.HyperParameterTuningAllocationStrategy HyperParameterTuningResourceConfig_AllocationStrategy { get; set; }
            public List<Amazon.SageMaker.Model.HyperParameterTuningInstanceConfig> HyperParameterTuningResourceConfig_InstanceConfig { get; set; }
            public System.Int32? HyperParameterTuningResourceConfig_InstanceCount { get; set; }
            public Amazon.SageMaker.TrainingInstanceType HyperParameterTuningResourceConfig_InstanceType { get; set; }
            public System.String HyperParameterTuningResourceConfig_VolumeKmsKeyId { get; set; }
            public System.Int32? HyperParameterTuningResourceConfig_VolumeSizeInGB { get; set; }
            public List<Amazon.SageMaker.Model.Channel> TrainingJobDefinition_InputDataConfig { get; set; }
            public Amazon.SageMaker.Model.OutputDataConfig TrainingJobDefinition_OutputDataConfig { get; set; }
            public Amazon.SageMaker.Model.ResourceConfig TrainingJobDefinition_ResourceConfig { get; set; }
            public System.Int32? RetryStrategy_MaximumRetryAttempt { get; set; }
            public System.String TrainingJobDefinition_RoleArn { get; set; }
            public Dictionary<System.String, System.String> TrainingJobDefinition_StaticHyperParameter { get; set; }
            public System.Int32? StoppingCondition_MaxPendingTimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
            public System.String TuningObjective_MetricName { get; set; }
            public Amazon.SageMaker.HyperParameterTuningJobObjectiveType TuningObjective_Type { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public List<Amazon.SageMaker.Model.HyperParameterTrainingJobDefinition> TrainingJobDefinition { get; set; }
            public List<Amazon.SageMaker.Model.ParentHyperParameterTuningJob> WarmStartConfig_ParentHyperParameterTuningJob { get; set; }
            public Amazon.SageMaker.HyperParameterTuningJobWarmStartType WarmStartConfig_WarmStartType { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse, NewSMHyperParameterTuningJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HyperParameterTuningJobArn;
        }
        
    }
}
