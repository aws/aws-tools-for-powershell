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
    /// Starts a model training job. After training completes, SageMaker saves the resulting
    /// model artifacts to an Amazon S3 location that you specify. 
    /// 
    ///  
    /// <para>
    /// If you choose to host your model using SageMaker hosting services, you can use the
    /// resulting model artifacts as part of the model. You can also use the artifacts in
    /// a machine learning service other than SageMaker, provided that you know how to use
    /// them for inference. 
    /// </para><para>
    /// In the request body, you provide the following: 
    /// </para><ul><li><para><code>AlgorithmSpecification</code> - Identifies the training algorithm to use. 
    /// </para></li><li><para><code>HyperParameters</code> - Specify these algorithm-specific parameters to enable
    /// the estimation of model parameters during training. Hyperparameters can be tuned to
    /// optimize this learning process. For a list of hyperparameters for each training algorithm
    /// provided by SageMaker, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
    /// 
    /// </para><important><para>
    /// Do not include any security-sensitive information including account access IDs, secrets
    /// or tokens in any hyperparameter field. If the use of security-sensitive credentials
    /// are detected, SageMaker will reject your training job request and return an exception
    /// error.
    /// </para></important></li><li><para><code>InputDataConfig</code> - Describes the input required by the training job and
    /// the Amazon S3, EFS, or FSx location where it is stored.
    /// </para></li><li><para><code>OutputDataConfig</code> - Identifies the Amazon S3 bucket where you want SageMaker
    /// to save the results of model training. 
    /// </para></li><li><para><code>ResourceConfig</code> - Identifies the resources, ML compute instances, and
    /// ML storage volumes to deploy for model training. In distributed training, you specify
    /// more than one instance. 
    /// </para></li><li><para><code>EnableManagedSpotTraining</code> - Optimize the cost of training machine learning
    /// models by up to 80% by using Amazon EC2 Spot instances. For more information, see
    /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-managed-spot-training.html">Managed
    /// Spot Training</a>. 
    /// </para></li><li><para><code>RoleArn</code> - The Amazon Resource Name (ARN) that SageMaker assumes to perform
    /// tasks on your behalf during model training. You must grant this role the necessary
    /// permissions so that SageMaker can successfully complete model training. 
    /// </para></li><li><para><code>StoppingCondition</code> - To help cap training costs, use <code>MaxRuntimeInSeconds</code>
    /// to set a time limit for training. Use <code>MaxWaitTimeInSeconds</code> to specify
    /// how long a managed spot training job has to complete. 
    /// </para></li><li><para><code>Environment</code> - The environment variables to set in the Docker container.
    /// </para></li><li><para><code>RetryStrategy</code> - The number of times to retry the job when the job fails
    /// due to an <code>InternalServerError</code>.
    /// </para></li></ul><para>
    ///  For more information about SageMaker, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/how-it-works.html">How
    /// It Works</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMTrainingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTrainingJob API operation.", Operation = new[] {"CreateTrainingJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateTrainingJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateTrainingJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTrainingJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMTrainingJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AlgorithmSpecification
        /// <summary>
        /// <para>
        /// <para>The registry path of the Docker image that contains the training algorithm and algorithm-specific
        /// metadata, including the input mode. For more information about algorithms provided
        /// by SageMaker, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
        /// For information about providing your own algorithms, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/your-algorithms.html">Using
        /// Your Own Algorithms with Amazon SageMaker</a>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.SageMaker.Model.AlgorithmSpecification AlgorithmSpecification { get; set; }
        #endregion
        
        #region Parameter DebugHookConfig_CollectionConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information for Amazon SageMaker Debugger tensor collections. To learn
        /// more about how to configure the <code>CollectionConfiguration</code> parameter, see
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/debugger-createtrainingjob-api.html">Use
        /// the SageMaker and Debugger Configuration API Operations to Create, Update, and Debug
        /// Your Training Job</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DebugHookConfig_CollectionConfigurations")]
        public Amazon.SageMaker.Model.CollectionConfiguration[] DebugHookConfig_CollectionConfiguration { get; set; }
        #endregion
        
        #region Parameter DebugRuleConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information for Amazon SageMaker Debugger rules for debugging output
        /// tensors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DebugRuleConfigurations")]
        public Amazon.SageMaker.Model.DebugRuleConfiguration[] DebugRuleConfiguration { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_DisableProfiler
        /// <summary>
        /// <para>
        /// <para>Configuration to turn off Amazon SageMaker Debugger's system monitoring and profiling
        /// functionality. To turn it off, set to <code>True</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProfilerConfig_DisableProfiler { get; set; }
        #endregion
        
        #region Parameter EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>To encrypt all communications between ML compute instances in distributed training,
        /// choose <code>True</code>. Encryption provides greater security for distributed training,
        /// but training might take longer. How long it takes depends on the amount of communication
        /// between compute instances, especially if you use a deep learning algorithm in distributed
        /// training. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/train-encrypt.html">Protect
        /// Communications Between ML Compute Instances in a Distributed Training Job</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter EnableManagedSpotTraining
        /// <summary>
        /// <para>
        /// <para>To train models using managed spot training, choose <code>True</code>. Managed spot
        /// training provides a fully managed and scalable infrastructure for training machine
        /// learning models. this option is useful when training jobs can be interrupted and when
        /// there is flexibility when the training job is run. </para><para>The complete and intermediate results of jobs are stored in an Amazon S3 bucket, and
        /// can be used as a starting point to train models incrementally. Amazon SageMaker provides
        /// metrics and logs in CloudWatch. They can be used to see when managed spot training
        /// jobs are running, interrupted, resumed, or completed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableManagedSpotTraining { get; set; }
        #endregion
        
        #region Parameter EnableNetworkIsolation
        /// <summary>
        /// <para>
        /// <para>Isolates the training container. No inbound or outbound network calls can be made,
        /// except for calls between peers within a training cluster for distributed training.
        /// If you enable network isolation for training jobs that are configured to use a VPC,
        /// SageMaker downloads and uploads customer data and model artifacts through the specified
        /// VPC, but the training container does not have network access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableNetworkIsolation { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container.</para>
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
        
        #region Parameter DebugHookConfig_HookParameter
        /// <summary>
        /// <para>
        /// <para>Configuration information for the Amazon SageMaker Debugger hook parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DebugHookConfig_HookParameters")]
        public System.Collections.Hashtable DebugHookConfig_HookParameter { get; set; }
        #endregion
        
        #region Parameter HyperParameter
        /// <summary>
        /// <para>
        /// <para>Algorithm-specific parameters that influence the quality of the model. You set hyperparameters
        /// before you start the learning process. For a list of hyperparameters for each training
        /// algorithm provided by SageMaker, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
        /// </para><para>You can specify a maximum of 100 hyperparameters. Each hyperparameter is a key-value
        /// pair. Each key and value is limited to 256 characters, as specified by the <code>Length
        /// Constraint</code>. </para><important><para>Do not include any security-sensitive information including account access IDs, secrets
        /// or tokens in any hyperparameter field. If the use of security-sensitive credentials
        /// are detected, SageMaker will reject your training job request and return an exception
        /// error.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameters")]
        public System.Collections.Hashtable HyperParameter { get; set; }
        #endregion
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of <code>Channel</code> objects. Each channel is a named input source. <code>InputDataConfig</code>
        /// describes the input data and its location. </para><para>Algorithms can accept input data from one or more channels. For example, an algorithm
        /// might have two channels of input data, <code>training_data</code> and <code>validation_data</code>.
        /// The configuration for each channel provides the S3, EFS, or FSx location where the
        /// input data is stored. It also provides information about the stored data: the MIME
        /// type, compression method, and whether the data is wrapped in RecordIO format. </para><para>Depending on the input mode that the algorithm supports, SageMaker either copies input
        /// data files from an S3 bucket to a local directory in the Docker container, or makes
        /// it available as input streams. For example, if you specify an EFS location, input
        /// data files are available as input streams. They do not need to be downloaded.</para><para>Your input must be in the same Amazon Web Services region as your training job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.Channel[] InputDataConfig { get; set; }
        #endregion
        
        #region Parameter CheckpointConfig_LocalPath
        /// <summary>
        /// <para>
        /// <para>(Optional) The local directory where checkpoints are written. The default directory
        /// is <code>/opt/ml/checkpoints/</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckpointConfig_LocalPath { get; set; }
        #endregion
        
        #region Parameter DebugHookConfig_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to local storage location for metrics and tensors. Defaults to <code>/opt/ml/output/tensors/</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DebugHookConfig_LocalPath { get; set; }
        #endregion
        
        #region Parameter TensorBoardOutputConfig_LocalPath
        /// <summary>
        /// <para>
        /// <para>Path to local storage location for tensorBoard output. Defaults to <code>/opt/ml/output/tensorboard</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TensorBoardOutputConfig_LocalPath { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>The number of times to retry the job. When the job is retried, it's <code>SecondaryStatus</code>
        /// is changed to <code>STARTING</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryStrategy_MaximumRetryAttempts")]
        public System.Int32? RetryStrategy_MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a training or compilation job can run
        /// before it is stopped.</para><para>For compilation jobs, if the job does not complete during this time, a <code>TimeOut</code>
        /// error is generated. We recommend starting with 900 seconds and increasing as necessary
        /// based on your model.</para><para>For all other jobs, if the job does not complete during this time, SageMaker ends
        /// the job. When <code>RetryStrategy</code> is specified in the job request, <code>MaxRuntimeInSeconds</code>
        /// specifies the maximum time for all of the attempts in total, not each individual attempt.
        /// The default value is 1 day. The maximum value is 28 days.</para><para>The maximum time that a <code>TrainingJob</code> can run in total, including any time
        /// spent publishing metrics or archiving and uploading models after it has been stopped,
        /// is 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxWaitTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a managed Spot training job has to complete.
        /// It is the amount of time spent waiting for Spot capacity plus the amount of time the
        /// job can run. It must be equal to or greater than <code>MaxRuntimeInSeconds</code>.
        /// If the job does not complete during this time, SageMaker ends the job.</para><para>When <code>RetryStrategy</code> is specified in the job request, <code>MaxWaitTimeInSeconds</code>
        /// specifies the maximum time for all of the attempts in total, not each individual attempt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxWaitTimeInSeconds")]
        public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the path to the S3 location where you want to store model artifacts. SageMaker
        /// creates subfolders for the artifacts. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.SageMaker.Model.OutputDataConfig OutputDataConfig { get; set; }
        #endregion
        
        #region Parameter ProfilerRuleConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information for Amazon SageMaker Debugger rules for profiling system
        /// and framework metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfilerRuleConfigurations")]
        public Amazon.SageMaker.Model.ProfilerRuleConfiguration[] ProfilerRuleConfiguration { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_ProfilingIntervalInMillisecond
        /// <summary>
        /// <para>
        /// <para>A time interval for capturing system metrics in milliseconds. Available values are
        /// 100, 200, 500, 1000 (1 second), 5000 (5 seconds), and 60000 (1 minute) milliseconds.
        /// The default value is 500 milliseconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfilerConfig_ProfilingIntervalInMilliseconds")]
        public System.Int64? ProfilerConfig_ProfilingIntervalInMillisecond { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_ProfilingParameter
        /// <summary>
        /// <para>
        /// <para>Configuration information for capturing framework metrics. Available key strings for
        /// different profiling options are <code>DetailedProfilingConfig</code>, <code>PythonProfilingConfig</code>,
        /// and <code>DataLoaderProfilingConfig</code>. The following codes are configuration
        /// structures for the <code>ProfilingParameters</code> parameter. To learn more about
        /// how to configure the <code>ProfilingParameters</code> parameter, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/debugger-createtrainingjob-api.html">Use
        /// the SageMaker and Debugger Configuration API Operations to Create, Update, and Debug
        /// Your Training Job</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfilerConfig_ProfilingParameters")]
        public System.Collections.Hashtable ProfilerConfig_ProfilingParameter { get; set; }
        #endregion
        
        #region Parameter ResourceConfig
        /// <summary>
        /// <para>
        /// <para>The resources, including the ML compute instances and ML storage volumes, to use for
        /// model training. </para><para>ML storage volumes store model artifacts and incremental states. Training algorithms
        /// might also use ML storage volumes for scratch space. If you want SageMaker to use
        /// the ML storage volume to store the training data, choose <code>File</code> as the
        /// <code>TrainingInputMode</code> in the algorithm specification. For distributed training
        /// algorithms, specify an instance count greater than 1.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.SageMaker.Model.ResourceConfig ResourceConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that SageMaker can assume to perform
        /// tasks on your behalf. </para><para>During model training, SageMaker needs your permission to read input data from an
        /// S3 bucket, download a Docker image that contains training code, write model artifacts
        /// to an S3 bucket, write logs to Amazon CloudWatch Logs, and publish metrics to Amazon
        /// CloudWatch. You grant permissions for all of these tasks to an IAM role. For more
        /// information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">SageMaker
        /// Roles</a>. </para><note><para>To be able to pass this role to SageMaker, the caller of this API must have the <code>iam:PassRole</code>
        /// permission.</para></note>
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
        
        #region Parameter DebugHookConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>Path to Amazon S3 storage location for metrics and tensors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DebugHookConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>Path to Amazon S3 storage location for system and framework metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfilerConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter TensorBoardOutputConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>Path to Amazon S3 storage location for TensorBoard output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TensorBoardOutputConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter CheckpointConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>Identifies the S3 path where you want SageMaker to store checkpoints. For example,
        /// <code>s3://bucket-name/key-name-prefix</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckpointConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. Specify the security groups for
        /// the VPC that is specified in the <code>Subnets</code> field.</para>
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
        /// Instance Types and Availability Zones</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingJobName
        /// <summary>
        /// <para>
        /// <para>The name of the training job. The name must be unique within an Amazon Web Services
        /// Region in an Amazon Web Services account. </para>
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
        public System.String TrainingJobName { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainingJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateTrainingJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateTrainingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainingJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrainingJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrainingJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrainingJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrainingJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTrainingJob (CreateTrainingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateTrainingJobResponse, NewSMTrainingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrainingJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AlgorithmSpecification = this.AlgorithmSpecification;
            #if MODULAR
            if (this.AlgorithmSpecification == null && ParameterWasBound(nameof(this.AlgorithmSpecification)))
            {
                WriteWarning("You are passing $null as a value for parameter AlgorithmSpecification which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CheckpointConfig_LocalPath = this.CheckpointConfig_LocalPath;
            context.CheckpointConfig_S3Uri = this.CheckpointConfig_S3Uri;
            if (this.DebugHookConfig_CollectionConfiguration != null)
            {
                context.DebugHookConfig_CollectionConfiguration = new List<Amazon.SageMaker.Model.CollectionConfiguration>(this.DebugHookConfig_CollectionConfiguration);
            }
            if (this.DebugHookConfig_HookParameter != null)
            {
                context.DebugHookConfig_HookParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DebugHookConfig_HookParameter.Keys)
                {
                    context.DebugHookConfig_HookParameter.Add((String)hashKey, (String)(this.DebugHookConfig_HookParameter[hashKey]));
                }
            }
            context.DebugHookConfig_LocalPath = this.DebugHookConfig_LocalPath;
            context.DebugHookConfig_S3OutputPath = this.DebugHookConfig_S3OutputPath;
            if (this.DebugRuleConfiguration != null)
            {
                context.DebugRuleConfiguration = new List<Amazon.SageMaker.Model.DebugRuleConfiguration>(this.DebugRuleConfiguration);
            }
            context.EnableInterContainerTrafficEncryption = this.EnableInterContainerTrafficEncryption;
            context.EnableManagedSpotTraining = this.EnableManagedSpotTraining;
            context.EnableNetworkIsolation = this.EnableNetworkIsolation;
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
            if (this.HyperParameter != null)
            {
                context.HyperParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HyperParameter.Keys)
                {
                    context.HyperParameter.Add((String)hashKey, (String)(this.HyperParameter[hashKey]));
                }
            }
            if (this.InputDataConfig != null)
            {
                context.InputDataConfig = new List<Amazon.SageMaker.Model.Channel>(this.InputDataConfig);
            }
            context.OutputDataConfig = this.OutputDataConfig;
            #if MODULAR
            if (this.OutputDataConfig == null && ParameterWasBound(nameof(this.OutputDataConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProfilerConfig_DisableProfiler = this.ProfilerConfig_DisableProfiler;
            context.ProfilerConfig_ProfilingIntervalInMillisecond = this.ProfilerConfig_ProfilingIntervalInMillisecond;
            if (this.ProfilerConfig_ProfilingParameter != null)
            {
                context.ProfilerConfig_ProfilingParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProfilerConfig_ProfilingParameter.Keys)
                {
                    context.ProfilerConfig_ProfilingParameter.Add((String)hashKey, (String)(this.ProfilerConfig_ProfilingParameter[hashKey]));
                }
            }
            context.ProfilerConfig_S3OutputPath = this.ProfilerConfig_S3OutputPath;
            if (this.ProfilerRuleConfiguration != null)
            {
                context.ProfilerRuleConfiguration = new List<Amazon.SageMaker.Model.ProfilerRuleConfiguration>(this.ProfilerRuleConfiguration);
            }
            context.ResourceConfig = this.ResourceConfig;
            #if MODULAR
            if (this.ResourceConfig == null && ParameterWasBound(nameof(this.ResourceConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetryStrategy_MaximumRetryAttempt = this.RetryStrategy_MaximumRetryAttempt;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            context.StoppingCondition_MaxWaitTimeInSecond = this.StoppingCondition_MaxWaitTimeInSecond;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TensorBoardOutputConfig_LocalPath = this.TensorBoardOutputConfig_LocalPath;
            context.TensorBoardOutputConfig_S3OutputPath = this.TensorBoardOutputConfig_S3OutputPath;
            context.TrainingJobName = this.TrainingJobName;
            #if MODULAR
            if (this.TrainingJobName == null && ParameterWasBound(nameof(this.TrainingJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMaker.Model.CreateTrainingJobRequest();
            
            if (cmdletContext.AlgorithmSpecification != null)
            {
                request.AlgorithmSpecification = cmdletContext.AlgorithmSpecification;
            }
            
             // populate CheckpointConfig
            var requestCheckpointConfigIsNull = true;
            request.CheckpointConfig = new Amazon.SageMaker.Model.CheckpointConfig();
            System.String requestCheckpointConfig_checkpointConfig_LocalPath = null;
            if (cmdletContext.CheckpointConfig_LocalPath != null)
            {
                requestCheckpointConfig_checkpointConfig_LocalPath = cmdletContext.CheckpointConfig_LocalPath;
            }
            if (requestCheckpointConfig_checkpointConfig_LocalPath != null)
            {
                request.CheckpointConfig.LocalPath = requestCheckpointConfig_checkpointConfig_LocalPath;
                requestCheckpointConfigIsNull = false;
            }
            System.String requestCheckpointConfig_checkpointConfig_S3Uri = null;
            if (cmdletContext.CheckpointConfig_S3Uri != null)
            {
                requestCheckpointConfig_checkpointConfig_S3Uri = cmdletContext.CheckpointConfig_S3Uri;
            }
            if (requestCheckpointConfig_checkpointConfig_S3Uri != null)
            {
                request.CheckpointConfig.S3Uri = requestCheckpointConfig_checkpointConfig_S3Uri;
                requestCheckpointConfigIsNull = false;
            }
             // determine if request.CheckpointConfig should be set to null
            if (requestCheckpointConfigIsNull)
            {
                request.CheckpointConfig = null;
            }
            
             // populate DebugHookConfig
            var requestDebugHookConfigIsNull = true;
            request.DebugHookConfig = new Amazon.SageMaker.Model.DebugHookConfig();
            List<Amazon.SageMaker.Model.CollectionConfiguration> requestDebugHookConfig_debugHookConfig_CollectionConfiguration = null;
            if (cmdletContext.DebugHookConfig_CollectionConfiguration != null)
            {
                requestDebugHookConfig_debugHookConfig_CollectionConfiguration = cmdletContext.DebugHookConfig_CollectionConfiguration;
            }
            if (requestDebugHookConfig_debugHookConfig_CollectionConfiguration != null)
            {
                request.DebugHookConfig.CollectionConfigurations = requestDebugHookConfig_debugHookConfig_CollectionConfiguration;
                requestDebugHookConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestDebugHookConfig_debugHookConfig_HookParameter = null;
            if (cmdletContext.DebugHookConfig_HookParameter != null)
            {
                requestDebugHookConfig_debugHookConfig_HookParameter = cmdletContext.DebugHookConfig_HookParameter;
            }
            if (requestDebugHookConfig_debugHookConfig_HookParameter != null)
            {
                request.DebugHookConfig.HookParameters = requestDebugHookConfig_debugHookConfig_HookParameter;
                requestDebugHookConfigIsNull = false;
            }
            System.String requestDebugHookConfig_debugHookConfig_LocalPath = null;
            if (cmdletContext.DebugHookConfig_LocalPath != null)
            {
                requestDebugHookConfig_debugHookConfig_LocalPath = cmdletContext.DebugHookConfig_LocalPath;
            }
            if (requestDebugHookConfig_debugHookConfig_LocalPath != null)
            {
                request.DebugHookConfig.LocalPath = requestDebugHookConfig_debugHookConfig_LocalPath;
                requestDebugHookConfigIsNull = false;
            }
            System.String requestDebugHookConfig_debugHookConfig_S3OutputPath = null;
            if (cmdletContext.DebugHookConfig_S3OutputPath != null)
            {
                requestDebugHookConfig_debugHookConfig_S3OutputPath = cmdletContext.DebugHookConfig_S3OutputPath;
            }
            if (requestDebugHookConfig_debugHookConfig_S3OutputPath != null)
            {
                request.DebugHookConfig.S3OutputPath = requestDebugHookConfig_debugHookConfig_S3OutputPath;
                requestDebugHookConfigIsNull = false;
            }
             // determine if request.DebugHookConfig should be set to null
            if (requestDebugHookConfigIsNull)
            {
                request.DebugHookConfig = null;
            }
            if (cmdletContext.DebugRuleConfiguration != null)
            {
                request.DebugRuleConfigurations = cmdletContext.DebugRuleConfiguration;
            }
            if (cmdletContext.EnableInterContainerTrafficEncryption != null)
            {
                request.EnableInterContainerTrafficEncryption = cmdletContext.EnableInterContainerTrafficEncryption.Value;
            }
            if (cmdletContext.EnableManagedSpotTraining != null)
            {
                request.EnableManagedSpotTraining = cmdletContext.EnableManagedSpotTraining.Value;
            }
            if (cmdletContext.EnableNetworkIsolation != null)
            {
                request.EnableNetworkIsolation = cmdletContext.EnableNetworkIsolation.Value;
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
            if (cmdletContext.HyperParameter != null)
            {
                request.HyperParameters = cmdletContext.HyperParameter;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            if (cmdletContext.OutputDataConfig != null)
            {
                request.OutputDataConfig = cmdletContext.OutputDataConfig;
            }
            
             // populate ProfilerConfig
            var requestProfilerConfigIsNull = true;
            request.ProfilerConfig = new Amazon.SageMaker.Model.ProfilerConfig();
            System.Boolean? requestProfilerConfig_profilerConfig_DisableProfiler = null;
            if (cmdletContext.ProfilerConfig_DisableProfiler != null)
            {
                requestProfilerConfig_profilerConfig_DisableProfiler = cmdletContext.ProfilerConfig_DisableProfiler.Value;
            }
            if (requestProfilerConfig_profilerConfig_DisableProfiler != null)
            {
                request.ProfilerConfig.DisableProfiler = requestProfilerConfig_profilerConfig_DisableProfiler.Value;
                requestProfilerConfigIsNull = false;
            }
            System.Int64? requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond = null;
            if (cmdletContext.ProfilerConfig_ProfilingIntervalInMillisecond != null)
            {
                requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond = cmdletContext.ProfilerConfig_ProfilingIntervalInMillisecond.Value;
            }
            if (requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond != null)
            {
                request.ProfilerConfig.ProfilingIntervalInMilliseconds = requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond.Value;
                requestProfilerConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestProfilerConfig_profilerConfig_ProfilingParameter = null;
            if (cmdletContext.ProfilerConfig_ProfilingParameter != null)
            {
                requestProfilerConfig_profilerConfig_ProfilingParameter = cmdletContext.ProfilerConfig_ProfilingParameter;
            }
            if (requestProfilerConfig_profilerConfig_ProfilingParameter != null)
            {
                request.ProfilerConfig.ProfilingParameters = requestProfilerConfig_profilerConfig_ProfilingParameter;
                requestProfilerConfigIsNull = false;
            }
            System.String requestProfilerConfig_profilerConfig_S3OutputPath = null;
            if (cmdletContext.ProfilerConfig_S3OutputPath != null)
            {
                requestProfilerConfig_profilerConfig_S3OutputPath = cmdletContext.ProfilerConfig_S3OutputPath;
            }
            if (requestProfilerConfig_profilerConfig_S3OutputPath != null)
            {
                request.ProfilerConfig.S3OutputPath = requestProfilerConfig_profilerConfig_S3OutputPath;
                requestProfilerConfigIsNull = false;
            }
             // determine if request.ProfilerConfig should be set to null
            if (requestProfilerConfigIsNull)
            {
                request.ProfilerConfig = null;
            }
            if (cmdletContext.ProfilerRuleConfiguration != null)
            {
                request.ProfilerRuleConfigurations = cmdletContext.ProfilerRuleConfiguration;
            }
            if (cmdletContext.ResourceConfig != null)
            {
                request.ResourceConfig = cmdletContext.ResourceConfig;
            }
            
             // populate RetryStrategy
            var requestRetryStrategyIsNull = true;
            request.RetryStrategy = new Amazon.SageMaker.Model.RetryStrategy();
            System.Int32? requestRetryStrategy_retryStrategy_MaximumRetryAttempt = null;
            if (cmdletContext.RetryStrategy_MaximumRetryAttempt != null)
            {
                requestRetryStrategy_retryStrategy_MaximumRetryAttempt = cmdletContext.RetryStrategy_MaximumRetryAttempt.Value;
            }
            if (requestRetryStrategy_retryStrategy_MaximumRetryAttempt != null)
            {
                request.RetryStrategy.MaximumRetryAttempts = requestRetryStrategy_retryStrategy_MaximumRetryAttempt.Value;
                requestRetryStrategyIsNull = false;
            }
             // determine if request.RetryStrategy should be set to null
            if (requestRetryStrategyIsNull)
            {
                request.RetryStrategy = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingCondition
            var requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.SageMaker.Model.StoppingCondition();
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
            System.Int32? requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxWaitTimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond = cmdletContext.StoppingCondition_MaxWaitTimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond != null)
            {
                request.StoppingCondition.MaxWaitTimeInSeconds = requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond.Value;
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
            
             // populate TensorBoardOutputConfig
            var requestTensorBoardOutputConfigIsNull = true;
            request.TensorBoardOutputConfig = new Amazon.SageMaker.Model.TensorBoardOutputConfig();
            System.String requestTensorBoardOutputConfig_tensorBoardOutputConfig_LocalPath = null;
            if (cmdletContext.TensorBoardOutputConfig_LocalPath != null)
            {
                requestTensorBoardOutputConfig_tensorBoardOutputConfig_LocalPath = cmdletContext.TensorBoardOutputConfig_LocalPath;
            }
            if (requestTensorBoardOutputConfig_tensorBoardOutputConfig_LocalPath != null)
            {
                request.TensorBoardOutputConfig.LocalPath = requestTensorBoardOutputConfig_tensorBoardOutputConfig_LocalPath;
                requestTensorBoardOutputConfigIsNull = false;
            }
            System.String requestTensorBoardOutputConfig_tensorBoardOutputConfig_S3OutputPath = null;
            if (cmdletContext.TensorBoardOutputConfig_S3OutputPath != null)
            {
                requestTensorBoardOutputConfig_tensorBoardOutputConfig_S3OutputPath = cmdletContext.TensorBoardOutputConfig_S3OutputPath;
            }
            if (requestTensorBoardOutputConfig_tensorBoardOutputConfig_S3OutputPath != null)
            {
                request.TensorBoardOutputConfig.S3OutputPath = requestTensorBoardOutputConfig_tensorBoardOutputConfig_S3OutputPath;
                requestTensorBoardOutputConfigIsNull = false;
            }
             // determine if request.TensorBoardOutputConfig should be set to null
            if (requestTensorBoardOutputConfigIsNull)
            {
                request.TensorBoardOutputConfig = null;
            }
            if (cmdletContext.TrainingJobName != null)
            {
                request.TrainingJobName = cmdletContext.TrainingJobName;
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
        
        private Amazon.SageMaker.Model.CreateTrainingJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTrainingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTrainingJob");
            try
            {
                #if DESKTOP
                return client.CreateTrainingJob(request);
                #elif CORECLR
                return client.CreateTrainingJobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.Model.AlgorithmSpecification AlgorithmSpecification { get; set; }
            public System.String CheckpointConfig_LocalPath { get; set; }
            public System.String CheckpointConfig_S3Uri { get; set; }
            public List<Amazon.SageMaker.Model.CollectionConfiguration> DebugHookConfig_CollectionConfiguration { get; set; }
            public Dictionary<System.String, System.String> DebugHookConfig_HookParameter { get; set; }
            public System.String DebugHookConfig_LocalPath { get; set; }
            public System.String DebugHookConfig_S3OutputPath { get; set; }
            public List<Amazon.SageMaker.Model.DebugRuleConfiguration> DebugRuleConfiguration { get; set; }
            public System.Boolean? EnableInterContainerTrafficEncryption { get; set; }
            public System.Boolean? EnableManagedSpotTraining { get; set; }
            public System.Boolean? EnableNetworkIsolation { get; set; }
            public Dictionary<System.String, System.String> Environment { get; set; }
            public System.String ExperimentConfig_ExperimentName { get; set; }
            public System.String ExperimentConfig_RunName { get; set; }
            public System.String ExperimentConfig_TrialComponentDisplayName { get; set; }
            public System.String ExperimentConfig_TrialName { get; set; }
            public Dictionary<System.String, System.String> HyperParameter { get; set; }
            public List<Amazon.SageMaker.Model.Channel> InputDataConfig { get; set; }
            public Amazon.SageMaker.Model.OutputDataConfig OutputDataConfig { get; set; }
            public System.Boolean? ProfilerConfig_DisableProfiler { get; set; }
            public System.Int64? ProfilerConfig_ProfilingIntervalInMillisecond { get; set; }
            public Dictionary<System.String, System.String> ProfilerConfig_ProfilingParameter { get; set; }
            public System.String ProfilerConfig_S3OutputPath { get; set; }
            public List<Amazon.SageMaker.Model.ProfilerRuleConfiguration> ProfilerRuleConfiguration { get; set; }
            public Amazon.SageMaker.Model.ResourceConfig ResourceConfig { get; set; }
            public System.Int32? RetryStrategy_MaximumRetryAttempt { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String TensorBoardOutputConfig_LocalPath { get; set; }
            public System.String TensorBoardOutputConfig_S3OutputPath { get; set; }
            public System.String TrainingJobName { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateTrainingJobResponse, NewSMTrainingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainingJobArn;
        }
        
    }
}
