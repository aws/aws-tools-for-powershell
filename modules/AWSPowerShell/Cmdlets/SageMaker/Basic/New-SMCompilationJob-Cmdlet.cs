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
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateCompilationJob API operation.", Operation = new[] {"CreateCompilationJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateCompilationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateCompilationJobResponse",
        "This cmdlet returns a System.String object.",
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InputConfig_DataInputConfig { get; set; }
        #endregion
        
        #region Parameter InputConfig_Framework
        /// <summary>
        /// <para>
        /// <para>Identifies the framework in which the model was trained. For example: TENSORFLOW.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.Framework")]
        public Amazon.SageMaker.Framework InputConfig_Framework { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that the training or compilation job can run.
        /// If job does not complete during this time, Amazon SageMaker ends the job. If value
        /// is not specified, default value is 1 day. The maximum value is 28 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxWaitTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, how long you are willing to wait for a managed
        /// spot training job to complete. It is the amount of time spent waiting for Spot capacity
        /// plus the amount of time the training job runs. It must be equal to or greater than
        /// <code>MaxRuntimeInSeconds</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxWaitTimeInSeconds")]
        public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker to perform
        /// tasks on your behalf. </para><para>During model compilation, Amazon SageMaker needs your permission to:</para><ul><li><para>Read input data from an S3 bucket</para></li><li><para>Write model artifacts to an S3 bucket</para></li><li><para>Write logs to Amazon CloudWatch Logs</para></li><li><para>Publish metrics to Amazon CloudWatch</para></li></ul><para>You grant permissions for all of these tasks to an IAM role. To pass this role to
        /// Amazon SageMaker, the caller of this API must have the <code>iam:PassRole</code> permission.
        /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">Amazon
        /// SageMaker Roles.</a></para>
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
        /// <para>Identifies the S3 path where you want Amazon SageMaker to store the model artifacts.
        /// For example, s3://bucket-name/key-name-prefix.</para>
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
        
        #region Parameter InputConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 path where the model artifacts, which result from model training, are stored.
        /// This path must point to a single gzip compressed tar archive (.tar.gz suffix).</para>
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
        public System.String InputConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputConfig_TargetDevice
        /// <summary>
        /// <para>
        /// <para>Identifies the device that you want to run your model on after it has been compiled.
        /// For example: ml_c5.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.TargetDevice")]
        public Amazon.SageMaker.TargetDevice OutputConfig_TargetDevice { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CompilationJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateCompilationJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateCompilationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CompilationJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CompilationJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CompilationJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CompilationJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CompilationJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCompilationJob (CreateCompilationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateCompilationJobResponse, NewSMCompilationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CompilationJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CompilationJobName = this.CompilationJobName;
            #if MODULAR
            if (this.CompilationJobName == null && ParameterWasBound(nameof(this.CompilationJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter CompilationJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputConfig_DataInputConfig = this.InputConfig_DataInputConfig;
            #if MODULAR
            if (this.InputConfig_DataInputConfig == null && ParameterWasBound(nameof(this.InputConfig_DataInputConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfig_DataInputConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputConfig_Framework = this.InputConfig_Framework;
            #if MODULAR
            if (this.InputConfig_Framework == null && ParameterWasBound(nameof(this.InputConfig_Framework)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfig_Framework which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputConfig_S3Uri = this.InputConfig_S3Uri;
            #if MODULAR
            if (this.InputConfig_S3Uri == null && ParameterWasBound(nameof(this.InputConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            #if MODULAR
            if (this.OutputConfig_S3OutputLocation == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_TargetDevice = this.OutputConfig_TargetDevice;
            #if MODULAR
            if (this.OutputConfig_TargetDevice == null && ParameterWasBound(nameof(this.OutputConfig_TargetDevice)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_TargetDevice which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            context.StoppingCondition_MaxWaitTimeInSecond = this.StoppingCondition_MaxWaitTimeInSecond;
            
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
            var requestInputConfigIsNull = true;
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
            var requestOutputConfigIsNull = true;
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
        
        private Amazon.SageMaker.Model.CreateCompilationJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateCompilationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateCompilationJob");
            try
            {
                #if DESKTOP
                return client.CreateCompilationJob(request);
                #elif CORECLR
                return client.CreateCompilationJobAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateCompilationJobResponse, NewSMCompilationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CompilationJobArn;
        }
        
    }
}
