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
    /// Creates an Autopilot job.
    /// 
    ///  
    /// <para>
    /// Find the best performing model after you run an Autopilot job by calling .
    /// </para><para>
    /// For information about how to use Autopilot, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development.html">Automate
    /// Model Development with Amazon SageMaker Autopilot</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMAutoMLJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAutoMLJob API operation.", Operation = new[] {"CreateAutoMLJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAutoMLJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAutoMLJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAutoMLJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMAutoMLJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ModelDeployConfig_AutoGenerateEndpointName
        /// <summary>
        /// <para>
        /// <para>Set to <code>True</code> to automatically generate an endpoint name for a one-click
        /// Autopilot model deployment; set to <code>False</code> otherwise. The default value
        /// is <code>True</code>.</para><note><para>If you set <code>AutoGenerateEndpointName</code> to <code>True</code>, do not specify
        /// the <code>EndpointName</code>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ModelDeployConfig_AutoGenerateEndpointName { get; set; }
        #endregion
        
        #region Parameter AutoMLJobName
        /// <summary>
        /// <para>
        /// <para>Identifies an Autopilot job. The name must be unique to your account and is case-insensitive.</para>
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
        public System.String AutoMLJobName { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>Whether to use traffic encryption between the container layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_EnableInterContainerTrafficEncryption")]
        public System.Boolean? SecurityConfig_EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter ModelDeployConfig_EndpointName
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint name to use for a one-click Autopilot model deployment if the
        /// endpoint name is not generated automatically.</para><note><para>Specify the <code>EndpointName</code> if and only if you set <code>AutoGenerateEndpointName</code>
        /// to <code>False</code>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelDeployConfig_EndpointName { get; set; }
        #endregion
        
        #region Parameter GenerateCandidateDefinitionsOnly
        /// <summary>
        /// <para>
        /// <para>Generates possible candidates without training the models. A candidate is a combination
        /// of data preprocessors, algorithms, and algorithm parameter settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GenerateCandidateDefinitionsOnly { get; set; }
        #endregion
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of channel objects that describes the input data and its location. Each channel
        /// is a named input source. Similar to <code>InputDataConfig</code> supported by . Format(s)
        /// supported: CSV. Minimum of 500 rows.</para>
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
        public Amazon.SageMaker.Model.AutoMLChannel[] InputDataConfig { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS encryption key ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxAutoMLJobRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, an AutoML job is allowed to wait for a trial to complete.
        /// It must be equal to or greater than <code>MaxRuntimePerTrainingJobInSeconds</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CompletionCriteria_MaxCandidates")]
        public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxRuntimePerTrainingJobInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, a job is allowed to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLJobObjective_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the objective metric used to measure the predictive quality of a machine
        /// learning system. This metric is optimized during training to provide the best estimate
        /// for model parameter values from data.</para><para>Here are the options:</para><ul><li><para><code>MSE</code>: The mean squared error (MSE) is the average of the squared differences
        /// between the predicted and actual values. It is used for regression. MSE values are
        /// always positive: the better a model is at predicting the actual values, the smaller
        /// the MSE value. When the data contains outliers, they tend to dominate the MSE, which
        /// might cause subpar prediction performance.</para></li><li><para><code>Accuracy</code>: The ratio of the number of correctly classified items to the
        /// total number of (correctly and incorrectly) classified items. It is used for binary
        /// and multiclass classification. It measures how close the predicted class values are
        /// to the actual values. Accuracy values vary between zero and one: one indicates perfect
        /// accuracy and zero indicates perfect inaccuracy.</para></li><li><para><code>F1</code>: The F1 score is the harmonic mean of the precision and recall. It
        /// is used for binary classification into classes traditionally referred to as positive
        /// and negative. Predictions are said to be true when they match their actual (correct)
        /// class and false when they do not. Precision is the ratio of the true positive predictions
        /// to all positive predictions (including the false positives) in a data set and measures
        /// the quality of the prediction when it predicts the positive class. Recall (or sensitivity)
        /// is the ratio of the true positive predictions to all actual positive instances and
        /// measures how completely a model predicts the actual class members in a data set. The
        /// standard F1 score weighs precision and recall equally. But which metric is paramount
        /// typically depends on specific aspects of a problem. F1 scores vary between zero and
        /// one: one indicates the best possible performance and zero the worst.</para></li><li><para><code>AUC</code>: The area under the curve (AUC) metric is used to compare and evaluate
        /// binary classification by algorithms such as logistic regression that return probabilities.
        /// A threshold is needed to map the probabilities into classifications. The relevant
        /// curve is the receiver operating characteristic curve that plots the true positive
        /// rate (TPR) of predictions (or recall) against the false positive rate (FPR) as a function
        /// of the threshold value, above which a prediction is considered positive. Increasing
        /// the threshold results in fewer false positives but more false negatives. AUC is the
        /// area under this receiver operating characteristic curve and so provides an aggregated
        /// measure of the model performance across all possible classification thresholds. The
        /// AUC score can also be interpreted as the probability that a randomly selected positive
        /// data point is more likely to be predicted positive than a randomly selected negative
        /// example. AUC scores vary between zero and one: a score of one indicates perfect accuracy
        /// and a score of one half indicates that the prediction is not better than a random
        /// classifier. Values under one half predict less accurately than a random predictor.
        /// But such consistently bad predictors can simply be inverted to obtain better than
        /// random predictors.</para></li><li><para><code>F1macro</code>: The F1macro score applies F1 scoring to multiclass classification.
        /// In this context, you have multiple classes to predict. You just calculate the precision
        /// and recall for each class as you did for the positive class in binary classification.
        /// Then, use these values to calculate the F1 score for each class and average them to
        /// obtain the F1macro score. F1macro scores vary between zero and one: one indicates
        /// the best possible performance and zero the worst.</para></li></ul><para>If you do not specify a metric explicitly, the default behavior is to automatically
        /// use:</para><ul><li><para><code>MSE</code>: for regression.</para></li><li><para><code>F1</code>: for binary classification</para></li><li><para><code>Accuracy</code>: for multiclass classification.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMetricEnum")]
        public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
        #endregion
        
        #region Parameter ProblemType
        /// <summary>
        /// <para>
        /// <para>Defines the type of supervised learning available for the candidates. Options include:
        /// <code>BinaryClassification</code>, <code>MulticlassClassification</code>, and <code>Regression</code>.
        /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development-problem-types.html">
        /// Amazon SageMaker Autopilot problem types and algorithm support</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ProblemType")]
        public Amazon.SageMaker.ProblemType ProblemType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that is used to access the data.</para><para>&lt;para&gt;Specifies whether to automatically deploy the best &amp;ATP; model to
        /// an endpoint and the name of that endpoint if deployed automatically.&lt;/para&gt;</para>
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
        
        #region Parameter OutputDataConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 output path. Must be 128 characters or less.</para>
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
        public System.String OutputDataConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. Specify the security groups for
        /// the VPC that is specified in the <code>Subnets</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_VpcConfig_SecurityGroupIds")]
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
        [Alias("AutoMLJobConfig_SecurityConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Each tag consists of a key and an optional value. Tag keys must be unique per resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The key used to encrypt stored data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_VolumeKmsKeyId")]
        public System.String SecurityConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoMLJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAutoMLJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAutoMLJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoMLJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoMLJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoMLJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoMLJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoMLJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAutoMLJob (CreateAutoMLJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAutoMLJobResponse, NewSMAutoMLJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoMLJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.CompletionCriteria_MaxCandidate = this.CompletionCriteria_MaxCandidate;
            context.CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            context.SecurityConfig_EnableInterContainerTrafficEncryption = this.SecurityConfig_EnableInterContainerTrafficEncryption;
            context.SecurityConfig_VolumeKmsKeyId = this.SecurityConfig_VolumeKmsKeyId;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.AutoMLJobName = this.AutoMLJobName;
            #if MODULAR
            if (this.AutoMLJobName == null && ParameterWasBound(nameof(this.AutoMLJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoMLJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoMLJobObjective_MetricName = this.AutoMLJobObjective_MetricName;
            context.GenerateCandidateDefinitionsOnly = this.GenerateCandidateDefinitionsOnly;
            if (this.InputDataConfig != null)
            {
                context.InputDataConfig = new List<Amazon.SageMaker.Model.AutoMLChannel>(this.InputDataConfig);
            }
            #if MODULAR
            if (this.InputDataConfig == null && ParameterWasBound(nameof(this.InputDataConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelDeployConfig_AutoGenerateEndpointName = this.ModelDeployConfig_AutoGenerateEndpointName;
            context.ModelDeployConfig_EndpointName = this.ModelDeployConfig_EndpointName;
            context.OutputDataConfig_KmsKeyId = this.OutputDataConfig_KmsKeyId;
            context.OutputDataConfig_S3OutputPath = this.OutputDataConfig_S3OutputPath;
            #if MODULAR
            if (this.OutputDataConfig_S3OutputPath == null && ParameterWasBound(nameof(this.OutputDataConfig_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProblemType = this.ProblemType;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMaker.Model.CreateAutoMLJobRequest();
            
            
             // populate AutoMLJobConfig
            var requestAutoMLJobConfigIsNull = true;
            request.AutoMLJobConfig = new Amazon.SageMaker.Model.AutoMLJobConfig();
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate = null;
            if (cmdletContext.CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate = cmdletContext.CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate.Value;
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria != null)
            {
                request.AutoMLJobConfig.CompletionCriteria = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria;
                requestAutoMLJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLSecurityConfig requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig = null;
            
             // populate SecurityConfig
            var requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig = new Amazon.SageMaker.Model.AutoMLSecurityConfig();
            System.Boolean? requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption = null;
            if (cmdletContext.SecurityConfig_EnableInterContainerTrafficEncryption != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption = cmdletContext.SecurityConfig_EnableInterContainerTrafficEncryption.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig.EnableInterContainerTrafficEncryption = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption.Value;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = false;
            }
            System.String requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId = null;
            if (cmdletContext.SecurityConfig_VolumeKmsKeyId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId = cmdletContext.SecurityConfig_VolumeKmsKeyId;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig.VolumeKmsKeyId = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = false;
            }
            Amazon.SageMaker.Model.VpcConfig requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig.SecurityGroupIds = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig.Subnets = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig.VpcConfig = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig != null)
            {
                request.AutoMLJobConfig.SecurityConfig = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig;
                requestAutoMLJobConfigIsNull = false;
            }
             // determine if request.AutoMLJobConfig should be set to null
            if (requestAutoMLJobConfigIsNull)
            {
                request.AutoMLJobConfig = null;
            }
            if (cmdletContext.AutoMLJobName != null)
            {
                request.AutoMLJobName = cmdletContext.AutoMLJobName;
            }
            
             // populate AutoMLJobObjective
            var requestAutoMLJobObjectiveIsNull = true;
            request.AutoMLJobObjective = new Amazon.SageMaker.Model.AutoMLJobObjective();
            Amazon.SageMaker.AutoMLMetricEnum requestAutoMLJobObjective_autoMLJobObjective_MetricName = null;
            if (cmdletContext.AutoMLJobObjective_MetricName != null)
            {
                requestAutoMLJobObjective_autoMLJobObjective_MetricName = cmdletContext.AutoMLJobObjective_MetricName;
            }
            if (requestAutoMLJobObjective_autoMLJobObjective_MetricName != null)
            {
                request.AutoMLJobObjective.MetricName = requestAutoMLJobObjective_autoMLJobObjective_MetricName;
                requestAutoMLJobObjectiveIsNull = false;
            }
             // determine if request.AutoMLJobObjective should be set to null
            if (requestAutoMLJobObjectiveIsNull)
            {
                request.AutoMLJobObjective = null;
            }
            if (cmdletContext.GenerateCandidateDefinitionsOnly != null)
            {
                request.GenerateCandidateDefinitionsOnly = cmdletContext.GenerateCandidateDefinitionsOnly.Value;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            
             // populate ModelDeployConfig
            var requestModelDeployConfigIsNull = true;
            request.ModelDeployConfig = new Amazon.SageMaker.Model.ModelDeployConfig();
            System.Boolean? requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName = null;
            if (cmdletContext.ModelDeployConfig_AutoGenerateEndpointName != null)
            {
                requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName = cmdletContext.ModelDeployConfig_AutoGenerateEndpointName.Value;
            }
            if (requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName != null)
            {
                request.ModelDeployConfig.AutoGenerateEndpointName = requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName.Value;
                requestModelDeployConfigIsNull = false;
            }
            System.String requestModelDeployConfig_modelDeployConfig_EndpointName = null;
            if (cmdletContext.ModelDeployConfig_EndpointName != null)
            {
                requestModelDeployConfig_modelDeployConfig_EndpointName = cmdletContext.ModelDeployConfig_EndpointName;
            }
            if (requestModelDeployConfig_modelDeployConfig_EndpointName != null)
            {
                request.ModelDeployConfig.EndpointName = requestModelDeployConfig_modelDeployConfig_EndpointName;
                requestModelDeployConfigIsNull = false;
            }
             // determine if request.ModelDeployConfig should be set to null
            if (requestModelDeployConfigIsNull)
            {
                request.ModelDeployConfig = null;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.SageMaker.Model.AutoMLOutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_KmsKeyId = null;
            if (cmdletContext.OutputDataConfig_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_KmsKeyId = cmdletContext.OutputDataConfig_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_KmsKeyId != null)
            {
                request.OutputDataConfig.KmsKeyId = requestOutputDataConfig_outputDataConfig_KmsKeyId;
                requestOutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3OutputPath = null;
            if (cmdletContext.OutputDataConfig_S3OutputPath != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputPath = cmdletContext.OutputDataConfig_S3OutputPath;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputPath != null)
            {
                request.OutputDataConfig.S3OutputPath = requestOutputDataConfig_outputDataConfig_S3OutputPath;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.ProblemType != null)
            {
                request.ProblemType = cmdletContext.ProblemType;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.SageMaker.Model.CreateAutoMLJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAutoMLJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAutoMLJob");
            try
            {
                #if DESKTOP
                return client.CreateAutoMLJob(request);
                #elif CORECLR
                return client.CreateAutoMLJobAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.Boolean? SecurityConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.String SecurityConfig_VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String AutoMLJobName { get; set; }
            public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
            public System.Boolean? GenerateCandidateDefinitionsOnly { get; set; }
            public List<Amazon.SageMaker.Model.AutoMLChannel> InputDataConfig { get; set; }
            public System.Boolean? ModelDeployConfig_AutoGenerateEndpointName { get; set; }
            public System.String ModelDeployConfig_EndpointName { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3OutputPath { get; set; }
            public Amazon.SageMaker.ProblemType ProblemType { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAutoMLJobResponse, NewSMAutoMLJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoMLJobArn;
        }
        
    }
}
