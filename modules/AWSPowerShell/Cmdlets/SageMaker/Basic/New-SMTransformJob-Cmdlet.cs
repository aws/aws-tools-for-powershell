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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Starts a transform job. A transform job uses a trained model to get inferences on
    /// a dataset and saves these results to an Amazon S3 location that you specify.
    /// 
    ///  
    /// <para>
    /// To perform batch transformations, you create a transform job and use the data that
    /// you have readily available.
    /// </para><para>
    /// In the request body, you provide the following:
    /// </para><ul><li><para><c>TransformJobName</c> - Identifies the transform job. The name must be unique within
    /// an Amazon Web Services Region in an Amazon Web Services account.
    /// </para></li><li><para><c>ModelName</c> - Identifies the model to use. <c>ModelName</c> must be the name
    /// of an existing Amazon SageMaker model in the same Amazon Web Services Region and Amazon
    /// Web Services account. For information on creating a model, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateModel.html">CreateModel</a>.
    /// </para></li><li><para><c>TransformInput</c> - Describes the dataset to be transformed and the Amazon S3
    /// location where it is stored.
    /// </para></li><li><para><c>TransformOutput</c> - Identifies the Amazon S3 location where you want Amazon
    /// SageMaker to save the results from the transform job.
    /// </para></li><li><para><c>TransformResources</c> - Identifies the ML compute instances and AMI image versions
    /// for the transform job.
    /// </para></li></ul><para>
    /// For more information about how batch transformation works, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/batch-transform.html">Batch
    /// Transform</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMTransformJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTransformJob API operation.", Operation = new[] {"CreateTransformJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateTransformJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateTransformJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTransformJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMTransformJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TransformOutput_Accept
        /// <summary>
        /// <para>
        /// <para>The MIME type used to specify the output data. Amazon SageMaker uses the MIME type
        /// with each http call to transfer data from the transform job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransformOutput_Accept { get; set; }
        #endregion
        
        #region Parameter TransformOutput_AssembleWith
        /// <summary>
        /// <para>
        /// <para>Defines how to assemble the results of the transform job as a single S3 object. Choose
        /// a format that is most convenient to you. To concatenate the results in binary format,
        /// specify <c>None</c>. To add a newline character at the end of every transformed record,
        /// specify <c>Line</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AssemblyType")]
        public Amazon.SageMaker.AssemblyType TransformOutput_AssembleWith { get; set; }
        #endregion
        
        #region Parameter BatchStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the number of records to include in a mini-batch for an HTTP inference request.
        /// A <i>record</i><i /> is a single unit of input data that inference can be made on.
        /// For example, a single line in a CSV file is a record. </para><para>To enable the batch strategy, you must set the <c>SplitType</c> property to <c>Line</c>,
        /// <c>RecordIO</c>, or <c>TFRecord</c>.</para><para>To use only one record when making an HTTP invocation request to a container, set
        /// <c>BatchStrategy</c> to <c>SingleRecord</c> and <c>SplitType</c> to <c>Line</c>.</para><para>To fit as many records in a mini-batch as can fit within the <c>MaxPayloadInMB</c>
        /// limit, set <c>BatchStrategy</c> to <c>MultiRecord</c> and <c>SplitType</c> to <c>Line</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.BatchStrategy")]
        public Amazon.SageMaker.BatchStrategy BatchStrategy { get; set; }
        #endregion
        
        #region Parameter TransformInput_CompressionType
        /// <summary>
        /// <para>
        /// <para>If your transform data is compressed, specify the compression type. Amazon SageMaker
        /// automatically decompresses the data for the transform job accordingly. The default
        /// value is <c>None</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.CompressionType")]
        public Amazon.SageMaker.CompressionType TransformInput_CompressionType { get; set; }
        #endregion
        
        #region Parameter TransformInput_ContentType
        /// <summary>
        /// <para>
        /// <para>The multipurpose internet mail extension (MIME) type of the data. Amazon SageMaker
        /// uses the MIME type with each http call to transfer data to the transform job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransformInput_ContentType { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_DestinationS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location being used to capture the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataCaptureConfig_DestinationS3Uri { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container. Don't include any sensitive
        /// data in your environment variables. We support up to 16 key and values entries in
        /// the map.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter DataCaptureConfig_GenerateInferenceId
        /// <summary>
        /// <para>
        /// <para>Flag that indicates whether to append inference id to the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataCaptureConfig_GenerateInferenceId { get; set; }
        #endregion
        
        #region Parameter DataProcessing_InputFilter
        /// <summary>
        /// <para>
        /// <para>A <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/batch-transform-data-processing.html#data-processing-operators">JSONPath</a>
        /// expression used to select a portion of the input data to pass to the algorithm. Use
        /// the <c>InputFilter</c> parameter to exclude fields, such as an ID column, from the
        /// input. If you want SageMaker to pass the entire input dataset to the algorithm, accept
        /// the default value <c>$</c>.</para><para>Examples: <c>"$"</c>, <c>"$[1:]"</c>, <c>"$.features"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataProcessing_InputFilter { get; set; }
        #endregion
        
        #region Parameter TransformResources_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of ML compute instances to use in the transform job. The default value
        /// is <c>1</c>, and the maximum is <c>100</c>. For distributed transform jobs, specify
        /// a value greater than <c>1</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TransformResources_InstanceCount { get; set; }
        #endregion
        
        #region Parameter TransformResources_InstanceType
        /// <summary>
        /// <para>
        /// <para>The ML compute instance type for the transform job. If you are using built-in algorithms
        /// to transform moderately sized datasets, we recommend using ml.m4.xlarge or <c>ml.m5.large</c>instance
        /// types.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.TransformInstanceType")]
        public Amazon.SageMaker.TransformInstanceType TransformResources_InstanceType { get; set; }
        #endregion
        
        #region Parameter ModelClientConfig_InvocationsMaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of retries when invocation requests are failing. The default value
        /// is 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelClientConfig_InvocationsMaxRetries")]
        public System.Int32? ModelClientConfig_InvocationsMaxRetry { get; set; }
        #endregion
        
        #region Parameter ModelClientConfig_InvocationsTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The timeout value in seconds for an invocation request. The default value is 600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelClientConfig_InvocationsTimeoutInSeconds")]
        public System.Int32? ModelClientConfig_InvocationsTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter DataProcessing_JoinSource
        /// <summary>
        /// <para>
        /// <para>Specifies the source of the data to join with the transformed data. The valid values
        /// are <c>None</c> and <c>Input</c>. The default value is <c>None</c>, which specifies
        /// not to join the input with the transformed data. If you want the batch transform job
        /// to join the original input data with the transformed data, set <c>JoinSource</c> to
        /// <c>Input</c>. You can specify <c>OutputFilter</c> as an additional filter to select
        /// a portion of the joined dataset and store it in the output file.</para><para>For JSON or JSONLines objects, such as a JSON array, SageMaker adds the transformed
        /// data to the input JSON object in an attribute called <c>SageMakerOutput</c>. The joined
        /// result for JSON must be a key-value pair object. If the input is not a key-value pair
        /// object, SageMaker creates a new JSON file. In the new JSON file, and the input data
        /// is stored under the <c>SageMakerInput</c> key and the results are stored in <c>SageMakerOutput</c>.</para><para>For CSV data, SageMaker takes each row as a JSON array and joins the transformed data
        /// with the input by appending each transformed row to the end of the input. The joined
        /// data has the original input data followed by the transformed data and the output is
        /// a CSV file.</para><para>For information on how joining in applied, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/batch-transform-data-processing.html#batch-transform-data-processing-workflow">Workflow
        /// for Associating Inferences with Input Records</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.JoinSource")]
        public Amazon.SageMaker.JoinSource DataProcessing_JoinSource { get; set; }
        #endregion
        
        #region Parameter DataCaptureConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Amazon Web Services Key Management Service key
        /// that SageMaker uses to encrypt data on the storage volume attached to the ML compute
        /// instance that hosts the batch transform job.</para><para>The KmsKeyId can be any of the following formats: </para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias name ARN: <c>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataCaptureConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter TransformOutput_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt the model artifacts at rest using Amazon S3 server-side
        /// encryption. The <c>KmsKeyId</c> can be any of the following formats: </para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias name ARN: <c>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>If you don't provide a KMS key ID, Amazon SageMaker uses the default KMS key for Amazon
        /// S3 for your role's account. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingKMSEncryption.html">KMS-Managed
        /// Encryption Keys</a> in the <i>Amazon Simple Storage Service Developer Guide.</i></para><para>The KMS key policy must grant permission to the IAM role that you specify in your
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateModel.html">CreateModel</a>
        /// request. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">Using
        /// Key Policies in Amazon Web Services KMS</a> in the <i>Amazon Web Services Key Management
        /// Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransformOutput_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaxConcurrentTransform
        /// <summary>
        /// <para>
        /// <para>The maximum number of parallel requests that can be sent to each instance in a transform
        /// job. If <c>MaxConcurrentTransforms</c> is set to <c>0</c> or left unset, Amazon SageMaker
        /// checks the optional execution-parameters to determine the settings for your chosen
        /// algorithm. If the execution-parameters endpoint is not enabled, the default value
        /// is <c>1</c>. For more information on execution-parameters, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/your-algorithms-batch-code.html#your-algorithms-batch-code-how-containe-serves-requests">How
        /// Containers Serve Requests</a>. For built-in algorithms, you don't need to set a value
        /// for <c>MaxConcurrentTransforms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxConcurrentTransforms")]
        public System.Int32? MaxConcurrentTransform { get; set; }
        #endregion
        
        #region Parameter MaxPayloadInMB
        /// <summary>
        /// <para>
        /// <para>The maximum allowed size of the payload, in MB. A <i>payload</i> is the data portion
        /// of a record (without metadata). The value in <c>MaxPayloadInMB</c> must be greater
        /// than, or equal to, the size of a single record. To estimate the size of a record in
        /// MB, divide the size of your dataset by the number of records. To ensure that the records
        /// fit within the maximum payload size, we recommend using a slightly larger value. The
        /// default value is <c>6</c> MB. </para><para>The value of <c>MaxPayloadInMB</c> cannot be greater than 100 MB. If you specify the
        /// <c>MaxConcurrentTransforms</c> parameter, the value of <c>(MaxConcurrentTransforms
        /// * MaxPayloadInMB)</c> also cannot exceed 100 MB.</para><para>For cases where the payload might be arbitrarily large and is transmitted using HTTP
        /// chunked encoding, set the value to <c>0</c>. This feature works only in supported
        /// algorithms. Currently, Amazon SageMaker built-in algorithms do not support HTTP chunked
        /// encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxPayloadInMB { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the model that you want to use for the transform job. <c>ModelName</c>
        /// must be the name of an existing Amazon SageMaker model within an Amazon Web Services
        /// Region in an Amazon Web Services account.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter DataProcessing_OutputFilter
        /// <summary>
        /// <para>
        /// <para>A <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/batch-transform-data-processing.html#data-processing-operators">JSONPath</a>
        /// expression used to select a portion of the joined dataset to save in the output file
        /// for a batch transform job. If you want SageMaker to store the entire input dataset
        /// in the output file, leave the default value, <c>$</c>. If you specify indexes that
        /// aren't within the dimension size of the joined dataset, you get an error.</para><para>Examples: <c>"$"</c>, <c>"$[0,5:]"</c>, <c>"$['id','SageMakerOutput']"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataProcessing_OutputFilter { get; set; }
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
        
        #region Parameter S3DataSource_S3DataType
        /// <summary>
        /// <para>
        /// <para>If you choose <c>S3Prefix</c>, <c>S3Uri</c> identifies a key name prefix. Amazon SageMaker
        /// uses all objects with the specified key name prefix for batch transform. </para><para>If you choose <c>ManifestFile</c>, <c>S3Uri</c> identifies an object that is a manifest
        /// file containing a list of object keys that you want Amazon SageMaker to use for batch
        /// transform. </para><para>The following values are compatible: <c>ManifestFile</c>, <c>S3Prefix</c></para><para>The following value is not compatible: <c>AugmentedManifestFile</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TransformInput_DataSource_S3DataSource_S3DataType")]
        [AWSConstantClassSource("Amazon.SageMaker.S3DataType")]
        public Amazon.SageMaker.S3DataType S3DataSource_S3DataType { get; set; }
        #endregion
        
        #region Parameter TransformOutput_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path where you want Amazon SageMaker to store the results of the transform
        /// job. For example, <c>s3://bucket-name/key-name-prefix</c>.</para><para>For every S3 object used as input for the transform job, batch transform stores the
        /// transformed data with an .<c>out</c> suffix in a corresponding subfolder in the location
        /// in the output prefix. For example, for the input data stored at <c>s3://bucket-name/input-name-prefix/dataset01/data.csv</c>,
        /// batch transform stores the transformed data at <c>s3://bucket-name/output-name-prefix/input-name-prefix/data.csv.out</c>.
        /// Batch transform doesn't upload partially processed objects. For an input S3 object
        /// that contains multiple records, it creates an .<c>out</c> file only if the transform
        /// job succeeds on the entire file. When the input contains multiple S3 objects, the
        /// batch transform job processes the listed S3 objects and uploads only the output for
        /// successfully processed objects. If any object fails in the transform job batch transform
        /// marks the job as failed to prompt investigation.</para>
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
        public System.String TransformOutput_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter S3DataSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>Depending on the value specified for the <c>S3DataType</c>, identifies either a key
        /// name prefix or a manifest. For example:</para><ul><li><para> A key name prefix might look like this: <c>s3://bucketname/exampleprefix/</c>. </para></li><li><para> A manifest might look like this: <c>s3://bucketname/example.manifest</c></para><para> The manifest is an S3 object which is a JSON file with the following format: </para><para><c>[ {"prefix": "s3://customer_bucket/some/prefix/"},</c></para><para><c>"relative/path/to/custdata-1",</c></para><para><c>"relative/path/custdata-2",</c></para><para><c>...</c></para><para><c>"relative/path/custdata-N"</c></para><para><c>]</c></para><para> The preceding JSON matches the following <c>S3Uris</c>: </para><para><c>s3://customer_bucket/some/prefix/relative/path/to/custdata-1</c></para><para><c>s3://customer_bucket/some/prefix/relative/path/custdata-2</c></para><para><c>...</c></para><para><c>s3://customer_bucket/some/prefix/relative/path/custdata-N</c></para><para> The complete set of <c>S3Uris</c> in this manifest constitutes the input data for
        /// the channel for this datasource. The object that each <c>S3Uris</c> points to must
        /// be readable by the IAM role that Amazon SageMaker uses to perform tasks on your behalf.</para></li></ul>
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
        [Alias("TransformInput_DataSource_S3DataSource_S3Uri")]
        public System.String S3DataSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter TransformInput_SplitType
        /// <summary>
        /// <para>
        /// <para>The method to use to split the transform job's data files into smaller batches. Splitting
        /// is necessary when the total size of each object is too large to fit in a single request.
        /// You can also use data splitting to improve performance by processing multiple concurrent
        /// mini-batches. The default value for <c>SplitType</c> is <c>None</c>, which indicates
        /// that input data files are not split, and request payloads contain the entire contents
        /// of an input object. Set the value of this parameter to <c>Line</c> to split records
        /// on a newline character boundary. <c>SplitType</c> also supports a number of record-oriented
        /// binary data formats. Currently, the supported record formats are:</para><ul><li><para>RecordIO</para></li><li><para>TFRecord</para></li></ul><para>When splitting is enabled, the size of a mini-batch depends on the values of the <c>BatchStrategy</c>
        /// and <c>MaxPayloadInMB</c> parameters. When the value of <c>BatchStrategy</c> is <c>MultiRecord</c>,
        /// Amazon SageMaker sends the maximum number of records in each request, up to the <c>MaxPayloadInMB</c>
        /// limit. If the value of <c>BatchStrategy</c> is <c>SingleRecord</c>, Amazon SageMaker
        /// sends individual records in each request.</para><note><para>Some data formats represent a record as a binary payload wrapped with extra padding
        /// bytes. When splitting is applied to a binary data format, padding is removed if the
        /// value of <c>BatchStrategy</c> is set to <c>SingleRecord</c>. Padding is not removed
        /// if the value of <c>BatchStrategy</c> is set to <c>MultiRecord</c>.</para><para>For more information about <c>RecordIO</c>, see <a href="https://mxnet.apache.org/api/faq/recordio">Create
        /// a Dataset Using RecordIO</a> in the MXNet documentation. For more information about
        /// <c>TFRecord</c>, see <a href="https://www.tensorflow.org/guide/data#consuming_tfrecord_data">Consuming
        /// TFRecord data</a> in the TensorFlow documentation.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SplitType")]
        public Amazon.SageMaker.SplitType TransformInput_SplitType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>(Optional) An array of key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i>Amazon Web Services Billing and Cost Management
        /// User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TransformResources_TransformAmiVersion
        /// <summary>
        /// <para>
        /// <para>Specifies an option from a collection of preconfigured Amazon Machine Image (AMI)
        /// images. Each image is configured by Amazon Web Services with a set of software and
        /// driver versions.</para><dl><dt>al2-ami-sagemaker-batch-gpu-470</dt><dd><ul><li><para>Accelerator: GPU</para></li><li><para>NVIDIA driver version: 470</para></li></ul></dd><dt>al2-ami-sagemaker-batch-gpu-535</dt><dd><ul><li><para>Accelerator: GPU</para></li><li><para>NVIDIA driver version: 535</para></li></ul></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransformResources_TransformAmiVersion { get; set; }
        #endregion
        
        #region Parameter TransformJobName
        /// <summary>
        /// <para>
        /// <para>The name of the transform job. The name must be unique within an Amazon Web Services
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
        public System.String TransformJobName { get; set; }
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
        
        #region Parameter TransformResources_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (Amazon Web Services KMS) key that
        /// Amazon SageMaker uses to encrypt model data on the storage volume attached to the
        /// ML compute instance(s) that run the batch transform job.</para><note><para>Certain Nitro-based instances include local storage, dependent on the instance type.
        /// Local storage volumes are encrypted using a hardware module on the instance. You can't
        /// request a <c>VolumeKmsKeyId</c> when using an instance type with local storage.</para><para>For a list of instance types that support local instance storage, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html#instance-store-volumes">Instance
        /// Store Volumes</a>.</para><para>For more information about local instance storage encryption, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ssd-instance-store.html">SSD
        /// Instance Store Volumes</a>.</para></note><para> The <c>VolumeKmsKeyId</c> can be any of the following formats:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias name ARN: <c>arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransformResources_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransformJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateTransformJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateTransformJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransformJobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransformJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTransformJob (CreateTransformJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateTransformJobResponse, NewSMTransformJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BatchStrategy = this.BatchStrategy;
            context.DataCaptureConfig_DestinationS3Uri = this.DataCaptureConfig_DestinationS3Uri;
            context.DataCaptureConfig_GenerateInferenceId = this.DataCaptureConfig_GenerateInferenceId;
            context.DataCaptureConfig_KmsKeyId = this.DataCaptureConfig_KmsKeyId;
            context.DataProcessing_InputFilter = this.DataProcessing_InputFilter;
            context.DataProcessing_JoinSource = this.DataProcessing_JoinSource;
            context.DataProcessing_OutputFilter = this.DataProcessing_OutputFilter;
            if (this.Environment != null)
            {
                context.Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment.Keys)
                {
                    context.Environment.Add((String)hashKey, (System.String)(this.Environment[hashKey]));
                }
            }
            context.ExperimentConfig_ExperimentName = this.ExperimentConfig_ExperimentName;
            context.ExperimentConfig_RunName = this.ExperimentConfig_RunName;
            context.ExperimentConfig_TrialComponentDisplayName = this.ExperimentConfig_TrialComponentDisplayName;
            context.ExperimentConfig_TrialName = this.ExperimentConfig_TrialName;
            context.MaxConcurrentTransform = this.MaxConcurrentTransform;
            context.MaxPayloadInMB = this.MaxPayloadInMB;
            context.ModelClientConfig_InvocationsMaxRetry = this.ModelClientConfig_InvocationsMaxRetry;
            context.ModelClientConfig_InvocationsTimeoutInSecond = this.ModelClientConfig_InvocationsTimeoutInSecond;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TransformInput_CompressionType = this.TransformInput_CompressionType;
            context.TransformInput_ContentType = this.TransformInput_ContentType;
            context.S3DataSource_S3DataType = this.S3DataSource_S3DataType;
            #if MODULAR
            if (this.S3DataSource_S3DataType == null && ParameterWasBound(nameof(this.S3DataSource_S3DataType)))
            {
                WriteWarning("You are passing $null as a value for parameter S3DataSource_S3DataType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3DataSource_S3Uri = this.S3DataSource_S3Uri;
            #if MODULAR
            if (this.S3DataSource_S3Uri == null && ParameterWasBound(nameof(this.S3DataSource_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter S3DataSource_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformInput_SplitType = this.TransformInput_SplitType;
            context.TransformJobName = this.TransformJobName;
            #if MODULAR
            if (this.TransformJobName == null && ParameterWasBound(nameof(this.TransformJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformOutput_Accept = this.TransformOutput_Accept;
            context.TransformOutput_AssembleWith = this.TransformOutput_AssembleWith;
            context.TransformOutput_KmsKeyId = this.TransformOutput_KmsKeyId;
            context.TransformOutput_S3OutputPath = this.TransformOutput_S3OutputPath;
            #if MODULAR
            if (this.TransformOutput_S3OutputPath == null && ParameterWasBound(nameof(this.TransformOutput_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformOutput_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformResources_InstanceCount = this.TransformResources_InstanceCount;
            #if MODULAR
            if (this.TransformResources_InstanceCount == null && ParameterWasBound(nameof(this.TransformResources_InstanceCount)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformResources_InstanceCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformResources_InstanceType = this.TransformResources_InstanceType;
            #if MODULAR
            if (this.TransformResources_InstanceType == null && ParameterWasBound(nameof(this.TransformResources_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformResources_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransformResources_TransformAmiVersion = this.TransformResources_TransformAmiVersion;
            context.TransformResources_VolumeKmsKeyId = this.TransformResources_VolumeKmsKeyId;
            
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
            var request = new Amazon.SageMaker.Model.CreateTransformJobRequest();
            
            if (cmdletContext.BatchStrategy != null)
            {
                request.BatchStrategy = cmdletContext.BatchStrategy;
            }
            
             // populate DataCaptureConfig
            var requestDataCaptureConfigIsNull = true;
            request.DataCaptureConfig = new Amazon.SageMaker.Model.BatchDataCaptureConfig();
            System.String requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri = null;
            if (cmdletContext.DataCaptureConfig_DestinationS3Uri != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri = cmdletContext.DataCaptureConfig_DestinationS3Uri;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri != null)
            {
                request.DataCaptureConfig.DestinationS3Uri = requestDataCaptureConfig_dataCaptureConfig_DestinationS3Uri;
                requestDataCaptureConfigIsNull = false;
            }
            System.Boolean? requestDataCaptureConfig_dataCaptureConfig_GenerateInferenceId = null;
            if (cmdletContext.DataCaptureConfig_GenerateInferenceId != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_GenerateInferenceId = cmdletContext.DataCaptureConfig_GenerateInferenceId.Value;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_GenerateInferenceId != null)
            {
                request.DataCaptureConfig.GenerateInferenceId = requestDataCaptureConfig_dataCaptureConfig_GenerateInferenceId.Value;
                requestDataCaptureConfigIsNull = false;
            }
            System.String requestDataCaptureConfig_dataCaptureConfig_KmsKeyId = null;
            if (cmdletContext.DataCaptureConfig_KmsKeyId != null)
            {
                requestDataCaptureConfig_dataCaptureConfig_KmsKeyId = cmdletContext.DataCaptureConfig_KmsKeyId;
            }
            if (requestDataCaptureConfig_dataCaptureConfig_KmsKeyId != null)
            {
                request.DataCaptureConfig.KmsKeyId = requestDataCaptureConfig_dataCaptureConfig_KmsKeyId;
                requestDataCaptureConfigIsNull = false;
            }
             // determine if request.DataCaptureConfig should be set to null
            if (requestDataCaptureConfigIsNull)
            {
                request.DataCaptureConfig = null;
            }
            
             // populate DataProcessing
            var requestDataProcessingIsNull = true;
            request.DataProcessing = new Amazon.SageMaker.Model.DataProcessing();
            System.String requestDataProcessing_dataProcessing_InputFilter = null;
            if (cmdletContext.DataProcessing_InputFilter != null)
            {
                requestDataProcessing_dataProcessing_InputFilter = cmdletContext.DataProcessing_InputFilter;
            }
            if (requestDataProcessing_dataProcessing_InputFilter != null)
            {
                request.DataProcessing.InputFilter = requestDataProcessing_dataProcessing_InputFilter;
                requestDataProcessingIsNull = false;
            }
            Amazon.SageMaker.JoinSource requestDataProcessing_dataProcessing_JoinSource = null;
            if (cmdletContext.DataProcessing_JoinSource != null)
            {
                requestDataProcessing_dataProcessing_JoinSource = cmdletContext.DataProcessing_JoinSource;
            }
            if (requestDataProcessing_dataProcessing_JoinSource != null)
            {
                request.DataProcessing.JoinSource = requestDataProcessing_dataProcessing_JoinSource;
                requestDataProcessingIsNull = false;
            }
            System.String requestDataProcessing_dataProcessing_OutputFilter = null;
            if (cmdletContext.DataProcessing_OutputFilter != null)
            {
                requestDataProcessing_dataProcessing_OutputFilter = cmdletContext.DataProcessing_OutputFilter;
            }
            if (requestDataProcessing_dataProcessing_OutputFilter != null)
            {
                request.DataProcessing.OutputFilter = requestDataProcessing_dataProcessing_OutputFilter;
                requestDataProcessingIsNull = false;
            }
             // determine if request.DataProcessing should be set to null
            if (requestDataProcessingIsNull)
            {
                request.DataProcessing = null;
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
            if (cmdletContext.MaxConcurrentTransform != null)
            {
                request.MaxConcurrentTransforms = cmdletContext.MaxConcurrentTransform.Value;
            }
            if (cmdletContext.MaxPayloadInMB != null)
            {
                request.MaxPayloadInMB = cmdletContext.MaxPayloadInMB.Value;
            }
            
             // populate ModelClientConfig
            var requestModelClientConfigIsNull = true;
            request.ModelClientConfig = new Amazon.SageMaker.Model.ModelClientConfig();
            System.Int32? requestModelClientConfig_modelClientConfig_InvocationsMaxRetry = null;
            if (cmdletContext.ModelClientConfig_InvocationsMaxRetry != null)
            {
                requestModelClientConfig_modelClientConfig_InvocationsMaxRetry = cmdletContext.ModelClientConfig_InvocationsMaxRetry.Value;
            }
            if (requestModelClientConfig_modelClientConfig_InvocationsMaxRetry != null)
            {
                request.ModelClientConfig.InvocationsMaxRetries = requestModelClientConfig_modelClientConfig_InvocationsMaxRetry.Value;
                requestModelClientConfigIsNull = false;
            }
            System.Int32? requestModelClientConfig_modelClientConfig_InvocationsTimeoutInSecond = null;
            if (cmdletContext.ModelClientConfig_InvocationsTimeoutInSecond != null)
            {
                requestModelClientConfig_modelClientConfig_InvocationsTimeoutInSecond = cmdletContext.ModelClientConfig_InvocationsTimeoutInSecond.Value;
            }
            if (requestModelClientConfig_modelClientConfig_InvocationsTimeoutInSecond != null)
            {
                request.ModelClientConfig.InvocationsTimeoutInSeconds = requestModelClientConfig_modelClientConfig_InvocationsTimeoutInSecond.Value;
                requestModelClientConfigIsNull = false;
            }
             // determine if request.ModelClientConfig should be set to null
            if (requestModelClientConfigIsNull)
            {
                request.ModelClientConfig = null;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TransformInput
            var requestTransformInputIsNull = true;
            request.TransformInput = new Amazon.SageMaker.Model.TransformInput();
            Amazon.SageMaker.CompressionType requestTransformInput_transformInput_CompressionType = null;
            if (cmdletContext.TransformInput_CompressionType != null)
            {
                requestTransformInput_transformInput_CompressionType = cmdletContext.TransformInput_CompressionType;
            }
            if (requestTransformInput_transformInput_CompressionType != null)
            {
                request.TransformInput.CompressionType = requestTransformInput_transformInput_CompressionType;
                requestTransformInputIsNull = false;
            }
            System.String requestTransformInput_transformInput_ContentType = null;
            if (cmdletContext.TransformInput_ContentType != null)
            {
                requestTransformInput_transformInput_ContentType = cmdletContext.TransformInput_ContentType;
            }
            if (requestTransformInput_transformInput_ContentType != null)
            {
                request.TransformInput.ContentType = requestTransformInput_transformInput_ContentType;
                requestTransformInputIsNull = false;
            }
            Amazon.SageMaker.SplitType requestTransformInput_transformInput_SplitType = null;
            if (cmdletContext.TransformInput_SplitType != null)
            {
                requestTransformInput_transformInput_SplitType = cmdletContext.TransformInput_SplitType;
            }
            if (requestTransformInput_transformInput_SplitType != null)
            {
                request.TransformInput.SplitType = requestTransformInput_transformInput_SplitType;
                requestTransformInputIsNull = false;
            }
            Amazon.SageMaker.Model.TransformDataSource requestTransformInput_transformInput_DataSource = null;
            
             // populate DataSource
            var requestTransformInput_transformInput_DataSourceIsNull = true;
            requestTransformInput_transformInput_DataSource = new Amazon.SageMaker.Model.TransformDataSource();
            Amazon.SageMaker.Model.TransformS3DataSource requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource = null;
            
             // populate S3DataSource
            var requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSourceIsNull = true;
            requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource = new Amazon.SageMaker.Model.TransformS3DataSource();
            Amazon.SageMaker.S3DataType requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType = null;
            if (cmdletContext.S3DataSource_S3DataType != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType = cmdletContext.S3DataSource_S3DataType;
            }
            if (requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource.S3DataType = requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType;
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSourceIsNull = false;
            }
            System.String requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3Uri = null;
            if (cmdletContext.S3DataSource_S3Uri != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3Uri = cmdletContext.S3DataSource_S3Uri;
            }
            if (requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3Uri != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource.S3Uri = requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3Uri;
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSourceIsNull = false;
            }
             // determine if requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource should be set to null
            if (requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSourceIsNull)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource = null;
            }
            if (requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource != null)
            {
                requestTransformInput_transformInput_DataSource.S3DataSource = requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource;
                requestTransformInput_transformInput_DataSourceIsNull = false;
            }
             // determine if requestTransformInput_transformInput_DataSource should be set to null
            if (requestTransformInput_transformInput_DataSourceIsNull)
            {
                requestTransformInput_transformInput_DataSource = null;
            }
            if (requestTransformInput_transformInput_DataSource != null)
            {
                request.TransformInput.DataSource = requestTransformInput_transformInput_DataSource;
                requestTransformInputIsNull = false;
            }
             // determine if request.TransformInput should be set to null
            if (requestTransformInputIsNull)
            {
                request.TransformInput = null;
            }
            if (cmdletContext.TransformJobName != null)
            {
                request.TransformJobName = cmdletContext.TransformJobName;
            }
            
             // populate TransformOutput
            var requestTransformOutputIsNull = true;
            request.TransformOutput = new Amazon.SageMaker.Model.TransformOutput();
            System.String requestTransformOutput_transformOutput_Accept = null;
            if (cmdletContext.TransformOutput_Accept != null)
            {
                requestTransformOutput_transformOutput_Accept = cmdletContext.TransformOutput_Accept;
            }
            if (requestTransformOutput_transformOutput_Accept != null)
            {
                request.TransformOutput.Accept = requestTransformOutput_transformOutput_Accept;
                requestTransformOutputIsNull = false;
            }
            Amazon.SageMaker.AssemblyType requestTransformOutput_transformOutput_AssembleWith = null;
            if (cmdletContext.TransformOutput_AssembleWith != null)
            {
                requestTransformOutput_transformOutput_AssembleWith = cmdletContext.TransformOutput_AssembleWith;
            }
            if (requestTransformOutput_transformOutput_AssembleWith != null)
            {
                request.TransformOutput.AssembleWith = requestTransformOutput_transformOutput_AssembleWith;
                requestTransformOutputIsNull = false;
            }
            System.String requestTransformOutput_transformOutput_KmsKeyId = null;
            if (cmdletContext.TransformOutput_KmsKeyId != null)
            {
                requestTransformOutput_transformOutput_KmsKeyId = cmdletContext.TransformOutput_KmsKeyId;
            }
            if (requestTransformOutput_transformOutput_KmsKeyId != null)
            {
                request.TransformOutput.KmsKeyId = requestTransformOutput_transformOutput_KmsKeyId;
                requestTransformOutputIsNull = false;
            }
            System.String requestTransformOutput_transformOutput_S3OutputPath = null;
            if (cmdletContext.TransformOutput_S3OutputPath != null)
            {
                requestTransformOutput_transformOutput_S3OutputPath = cmdletContext.TransformOutput_S3OutputPath;
            }
            if (requestTransformOutput_transformOutput_S3OutputPath != null)
            {
                request.TransformOutput.S3OutputPath = requestTransformOutput_transformOutput_S3OutputPath;
                requestTransformOutputIsNull = false;
            }
             // determine if request.TransformOutput should be set to null
            if (requestTransformOutputIsNull)
            {
                request.TransformOutput = null;
            }
            
             // populate TransformResources
            var requestTransformResourcesIsNull = true;
            request.TransformResources = new Amazon.SageMaker.Model.TransformResources();
            System.Int32? requestTransformResources_transformResources_InstanceCount = null;
            if (cmdletContext.TransformResources_InstanceCount != null)
            {
                requestTransformResources_transformResources_InstanceCount = cmdletContext.TransformResources_InstanceCount.Value;
            }
            if (requestTransformResources_transformResources_InstanceCount != null)
            {
                request.TransformResources.InstanceCount = requestTransformResources_transformResources_InstanceCount.Value;
                requestTransformResourcesIsNull = false;
            }
            Amazon.SageMaker.TransformInstanceType requestTransformResources_transformResources_InstanceType = null;
            if (cmdletContext.TransformResources_InstanceType != null)
            {
                requestTransformResources_transformResources_InstanceType = cmdletContext.TransformResources_InstanceType;
            }
            if (requestTransformResources_transformResources_InstanceType != null)
            {
                request.TransformResources.InstanceType = requestTransformResources_transformResources_InstanceType;
                requestTransformResourcesIsNull = false;
            }
            System.String requestTransformResources_transformResources_TransformAmiVersion = null;
            if (cmdletContext.TransformResources_TransformAmiVersion != null)
            {
                requestTransformResources_transformResources_TransformAmiVersion = cmdletContext.TransformResources_TransformAmiVersion;
            }
            if (requestTransformResources_transformResources_TransformAmiVersion != null)
            {
                request.TransformResources.TransformAmiVersion = requestTransformResources_transformResources_TransformAmiVersion;
                requestTransformResourcesIsNull = false;
            }
            System.String requestTransformResources_transformResources_VolumeKmsKeyId = null;
            if (cmdletContext.TransformResources_VolumeKmsKeyId != null)
            {
                requestTransformResources_transformResources_VolumeKmsKeyId = cmdletContext.TransformResources_VolumeKmsKeyId;
            }
            if (requestTransformResources_transformResources_VolumeKmsKeyId != null)
            {
                request.TransformResources.VolumeKmsKeyId = requestTransformResources_transformResources_VolumeKmsKeyId;
                requestTransformResourcesIsNull = false;
            }
             // determine if request.TransformResources should be set to null
            if (requestTransformResourcesIsNull)
            {
                request.TransformResources = null;
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
        
        private Amazon.SageMaker.Model.CreateTransformJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTransformJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTransformJob");
            try
            {
                return client.CreateTransformJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.BatchStrategy BatchStrategy { get; set; }
            public System.String DataCaptureConfig_DestinationS3Uri { get; set; }
            public System.Boolean? DataCaptureConfig_GenerateInferenceId { get; set; }
            public System.String DataCaptureConfig_KmsKeyId { get; set; }
            public System.String DataProcessing_InputFilter { get; set; }
            public Amazon.SageMaker.JoinSource DataProcessing_JoinSource { get; set; }
            public System.String DataProcessing_OutputFilter { get; set; }
            public Dictionary<System.String, System.String> Environment { get; set; }
            public System.String ExperimentConfig_ExperimentName { get; set; }
            public System.String ExperimentConfig_RunName { get; set; }
            public System.String ExperimentConfig_TrialComponentDisplayName { get; set; }
            public System.String ExperimentConfig_TrialName { get; set; }
            public System.Int32? MaxConcurrentTransform { get; set; }
            public System.Int32? MaxPayloadInMB { get; set; }
            public System.Int32? ModelClientConfig_InvocationsMaxRetry { get; set; }
            public System.Int32? ModelClientConfig_InvocationsTimeoutInSecond { get; set; }
            public System.String ModelName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public Amazon.SageMaker.CompressionType TransformInput_CompressionType { get; set; }
            public System.String TransformInput_ContentType { get; set; }
            public Amazon.SageMaker.S3DataType S3DataSource_S3DataType { get; set; }
            public System.String S3DataSource_S3Uri { get; set; }
            public Amazon.SageMaker.SplitType TransformInput_SplitType { get; set; }
            public System.String TransformJobName { get; set; }
            public System.String TransformOutput_Accept { get; set; }
            public Amazon.SageMaker.AssemblyType TransformOutput_AssembleWith { get; set; }
            public System.String TransformOutput_KmsKeyId { get; set; }
            public System.String TransformOutput_S3OutputPath { get; set; }
            public System.Int32? TransformResources_InstanceCount { get; set; }
            public Amazon.SageMaker.TransformInstanceType TransformResources_InstanceType { get; set; }
            public System.String TransformResources_TransformAmiVersion { get; set; }
            public System.String TransformResources_VolumeKmsKeyId { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateTransformJobResponse, NewSMTransformJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransformJobArn;
        }
        
    }
}
