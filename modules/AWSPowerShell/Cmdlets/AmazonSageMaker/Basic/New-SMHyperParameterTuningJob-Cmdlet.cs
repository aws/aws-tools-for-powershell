/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Starts a hyperparameter tuning job.
    /// </summary>
    [Cmdlet("New", "SMHyperParameterTuningJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateHyperParameterTuningJob API operation.", Operation = new[] {"CreateHyperParameterTuningJob"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateHyperParameterTuningJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMHyperParameterTuningJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ParameterRanges_CategoricalParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a>CategoricalParameterRange</a> objects that specify ranges of categorical
        /// hyperparameters that a hyperparameter tuning job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_CategoricalParameterRanges")]
        public Amazon.SageMaker.Model.CategoricalParameterRange[] ParameterRanges_CategoricalParameterRange { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_ContinuousParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a>ContinuousParameterRange</a> objects that specify ranges of continuous
        /// hyperparameters that a hyperparameter tuning job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_ContinuousParameterRanges")]
        public Amazon.SageMaker.Model.ContinuousParameterRange[] ParameterRanges_ContinuousParameterRange { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobName
        /// <summary>
        /// <para>
        /// <para>The name of the tuning job. This name is the prefix for the names of all training
        /// jobs that this tuning job launches. The name must be unique within the same AWS account
        /// and AWS Region. Names are not case sensitive, and must be between 1-32 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String HyperParameterTuningJobName { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_InputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of <a>Channel</a> objects that specify the input for the training jobs that
        /// the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.Channel[] TrainingJobDefinition_InputDataConfig { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_IntegerParameterRange
        /// <summary>
        /// <para>
        /// <para>The array of <a>IntegerParameterRange</a> objects that specify ranges of integer hyperparameters
        /// that a hyperparameter tuning job searches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_ParameterRanges_IntegerParameterRanges")]
        public Amazon.SageMaker.Model.IntegerParameterRange[] ParameterRanges_IntegerParameterRange { get; set; }
        #endregion
        
        #region Parameter ResourceLimits_MaxNumberOfTrainingJob
        /// <summary>
        /// <para>
        /// <para>The maximum number of training jobs that a hyperparameter tuning job can launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_ResourceLimits_MaxNumberOfTrainingJobs")]
        public System.Int32 ResourceLimits_MaxNumberOfTrainingJob { get; set; }
        #endregion
        
        #region Parameter ResourceLimits_MaxParallelTrainingJob
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent training jobs that a hyperparameter tuning job can
        /// launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_ResourceLimits_MaxParallelTrainingJobs")]
        public System.Int32 ResourceLimits_MaxParallelTrainingJob { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that the training job can run. If model training
        /// does not complete during this time, Amazon SageMaker ends the job. If value is not
        /// specified, default value is 1 day. Maximum value is 5 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32 StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter AlgorithmSpecification_MetricDefinition
        /// <summary>
        /// <para>
        /// <para>An array of <a>MetricDefinition</a> objects that specify the metrics that the algorithm
        /// emits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_MetricDefinitions")]
        public Amazon.SageMaker.Model.MetricDefinition[] AlgorithmSpecification_MetricDefinition { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobObjective_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric to use for the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_MetricName")]
        public System.String HyperParameterTuningJobObjective_MetricName { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_OutputDataConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the path to the Amazon S3 bucket where you store model artifacts from the
        /// training jobs that the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.OutputDataConfig TrainingJobDefinition_OutputDataConfig { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_ResourceConfig
        /// <summary>
        /// <para>
        /// <para>The resources, including the compute instances and storage volumes, to use for the
        /// training jobs that the tuning job launches.</para><para>Storage volumes store model artifacts and incremental states. Training algorithms
        /// might also use storage volumes for scratch space. If you want Amazon SageMaker to
        /// use the storage volume to store the training data, choose <code>File</code> as the
        /// <code>TrainingInputMode</code> in the algorithm specification. For distributed training
        /// algorithms, specify an instance count greater than 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.ResourceConfig TrainingJobDefinition_ResourceConfig { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role associated with the training jobs that
        /// the tuning job launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrainingJobDefinition_RoleArn { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. Specify the security groups for
        /// the VPC that is specified in the <code>Subnets</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter TrainingJobDefinition_StaticHyperParameter
        /// <summary>
        /// <para>
        /// <para>Specifies the values of hyperparameters that do not change for the tuning job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_StaticHyperParameters")]
        public System.Collections.Hashtable TrainingJobDefinition_StaticHyperParameter { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobConfig_Strategy
        /// <summary>
        /// <para>
        /// <para>Specifies the search strategy for hyperparameters. Currently, the only valid value
        /// is <code>Bayesian</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningJobStrategyType")]
        public Amazon.SageMaker.HyperParameterTuningJobStrategyType HyperParameterTuningJobConfig_Strategy { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your AWS resources in
        /// different ways, for example, by purpose, owner, or environment. For more information,
        /// see <a href="http://docs.aws.amazon.com//awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i>AWS Billing and Cost Management User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AlgorithmSpecification_TrainingImage
        /// <summary>
        /// <para>
        /// <para> The registry path of the Docker image that contains the training algorithm. For information
        /// about Docker registry paths for built-in algorithms, see <a>sagemaker-algo-docker-registry-paths</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_TrainingImage")]
        public System.String AlgorithmSpecification_TrainingImage { get; set; }
        #endregion
        
        #region Parameter AlgorithmSpecification_TrainingInputMode
        /// <summary>
        /// <para>
        /// <para>The input mode that the algorithm supports: File or Pipe. In File input mode, Amazon
        /// SageMaker downloads the training data from Amazon S3 to the storage volume that is
        /// attached to the training instance and mounts the directory to the Docker volume for
        /// the training container. In Pipe input mode, Amazon SageMaker streams data directly
        /// from Amazon S3 to the container. </para><para>If you specify File mode, make sure that you provision the storage volume that is
        /// attached to the training instance with enough capacity to accommodate the training
        /// data downloaded from Amazon S3, the model artifacts, and intermediate information.</para><para>For more information about input modes, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode")]
        [AWSConstantClassSource("Amazon.SageMaker.TrainingInputMode")]
        public Amazon.SageMaker.TrainingInputMode AlgorithmSpecification_TrainingInputMode { get; set; }
        #endregion
        
        #region Parameter HyperParameterTuningJobObjective_Type
        /// <summary>
        /// <para>
        /// <para>Whether to minimize or maximize the objective metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.HyperParameterTuningJobObjectiveType")]
        public Amazon.SageMaker.HyperParameterTuningJobObjectiveType HyperParameterTuningJobObjective_Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HyperParameterTuningJobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMHyperParameterTuningJob (CreateHyperParameterTuningJob)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_MetricName = this.HyperParameterTuningJobObjective_MetricName;
            context.HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type = this.HyperParameterTuningJobObjective_Type;
            if (this.ParameterRanges_CategoricalParameterRange != null)
            {
                context.HyperParameterTuningJobConfig_ParameterRanges_CategoricalParameterRanges = new List<Amazon.SageMaker.Model.CategoricalParameterRange>(this.ParameterRanges_CategoricalParameterRange);
            }
            if (this.ParameterRanges_ContinuousParameterRange != null)
            {
                context.HyperParameterTuningJobConfig_ParameterRanges_ContinuousParameterRanges = new List<Amazon.SageMaker.Model.ContinuousParameterRange>(this.ParameterRanges_ContinuousParameterRange);
            }
            if (this.ParameterRanges_IntegerParameterRange != null)
            {
                context.HyperParameterTuningJobConfig_ParameterRanges_IntegerParameterRanges = new List<Amazon.SageMaker.Model.IntegerParameterRange>(this.ParameterRanges_IntegerParameterRange);
            }
            if (ParameterWasBound("ResourceLimits_MaxNumberOfTrainingJob"))
                context.HyperParameterTuningJobConfig_ResourceLimits_MaxNumberOfTrainingJobs = this.ResourceLimits_MaxNumberOfTrainingJob;
            if (ParameterWasBound("ResourceLimits_MaxParallelTrainingJob"))
                context.HyperParameterTuningJobConfig_ResourceLimits_MaxParallelTrainingJobs = this.ResourceLimits_MaxParallelTrainingJob;
            context.HyperParameterTuningJobConfig_Strategy = this.HyperParameterTuningJobConfig_Strategy;
            context.HyperParameterTuningJobName = this.HyperParameterTuningJobName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            if (this.AlgorithmSpecification_MetricDefinition != null)
            {
                context.TrainingJobDefinition_AlgorithmSpecification_MetricDefinitions = new List<Amazon.SageMaker.Model.MetricDefinition>(this.AlgorithmSpecification_MetricDefinition);
            }
            context.TrainingJobDefinition_AlgorithmSpecification_TrainingImage = this.AlgorithmSpecification_TrainingImage;
            context.TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode = this.AlgorithmSpecification_TrainingInputMode;
            if (this.TrainingJobDefinition_InputDataConfig != null)
            {
                context.TrainingJobDefinition_InputDataConfig = new List<Amazon.SageMaker.Model.Channel>(this.TrainingJobDefinition_InputDataConfig);
            }
            context.TrainingJobDefinition_OutputDataConfig = this.TrainingJobDefinition_OutputDataConfig;
            context.TrainingJobDefinition_ResourceConfig = this.TrainingJobDefinition_ResourceConfig;
            context.TrainingJobDefinition_RoleArn = this.TrainingJobDefinition_RoleArn;
            if (this.TrainingJobDefinition_StaticHyperParameter != null)
            {
                context.TrainingJobDefinition_StaticHyperParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TrainingJobDefinition_StaticHyperParameter.Keys)
                {
                    context.TrainingJobDefinition_StaticHyperParameters.Add((String)hashKey, (String)(this.TrainingJobDefinition_StaticHyperParameter[hashKey]));
                }
            }
            if (ParameterWasBound("StoppingCondition_MaxRuntimeInSecond"))
                context.TrainingJobDefinition_StoppingCondition_MaxRuntimeInSeconds = this.StoppingCondition_MaxRuntimeInSecond;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.TrainingJobDefinition_VpcConfig_SecurityGroupIds = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.TrainingJobDefinition_VpcConfig_Subnets = new List<System.String>(this.VpcConfig_Subnet);
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
            var request = new Amazon.SageMaker.Model.CreateHyperParameterTuningJobRequest();
            
            
             // populate HyperParameterTuningJobConfig
            bool requestHyperParameterTuningJobConfigIsNull = true;
            request.HyperParameterTuningJobConfig = new Amazon.SageMaker.Model.HyperParameterTuningJobConfig();
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
            Amazon.SageMaker.Model.HyperParameterTuningJobObjective requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective = null;
            
             // populate HyperParameterTuningJobObjective
            bool requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjectiveIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective = new Amazon.SageMaker.Model.HyperParameterTuningJobObjective();
            System.String requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName = null;
            if (cmdletContext.HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_MetricName != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName = cmdletContext.HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_MetricName;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective.MetricName = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_MetricName;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjectiveIsNull = false;
            }
            Amazon.SageMaker.HyperParameterTuningJobObjectiveType requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_Type = null;
            if (cmdletContext.HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_HyperParameterTuningJobObjective_hyperParameterTuningJobObjective_Type = cmdletContext.HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type;
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
            bool requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits = new Amazon.SageMaker.Model.ResourceLimits();
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob = null;
            if (cmdletContext.HyperParameterTuningJobConfig_ResourceLimits_MaxNumberOfTrainingJobs != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob = cmdletContext.HyperParameterTuningJobConfig_ResourceLimits_MaxNumberOfTrainingJobs.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits.MaxNumberOfTrainingJobs = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxNumberOfTrainingJob.Value;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimitsIsNull = false;
            }
            System.Int32? requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob = null;
            if (cmdletContext.HyperParameterTuningJobConfig_ResourceLimits_MaxParallelTrainingJobs != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob = cmdletContext.HyperParameterTuningJobConfig_ResourceLimits_MaxParallelTrainingJobs.Value;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits.MaxParallelTrainingJobs = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ResourceLimits_resourceLimits_MaxParallelTrainingJob.Value;
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
            Amazon.SageMaker.Model.ParameterRanges requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges = null;
            
             // populate ParameterRanges
            bool requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = true;
            requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges = new Amazon.SageMaker.Model.ParameterRanges();
            List<Amazon.SageMaker.Model.CategoricalParameterRange> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange = null;
            if (cmdletContext.HyperParameterTuningJobConfig_ParameterRanges_CategoricalParameterRanges != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange = cmdletContext.HyperParameterTuningJobConfig_ParameterRanges_CategoricalParameterRanges;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges.CategoricalParameterRanges = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_CategoricalParameterRange;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.ContinuousParameterRange> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange = null;
            if (cmdletContext.HyperParameterTuningJobConfig_ParameterRanges_ContinuousParameterRanges != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange = cmdletContext.HyperParameterTuningJobConfig_ParameterRanges_ContinuousParameterRanges;
            }
            if (requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges.ContinuousParameterRanges = requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_ContinuousParameterRange;
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.SageMaker.Model.IntegerParameterRange> requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_IntegerParameterRange = null;
            if (cmdletContext.HyperParameterTuningJobConfig_ParameterRanges_IntegerParameterRanges != null)
            {
                requestHyperParameterTuningJobConfig_hyperParameterTuningJobConfig_ParameterRanges_parameterRanges_IntegerParameterRange = cmdletContext.HyperParameterTuningJobConfig_ParameterRanges_IntegerParameterRanges;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
             // populate TrainingJobDefinition
            bool requestTrainingJobDefinitionIsNull = true;
            request.TrainingJobDefinition = new Amazon.SageMaker.Model.HyperParameterTrainingJobDefinition();
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
            if (cmdletContext.TrainingJobDefinition_StaticHyperParameters != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter = cmdletContext.TrainingJobDefinition_StaticHyperParameters;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter != null)
            {
                request.TrainingJobDefinition.StaticHyperParameters = requestTrainingJobDefinition_trainingJobDefinition_StaticHyperParameter;
                requestTrainingJobDefinitionIsNull = false;
            }
            Amazon.SageMaker.Model.StoppingCondition requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition = null;
            
             // populate StoppingCondition
            bool requestTrainingJobDefinition_trainingJobDefinition_StoppingConditionIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition = new Amazon.SageMaker.Model.StoppingCondition();
            System.Int32? requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.TrainingJobDefinition_StoppingCondition_MaxRuntimeInSeconds != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.TrainingJobDefinition_StoppingCondition_MaxRuntimeInSeconds.Value;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition.MaxRuntimeInSeconds = requestTrainingJobDefinition_trainingJobDefinition_StoppingCondition_stoppingCondition_MaxRuntimeInSecond.Value;
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
            Amazon.SageMaker.Model.VpcConfig requestTrainingJobDefinition_trainingJobDefinition_VpcConfig = null;
            
             // populate VpcConfig
            bool requestTrainingJobDefinition_trainingJobDefinition_VpcConfigIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.TrainingJobDefinition_VpcConfig_SecurityGroupIds != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.TrainingJobDefinition_VpcConfig_SecurityGroupIds;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig.SecurityGroupIds = requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_SecurityGroupId;
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfigIsNull = false;
            }
            List<System.String> requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.TrainingJobDefinition_VpcConfig_Subnets != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_VpcConfig_vpcConfig_Subnet = cmdletContext.TrainingJobDefinition_VpcConfig_Subnets;
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
            Amazon.SageMaker.Model.HyperParameterAlgorithmSpecification requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification = null;
            
             // populate AlgorithmSpecification
            bool requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = true;
            requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification = new Amazon.SageMaker.Model.HyperParameterAlgorithmSpecification();
            List<Amazon.SageMaker.Model.MetricDefinition> requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition = null;
            if (cmdletContext.TrainingJobDefinition_AlgorithmSpecification_MetricDefinitions != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition = cmdletContext.TrainingJobDefinition_AlgorithmSpecification_MetricDefinitions;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification.MetricDefinitions = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_MetricDefinition;
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = false;
            }
            System.String requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage = null;
            if (cmdletContext.TrainingJobDefinition_AlgorithmSpecification_TrainingImage != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage = cmdletContext.TrainingJobDefinition_AlgorithmSpecification_TrainingImage;
            }
            if (requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification.TrainingImage = requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingImage;
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecificationIsNull = false;
            }
            Amazon.SageMaker.TrainingInputMode requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingInputMode = null;
            if (cmdletContext.TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode != null)
            {
                requestTrainingJobDefinition_trainingJobDefinition_AlgorithmSpecification_algorithmSpecification_TrainingInputMode = cmdletContext.TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode;
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
             // determine if request.TrainingJobDefinition should be set to null
            if (requestTrainingJobDefinitionIsNull)
            {
                request.TrainingJobDefinition = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HyperParameterTuningJobArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateHyperParameterTuningJobAsync(request);
                return task.Result;
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
            public System.String HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_MetricName { get; set; }
            public Amazon.SageMaker.HyperParameterTuningJobObjectiveType HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type { get; set; }
            public List<Amazon.SageMaker.Model.CategoricalParameterRange> HyperParameterTuningJobConfig_ParameterRanges_CategoricalParameterRanges { get; set; }
            public List<Amazon.SageMaker.Model.ContinuousParameterRange> HyperParameterTuningJobConfig_ParameterRanges_ContinuousParameterRanges { get; set; }
            public List<Amazon.SageMaker.Model.IntegerParameterRange> HyperParameterTuningJobConfig_ParameterRanges_IntegerParameterRanges { get; set; }
            public System.Int32? HyperParameterTuningJobConfig_ResourceLimits_MaxNumberOfTrainingJobs { get; set; }
            public System.Int32? HyperParameterTuningJobConfig_ResourceLimits_MaxParallelTrainingJobs { get; set; }
            public Amazon.SageMaker.HyperParameterTuningJobStrategyType HyperParameterTuningJobConfig_Strategy { get; set; }
            public System.String HyperParameterTuningJobName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tags { get; set; }
            public List<Amazon.SageMaker.Model.MetricDefinition> TrainingJobDefinition_AlgorithmSpecification_MetricDefinitions { get; set; }
            public System.String TrainingJobDefinition_AlgorithmSpecification_TrainingImage { get; set; }
            public Amazon.SageMaker.TrainingInputMode TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode { get; set; }
            public List<Amazon.SageMaker.Model.Channel> TrainingJobDefinition_InputDataConfig { get; set; }
            public Amazon.SageMaker.Model.OutputDataConfig TrainingJobDefinition_OutputDataConfig { get; set; }
            public Amazon.SageMaker.Model.ResourceConfig TrainingJobDefinition_ResourceConfig { get; set; }
            public System.String TrainingJobDefinition_RoleArn { get; set; }
            public Dictionary<System.String, System.String> TrainingJobDefinition_StaticHyperParameters { get; set; }
            public System.Int32? TrainingJobDefinition_StoppingCondition_MaxRuntimeInSeconds { get; set; }
            public List<System.String> TrainingJobDefinition_VpcConfig_SecurityGroupIds { get; set; }
            public List<System.String> TrainingJobDefinition_VpcConfig_Subnets { get; set; }
        }
        
    }
}
