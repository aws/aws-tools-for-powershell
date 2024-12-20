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
    /// Creates a job that optimizes a model for inference performance. To create the job,
    /// you provide the location of a source model, and you provide the settings for the optimization
    /// techniques that you want the job to apply. When the job completes successfully, SageMaker
    /// uploads the new optimized model to the output destination that you specify.
    /// 
    ///  
    /// <para>
    /// For more information about how to use this action, and about the supported optimization
    /// techniques, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-optimize.html">Optimize
    /// model inference with Amazon SageMaker</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMOptimizationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateOptimizationJob API operation.", Operation = new[] {"CreateOptimizationJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateOptimizationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateOptimizationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateOptimizationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMOptimizationJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ModelAccessConfig_AcceptEula
        /// <summary>
        /// <para>
        /// <para>Specifies agreement to the model end-user license agreement (EULA). The <c>AcceptEula</c>
        /// value must be explicitly defined as <c>True</c> in order to accept the EULA that this
        /// model requires. You are responsible for reviewing and complying with any applicable
        /// license terms and making sure they are acceptable for your use case before downloading
        /// or using a model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelSource_S3_ModelAccessConfig_AcceptEula")]
        public System.Boolean? ModelAccessConfig_AcceptEula { get; set; }
        #endregion
        
        #region Parameter DeploymentInstanceType
        /// <summary>
        /// <para>
        /// <para>The type of instance that hosts the optimized model that you create with the optimization
        /// job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.OptimizationJobDeploymentInstanceType")]
        public Amazon.SageMaker.OptimizationJobDeploymentInstanceType DeploymentInstanceType { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a key in Amazon Web Services KMS. SageMaker uses
        /// they key to encrypt the artifacts of the optimized model when SageMaker uploads the
        /// model to Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxPendingTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a training or compilation job can be
        /// pending before it is stopped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxPendingTimeInSeconds")]
        public System.Int32? StoppingCondition_MaxPendingTimeInSecond { get; set; }
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
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
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
        [Alias("StoppingCondition_MaxWaitTimeInSeconds")]
        public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
        #endregion
        
        #region Parameter OptimizationConfig
        /// <summary>
        /// <para>
        /// <para>Settings for each of the optimization techniques that the job applies.</para>
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
        [Alias("OptimizationConfigs")]
        public Amazon.SageMaker.Model.OptimizationConfig[] OptimizationConfig { get; set; }
        #endregion
        
        #region Parameter OptimizationEnvironment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the model container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable OptimizationEnvironment { get; set; }
        #endregion
        
        #region Parameter OptimizationJobName
        /// <summary>
        /// <para>
        /// <para>A custom name for the new optimization job.</para>
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
        public System.String OptimizationJobName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker AI to
        /// perform tasks on your behalf. </para><para>During model optimization, Amazon SageMaker AI needs your permission to:</para><ul><li><para>Read input data from an S3 bucket</para></li><li><para>Write model artifacts to an S3 bucket</para></li><li><para>Write logs to Amazon CloudWatch Logs</para></li><li><para>Publish metrics to Amazon CloudWatch</para></li></ul><para>You grant permissions for all of these tasks to an IAM role. To pass this role to
        /// Amazon SageMaker AI, the caller of this API must have the <c>iam:PassRole</c> permission.
        /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">Amazon
        /// SageMaker AI Roles.</a></para>
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
        
        #region Parameter OutputConfig_S3OutputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for where to store the optimized model that you create with an optimization
        /// job.</para>
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
        public System.String OutputConfig_S3OutputLocation { get; set; }
        #endregion
        
        #region Parameter S3_S3Uri
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 URI that locates a source model to optimize with an optimization job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelSource_S3_S3Uri")]
        public System.String S3_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your optimized model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs associated with the optimization job. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OptimizationJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateOptimizationJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateOptimizationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OptimizationJobArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMOptimizationJob (CreateOptimizationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateOptimizationJobResponse, NewSMOptimizationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentInstanceType = this.DeploymentInstanceType;
            #if MODULAR
            if (this.DeploymentInstanceType == null && ParameterWasBound(nameof(this.DeploymentInstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentInstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelAccessConfig_AcceptEula = this.ModelAccessConfig_AcceptEula;
            context.S3_S3Uri = this.S3_S3Uri;
            if (this.OptimizationConfig != null)
            {
                context.OptimizationConfig = new List<Amazon.SageMaker.Model.OptimizationConfig>(this.OptimizationConfig);
            }
            #if MODULAR
            if (this.OptimizationConfig == null && ParameterWasBound(nameof(this.OptimizationConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter OptimizationConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OptimizationEnvironment != null)
            {
                context.OptimizationEnvironment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OptimizationEnvironment.Keys)
                {
                    context.OptimizationEnvironment.Add((String)hashKey, (System.String)(this.OptimizationEnvironment[hashKey]));
                }
            }
            context.OptimizationJobName = this.OptimizationJobName;
            #if MODULAR
            if (this.OptimizationJobName == null && ParameterWasBound(nameof(this.OptimizationJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter OptimizationJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            #if MODULAR
            if (this.OutputConfig_S3OutputLocation == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingCondition_MaxPendingTimeInSecond = this.StoppingCondition_MaxPendingTimeInSecond;
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            context.StoppingCondition_MaxWaitTimeInSecond = this.StoppingCondition_MaxWaitTimeInSecond;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.SageMaker.Model.CreateOptimizationJobRequest();
            
            if (cmdletContext.DeploymentInstanceType != null)
            {
                request.DeploymentInstanceType = cmdletContext.DeploymentInstanceType;
            }
            
             // populate ModelSource
            var requestModelSourceIsNull = true;
            request.ModelSource = new Amazon.SageMaker.Model.OptimizationJobModelSource();
            Amazon.SageMaker.Model.OptimizationJobModelSourceS3 requestModelSource_modelSource_S3 = null;
            
             // populate S3
            var requestModelSource_modelSource_S3IsNull = true;
            requestModelSource_modelSource_S3 = new Amazon.SageMaker.Model.OptimizationJobModelSourceS3();
            System.String requestModelSource_modelSource_S3_s3_S3Uri = null;
            if (cmdletContext.S3_S3Uri != null)
            {
                requestModelSource_modelSource_S3_s3_S3Uri = cmdletContext.S3_S3Uri;
            }
            if (requestModelSource_modelSource_S3_s3_S3Uri != null)
            {
                requestModelSource_modelSource_S3.S3Uri = requestModelSource_modelSource_S3_s3_S3Uri;
                requestModelSource_modelSource_S3IsNull = false;
            }
            Amazon.SageMaker.Model.OptimizationModelAccessConfig requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig = null;
            
             // populate ModelAccessConfig
            var requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfigIsNull = true;
            requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig = new Amazon.SageMaker.Model.OptimizationModelAccessConfig();
            System.Boolean? requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig_modelAccessConfig_AcceptEula = null;
            if (cmdletContext.ModelAccessConfig_AcceptEula != null)
            {
                requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig_modelAccessConfig_AcceptEula = cmdletContext.ModelAccessConfig_AcceptEula.Value;
            }
            if (requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig_modelAccessConfig_AcceptEula != null)
            {
                requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig.AcceptEula = requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig_modelAccessConfig_AcceptEula.Value;
                requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfigIsNull = false;
            }
             // determine if requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig should be set to null
            if (requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfigIsNull)
            {
                requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig = null;
            }
            if (requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig != null)
            {
                requestModelSource_modelSource_S3.ModelAccessConfig = requestModelSource_modelSource_S3_modelSource_S3_ModelAccessConfig;
                requestModelSource_modelSource_S3IsNull = false;
            }
             // determine if requestModelSource_modelSource_S3 should be set to null
            if (requestModelSource_modelSource_S3IsNull)
            {
                requestModelSource_modelSource_S3 = null;
            }
            if (requestModelSource_modelSource_S3 != null)
            {
                request.ModelSource.S3 = requestModelSource_modelSource_S3;
                requestModelSourceIsNull = false;
            }
             // determine if request.ModelSource should be set to null
            if (requestModelSourceIsNull)
            {
                request.ModelSource = null;
            }
            if (cmdletContext.OptimizationConfig != null)
            {
                request.OptimizationConfigs = cmdletContext.OptimizationConfig;
            }
            if (cmdletContext.OptimizationEnvironment != null)
            {
                request.OptimizationEnvironment = cmdletContext.OptimizationEnvironment;
            }
            if (cmdletContext.OptimizationJobName != null)
            {
                request.OptimizationJobName = cmdletContext.OptimizationJobName;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.OptimizationJobOutputConfig();
            System.String requestOutputConfig_outputConfig_KmsKeyId = null;
            if (cmdletContext.OutputConfig_KmsKeyId != null)
            {
                requestOutputConfig_outputConfig_KmsKeyId = cmdletContext.OutputConfig_KmsKeyId;
            }
            if (requestOutputConfig_outputConfig_KmsKeyId != null)
            {
                request.OutputConfig.KmsKeyId = requestOutputConfig_outputConfig_KmsKeyId;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3OutputLocation = null;
            if (cmdletContext.OutputConfig_S3OutputLocation != null)
            {
                requestOutputConfig_outputConfig_S3OutputLocation = cmdletContext.OutputConfig_S3OutputLocation;
            }
            if (requestOutputConfig_outputConfig_S3OutputLocation != null)
            {
                request.OutputConfig.S3OutputLocation = requestOutputConfig_outputConfig_S3OutputLocation;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingCondition
            var requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.SageMaker.Model.StoppingCondition();
            System.Int32? requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxPendingTimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond = cmdletContext.StoppingCondition_MaxPendingTimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond != null)
            {
                request.StoppingCondition.MaxPendingTimeInSeconds = requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond.Value;
                requestStoppingConditionIsNull = false;
            }
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
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.SageMaker.Model.OptimizationVpcConfig();
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
        
        private Amazon.SageMaker.Model.CreateOptimizationJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateOptimizationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateOptimizationJob");
            try
            {
                #if DESKTOP
                return client.CreateOptimizationJob(request);
                #elif CORECLR
                return client.CreateOptimizationJobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.OptimizationJobDeploymentInstanceType DeploymentInstanceType { get; set; }
            public System.Boolean? ModelAccessConfig_AcceptEula { get; set; }
            public System.String S3_S3Uri { get; set; }
            public List<Amazon.SageMaker.Model.OptimizationConfig> OptimizationConfig { get; set; }
            public Dictionary<System.String, System.String> OptimizationEnvironment { get; set; }
            public System.String OptimizationJobName { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String OutputConfig_S3OutputLocation { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxPendingTimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateOptimizationJobResponse, NewSMOptimizationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OptimizationJobArn;
        }
        
    }
}
