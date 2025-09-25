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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Creates a new document classifier that you can use to categorize documents. To create
    /// a classifier, you provide a set of training documents that are labeled with the categories
    /// that you want to use. For more information, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/training-classifier-model.html">Training
    /// classifier models</a> in the Comprehend Developer Guide.
    /// </summary>
    [Cmdlet("New", "COMPDocumentClassifier", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Comprehend CreateDocumentClassifier API operation.", Operation = new[] {"CreateDocumentClassifier"}, SelectReturnType = typeof(Amazon.Comprehend.Model.CreateDocumentClassifierResponse))]
    [AWSCmdletOutput("System.String or Amazon.Comprehend.Model.CreateDocumentClassifierResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Comprehend.Model.CreateDocumentClassifierResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCOMPDocumentClassifierCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InputDataConfig_AugmentedManifest
        /// <summary>
        /// <para>
        /// <para>A list of augmented manifest files that provide training data for your custom model.
        /// An augmented manifest file is a labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth.</para><para>This parameter is required if you set <c>DataFormat</c> to <c>AUGMENTED_MANIFEST</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_AugmentedManifests")]
        public Amazon.Comprehend.Model.AugmentedManifestsListItem[] InputDataConfig_AugmentedManifest { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. If you don't set the client request token, Amazon
        /// Comprehend generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that grants Amazon Comprehend read
        /// access to your input data.</para>
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
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_DataFormat
        /// <summary>
        /// <para>
        /// <para>The format of your training data:</para><ul><li><para><c>COMPREHEND_CSV</c>: A two-column CSV file, where labels are provided in the first
        /// column, and documents are provided in the second. If you use this value, you must
        /// provide the <c>S3Uri</c> parameter in your request.</para></li><li><para><c>AUGMENTED_MANIFEST</c>: A labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth. This file is in JSON lines format. Each line is a complete JSON object
        /// that contains a training document and its associated labels. </para><para>If you use this value, you must provide the <c>AugmentedManifests</c> parameter in
        /// your request.</para></li></ul><para>If you don't specify a value, Amazon Comprehend uses <c>COMPREHEND_CSV</c> as the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentClassifierDataFormat")]
        public Amazon.Comprehend.DocumentClassifierDataFormat InputDataConfig_DataFormat { get; set; }
        #endregion
        
        #region Parameter DocumentClassifierName
        /// <summary>
        /// <para>
        /// <para>The name of the document classifier.</para>
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
        public System.String DocumentClassifierName { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_DocumentReadAction
        /// <summary>
        /// <para>
        /// <para>This field defines the Amazon Textract API operation that Amazon Comprehend uses to
        /// extract text from PDF files and image files. Enter one of the following values:</para><ul><li><para><c>TEXTRACT_DETECT_DOCUMENT_TEXT</c> - The Amazon Comprehend service uses the <c>DetectDocumentText</c>
        /// API operation. </para></li><li><para><c>TEXTRACT_ANALYZE_DOCUMENT</c> - The Amazon Comprehend service uses the <c>AnalyzeDocument</c>
        /// API operation. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_DocumentReaderConfig_DocumentReadAction")]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentReadAction")]
        public Amazon.Comprehend.DocumentReadAction DocumentReaderConfig_DocumentReadAction { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_DocumentReadMode
        /// <summary>
        /// <para>
        /// <para>Determines the text extraction actions for PDF files. Enter one of the following values:</para><ul><li><para><c>SERVICE_DEFAULT</c> - use the Amazon Comprehend service defaults for PDF files.</para></li><li><para><c>FORCE_DOCUMENT_READ_ACTION</c> - Amazon Comprehend uses the Textract API specified
        /// by DocumentReadAction for all PDF files, including digital PDF files. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_DocumentReaderConfig_DocumentReadMode")]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentReadMode")]
        public Amazon.Comprehend.DocumentReadMode DocumentReaderConfig_DocumentReadMode { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_DocumentType
        /// <summary>
        /// <para>
        /// <para>The type of input documents for training the model. Provide plain-text documents to
        /// create a plain-text model, and provide semi-structured documents to create a native
        /// document model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentClassifierDocumentTypeFormat")]
        public Amazon.Comprehend.DocumentClassifierDocumentTypeFormat InputDataConfig_DocumentType { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_FeatureType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of Amazon Textract features to apply. If you chose <c>TEXTRACT_ANALYZE_DOCUMENT</c>
        /// as the read action, you must specify one or both of the following values:</para><ul><li><para><c>TABLES</c> - Returns additional information about any tables that are detected
        /// in the input document. </para></li><li><para><c>FORMS</c> - Returns additional information about any forms that are detected in
        /// the input document. </para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_DocumentReaderConfig_FeatureTypes")]
        public System.String[] DocumentReaderConfig_FeatureType { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_FlywheelStatsS3Prefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 prefix for the data lake location of the flywheel statistics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_FlywheelStatsS3Prefix { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the Amazon Web Services Key Management Service (KMS) key that Amazon Comprehend
        /// uses to encrypt the output results from an analysis job. The KmsKeyId can be one of
        /// the following formats:</para><ul><li><para>KMS Key ID: <c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <c>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>KMS Key Alias: <c>"alias/ExampleAlias"</c></para></li><li><para>ARN of a KMS Key Alias: <c>"arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_LabelDelimiter
        /// <summary>
        /// <para>
        /// <para>Indicates the delimiter used to separate each label for training a multi-label classifier.
        /// The default delimiter between labels is a pipe (|). You can use a different character
        /// as a delimiter (if it's an allowed character) by specifying it under Delimiter for
        /// labels. If the training documents use a delimiter other than the default or the delimiter
        /// you specify, the labels on that line will be combined to make a single unique label,
        /// such as LABELLABELLABEL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_LabelDelimiter { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language of the input documents. You can specify any of the languages supported
        /// by Amazon Comprehend. All documents must be in the same language.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Comprehend.LanguageCode")]
        public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>Indicates the mode in which the classifier will be trained. The classifier can be
        /// trained in multi-class (single-label) mode or multi-label mode. Multi-class mode identifies
        /// a single class label for each document and multi-label mode identifies one or more
        /// class labels for each document. Multiple labels for an individual document are separated
        /// by a delimiter. The default delimiter between labels is a pipe (|).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentClassifierMode")]
        public Amazon.Comprehend.DocumentClassifierMode Mode { get; set; }
        #endregion
        
        #region Parameter ModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the KMS key that Amazon Comprehend uses to encrypt trained custom models. The
        /// ModelKmsKeyId can be either of the following formats:</para><ul><li><para>KMS Key ID: <c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <c>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ModelPolicy
        /// <summary>
        /// <para>
        /// <para>The resource-based policy to attach to your custom document classifier model. You
        /// can use this policy to allow another Amazon Web Services account to import your custom
        /// model.</para><para>Provide your policy as a JSON body that you enter as a UTF-8 encoded string without
        /// line breaks. To provide valid JSON, enclose the attribute names and values in double
        /// quotes. If the JSON body is also enclosed in double quotes, then you must escape the
        /// double quotes that are inside the policy:</para><para><c>"{\"attribute\": \"value\", \"attribute\": [\"value\"]}"</c></para><para>To avoid escaping quotes, you can use single quotes to enclose the policy and double
        /// quotes to enclose the JSON names and values:</para><para><c>'{"attribute": "value", "attribute": ["value"]}'</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPolicy { get; set; }
        #endregion
        
        #region Parameter Documents_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI location of the training documents specified in the S3Uri CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Documents_S3Uri")]
        public System.String Documents_S3Uri { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the input data. The S3 bucket must be in the same Region as
        /// the API endpoint that you are calling. The URI can point to a single input file or
        /// it can provide the prefix for a collection of input files.</para><para>For example, if you use the URI <c>S3://bucketName/prefix</c>, if the prefix is a
        /// single file, Amazon Comprehend uses that file as input. If more than one file begins
        /// with the prefix, Amazon Comprehend uses all of them as input.</para><para>This parameter is required if you set <c>DataFormat</c> to <c>COMPREHEND_CSV</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>When you use the <c>OutputDataConfig</c> object while creating a custom classifier,
        /// you specify the Amazon S3 location where you want to write the confusion matrix and
        /// other output files. The URI must be in the same Region as the API endpoint that you
        /// are calling. The location is used as the prefix for the actual location of this output
        /// file.</para><para>When the custom classifier job is finished, the service creates the output file in
        /// a directory specific to the job. The <c>S3Uri</c> field contains the location of the
        /// output file, called <c>output.tar.gz</c>. It is a compressed archive that contains
        /// the confusion matrix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID number for a security group on an instance of your private VPC. Security groups
        /// on your VPC function serve as a virtual firewall to control inbound and outbound traffic
        /// and provides security for the resources that you’ll be accessing on the VPC. This
        /// ID number is preceded by "sg-", for instance: "sg-03b388029b0a285ea". For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html">Security
        /// Groups for your VPC</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID for each subnet being used in your private VPC. This subnet is a subset of
        /// the a range of IPv4 addresses used by the VPC and is specific to a given availability
        /// zone in the VPC’s Region. This ID number is preceded by "subnet-", for instance: "subnet-04ccf456919e69055".
        /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and Subnets</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the document classifier. A tag is a key-value pair that adds
        /// as a metadata to a resource used by Amazon Comprehend. For example, a tag with "Sales"
        /// as the key might be added to a resource to indicate its use by the sales department.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Comprehend.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Documents_TestS3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI location of the test documents included in the TestS3Uri CSV file. This
        /// field is not required if you do not specify a test CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Documents_TestS3Uri")]
        public System.String Documents_TestS3Uri { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_TestS3Uri
        /// <summary>
        /// <para>
        /// <para>This specifies the Amazon S3 location that contains the test annotations for the document
        /// classifier. The URI must be in the same Amazon Web Services Region as the API endpoint
        /// that you are calling. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_TestS3Uri { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>The version name given to the newly created classifier. Version names can have a maximum
        /// of 256 characters. Alphanumeric characters, hyphens (-) and underscores (_) are allowed.
        /// The version name must be unique among all models with the same classifier name in
        /// the Amazon Web Services account/Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the Amazon Web Services Key Management Service (KMS) key that Amazon Comprehend
        /// uses to encrypt data on the storage volume attached to the ML compute instance(s)
        /// that process the analysis job. The VolumeKmsKeyId can be either of the following formats:</para><ul><li><para>KMS Key ID: <c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <c>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DocumentClassifierArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.CreateDocumentClassifierResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.CreateDocumentClassifierResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DocumentClassifierArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DocumentClassifierName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COMPDocumentClassifier (CreateDocumentClassifier)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.CreateDocumentClassifierResponse, NewCOMPDocumentClassifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentClassifierName = this.DocumentClassifierName;
            #if MODULAR
            if (this.DocumentClassifierName == null && ParameterWasBound(nameof(this.DocumentClassifierName)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentClassifierName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputDataConfig_AugmentedManifest != null)
            {
                context.InputDataConfig_AugmentedManifest = new List<Amazon.Comprehend.Model.AugmentedManifestsListItem>(this.InputDataConfig_AugmentedManifest);
            }
            context.InputDataConfig_DataFormat = this.InputDataConfig_DataFormat;
            context.DocumentReaderConfig_DocumentReadAction = this.DocumentReaderConfig_DocumentReadAction;
            context.DocumentReaderConfig_DocumentReadMode = this.DocumentReaderConfig_DocumentReadMode;
            if (this.DocumentReaderConfig_FeatureType != null)
            {
                context.DocumentReaderConfig_FeatureType = new List<System.String>(this.DocumentReaderConfig_FeatureType);
            }
            context.Documents_S3Uri = this.Documents_S3Uri;
            context.Documents_TestS3Uri = this.Documents_TestS3Uri;
            context.InputDataConfig_DocumentType = this.InputDataConfig_DocumentType;
            context.InputDataConfig_LabelDelimiter = this.InputDataConfig_LabelDelimiter;
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            context.InputDataConfig_TestS3Uri = this.InputDataConfig_TestS3Uri;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mode = this.Mode;
            context.ModelKmsKeyId = this.ModelKmsKeyId;
            context.ModelPolicy = this.ModelPolicy;
            context.OutputDataConfig_FlywheelStatsS3Prefix = this.OutputDataConfig_FlywheelStatsS3Prefix;
            context.OutputDataConfig_KmsKeyId = this.OutputDataConfig_KmsKeyId;
            context.OutputDataConfig_S3Uri = this.OutputDataConfig_S3Uri;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Comprehend.Model.Tag>(this.Tag);
            }
            context.VersionName = this.VersionName;
            context.VolumeKmsKeyId = this.VolumeKmsKeyId;
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
            var request = new Amazon.Comprehend.Model.CreateDocumentClassifierRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.DocumentClassifierName != null)
            {
                request.DocumentClassifierName = cmdletContext.DocumentClassifierName;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.Comprehend.Model.DocumentClassifierInputDataConfig();
            List<Amazon.Comprehend.Model.AugmentedManifestsListItem> requestInputDataConfig_inputDataConfig_AugmentedManifest = null;
            if (cmdletContext.InputDataConfig_AugmentedManifest != null)
            {
                requestInputDataConfig_inputDataConfig_AugmentedManifest = cmdletContext.InputDataConfig_AugmentedManifest;
            }
            if (requestInputDataConfig_inputDataConfig_AugmentedManifest != null)
            {
                request.InputDataConfig.AugmentedManifests = requestInputDataConfig_inputDataConfig_AugmentedManifest;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.DocumentClassifierDataFormat requestInputDataConfig_inputDataConfig_DataFormat = null;
            if (cmdletContext.InputDataConfig_DataFormat != null)
            {
                requestInputDataConfig_inputDataConfig_DataFormat = cmdletContext.InputDataConfig_DataFormat;
            }
            if (requestInputDataConfig_inputDataConfig_DataFormat != null)
            {
                request.InputDataConfig.DataFormat = requestInputDataConfig_inputDataConfig_DataFormat;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.DocumentClassifierDocumentTypeFormat requestInputDataConfig_inputDataConfig_DocumentType = null;
            if (cmdletContext.InputDataConfig_DocumentType != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentType = cmdletContext.InputDataConfig_DocumentType;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentType != null)
            {
                request.InputDataConfig.DocumentType = requestInputDataConfig_inputDataConfig_DocumentType;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_LabelDelimiter = null;
            if (cmdletContext.InputDataConfig_LabelDelimiter != null)
            {
                requestInputDataConfig_inputDataConfig_LabelDelimiter = cmdletContext.InputDataConfig_LabelDelimiter;
            }
            if (requestInputDataConfig_inputDataConfig_LabelDelimiter != null)
            {
                request.InputDataConfig.LabelDelimiter = requestInputDataConfig_inputDataConfig_LabelDelimiter;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_S3Uri = null;
            if (cmdletContext.InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3Uri = cmdletContext.InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3Uri != null)
            {
                request.InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3Uri;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_TestS3Uri = null;
            if (cmdletContext.InputDataConfig_TestS3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_TestS3Uri = cmdletContext.InputDataConfig_TestS3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_TestS3Uri != null)
            {
                request.InputDataConfig.TestS3Uri = requestInputDataConfig_inputDataConfig_TestS3Uri;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DocumentClassifierDocuments requestInputDataConfig_inputDataConfig_Documents = null;
            
             // populate Documents
            var requestInputDataConfig_inputDataConfig_DocumentsIsNull = true;
            requestInputDataConfig_inputDataConfig_Documents = new Amazon.Comprehend.Model.DocumentClassifierDocuments();
            System.String requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri = null;
            if (cmdletContext.Documents_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri = cmdletContext.Documents_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Documents.S3Uri = requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri;
                requestInputDataConfig_inputDataConfig_DocumentsIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_Documents_documents_TestS3Uri = null;
            if (cmdletContext.Documents_TestS3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Documents_documents_TestS3Uri = cmdletContext.Documents_TestS3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_Documents_documents_TestS3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Documents.TestS3Uri = requestInputDataConfig_inputDataConfig_Documents_documents_TestS3Uri;
                requestInputDataConfig_inputDataConfig_DocumentsIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_Documents should be set to null
            if (requestInputDataConfig_inputDataConfig_DocumentsIsNull)
            {
                requestInputDataConfig_inputDataConfig_Documents = null;
            }
            if (requestInputDataConfig_inputDataConfig_Documents != null)
            {
                request.InputDataConfig.Documents = requestInputDataConfig_inputDataConfig_Documents;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DocumentReaderConfig requestInputDataConfig_inputDataConfig_DocumentReaderConfig = null;
            
             // populate DocumentReaderConfig
            var requestInputDataConfig_inputDataConfig_DocumentReaderConfigIsNull = true;
            requestInputDataConfig_inputDataConfig_DocumentReaderConfig = new Amazon.Comprehend.Model.DocumentReaderConfig();
            Amazon.Comprehend.DocumentReadAction requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadAction = null;
            if (cmdletContext.DocumentReaderConfig_DocumentReadAction != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadAction = cmdletContext.DocumentReaderConfig_DocumentReadAction;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadAction != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig.DocumentReadAction = requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadAction;
                requestInputDataConfig_inputDataConfig_DocumentReaderConfigIsNull = false;
            }
            Amazon.Comprehend.DocumentReadMode requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadMode = null;
            if (cmdletContext.DocumentReaderConfig_DocumentReadMode != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadMode = cmdletContext.DocumentReaderConfig_DocumentReadMode;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadMode != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig.DocumentReadMode = requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_DocumentReadMode;
                requestInputDataConfig_inputDataConfig_DocumentReaderConfigIsNull = false;
            }
            List<System.String> requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_FeatureType = null;
            if (cmdletContext.DocumentReaderConfig_FeatureType != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_FeatureType = cmdletContext.DocumentReaderConfig_FeatureType;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_FeatureType != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig.FeatureTypes = requestInputDataConfig_inputDataConfig_DocumentReaderConfig_documentReaderConfig_FeatureType;
                requestInputDataConfig_inputDataConfig_DocumentReaderConfigIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_DocumentReaderConfig should be set to null
            if (requestInputDataConfig_inputDataConfig_DocumentReaderConfigIsNull)
            {
                requestInputDataConfig_inputDataConfig_DocumentReaderConfig = null;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentReaderConfig != null)
            {
                request.InputDataConfig.DocumentReaderConfig = requestInputDataConfig_inputDataConfig_DocumentReaderConfig;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.ModelKmsKeyId != null)
            {
                request.ModelKmsKeyId = cmdletContext.ModelKmsKeyId;
            }
            if (cmdletContext.ModelPolicy != null)
            {
                request.ModelPolicy = cmdletContext.ModelPolicy;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Comprehend.Model.DocumentClassifierOutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_FlywheelStatsS3Prefix = null;
            if (cmdletContext.OutputDataConfig_FlywheelStatsS3Prefix != null)
            {
                requestOutputDataConfig_outputDataConfig_FlywheelStatsS3Prefix = cmdletContext.OutputDataConfig_FlywheelStatsS3Prefix;
            }
            if (requestOutputDataConfig_outputDataConfig_FlywheelStatsS3Prefix != null)
            {
                request.OutputDataConfig.FlywheelStatsS3Prefix = requestOutputDataConfig_outputDataConfig_FlywheelStatsS3Prefix;
                requestOutputDataConfigIsNull = false;
            }
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
            System.String requestOutputDataConfig_outputDataConfig_S3Uri = null;
            if (cmdletContext.OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Uri = cmdletContext.OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Uri != null)
            {
                request.OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3Uri;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
            }
            if (cmdletContext.VolumeKmsKeyId != null)
            {
                request.VolumeKmsKeyId = cmdletContext.VolumeKmsKeyId;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Comprehend.Model.VpcConfig();
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
        
        private Amazon.Comprehend.Model.CreateDocumentClassifierResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.CreateDocumentClassifierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "CreateDocumentClassifier");
            try
            {
                return client.CreateDocumentClassifierAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String DocumentClassifierName { get; set; }
            public List<Amazon.Comprehend.Model.AugmentedManifestsListItem> InputDataConfig_AugmentedManifest { get; set; }
            public Amazon.Comprehend.DocumentClassifierDataFormat InputDataConfig_DataFormat { get; set; }
            public Amazon.Comprehend.DocumentReadAction DocumentReaderConfig_DocumentReadAction { get; set; }
            public Amazon.Comprehend.DocumentReadMode DocumentReaderConfig_DocumentReadMode { get; set; }
            public List<System.String> DocumentReaderConfig_FeatureType { get; set; }
            public System.String Documents_S3Uri { get; set; }
            public System.String Documents_TestS3Uri { get; set; }
            public Amazon.Comprehend.DocumentClassifierDocumentTypeFormat InputDataConfig_DocumentType { get; set; }
            public System.String InputDataConfig_LabelDelimiter { get; set; }
            public System.String InputDataConfig_S3Uri { get; set; }
            public System.String InputDataConfig_TestS3Uri { get; set; }
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public Amazon.Comprehend.DocumentClassifierMode Mode { get; set; }
            public System.String ModelKmsKeyId { get; set; }
            public System.String ModelPolicy { get; set; }
            public System.String OutputDataConfig_FlywheelStatsS3Prefix { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public List<Amazon.Comprehend.Model.Tag> Tag { get; set; }
            public System.String VersionName { get; set; }
            public System.String VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.Comprehend.Model.CreateDocumentClassifierResponse, NewCOMPDocumentClassifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DocumentClassifierArn;
        }
        
    }
}
