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
using System.Threading;
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Creates a new model transform job. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/machine-learning-model-transform.html">Use
    /// a trained model to generate new model artifacts</a>.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#startmlmodeltransformjob">neptune-db:StartMLModelTransformJob</a>
    /// IAM action in that cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "NEPTMLModelTransformJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptunedata.Model.StartMLModelTransformJobResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData StartMLModelTransformJob API operation.", Operation = new[] {"StartMLModelTransformJob"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.StartMLModelTransformJobResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.StartMLModelTransformJobResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.StartMLModelTransformJobResponse object containing multiple properties."
    )]
    public partial class StartNEPTMLModelTransformJobCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BaseProcessingInstanceType
        /// <summary>
        /// <para>
        /// <para>The type of ML instance used in preparing and managing training of ML models. This
        /// is an ML compute instance chosen based on memory requirements for processing the training
        /// data and model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BaseProcessingInstanceType { get; set; }
        #endregion
        
        #region Parameter BaseProcessingInstanceVolumeSizeInGB
        /// <summary>
        /// <para>
        /// <para>The disk volume size of the training instance in gigabytes. The default is 0. Both
        /// input data and the output model are stored on disk, so the volume size must be large
        /// enough to hold both data sets. If not specified or 0, Neptune ML selects a disk volume
        /// size based on the recommendation generated in the data processing step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BaseProcessingInstanceVolumeSizeInGB { get; set; }
        #endregion
        
        #region Parameter DataProcessingJobId
        /// <summary>
        /// <para>
        /// <para>The job ID of a completed data-processing job. You must include either <c>dataProcessingJobId</c>
        /// and a <c>mlModelTrainingJobId</c>, or a <c>trainingJobName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataProcessingJobId { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the new job. The default is an autogenerated UUID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter MlModelTrainingJobId
        /// <summary>
        /// <para>
        /// <para>The job ID of a completed model-training job. You must include either <c>dataProcessingJobId</c>
        /// and a <c>mlModelTrainingJobId</c>, or a <c>trainingJobName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MlModelTrainingJobId { get; set; }
        #endregion
        
        #region Parameter ModelTransformOutputS3Location
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where the model artifacts are to be stored.</para>
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
        public System.String ModelTransformOutputS3Location { get; set; }
        #endregion
        
        #region Parameter NeptuneIamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that provides Neptune access to SageMaker and Amazon S3 resources.
        /// This must be listed in your DB cluster parameter group or an error will occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NeptuneIamRoleArn { get; set; }
        #endregion
        
        #region Parameter S3OutputEncryptionKMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Key Management Service (KMS) key that SageMaker uses to encrypt the output
        /// of the processing job. The default is none.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3OutputEncryptionKMSKey { get; set; }
        #endregion
        
        #region Parameter SagemakerIamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role for SageMaker execution. This must be listed in your DB cluster
        /// parameter group or an error will occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SagemakerIamRoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs. The default is None.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter CustomModelTransformParameters_SourceS3DirectoryPath
        /// <summary>
        /// <para>
        /// <para>The path to the Amazon S3 location where the Python module implementing your model
        /// is located. This must point to a valid existing Amazon S3 location that contains,
        /// at a minimum, a training script, a transform script, and a <c>model-hpo-configuration.json</c>
        /// file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomModelTransformParameters_SourceS3DirectoryPath { get; set; }
        #endregion
        
        #region Parameter Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets in the Neptune VPC. The default is None.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter TrainingJobName
        /// <summary>
        /// <para>
        /// <para>The name of a completed SageMaker training job. You must include either <c>dataProcessingJobId</c>
        /// and a <c>mlModelTrainingJobId</c>, or a <c>trainingJobName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingJobName { get; set; }
        #endregion
        
        #region Parameter CustomModelTransformParameters_TransformEntryPointScript
        /// <summary>
        /// <para>
        /// <para>The name of the entry point in your module of a script that should be run after the
        /// best model from the hyperparameter search has been identified, to compute the model
        /// artifacts necessary for model deployment. It should be able to run with no command-line
        /// arguments. The default is <c>transform.py</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomModelTransformParameters_TransformEntryPointScript { get; set; }
        #endregion
        
        #region Parameter VolumeEncryptionKMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Key Management Service (KMS) key that SageMaker uses to encrypt data on
        /// the storage volume attached to the ML compute instances that run the training job.
        /// The default is None.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VolumeEncryptionKMSKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.StartMLModelTransformJobResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.StartMLModelTransformJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NEPTMLModelTransformJob (StartMLModelTransformJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.StartMLModelTransformJobResponse, StartNEPTMLModelTransformJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseProcessingInstanceType = this.BaseProcessingInstanceType;
            context.BaseProcessingInstanceVolumeSizeInGB = this.BaseProcessingInstanceVolumeSizeInGB;
            context.CustomModelTransformParameters_SourceS3DirectoryPath = this.CustomModelTransformParameters_SourceS3DirectoryPath;
            context.CustomModelTransformParameters_TransformEntryPointScript = this.CustomModelTransformParameters_TransformEntryPointScript;
            context.DataProcessingJobId = this.DataProcessingJobId;
            context.Id = this.Id;
            context.MlModelTrainingJobId = this.MlModelTrainingJobId;
            context.ModelTransformOutputS3Location = this.ModelTransformOutputS3Location;
            #if MODULAR
            if (this.ModelTransformOutputS3Location == null && ParameterWasBound(nameof(this.ModelTransformOutputS3Location)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelTransformOutputS3Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NeptuneIamRoleArn = this.NeptuneIamRoleArn;
            context.S3OutputEncryptionKMSKey = this.S3OutputEncryptionKMSKey;
            context.SagemakerIamRoleArn = this.SagemakerIamRoleArn;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            if (this.Subnet != null)
            {
                context.Subnet = new List<System.String>(this.Subnet);
            }
            context.TrainingJobName = this.TrainingJobName;
            context.VolumeEncryptionKMSKey = this.VolumeEncryptionKMSKey;
            
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
            var request = new Amazon.Neptunedata.Model.StartMLModelTransformJobRequest();
            
            if (cmdletContext.BaseProcessingInstanceType != null)
            {
                request.BaseProcessingInstanceType = cmdletContext.BaseProcessingInstanceType;
            }
            if (cmdletContext.BaseProcessingInstanceVolumeSizeInGB != null)
            {
                request.BaseProcessingInstanceVolumeSizeInGB = cmdletContext.BaseProcessingInstanceVolumeSizeInGB.Value;
            }
            
             // populate CustomModelTransformParameters
            var requestCustomModelTransformParametersIsNull = true;
            request.CustomModelTransformParameters = new Amazon.Neptunedata.Model.CustomModelTransformParameters();
            System.String requestCustomModelTransformParameters_customModelTransformParameters_SourceS3DirectoryPath = null;
            if (cmdletContext.CustomModelTransformParameters_SourceS3DirectoryPath != null)
            {
                requestCustomModelTransformParameters_customModelTransformParameters_SourceS3DirectoryPath = cmdletContext.CustomModelTransformParameters_SourceS3DirectoryPath;
            }
            if (requestCustomModelTransformParameters_customModelTransformParameters_SourceS3DirectoryPath != null)
            {
                request.CustomModelTransformParameters.SourceS3DirectoryPath = requestCustomModelTransformParameters_customModelTransformParameters_SourceS3DirectoryPath;
                requestCustomModelTransformParametersIsNull = false;
            }
            System.String requestCustomModelTransformParameters_customModelTransformParameters_TransformEntryPointScript = null;
            if (cmdletContext.CustomModelTransformParameters_TransformEntryPointScript != null)
            {
                requestCustomModelTransformParameters_customModelTransformParameters_TransformEntryPointScript = cmdletContext.CustomModelTransformParameters_TransformEntryPointScript;
            }
            if (requestCustomModelTransformParameters_customModelTransformParameters_TransformEntryPointScript != null)
            {
                request.CustomModelTransformParameters.TransformEntryPointScript = requestCustomModelTransformParameters_customModelTransformParameters_TransformEntryPointScript;
                requestCustomModelTransformParametersIsNull = false;
            }
             // determine if request.CustomModelTransformParameters should be set to null
            if (requestCustomModelTransformParametersIsNull)
            {
                request.CustomModelTransformParameters = null;
            }
            if (cmdletContext.DataProcessingJobId != null)
            {
                request.DataProcessingJobId = cmdletContext.DataProcessingJobId;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.MlModelTrainingJobId != null)
            {
                request.MlModelTrainingJobId = cmdletContext.MlModelTrainingJobId;
            }
            if (cmdletContext.ModelTransformOutputS3Location != null)
            {
                request.ModelTransformOutputS3Location = cmdletContext.ModelTransformOutputS3Location;
            }
            if (cmdletContext.NeptuneIamRoleArn != null)
            {
                request.NeptuneIamRoleArn = cmdletContext.NeptuneIamRoleArn;
            }
            if (cmdletContext.S3OutputEncryptionKMSKey != null)
            {
                request.S3OutputEncryptionKMSKey = cmdletContext.S3OutputEncryptionKMSKey;
            }
            if (cmdletContext.SagemakerIamRoleArn != null)
            {
                request.SagemakerIamRoleArn = cmdletContext.SagemakerIamRoleArn;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.Subnet != null)
            {
                request.Subnets = cmdletContext.Subnet;
            }
            if (cmdletContext.TrainingJobName != null)
            {
                request.TrainingJobName = cmdletContext.TrainingJobName;
            }
            if (cmdletContext.VolumeEncryptionKMSKey != null)
            {
                request.VolumeEncryptionKMSKey = cmdletContext.VolumeEncryptionKMSKey;
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
        
        private Amazon.Neptunedata.Model.StartMLModelTransformJobResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.StartMLModelTransformJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "StartMLModelTransformJob");
            try
            {
                return client.StartMLModelTransformJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BaseProcessingInstanceType { get; set; }
            public System.Int32? BaseProcessingInstanceVolumeSizeInGB { get; set; }
            public System.String CustomModelTransformParameters_SourceS3DirectoryPath { get; set; }
            public System.String CustomModelTransformParameters_TransformEntryPointScript { get; set; }
            public System.String DataProcessingJobId { get; set; }
            public System.String Id { get; set; }
            public System.String MlModelTrainingJobId { get; set; }
            public System.String ModelTransformOutputS3Location { get; set; }
            public System.String NeptuneIamRoleArn { get; set; }
            public System.String S3OutputEncryptionKMSKey { get; set; }
            public System.String SagemakerIamRoleArn { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> Subnet { get; set; }
            public System.String TrainingJobName { get; set; }
            public System.String VolumeEncryptionKMSKey { get; set; }
            public System.Func<Amazon.Neptunedata.Model.StartMLModelTransformJobResponse, StartNEPTMLModelTransformJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
