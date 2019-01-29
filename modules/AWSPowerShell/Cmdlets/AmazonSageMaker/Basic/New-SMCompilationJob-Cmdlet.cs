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
    /// Starts a model compilation job. After the model has been compiled, Amazon SageMaker
    /// saves the resulting model artifacts to an Amazon Simple Storage Service (Amazon S3)
    /// bucket that you specify. 
    /// 
    ///  
    /// <para>
    /// If you choose to host your model using Amazon SageMaker hosting services, you can
    /// use the resulting model artifacts as part of the model. You can also use the artifacts
    /// with AWS IoT Greengrass. In that case, deploy them as an ML resource.
    /// </para><para>
    /// In the request body, you provide the following:
    /// </para><ul><li><para>
    /// A name for the compilation job
    /// </para></li><li><para>
    ///  Information about the input model artifacts 
    /// </para></li><li><para>
    /// The output location for the compiled model and the device (target) that the model
    /// runs on 
    /// </para></li><li><para><code>The Amazon Resource Name (ARN) of the IAM role that Amazon SageMaker assumes
    /// to perform the model compilation job</code></para></li></ul><para>
    /// You can also provide a <code>Tag</code> to track the model compilation job's resource
    /// use and costs. The response body contains the <code>CompilationJobArn</code> for the
    /// compiled job.
    /// </para><para>
    /// To stop a model compilation job, use <a>StopCompilationJob</a>. To get information
    /// about a particular model compilation job, use <a>DescribeCompilationJob</a>. To get
    /// information about multiple model compilation jobs, use <a>ListCompilationJobs</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMCompilationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateCompilationJob API operation.", Operation = new[] {"CreateCompilationJob"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateCompilationJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMCompilationJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter CompilationJobName
        /// <summary>
        /// <para>
        /// <para>A name for the model compilation job. The name must be unique within the AWS Region
        /// and within your AWS account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CompilationJobName { get; set; }
        #endregion
        
        #region Parameter InputConfig_DataInputConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the name and shape of the expected data inputs for your trained model with
        /// a JSON dictionary form. The data inputs are <a>InputConfig$Framework</a> specific.
        /// </para><ul><li><para><code>TensorFlow</code>: You must specify the name and shape (NHWC format) of the
        /// expected data inputs using a dictionary format for your trained model. The dictionary
        /// formats required for the console and CLI are different.</para><ul><li><para>Examples for one input:</para><ul><li><para>If using the console, <code>{"input":[1,1024,1024,3]}</code></para></li><li><para>If using the CLI, <code>{\"input\":[1,1024,1024,3]}</code></para></li></ul></li><li><para>Examples for two inputs:</para><ul><li><para>If using the console, <code>{"data1": [1,28,28,1], "data2":[1,28,28,1]}</code></para></li><li><para>If using the CLI, <code>{\"data1\": [1,28,28,1], \"data2\":[1,28,28,1]}</code></para></li></ul></li></ul></li><li><para><code>MXNET/ONNX</code>: You must specify the name and shape (NCHW format) of the
        /// expected data inputs in order using a dictionary format for your trained model. The
        /// dictionary formats required for the console and CLI are different.</para><ul><li><para>Examples for one input:</para><ul><li><para>If using the console, <code>{"data":[1,3,1024,1024]}</code></para></li><li><para>If using the CLI, <code>{\"data\":[1,3,1024,1024]}</code></para></li></ul></li><li><para>Examples for two inputs:</para><ul><li><para>If using the console, <code>{"var1": [1,1,28,28], "var2":[1,1,28,28]} </code></para></li><li><para>If using the CLI, <code>{\"var1\": [1,1,28,28], \"var2\":[1,1,28,28]}</code></para></li></ul></li></ul></li><li><para><code>PyTorch</code>: You can either specify the name and shape (NCHW format) of
        /// expected data inputs in order using a dictionary format for your trained model or
        /// you can specify the shape only using a list format. The dictionary formats required
        /// for the console and CLI are different. The list formats for the console and CLI are
        /// the same.</para><ul><li><para>Examples for one input in dictionary format:</para><ul><li><para>If using the console, <code>{"input0":[1,3,224,224]}</code></para></li><li><para>If using the CLI, <code>{\"input0\":[1,3,224,224]}</code></para></li></ul></li><li><para>Example for one input in list format: <code>[[1,3,224,224]]</code></para></li><li><para>Examples for two inputs in dictionary format:</para><ul><li><para>If using the console, <code>{"input0":[1,3,224,224], "input1":[1,3,224,224]}</code></para></li><li><para>If using the CLI, <code>{\"input0\":[1,3,224,224], \"input1\":[1,3,224,224]} </code></para></li></ul></li><li><para>Example for two inputs in list format: <code>[[1,3,224,224], [1,3,224,224]]</code></para></li></ul></li><li><para><code>XGBOOST</code>: input data name and shape are not needed.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InputConfig_DataInputConfig { get; set; }
        #endregion
        
        #region Parameter InputConfig_Framework
        /// <summary>
        /// <para>
        /// <para>Identifies the framework in which the model was trained. For example: TENSORFLOW.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.Framework")]
        public Amazon.SageMaker.Framework InputConfig_Framework { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that the training job can run. If model training
        /// does not complete during this time, Amazon SageMaker ends the job. If value is not
        /// specified, default value is 1 day. Maximum value is 28 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32 StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IIAMAM role that enables Amazon SageMaker to
        /// perform tasks on your behalf. </para><para>During model compilation, Amazon SageMaker needs your permission to:</para><ul><li><para>Read input data from an S3 bucket</para></li><li><para>Write model artifacts to an S3 bucket</para></li><li><para>Write logs to Amazon CloudWatch Logs</para></li><li><para>Publish metrics to Amazon CloudWatch</para></li></ul><para>You grant permissions for all of these tasks to an IAM role. To pass this role to
        /// Amazon SageMaker, the caller of this API must have the <code>iam:PassRole</code> permission.
        /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">Amazon
        /// SageMaker Roles.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3OutputLocation
        /// <summary>
        /// <para>
        /// <para>Identifies the S3 path where you want Amazon SageMaker to store the model artifacts.
        /// For example, s3://bucket-name/key-name-prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputConfig_S3OutputLocation { get; set; }
        #endregion
        
        #region Parameter InputConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 path where the model artifacts, which result from model training, are stored.
        /// This path must point to a single gzip compressed tar archive (.tar.gz suffix).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InputConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputConfig_TargetDevice
        /// <summary>
        /// <para>
        /// <para>Identifies the device that you want to run your model on after it has been compiled.
        /// For example: ml_c5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.TargetDevice")]
        public Amazon.SageMaker.TargetDevice OutputConfig_TargetDevice { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CompilationJobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCompilationJob (CreateCompilationJob)"))
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
            
            context.CompilationJobName = this.CompilationJobName;
            context.InputConfig_DataInputConfig = this.InputConfig_DataInputConfig;
            context.InputConfig_Framework = this.InputConfig_Framework;
            context.InputConfig_S3Uri = this.InputConfig_S3Uri;
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            context.OutputConfig_TargetDevice = this.OutputConfig_TargetDevice;
            context.RoleArn = this.RoleArn;
            if (ParameterWasBound("StoppingCondition_MaxRuntimeInSecond"))
                context.StoppingCondition_MaxRuntimeInSeconds = this.StoppingCondition_MaxRuntimeInSecond;
            
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
            var request = new Amazon.SageMaker.Model.CreateCompilationJobRequest();
            
            if (cmdletContext.CompilationJobName != null)
            {
                request.CompilationJobName = cmdletContext.CompilationJobName;
            }
            
             // populate InputConfig
            bool requestInputConfigIsNull = true;
            request.InputConfig = new Amazon.SageMaker.Model.InputConfig();
            System.String requestInputConfig_inputConfig_DataInputConfig = null;
            if (cmdletContext.InputConfig_DataInputConfig != null)
            {
                requestInputConfig_inputConfig_DataInputConfig = cmdletContext.InputConfig_DataInputConfig;
            }
            if (requestInputConfig_inputConfig_DataInputConfig != null)
            {
                request.InputConfig.DataInputConfig = requestInputConfig_inputConfig_DataInputConfig;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Framework requestInputConfig_inputConfig_Framework = null;
            if (cmdletContext.InputConfig_Framework != null)
            {
                requestInputConfig_inputConfig_Framework = cmdletContext.InputConfig_Framework;
            }
            if (requestInputConfig_inputConfig_Framework != null)
            {
                request.InputConfig.Framework = requestInputConfig_inputConfig_Framework;
                requestInputConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_S3Uri = null;
            if (cmdletContext.InputConfig_S3Uri != null)
            {
                requestInputConfig_inputConfig_S3Uri = cmdletContext.InputConfig_S3Uri;
            }
            if (requestInputConfig_inputConfig_S3Uri != null)
            {
                request.InputConfig.S3Uri = requestInputConfig_inputConfig_S3Uri;
                requestInputConfigIsNull = false;
            }
             // determine if request.InputConfig should be set to null
            if (requestInputConfigIsNull)
            {
                request.InputConfig = null;
            }
            
             // populate OutputConfig
            bool requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.OutputConfig();
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
            Amazon.SageMaker.TargetDevice requestOutputConfig_outputConfig_TargetDevice = null;
            if (cmdletContext.OutputConfig_TargetDevice != null)
            {
                requestOutputConfig_outputConfig_TargetDevice = cmdletContext.OutputConfig_TargetDevice;
            }
            if (requestOutputConfig_outputConfig_TargetDevice != null)
            {
                request.OutputConfig.TargetDevice = requestOutputConfig_outputConfig_TargetDevice;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CompilationJobArn;
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
        
        private Amazon.SageMaker.Model.CreateCompilationJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateCompilationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateCompilationJob");
            try
            {
                #if DESKTOP
                return client.CreateCompilationJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCompilationJobAsync(request);
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
            public System.String CompilationJobName { get; set; }
            public System.String InputConfig_DataInputConfig { get; set; }
            public Amazon.SageMaker.Framework InputConfig_Framework { get; set; }
            public System.String InputConfig_S3Uri { get; set; }
            public System.String OutputConfig_S3OutputLocation { get; set; }
            public Amazon.SageMaker.TargetDevice OutputConfig_TargetDevice { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSeconds { get; set; }
        }
        
    }
}
