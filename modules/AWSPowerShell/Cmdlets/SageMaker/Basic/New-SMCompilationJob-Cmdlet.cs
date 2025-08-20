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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Starts a model compilation job. After the model has been compiled, Amazon SageMaker
    /// AI saves the resulting model artifacts to an Amazon Simple Storage Service (Amazon
    /// S3) bucket that you specify. 
    /// 
    ///  
    /// <para>
    /// If you choose to host your model using Amazon SageMaker AI hosting services, you can
    /// use the resulting model artifacts as part of the model. You can also use the artifacts
    /// with Amazon Web Services IoT Greengrass. In that case, deploy them as an ML resource.
    /// </para><para>
    /// In the request body, you provide the following:
    /// </para><ul><li><para>
    /// A name for the compilation job
    /// </para></li><li><para>
    ///  Information about the input model artifacts 
    /// </para></li><li><para>
    /// The output location for the compiled model and the device (target) that the model
    /// runs on 
    /// </para></li><li><para>
    /// The Amazon Resource Name (ARN) of the IAM role that Amazon SageMaker AI assumes to
    /// perform the model compilation job. 
    /// </para></li></ul><para>
    /// You can also provide a <c>Tag</c> to track the model compilation job's resource use
    /// and costs. The response body contains the <c>CompilationJobArn</c> for the compiled
    /// job.
    /// </para><para>
    /// To stop a model compilation job, use <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StopCompilationJob.html">StopCompilationJob</a>.
    /// To get information about a particular model compilation job, use <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeCompilationJob.html">DescribeCompilationJob</a>.
    /// To get information about multiple model compilation jobs, use <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ListCompilationJobs.html">ListCompilationJobs</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMCompilationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateCompilationJob API operation.", Operation = new[] {"CreateCompilationJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateCompilationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateCompilationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateCompilationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMCompilationJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TargetPlatform_Accelerator
        /// <summary>
        /// <para>
        /// <para>Specifies a target platform accelerator (optional).</para><ul><li><para><c>NVIDIA</c>: Nvidia graphics processing unit. It also requires <c>gpu-code</c>,
        /// <c>trt-ver</c>, <c>cuda-ver</c> compiler options</para></li><li><para><c>MALI</c>: ARM Mali graphics processor</para></li><li><para><c>INTEL_GRAPHICS</c>: Integrated Intel graphics</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_TargetPlatform_Accelerator")]
        [AWSConstantClassSource("Amazon.SageMaker.TargetPlatformAccelerator")]
        public Amazon.SageMaker.TargetPlatformAccelerator TargetPlatform_Accelerator { get; set; }
        #endregion
        
        #region Parameter TargetPlatform_Arch
        /// <summary>
        /// <para>
        /// <para>Specifies a target platform architecture.</para><ul><li><para><c>X86_64</c>: 64-bit version of the x86 instruction set.</para></li><li><para><c>X86</c>: 32-bit version of the x86 instruction set.</para></li><li><para><c>ARM64</c>: ARMv8 64-bit CPU.</para></li><li><para><c>ARM_EABIHF</c>: ARMv7 32-bit, Hard Float.</para></li><li><para><c>ARM_EABI</c>: ARMv7 32-bit, Soft Float. Used by Android 32-bit ARM platform.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_TargetPlatform_Arch")]
        [AWSConstantClassSource("Amazon.SageMaker.TargetPlatformArch")]
        public Amazon.SageMaker.TargetPlatformArch TargetPlatform_Arch { get; set; }
        #endregion
        
        #region Parameter CompilationJobName
        /// <summary>
        /// <para>
        /// <para>A name for the model compilation job. The name must be unique within the Amazon Web
        /// Services Region and within your Amazon Web Services account. </para>
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
        
        #region Parameter OutputConfig_CompilerOption
        /// <summary>
        /// <para>
        /// <para>Specifies additional parameters for compiler options in JSON format. The compiler
        /// options are <c>TargetPlatform</c> specific. It is required for NVIDIA accelerators
        /// and highly recommended for CPU compilations. For any other cases, it is optional to
        /// specify <c>CompilerOptions.</c></para><ul><li><para><c>DTYPE</c>: Specifies the data type for the input. When compiling for <c>ml_*</c>
        /// (except for <c>ml_inf</c>) instances using PyTorch framework, provide the data type
        /// (dtype) of the model's input. <c>"float32"</c> is used if <c>"DTYPE"</c> is not specified.
        /// Options for data type are:</para><ul><li><para>float32: Use either <c>"float"</c> or <c>"float32"</c>.</para></li><li><para>int64: Use either <c>"int64"</c> or <c>"long"</c>.</para></li></ul><para> For example, <c>{"dtype" : "float32"}</c>.</para></li><li><para><c>CPU</c>: Compilation for CPU supports the following compiler options.</para><ul><li><para><c>mcpu</c>: CPU micro-architecture. For example, <c>{'mcpu': 'skylake-avx512'}</c></para></li><li><para><c>mattr</c>: CPU flags. For example, <c>{'mattr': ['+neon', '+vfpv4']}</c></para></li></ul></li><li><para><c>ARM</c>: Details of ARM CPU compilations.</para><ul><li><para><c>NEON</c>: NEON is an implementation of the Advanced SIMD extension used in ARMv7
        /// processors.</para><para>For example, add <c>{'mattr': ['+neon']}</c> to the compiler options if compiling
        /// for ARM 32-bit platform with the NEON support.</para></li></ul></li><li><para><c>NVIDIA</c>: Compilation for NVIDIA GPU supports the following compiler options.</para><ul><li><para><c>gpu_code</c>: Specifies the targeted architecture.</para></li><li><para><c>trt-ver</c>: Specifies the TensorRT versions in x.y.z. format.</para></li><li><para><c>cuda-ver</c>: Specifies the CUDA version in x.y format.</para></li></ul><para>For example, <c>{'gpu-code': 'sm_72', 'trt-ver': '6.0.1', 'cuda-ver': '10.1'}</c></para></li><li><para><c>ANDROID</c>: Compilation for the Android OS supports the following compiler options:</para><ul><li><para><c>ANDROID_PLATFORM</c>: Specifies the Android API levels. Available levels range
        /// from 21 to 29. For example, <c>{'ANDROID_PLATFORM': 28}</c>.</para></li><li><para><c>mattr</c>: Add <c>{'mattr': ['+neon']}</c> to compiler options if compiling for
        /// ARM 32-bit platform with NEON support.</para></li></ul></li><li><para><c>INFERENTIA</c>: Compilation for target ml_inf1 uses compiler options passed in
        /// as a JSON string. For example, <c>"CompilerOptions": "\"--verbose 1 --num-neuroncores
        /// 2 -O2\""</c>. </para><para>For information about supported compiler options, see <a href="https://awsdocs-neuron.readthedocs-hosted.com/en/latest/compiler/neuronx-cc/api-reference-guide/neuron-compiler-cli-reference-guide.html">
        /// Neuron Compiler CLI Reference Guide</a>. </para></li><li><para><c>CoreML</c>: Compilation for the CoreML <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_OutputConfig.html">OutputConfig</a><c>TargetDevice</c> supports the following compiler options:</para><ul><li><para><c>class_labels</c>: Specifies the classification labels file name inside input tar.gz
        /// file. For example, <c>{"class_labels": "imagenet_labels_1000.txt"}</c>. Labels inside
        /// the txt file should be separated by newlines.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_CompilerOptions")]
        public System.String OutputConfig_CompilerOption { get; set; }
        #endregion
        
        #region Parameter InputConfig_DataInputConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the name and shape of the expected data inputs for your trained model with
        /// a JSON dictionary form. The data inputs are <c>Framework</c> specific. </para><ul><li><para><c>TensorFlow</c>: You must specify the name and shape (NHWC format) of the expected
        /// data inputs using a dictionary format for your trained model. The dictionary formats
        /// required for the console and CLI are different.</para><ul><li><para>Examples for one input:</para><ul><li><para>If using the console, <c>{"input":[1,1024,1024,3]}</c></para></li><li><para>If using the CLI, <c>{\"input\":[1,1024,1024,3]}</c></para></li></ul></li><li><para>Examples for two inputs:</para><ul><li><para>If using the console, <c>{"data1": [1,28,28,1], "data2":[1,28,28,1]}</c></para></li><li><para>If using the CLI, <c>{\"data1\": [1,28,28,1], \"data2\":[1,28,28,1]}</c></para></li></ul></li></ul></li><li><para><c>KERAS</c>: You must specify the name and shape (NCHW format) of expected data
        /// inputs using a dictionary format for your trained model. Note that while Keras model
        /// artifacts should be uploaded in NHWC (channel-last) format, <c>DataInputConfig</c>
        /// should be specified in NCHW (channel-first) format. The dictionary formats required
        /// for the console and CLI are different.</para><ul><li><para>Examples for one input:</para><ul><li><para>If using the console, <c>{"input_1":[1,3,224,224]}</c></para></li><li><para>If using the CLI, <c>{\"input_1\":[1,3,224,224]}</c></para></li></ul></li><li><para>Examples for two inputs:</para><ul><li><para>If using the console, <c>{"input_1": [1,3,224,224], "input_2":[1,3,224,224]} </c></para></li><li><para>If using the CLI, <c>{\"input_1\": [1,3,224,224], \"input_2\":[1,3,224,224]}</c></para></li></ul></li></ul></li><li><para><c>MXNET/ONNX/DARKNET</c>: You must specify the name and shape (NCHW format) of the
        /// expected data inputs in order using a dictionary format for your trained model. The
        /// dictionary formats required for the console and CLI are different.</para><ul><li><para>Examples for one input:</para><ul><li><para>If using the console, <c>{"data":[1,3,1024,1024]}</c></para></li><li><para>If using the CLI, <c>{\"data\":[1,3,1024,1024]}</c></para></li></ul></li><li><para>Examples for two inputs:</para><ul><li><para>If using the console, <c>{"var1": [1,1,28,28], "var2":[1,1,28,28]} </c></para></li><li><para>If using the CLI, <c>{\"var1\": [1,1,28,28], \"var2\":[1,1,28,28]}</c></para></li></ul></li></ul></li><li><para><c>PyTorch</c>: You can either specify the name and shape (NCHW format) of expected
        /// data inputs in order using a dictionary format for your trained model or you can specify
        /// the shape only using a list format. The dictionary formats required for the console
        /// and CLI are different. The list formats for the console and CLI are the same.</para><ul><li><para>Examples for one input in dictionary format:</para><ul><li><para>If using the console, <c>{"input0":[1,3,224,224]}</c></para></li><li><para>If using the CLI, <c>{\"input0\":[1,3,224,224]}</c></para></li></ul></li><li><para>Example for one input in list format: <c>[[1,3,224,224]]</c></para></li><li><para>Examples for two inputs in dictionary format:</para><ul><li><para>If using the console, <c>{"input0":[1,3,224,224], "input1":[1,3,224,224]}</c></para></li><li><para>If using the CLI, <c>{\"input0\":[1,3,224,224], \"input1\":[1,3,224,224]} </c></para></li></ul></li><li><para>Example for two inputs in list format: <c>[[1,3,224,224], [1,3,224,224]]</c></para></li></ul></li><li><para><c>XGBOOST</c>: input data name and shape are not needed.</para></li></ul><para><c>DataInputConfig</c> supports the following parameters for <c>CoreML</c><c>TargetDevice</c>
        /// (ML Model format):</para><ul><li><para><c>shape</c>: Input shape, for example <c>{"input_1": {"shape": [1,224,224,3]}}</c>.
        /// In addition to static input shapes, CoreML converter supports Flexible input shapes:</para><ul><li><para>Range Dimension. You can use the Range Dimension feature if you know the input shape
        /// will be within some specific interval in that dimension, for example: <c>{"input_1":
        /// {"shape": ["1..10", 224, 224, 3]}}</c></para></li><li><para>Enumerated shapes. Sometimes, the models are trained to work only on a select set
        /// of inputs. You can enumerate all supported input shapes, for example: <c>{"input_1":
        /// {"shape": [[1, 224, 224, 3], [1, 160, 160, 3]]}}</c></para></li></ul></li><li><para><c>default_shape</c>: Default input shape. You can set a default shape during conversion
        /// for both Range Dimension and Enumerated Shapes. For example <c>{"input_1": {"shape":
        /// ["1..10", 224, 224, 3], "default_shape": [1, 224, 224, 3]}}</c></para></li><li><para><c>type</c>: Input type. Allowed values: <c>Image</c> and <c>Tensor</c>. By default,
        /// the converter generates an ML Model with inputs of type Tensor (MultiArray). User
        /// can set input type to be Image. Image input type requires additional input parameters
        /// such as <c>bias</c> and <c>scale</c>.</para></li><li><para><c>bias</c>: If the input type is an Image, you need to provide the bias vector.</para></li><li><para><c>scale</c>: If the input type is an Image, you need to provide a scale factor.</para></li></ul><para>CoreML <c>ClassifierConfig</c> parameters can be specified using <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_OutputConfig.html">OutputConfig</a><c>CompilerOptions</c>. CoreML converter supports Tensorflow and PyTorch models. CoreML
        /// conversion examples:</para><ul><li><para>Tensor type input:</para><ul><li><para><c>"DataInputConfig": {"input_1": {"shape": [[1,224,224,3], [1,160,160,3]], "default_shape":
        /// [1,224,224,3]}}</c></para></li></ul></li><li><para>Tensor type input without input name (PyTorch):</para><ul><li><para><c>"DataInputConfig": [{"shape": [[1,3,224,224], [1,3,160,160]], "default_shape":
        /// [1,3,224,224]}]</c></para></li></ul></li><li><para>Image type input:</para><ul><li><para><c>"DataInputConfig": {"input_1": {"shape": [[1,224,224,3], [1,160,160,3]], "default_shape":
        /// [1,224,224,3], "type": "Image", "bias": [-1,-1,-1], "scale": 0.007843137255}}</c></para></li><li><para><c>"CompilerOptions": {"class_labels": "imagenet_labels_1000.txt"}</c></para></li></ul></li><li><para>Image type input without input name (PyTorch):</para><ul><li><para><c>"DataInputConfig": [{"shape": [[1,3,224,224], [1,3,160,160]], "default_shape":
        /// [1,3,224,224], "type": "Image", "bias": [-1,-1,-1], "scale": 0.007843137255}]</c></para></li><li><para><c>"CompilerOptions": {"class_labels": "imagenet_labels_1000.txt"}</c></para></li></ul></li></ul><para>Depending on the model format, <c>DataInputConfig</c> requires the following parameters
        /// for <c>ml_eia2</c><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_OutputConfig.html#sagemaker-Type-OutputConfig-TargetDevice">OutputConfig:TargetDevice</a>.</para><ul><li><para>For TensorFlow models saved in the SavedModel format, specify the input names from
        /// <c>signature_def_key</c> and the input model shapes for <c>DataInputConfig</c>. Specify
        /// the <c>signature_def_key</c> in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_OutputConfig.html#sagemaker-Type-OutputConfig-CompilerOptions"><c>OutputConfig:CompilerOptions</c></a> if the model does not use TensorFlow's default
        /// signature def key. For example:</para><ul><li><para><c>"DataInputConfig": {"inputs": [1, 224, 224, 3]}</c></para></li><li><para><c>"CompilerOptions": {"signature_def_key": "serving_custom"}</c></para></li></ul></li><li><para>For TensorFlow models saved as a frozen graph, specify the input tensor names and
        /// shapes in <c>DataInputConfig</c> and the output tensor names for <c>output_names</c>
        /// in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_OutputConfig.html#sagemaker-Type-OutputConfig-CompilerOptions"><c>OutputConfig:CompilerOptions</c></a>. For example:</para><ul><li><para><c>"DataInputConfig": {"input_tensor:0": [1, 224, 224, 3]}</c></para></li><li><para><c>"CompilerOptions": {"output_names": ["output_tensor:0"]}</c></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_DataInputConfig { get; set; }
        #endregion
        
        #region Parameter InputConfig_Framework
        /// <summary>
        /// <para>
        /// <para>Identifies the framework in which the model was trained. For example: TENSORFLOW.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.Framework")]
        public Amazon.SageMaker.Framework InputConfig_Framework { get; set; }
        #endregion
        
        #region Parameter InputConfig_FrameworkVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the framework version to use. This API field is only supported for the MXNet,
        /// PyTorch, TensorFlow and TensorFlow Lite frameworks.</para><para>For information about framework versions supported for cloud targets and edge devices,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/neo-supported-cloud.html">Cloud
        /// Supported Instance Types and Frameworks</a> and <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/neo-supported-devices-edge-frameworks.html">Edge
        /// Supported Frameworks</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_FrameworkVersion { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service key (Amazon Web Services KMS) that
        /// Amazon SageMaker AI uses to encrypt your output models with Amazon S3 server-side
        /// encryption after compilation job. If you don't provide a KMS key ID, Amazon SageMaker
        /// AI uses the default KMS key for Amazon S3 for your role's account. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/UsingKMSEncryption.html">KMS-Managed
        /// Encryption Keys</a> in the <i>Amazon Simple Storage Service Developer Guide.</i></para><para>The KmsKeyId can be any of the following formats: </para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias name ARN: <c>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxPendingTimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that a training or compilation job can be
        /// pending before it is stopped.</para><note><para>When working with training jobs that use capacity from <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/reserve-capacity-with-training-plans.html">training
        /// plans</a>, not all <c>Pending</c> job states count against the <c>MaxPendingTimeInSeconds</c>
        /// limit. The following scenarios do not increment the <c>MaxPendingTimeInSeconds</c>
        /// counter:</para><ul><li><para>The plan is in a <c>Scheduled</c> state: Jobs queued (in <c>Pending</c> status) before
        /// a plan's start date (waiting for scheduled start time)</para></li><li><para>Between capacity reservations: Jobs temporarily back to <c>Pending</c> status between
        /// two capacity reservation periods</para></li></ul><para><c>MaxPendingTimeInSeconds</c> only increments when jobs are actively waiting for
        /// capacity in an <c>Active</c> plan.</para></note>
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
        
        #region Parameter ModelPackageVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a versioned model package. Provide either a <c>ModelPackageVersionArn</c>
        /// or an <c>InputConfig</c> object in the request syntax. The presence of both objects
        /// in the <c>CreateCompilationJob</c> request will return an exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPackageVersionArn { get; set; }
        #endregion
        
        #region Parameter TargetPlatform_Os
        /// <summary>
        /// <para>
        /// <para>Specifies a target platform OS.</para><ul><li><para><c>LINUX</c>: Linux-based operating systems.</para></li><li><para><c>ANDROID</c>: Android operating systems. Android API level can be specified using
        /// the <c>ANDROID_PLATFORM</c> compiler option. For example, <c>"CompilerOptions": {'ANDROID_PLATFORM':
        /// 28}</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_TargetPlatform_Os")]
        [AWSConstantClassSource("Amazon.SageMaker.TargetPlatformOs")]
        public Amazon.SageMaker.TargetPlatformOs TargetPlatform_Os { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker AI to
        /// perform tasks on your behalf. </para><para>During model compilation, Amazon SageMaker AI needs your permission to:</para><ul><li><para>Read input data from an S3 bucket</para></li><li><para>Write model artifacts to an S3 bucket</para></li><li><para>Write logs to Amazon CloudWatch Logs</para></li><li><para>Publish metrics to Amazon CloudWatch</para></li></ul><para>You grant permissions for all of these tasks to an IAM role. To pass this role to
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
        /// <para>Identifies the S3 bucket where you want Amazon SageMaker AI to store the model artifacts.
        /// For example, <c>s3://bucket-name/key-name-prefix</c>.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs. IDs have the form of <c>sg-xxxxxxxx</c>. Specify the security
        /// groups for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC that you want to connect the compilation job to for
        /// accessing the model in Amazon S3.</para>
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
        
        #region Parameter OutputConfig_TargetDevice
        /// <summary>
        /// <para>
        /// <para>Identifies the target device or the machine learning instance that you want to run
        /// your model on after the compilation has completed. Alternatively, you can specify
        /// OS, architecture, and accelerator using <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_TargetPlatform.html">TargetPlatform</a>
        /// fields. It can be used instead of <c>TargetPlatform</c>.</para><note><para>Currently <c>ml_trn1</c> is available only in US East (N. Virginia) Region, and <c>ml_inf2</c>
        /// is available only in US East (Ohio) Region.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
            this._AWSSignerType = "v4";
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
            context.InputConfig_Framework = this.InputConfig_Framework;
            context.InputConfig_FrameworkVersion = this.InputConfig_FrameworkVersion;
            context.InputConfig_S3Uri = this.InputConfig_S3Uri;
            context.ModelPackageVersionArn = this.ModelPackageVersionArn;
            context.OutputConfig_CompilerOption = this.OutputConfig_CompilerOption;
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            #if MODULAR
            if (this.OutputConfig_S3OutputLocation == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_TargetDevice = this.OutputConfig_TargetDevice;
            context.TargetPlatform_Accelerator = this.TargetPlatform_Accelerator;
            context.TargetPlatform_Arch = this.TargetPlatform_Arch;
            context.TargetPlatform_Os = this.TargetPlatform_Os;
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
            System.String requestInputConfig_inputConfig_FrameworkVersion = null;
            if (cmdletContext.InputConfig_FrameworkVersion != null)
            {
                requestInputConfig_inputConfig_FrameworkVersion = cmdletContext.InputConfig_FrameworkVersion;
            }
            if (requestInputConfig_inputConfig_FrameworkVersion != null)
            {
                request.InputConfig.FrameworkVersion = requestInputConfig_inputConfig_FrameworkVersion;
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
            if (cmdletContext.ModelPackageVersionArn != null)
            {
                request.ModelPackageVersionArn = cmdletContext.ModelPackageVersionArn;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.OutputConfig();
            System.String requestOutputConfig_outputConfig_CompilerOption = null;
            if (cmdletContext.OutputConfig_CompilerOption != null)
            {
                requestOutputConfig_outputConfig_CompilerOption = cmdletContext.OutputConfig_CompilerOption;
            }
            if (requestOutputConfig_outputConfig_CompilerOption != null)
            {
                request.OutputConfig.CompilerOptions = requestOutputConfig_outputConfig_CompilerOption;
                requestOutputConfigIsNull = false;
            }
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
            Amazon.SageMaker.Model.TargetPlatform requestOutputConfig_outputConfig_TargetPlatform = null;
            
             // populate TargetPlatform
            var requestOutputConfig_outputConfig_TargetPlatformIsNull = true;
            requestOutputConfig_outputConfig_TargetPlatform = new Amazon.SageMaker.Model.TargetPlatform();
            Amazon.SageMaker.TargetPlatformAccelerator requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Accelerator = null;
            if (cmdletContext.TargetPlatform_Accelerator != null)
            {
                requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Accelerator = cmdletContext.TargetPlatform_Accelerator;
            }
            if (requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Accelerator != null)
            {
                requestOutputConfig_outputConfig_TargetPlatform.Accelerator = requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Accelerator;
                requestOutputConfig_outputConfig_TargetPlatformIsNull = false;
            }
            Amazon.SageMaker.TargetPlatformArch requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Arch = null;
            if (cmdletContext.TargetPlatform_Arch != null)
            {
                requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Arch = cmdletContext.TargetPlatform_Arch;
            }
            if (requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Arch != null)
            {
                requestOutputConfig_outputConfig_TargetPlatform.Arch = requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Arch;
                requestOutputConfig_outputConfig_TargetPlatformIsNull = false;
            }
            Amazon.SageMaker.TargetPlatformOs requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Os = null;
            if (cmdletContext.TargetPlatform_Os != null)
            {
                requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Os = cmdletContext.TargetPlatform_Os;
            }
            if (requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Os != null)
            {
                requestOutputConfig_outputConfig_TargetPlatform.Os = requestOutputConfig_outputConfig_TargetPlatform_targetPlatform_Os;
                requestOutputConfig_outputConfig_TargetPlatformIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_TargetPlatform should be set to null
            if (requestOutputConfig_outputConfig_TargetPlatformIsNull)
            {
                requestOutputConfig_outputConfig_TargetPlatform = null;
            }
            if (requestOutputConfig_outputConfig_TargetPlatform != null)
            {
                request.OutputConfig.TargetPlatform = requestOutputConfig_outputConfig_TargetPlatform;
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
            request.StoppingCondition = new Amazon.SageMaker.Model.StoppingCondition();
            System.Int32? requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxPendingTimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond = cmdletContext.StoppingCondition_MaxPendingTimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond != null)
            {
                request.StoppingCondition.MaxPendingTimeInSeconds = requestStoppingCondition_stoppingCondition_MaxPendingTimeInSecond.Value;
            }
            System.Int32? requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxRuntimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.StoppingCondition_MaxRuntimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond != null)
            {
                request.StoppingCondition.MaxRuntimeInSeconds = requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond.Value;
            }
            System.Int32? requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxWaitTimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond = cmdletContext.StoppingCondition_MaxWaitTimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond != null)
            {
                request.StoppingCondition.MaxWaitTimeInSeconds = requestStoppingCondition_stoppingCondition_MaxWaitTimeInSecond.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.SageMaker.Model.NeoVpcConfig();
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
            public System.String InputConfig_FrameworkVersion { get; set; }
            public System.String InputConfig_S3Uri { get; set; }
            public System.String ModelPackageVersionArn { get; set; }
            public System.String OutputConfig_CompilerOption { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String OutputConfig_S3OutputLocation { get; set; }
            public Amazon.SageMaker.TargetDevice OutputConfig_TargetDevice { get; set; }
            public Amazon.SageMaker.TargetPlatformAccelerator TargetPlatform_Accelerator { get; set; }
            public Amazon.SageMaker.TargetPlatformArch TargetPlatform_Arch { get; set; }
            public Amazon.SageMaker.TargetPlatformOs TargetPlatform_Os { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxPendingTimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public System.Int32? StoppingCondition_MaxWaitTimeInSecond { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateCompilationJobResponse, NewSMCompilationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CompilationJobArn;
        }
        
    }
}
