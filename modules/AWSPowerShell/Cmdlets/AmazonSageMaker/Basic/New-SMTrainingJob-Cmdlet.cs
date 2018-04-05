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
    /// Starts a model training job. After training completes, Amazon SageMaker saves the
    /// resulting model artifacts to an Amazon S3 location that you specify. 
    /// 
    ///  
    /// <para>
    /// If you choose to host your model using Amazon SageMaker hosting services, you can
    /// use the resulting model artifacts as part of the model. You can also use the artifacts
    /// in a deep learning service other than Amazon SageMaker, provided that you know how
    /// to use them for inferences. 
    /// </para><para>
    /// In the request body, you provide the following: 
    /// </para><ul><li><para><code>AlgorithmSpecification</code> - Identifies the training algorithm to use. 
    /// </para></li><li><para><code>HyperParameters</code> - Specify these algorithm-specific parameters to influence
    /// the quality of the final model. For a list of hyperparameters for each training algorithm
    /// provided by Amazon SageMaker, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
    /// 
    /// </para></li><li><para><code>InputDataConfig</code> - Describes the training dataset and the Amazon S3 location
    /// where it is stored.
    /// </para></li><li><para><code>OutputDataConfig</code> - Identifies the Amazon S3 location where you want
    /// Amazon SageMaker to save the results of model training. 
    /// </para></li><li><para><code>ResourceConfig</code> - Identifies the resources, ML compute instances, and
    /// ML storage volumes to deploy for model training. In distributed training, you specify
    /// more than one instance. 
    /// </para></li><li><para><code>RoleARN</code> - The Amazon Resource Number (ARN) that Amazon SageMaker assumes
    /// to perform tasks on your behalf during model training. You must grant this role the
    /// necessary permissions so that Amazon SageMaker can successfully complete model training.
    /// 
    /// </para></li><li><para><code>StoppingCondition</code> - Sets a duration for training. Use this parameter
    /// to cap model training costs. 
    /// </para></li></ul><para>
    ///  For more information about Amazon SageMaker, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/how-it-works.html">How
    /// It Works</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMTrainingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTrainingJob API operation.", Operation = new[] {"CreateTrainingJob"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTrainingJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMTrainingJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AlgorithmSpecification
        /// <summary>
        /// <para>
        /// <para>The registry path of the Docker image that contains the training algorithm and algorithm-specific
        /// metadata, including the input mode. For more information about algorithms provided
        /// by Amazon SageMaker, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
        /// For information about providing your own algorithms, see <a>your-algorithms</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.AlgorithmSpecification AlgorithmSpecification { get; set; }
        #endregion
        
        #region Parameter HyperParameter
        /// <summary>
        /// <para>
        /// <para>Algorithm-specific parameters. You set hyperparameters before you start the learning
        /// process. Hyperparameters influence the quality of the model. For a list of hyperparameters
        /// for each training algorithm provided by Amazon SageMaker, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/algos.html">Algorithms</a>.
        /// </para><para>You can specify a maximum of 100 hyperparameters. Each hyperparameter is a key-value
        /// pair. Each key and value is limited to 256 characters, as specified by the <code>Length
        /// Constraint</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HyperParameters")]
        public System.Collections.Hashtable HyperParameter { get; set; }
        #endregion
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of <code>Channel</code> objects. Each channel is a named input source. <code>InputDataConfig</code>
        /// describes the input data and its location. </para><para>Algorithms can accept input data from one or more channels. For example, an algorithm
        /// might have two channels of input data, <code>training_data</code> and <code>validation_data</code>.
        /// The configuration for each channel provides the S3 location where the input data is
        /// stored. It also provides information about the stored data: the MIME type, compression
        /// method, and whether the data is wrapped in RecordIO format. </para><para>Depending on the input mode that the algorithm supports, Amazon SageMaker either copies
        /// input data files from an S3 bucket to a local directory in the Docker container, or
        /// makes it available as input streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.Channel[] InputDataConfig { get; set; }
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
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32 StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the path to the S3 bucket where you want to store model artifacts. Amazon
        /// SageMaker creates subfolders for the artifacts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.OutputDataConfig OutputDataConfig { get; set; }
        #endregion
        
        #region Parameter ResourceConfig
        /// <summary>
        /// <para>
        /// <para>The resources, including the ML compute instances and ML storage volumes, to use for
        /// model training. </para><para>ML storage volumes store model artifacts and incremental states. Training algorithms
        /// might also use ML storage volumes for scratch space. If you want Amazon SageMaker
        /// to use the ML storage volume to store the training data, choose <code>File</code>
        /// as the <code>TrainingInputMode</code> in the algorithm specification. For distributed
        /// training algorithms, specify an instance count greater than 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.ResourceConfig ResourceConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that Amazon SageMaker can assume to
        /// perform tasks on your behalf. </para><para>During model training, Amazon SageMaker needs your permission to read input data from
        /// an S3 bucket, download a Docker image that contains training code, write model artifacts
        /// to an S3 bucket, write logs to Amazon CloudWatch Logs, and publish metrics to Amazon
        /// CloudWatch. You grant permissions for all of these tasks to an IAM role. For more
        /// information, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">Amazon
        /// SageMaker Roles</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. For more information, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i>AWS Billing and Cost Management User Guide</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingJobName
        /// <summary>
        /// <para>
        /// <para>The name of the training job. The name must be unique within an AWS Region in an AWS
        /// account. It appears in the Amazon SageMaker console. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TrainingJobName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TrainingJobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTrainingJob (CreateTrainingJob)"))
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
            
            context.AlgorithmSpecification = this.AlgorithmSpecification;
            if (this.HyperParameter != null)
            {
                context.HyperParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HyperParameter.Keys)
                {
                    context.HyperParameters.Add((String)hashKey, (String)(this.HyperParameter[hashKey]));
                }
            }
            if (this.InputDataConfig != null)
            {
                context.InputDataConfig = new List<Amazon.SageMaker.Model.Channel>(this.InputDataConfig);
            }
            context.OutputDataConfig = this.OutputDataConfig;
            context.ResourceConfig = this.ResourceConfig;
            context.RoleArn = this.RoleArn;
            if (ParameterWasBound("StoppingCondition_MaxRuntimeInSecond"))
                context.StoppingCondition_MaxRuntimeInSeconds = this.StoppingCondition_MaxRuntimeInSecond;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TrainingJobName = this.TrainingJobName;
            
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
            if (cmdletContext.HyperParameters != null)
            {
                request.HyperParameters = cmdletContext.HyperParameters;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            if (cmdletContext.OutputDataConfig != null)
            {
                request.OutputDataConfig = cmdletContext.OutputDataConfig;
            }
            if (cmdletContext.ResourceConfig != null)
            {
                request.ResourceConfig = cmdletContext.ResourceConfig;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingCondition
            bool requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.SageMaker.Model.StoppingCondition();
            System.Int32? requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxRuntimeInSeconds != null)
            {
                requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.StoppingCondition_MaxRuntimeInSeconds.Value;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TrainingJobName != null)
            {
                request.TrainingJobName = cmdletContext.TrainingJobName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TrainingJobArn;
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
        
        private Amazon.SageMaker.Model.CreateTrainingJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTrainingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTrainingJob");
            try
            {
                #if DESKTOP
                return client.CreateTrainingJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateTrainingJobAsync(request);
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
            public Amazon.SageMaker.Model.AlgorithmSpecification AlgorithmSpecification { get; set; }
            public Dictionary<System.String, System.String> HyperParameters { get; set; }
            public List<Amazon.SageMaker.Model.Channel> InputDataConfig { get; set; }
            public Amazon.SageMaker.Model.OutputDataConfig OutputDataConfig { get; set; }
            public Amazon.SageMaker.Model.ResourceConfig ResourceConfig { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSeconds { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tags { get; set; }
            public System.String TrainingJobName { get; set; }
        }
        
    }
}
