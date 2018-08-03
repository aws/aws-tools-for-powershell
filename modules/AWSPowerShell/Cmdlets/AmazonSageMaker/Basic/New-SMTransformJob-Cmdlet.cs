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
    /// Starts a transform job. A transform job uses a trained model to get inferences on
    /// a dataset and saves these results to an Amazon S3 location that you specify.
    /// 
    ///  
    /// <para>
    /// To perform batch transformations, you create a transform job and use the data that
    /// you have readily available.
    /// </para><para>
    /// In the request body, you provide the following:
    /// </para><ul><li><para><code>TransformJobName</code> - Identifies the transform job. The name must be unique
    /// within an AWS Region in an AWS account.
    /// </para></li><li><para><code>ModelName</code> - Identifies the model to use. <code>ModelName</code> must
    /// be the name of an existing Amazon SageMaker model within an AWS Region in an AWS account.
    /// </para></li><li><para><code>TransformInput</code> - Describes the dataset to be transformed and the Amazon
    /// S3 location where it is stored.
    /// </para></li><li><para><code>TransformOutput</code> - Identifies the Amazon S3 location where you want Amazon
    /// SageMaker to save the results from the transform job.
    /// </para></li><li><para><code>TransformResources</code> - Identifies the ML compute instances for the transform
    /// job.
    /// </para></li></ul><para>
    ///  For more information about how batch transformation works Amazon SageMaker, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/batch-transform.html">How It
    /// Works</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMTransformJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTransformJob API operation.", Operation = new[] {"CreateTransformJob"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTransformJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMTransformJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter TransformOutput_Accept
        /// <summary>
        /// <para>
        /// <para>The MIME type used to specify the output data. Amazon SageMaker uses the MIME type
        /// with each http call to transfer data from the transform job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TransformOutput_Accept { get; set; }
        #endregion
        
        #region Parameter TransformOutput_AssembleWith
        /// <summary>
        /// <para>
        /// <para>Defines how to assemble the results of the transform job as a single S3 object. You
        /// should select a format that is most convenient to you. To concatenate the results
        /// in binary format, specify <code>None</code>. To add a newline character at the end
        /// of every transformed record, specify <code>Line</code>. To assemble the output in
        /// RecordIO format, specify <code>RecordIO</code>. The default value is <code>None</code>.</para><para>For information about the <code>RecordIO</code> format, see <a href="http://mxnet.io/architecture/note_data_loading.html#data-format">Data
        /// Format</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.AssemblyType")]
        public Amazon.SageMaker.AssemblyType TransformOutput_AssembleWith { get; set; }
        #endregion
        
        #region Parameter BatchStrategy
        /// <summary>
        /// <para>
        /// <para>Determines the number of records included in a single mini-batch. <code>SingleRecord</code>
        /// means only one record is used per mini-batch. <code>MultiRecord</code> means a mini-batch
        /// is set to contain as many records that can fit within the <code>MaxPayloadInMB</code>
        /// limit.</para><para>Batch transform will automatically split your input data into whatever payload size
        /// is specified if you set <code>SplitType</code> to <code>Line</code> and <code>BatchStrategy</code>
        /// to <code>MultiRecord</code>. There's no need to split the dataset into smaller files
        /// or to use larger payload sizes unless the records in your dataset are very large.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.BatchStrategy")]
        public Amazon.SageMaker.BatchStrategy BatchStrategy { get; set; }
        #endregion
        
        #region Parameter TransformInput_CompressionType
        /// <summary>
        /// <para>
        /// <para>Compressing data helps save on storage space. If your transform data is compressed,
        /// specify the compression type.and Amazon SageMaker will automatically decompress the
        /// data for the transform job accordingly. The default value is <code>None</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String TransformInput_ContentType { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to set in the Docker container. We support up to 16 key
        /// and values entries in the map.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Environment { get; set; }
        #endregion
        
        #region Parameter TransformResources_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of ML compute instances to use in the transform job. For distributed transform,
        /// provide a value greater than 1. The default value is <code>1</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TransformResources_InstanceCount { get; set; }
        #endregion
        
        #region Parameter TransformResources_InstanceType
        /// <summary>
        /// <para>
        /// <para>The ML compute instance type for the transform job. For using built-in algorithms
        /// to transform moderately sized datasets, ml.m4.xlarge or <code>ml.m5.large</code> should
        /// suffice. There is no default value for <code>InstanceType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.TransformInstanceType")]
        public Amazon.SageMaker.TransformInstanceType TransformResources_InstanceType { get; set; }
        #endregion
        
        #region Parameter TransformOutput_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service (AWS KMS) key for Amazon S3 server-side encryption
        /// that Amazon SageMaker uses to encrypt the transformed data.</para><para>If you don't provide a KMS key ID, Amazon SageMaker uses the default KMS key for Amazon
        /// S3 for your role's account. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingKMSEncryption.html">KMS-Managed
        /// Encryption Keys</a> in the <i>Amazon Simple Storage Service Developer Guide.</i></para><para>The KMS key policy must grant permission to the IAM role that you specify in your
        /// <code>CreateTramsformJob</code> request. For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">Using
        /// Key Policies in AWS KMS</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TransformOutput_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaxConcurrentTransform
        /// <summary>
        /// <para>
        /// <para>The maximum number of parallel requests that can be sent to each instance in a transform
        /// job. This is good for algorithms that implement multiple workers on larger instances
        /// . The default value is <code>1</code>. To allow Amazon SageMaker to determine the
        /// appropriate number for <code>MaxConcurrentTransforms</code>, set the value to <code>0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxConcurrentTransforms")]
        public System.Int32 MaxConcurrentTransform { get; set; }
        #endregion
        
        #region Parameter MaxPayloadInMB
        /// <summary>
        /// <para>
        /// <para>The maximum payload size allowed, in MB. A payload is the data portion of a record
        /// (without metadata). The value in <code>MaxPayloadInMB</code> must be greater or equal
        /// to the size of a single record. You can approximate the size of a record by dividing
        /// the size of your dataset by the number of records. Then multiply this value by the
        /// number of records you want in a mini-batch. It is recommended to enter a value slightly
        /// larger than this to ensure the records fit within the maximum payload size. The default
        /// value is <code>6</code> MB. For an unlimited payload size, set the value to <code>0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxPayloadInMB { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the model that you want to use for the transform job. <code>ModelName</code>
        /// must be the name of an existing Amazon SageMaker model within an AWS Region in an
        /// AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter S3DataSource_S3DataType
        /// <summary>
        /// <para>
        /// <para>If you choose <code>S3Prefix</code>, <code>S3Uri</code> identifies a key name prefix.
        /// Amazon SageMaker uses all objects with the specified key name prefix for batch transform.
        /// </para><para>If you choose <code>ManifestFile</code>, <code>S3Uri</code> identifies an object that
        /// is a manifest file containing a list of object keys that you want Amazon SageMaker
        /// to use for batch transform. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TransformInput_DataSource_S3DataSource_S3DataType")]
        [AWSConstantClassSource("Amazon.SageMaker.S3DataType")]
        public Amazon.SageMaker.S3DataType S3DataSource_S3DataType { get; set; }
        #endregion
        
        #region Parameter TransformOutput_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path where you want Amazon SageMaker to store the results of the transform
        /// job. For example, <code>s3://bucket-name/key-name-prefix</code>.</para><para>For every S3 object used as input for the transform job, the transformed data is stored
        /// in a corresponding subfolder in the location under the output prefix. For example,
        /// the input data <code>s3://bucket-name/input-name-prefix/dataset01/data.csv</code>
        /// will have the transformed data stored at <code>s3://bucket-name/key-name-prefix/dataset01/</code>,
        /// based on the original name, as a series of .part files (.part0001, part0002, etc).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TransformOutput_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter S3DataSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>Depending on the value specified for the <code>S3DataType</code>, identifies either
        /// a key name prefix or a manifest. For example:</para><ul><li><para> A key name prefix might look like this: <code>s3://bucketname/exampleprefix</code>.
        /// </para></li><li><para> A manifest might look like this: <code>s3://bucketname/example.manifest</code></para><para> The manifest is an S3 object which is a JSON file with the following format: </para><para><code>[</code></para><para><code> {"prefix": "s3://customer_bucket/some/prefix/"},</code></para><para><code> "relative/path/to/custdata-1",</code></para><para><code> "relative/path/custdata-2",</code></para><para><code> ...</code></para><para><code> ]</code></para><para> The preceding JSON matches the following <code>S3Uris</code>: </para><para><code>s3://customer_bucket/some/prefix/relative/path/to/custdata-1</code></para><para><code>s3://customer_bucket/some/prefix/relative/path/custdata-1</code></para><para><code>...</code></para><para> The complete set of <code>S3Uris</code> in this manifest constitutes the input data
        /// for the channel for this datasource. The object that each <code>S3Uris</code> points
        /// to must be readable by the IAM role that Amazon SageMaker uses to perform tasks on
        /// your behalf.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TransformInput_DataSource_S3DataSource_S3Uri")]
        public System.String S3DataSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter TransformInput_SplitType
        /// <summary>
        /// <para>
        /// <para>The method to use to split the transform job's data into smaller batches. The default
        /// value is <code>None</code>. If you don't want to split the data, specify <code>None</code>.
        /// If you want to split records on a newline character boundary, specify <code>Line</code>.
        /// To split records according to the RecordIO format, specify <code>RecordIO</code>.</para><para>Amazon SageMaker will send maximum number of records per batch in each request up
        /// to the MaxPayloadInMB limit. For more information, see <a href="http://mxnet.io/architecture/note_data_loading.html#data-format">RecordIO
        /// data format</a>.</para><note><para>For information about the <code>RecordIO</code> format, see <a href="http://mxnet.io/architecture/note_data_loading.html#data-format">Data
        /// Format</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.SplitType")]
        public Amazon.SageMaker.SplitType TransformInput_SplitType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. Adding tags is optional. For more information, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i>AWS Billing and Cost Management User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TransformJobName
        /// <summary>
        /// <para>
        /// <para>The name of the transform job. The name must be unique within an AWS Region in an
        /// AWS account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TransformJobName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TransformJobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTransformJob (CreateTransformJob)"))
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
            
            context.BatchStrategy = this.BatchStrategy;
            if (this.Environment != null)
            {
                context.Environment = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Environment.Keys)
                {
                    context.Environment.Add((String)hashKey, (String)(this.Environment[hashKey]));
                }
            }
            if (ParameterWasBound("MaxConcurrentTransform"))
                context.MaxConcurrentTransforms = this.MaxConcurrentTransform;
            if (ParameterWasBound("MaxPayloadInMB"))
                context.MaxPayloadInMB = this.MaxPayloadInMB;
            context.ModelName = this.ModelName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TransformInput_CompressionType = this.TransformInput_CompressionType;
            context.TransformInput_ContentType = this.TransformInput_ContentType;
            context.TransformInput_DataSource_S3DataSource_S3DataType = this.S3DataSource_S3DataType;
            context.TransformInput_DataSource_S3DataSource_S3Uri = this.S3DataSource_S3Uri;
            context.TransformInput_SplitType = this.TransformInput_SplitType;
            context.TransformJobName = this.TransformJobName;
            context.TransformOutput_Accept = this.TransformOutput_Accept;
            context.TransformOutput_AssembleWith = this.TransformOutput_AssembleWith;
            context.TransformOutput_KmsKeyId = this.TransformOutput_KmsKeyId;
            context.TransformOutput_S3OutputPath = this.TransformOutput_S3OutputPath;
            if (ParameterWasBound("TransformResources_InstanceCount"))
                context.TransformResources_InstanceCount = this.TransformResources_InstanceCount;
            context.TransformResources_InstanceType = this.TransformResources_InstanceType;
            
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
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.MaxConcurrentTransforms != null)
            {
                request.MaxConcurrentTransforms = cmdletContext.MaxConcurrentTransforms.Value;
            }
            if (cmdletContext.MaxPayloadInMB != null)
            {
                request.MaxPayloadInMB = cmdletContext.MaxPayloadInMB.Value;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
             // populate TransformInput
            bool requestTransformInputIsNull = true;
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
            bool requestTransformInput_transformInput_DataSourceIsNull = true;
            requestTransformInput_transformInput_DataSource = new Amazon.SageMaker.Model.TransformDataSource();
            Amazon.SageMaker.Model.TransformS3DataSource requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource = null;
            
             // populate S3DataSource
            bool requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSourceIsNull = true;
            requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource = new Amazon.SageMaker.Model.TransformS3DataSource();
            Amazon.SageMaker.S3DataType requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType = null;
            if (cmdletContext.TransformInput_DataSource_S3DataSource_S3DataType != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType = cmdletContext.TransformInput_DataSource_S3DataSource_S3DataType;
            }
            if (requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource.S3DataType = requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3DataType;
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSourceIsNull = false;
            }
            System.String requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3Uri = null;
            if (cmdletContext.TransformInput_DataSource_S3DataSource_S3Uri != null)
            {
                requestTransformInput_transformInput_DataSource_transformInput_DataSource_S3DataSource_s3DataSource_S3Uri = cmdletContext.TransformInput_DataSource_S3DataSource_S3Uri;
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
            bool requestTransformOutputIsNull = true;
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
            bool requestTransformResourcesIsNull = true;
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
             // determine if request.TransformResources should be set to null
            if (requestTransformResourcesIsNull)
            {
                request.TransformResources = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TransformJobArn;
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
        
        private Amazon.SageMaker.Model.CreateTransformJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTransformJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTransformJob");
            try
            {
                #if DESKTOP
                return client.CreateTransformJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateTransformJobAsync(request);
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
            public Amazon.SageMaker.BatchStrategy BatchStrategy { get; set; }
            public Dictionary<System.String, System.String> Environment { get; set; }
            public System.Int32? MaxConcurrentTransforms { get; set; }
            public System.Int32? MaxPayloadInMB { get; set; }
            public System.String ModelName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tags { get; set; }
            public Amazon.SageMaker.CompressionType TransformInput_CompressionType { get; set; }
            public System.String TransformInput_ContentType { get; set; }
            public Amazon.SageMaker.S3DataType TransformInput_DataSource_S3DataSource_S3DataType { get; set; }
            public System.String TransformInput_DataSource_S3DataSource_S3Uri { get; set; }
            public Amazon.SageMaker.SplitType TransformInput_SplitType { get; set; }
            public System.String TransformJobName { get; set; }
            public System.String TransformOutput_Accept { get; set; }
            public Amazon.SageMaker.AssemblyType TransformOutput_AssembleWith { get; set; }
            public System.String TransformOutput_KmsKeyId { get; set; }
            public System.String TransformOutput_S3OutputPath { get; set; }
            public System.Int32? TransformResources_InstanceCount { get; set; }
            public Amazon.SageMaker.TransformInstanceType TransformResources_InstanceType { get; set; }
        }
        
    }
}
