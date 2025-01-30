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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Creates an entity recognizer using submitted files. After your <c>CreateEntityRecognizer</c>
    /// request is submitted, you can check job status using the <c>DescribeEntityRecognizer</c>
    /// API.
    /// </summary>
    [Cmdlet("New", "COMPEntityRecognizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Comprehend CreateEntityRecognizer API operation.", Operation = new[] {"CreateEntityRecognizer"}, SelectReturnType = typeof(Amazon.Comprehend.Model.CreateEntityRecognizerResponse))]
    [AWSCmdletOutput("System.String or Amazon.Comprehend.Model.CreateEntityRecognizerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Comprehend.Model.CreateEntityRecognizerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCOMPEntityRecognizerCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputDataConfig_AugmentedManifest
        /// <summary>
        /// <para>
        /// <para>A list of augmented manifest files that provide training data for your custom model.
        /// An augmented manifest file is a labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth.</para><para>This parameter is required if you set <c>DataFormat</c> to <c>AUGMENTED_MANIFEST</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_AugmentedManifests")]
        public Amazon.Comprehend.Model.AugmentedManifestsListItem[] InputDataConfig_AugmentedManifest { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the request. If you don't set the client request token, Amazon
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
        /// <para>The format of your training data:</para><ul><li><para><c>COMPREHEND_CSV</c>: A CSV file that supplements your training documents. The CSV
        /// file contains information about the custom entities that your trained model will detect.
        /// The required format of the file depends on whether you are providing annotations or
        /// an entity list.</para><para>If you use this value, you must provide your CSV file by using either the <c>Annotations</c>
        /// or <c>EntityList</c> parameters. You must provide your training documents by using
        /// the <c>Documents</c> parameter.</para></li><li><para><c>AUGMENTED_MANIFEST</c>: A labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth. This file is in JSON lines format. Each line is a complete JSON object
        /// that contains a training document and its labels. Each label annotates a named entity
        /// in the training document. </para><para>If you use this value, you must provide the <c>AugmentedManifests</c> parameter in
        /// your request.</para></li></ul><para>If you don't specify a value, Amazon Comprehend uses <c>COMPREHEND_CSV</c> as the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.EntityRecognizerDataFormat")]
        public Amazon.Comprehend.EntityRecognizerDataFormat InputDataConfig_DataFormat { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_EntityType
        /// <summary>
        /// <para>
        /// <para>The entity types in the labeled training data that Amazon Comprehend uses to train
        /// the custom entity recognizer. Any entity types that you don't specify are ignored.</para><para>A maximum of 25 entity types can be used at one time to train an entity recognizer.
        /// Entity types must not contain the following invalid characters: \n (line break), \\n
        /// (escaped line break), \r (carriage return), \\r (escaped carriage return), \t (tab),
        /// \\t (escaped tab), space, and , (comma). </para>
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
        [Alias("InputDataConfig_EntityTypes")]
        public Amazon.Comprehend.Model.EntityTypesListItem[] InputDataConfig_EntityType { get; set; }
        #endregion
        
        #region Parameter Documents_InputFormat
        /// <summary>
        /// <para>
        /// <para> Specifies how the text in an input file should be processed. This is optional, and
        /// the default is ONE_DOC_PER_LINE. ONE_DOC_PER_FILE - Each file is considered a separate
        /// document. Use this option when you are processing large documents, such as newspaper
        /// articles or scientific papers. ONE_DOC_PER_LINE - Each line in a file is considered
        /// a separate document. Use this option when you are processing many short documents,
        /// such as text messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Documents_InputFormat")]
        [AWSConstantClassSource("Amazon.Comprehend.InputFormat")]
        public Amazon.Comprehend.InputFormat Documents_InputFormat { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para> You can specify any of the following languages: English ("en"), Spanish ("es"), French
        /// ("fr"), Italian ("it"), German ("de"), or Portuguese ("pt"). If you plan to use this
        /// entity recognizer with PDF, Word, or image input files, you must specify English as
        /// the language. All training documents must be in the same language.</para>
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
        /// <para>The JSON resource-based policy to attach to your custom entity recognizer model. You
        /// can use this policy to allow another Amazon Web Services account to import your custom
        /// model.</para><para>Provide your JSON as a UTF-8 encoded string without line breaks. To provide valid
        /// JSON for your policy, enclose the attribute names and values in double quotes. If
        /// the JSON body is also enclosed in double quotes, then you must escape the double quotes
        /// that are inside the policy:</para><para><c>"{\"attribute\": \"value\", \"attribute\": [\"value\"]}"</c></para><para>To avoid escaping quotes, you can use single quotes to enclose the policy and double
        /// quotes to enclose the JSON names and values:</para><para><c>'{"attribute": "value", "attribute": ["value"]}'</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelPolicy { get; set; }
        #endregion
        
        #region Parameter RecognizerName
        /// <summary>
        /// <para>
        /// <para>The name given to the newly created recognizer. Recognizer names can be a maximum
        /// of 256 characters. Alphanumeric characters, hyphens (-) and underscores (_) are allowed.
        /// The name must be unique in the account/Region.</para>
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
        public System.String RecognizerName { get; set; }
        #endregion
        
        #region Parameter Annotations_S3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the annotations for an entity recognizer are
        /// located. The URI must be in the same Region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Annotations_S3Uri")]
        public System.String Annotations_S3Uri { get; set; }
        #endregion
        
        #region Parameter Documents_S3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the training documents for an entity recognizer
        /// are located. The URI must be in the same Region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Documents_S3Uri")]
        public System.String Documents_S3Uri { get; set; }
        #endregion
        
        #region Parameter EntityList_S3Uri
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 location where the entity list is located. The URI must be
        /// in the same Region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_EntityList_S3Uri")]
        public System.String EntityList_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID number for a security group on an instance of your private VPC. Security groups
        /// on your VPC function serve as a virtual firewall to control inbound and outbound traffic
        /// and provides security for the resources that you’ll be accessing on the VPC. This
        /// ID number is preceded by "sg-", for instance: "sg-03b388029b0a285ea". For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html">Security
        /// Groups for your VPC</a>. </para>
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
        /// and Subnets</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the entity recognizer. A tag is a key-value pair that adds
        /// as a metadata to a resource used by Amazon Comprehend. For example, a tag with "Sales"
        /// as the key might be added to a resource to indicate its use by the sales department.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Comprehend.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Annotations_TestS3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the test annotations for an entity recognizer
        /// are located. The URI must be in the same Region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Annotations_TestS3Uri")]
        public System.String Annotations_TestS3Uri { get; set; }
        #endregion
        
        #region Parameter Documents_TestS3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the test documents for an entity recognizer
        /// are located. The URI must be in the same Amazon Web Services Region as the API endpoint
        /// that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_Documents_TestS3Uri")]
        public System.String Documents_TestS3Uri { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>The version name given to the newly created recognizer. Version names can be a maximum
        /// of 256 characters. Alphanumeric characters, hyphens (-) and underscores (_) are allowed.
        /// The version name must be unique among all models with the same recognizer name in
        /// the account/Region.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EntityRecognizerArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.CreateEntityRecognizerResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.CreateEntityRecognizerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EntityRecognizerArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecognizerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecognizerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecognizerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecognizerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COMPEntityRecognizer (CreateEntityRecognizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.CreateEntityRecognizerResponse, NewCOMPEntityRecognizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecognizerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Annotations_S3Uri = this.Annotations_S3Uri;
            context.Annotations_TestS3Uri = this.Annotations_TestS3Uri;
            if (this.InputDataConfig_AugmentedManifest != null)
            {
                context.InputDataConfig_AugmentedManifest = new List<Amazon.Comprehend.Model.AugmentedManifestsListItem>(this.InputDataConfig_AugmentedManifest);
            }
            context.InputDataConfig_DataFormat = this.InputDataConfig_DataFormat;
            context.Documents_InputFormat = this.Documents_InputFormat;
            context.Documents_S3Uri = this.Documents_S3Uri;
            context.Documents_TestS3Uri = this.Documents_TestS3Uri;
            context.EntityList_S3Uri = this.EntityList_S3Uri;
            if (this.InputDataConfig_EntityType != null)
            {
                context.InputDataConfig_EntityType = new List<Amazon.Comprehend.Model.EntityTypesListItem>(this.InputDataConfig_EntityType);
            }
            #if MODULAR
            if (this.InputDataConfig_EntityType == null && ParameterWasBound(nameof(this.InputDataConfig_EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelKmsKeyId = this.ModelKmsKeyId;
            context.ModelPolicy = this.ModelPolicy;
            context.RecognizerName = this.RecognizerName;
            #if MODULAR
            if (this.RecognizerName == null && ParameterWasBound(nameof(this.RecognizerName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecognizerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Comprehend.Model.CreateEntityRecognizerRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.Comprehend.Model.EntityRecognizerInputDataConfig();
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
            Amazon.Comprehend.EntityRecognizerDataFormat requestInputDataConfig_inputDataConfig_DataFormat = null;
            if (cmdletContext.InputDataConfig_DataFormat != null)
            {
                requestInputDataConfig_inputDataConfig_DataFormat = cmdletContext.InputDataConfig_DataFormat;
            }
            if (requestInputDataConfig_inputDataConfig_DataFormat != null)
            {
                request.InputDataConfig.DataFormat = requestInputDataConfig_inputDataConfig_DataFormat;
                requestInputDataConfigIsNull = false;
            }
            List<Amazon.Comprehend.Model.EntityTypesListItem> requestInputDataConfig_inputDataConfig_EntityType = null;
            if (cmdletContext.InputDataConfig_EntityType != null)
            {
                requestInputDataConfig_inputDataConfig_EntityType = cmdletContext.InputDataConfig_EntityType;
            }
            if (requestInputDataConfig_inputDataConfig_EntityType != null)
            {
                request.InputDataConfig.EntityTypes = requestInputDataConfig_inputDataConfig_EntityType;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognizerEntityList requestInputDataConfig_inputDataConfig_EntityList = null;
            
             // populate EntityList
            var requestInputDataConfig_inputDataConfig_EntityListIsNull = true;
            requestInputDataConfig_inputDataConfig_EntityList = new Amazon.Comprehend.Model.EntityRecognizerEntityList();
            System.String requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri = null;
            if (cmdletContext.EntityList_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri = cmdletContext.EntityList_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityList.S3Uri = requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri;
                requestInputDataConfig_inputDataConfig_EntityListIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_EntityList should be set to null
            if (requestInputDataConfig_inputDataConfig_EntityListIsNull)
            {
                requestInputDataConfig_inputDataConfig_EntityList = null;
            }
            if (requestInputDataConfig_inputDataConfig_EntityList != null)
            {
                request.InputDataConfig.EntityList = requestInputDataConfig_inputDataConfig_EntityList;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognizerAnnotations requestInputDataConfig_inputDataConfig_Annotations = null;
            
             // populate Annotations
            var requestInputDataConfig_inputDataConfig_AnnotationsIsNull = true;
            requestInputDataConfig_inputDataConfig_Annotations = new Amazon.Comprehend.Model.EntityRecognizerAnnotations();
            System.String requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri = null;
            if (cmdletContext.Annotations_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri = cmdletContext.Annotations_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Annotations.S3Uri = requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri;
                requestInputDataConfig_inputDataConfig_AnnotationsIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_Annotations_annotations_TestS3Uri = null;
            if (cmdletContext.Annotations_TestS3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Annotations_annotations_TestS3Uri = cmdletContext.Annotations_TestS3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_Annotations_annotations_TestS3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Annotations.TestS3Uri = requestInputDataConfig_inputDataConfig_Annotations_annotations_TestS3Uri;
                requestInputDataConfig_inputDataConfig_AnnotationsIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_Annotations should be set to null
            if (requestInputDataConfig_inputDataConfig_AnnotationsIsNull)
            {
                requestInputDataConfig_inputDataConfig_Annotations = null;
            }
            if (requestInputDataConfig_inputDataConfig_Annotations != null)
            {
                request.InputDataConfig.Annotations = requestInputDataConfig_inputDataConfig_Annotations;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognizerDocuments requestInputDataConfig_inputDataConfig_Documents = null;
            
             // populate Documents
            var requestInputDataConfig_inputDataConfig_DocumentsIsNull = true;
            requestInputDataConfig_inputDataConfig_Documents = new Amazon.Comprehend.Model.EntityRecognizerDocuments();
            Amazon.Comprehend.InputFormat requestInputDataConfig_inputDataConfig_Documents_documents_InputFormat = null;
            if (cmdletContext.Documents_InputFormat != null)
            {
                requestInputDataConfig_inputDataConfig_Documents_documents_InputFormat = cmdletContext.Documents_InputFormat;
            }
            if (requestInputDataConfig_inputDataConfig_Documents_documents_InputFormat != null)
            {
                requestInputDataConfig_inputDataConfig_Documents.InputFormat = requestInputDataConfig_inputDataConfig_Documents_documents_InputFormat;
                requestInputDataConfig_inputDataConfig_DocumentsIsNull = false;
            }
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
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.ModelKmsKeyId != null)
            {
                request.ModelKmsKeyId = cmdletContext.ModelKmsKeyId;
            }
            if (cmdletContext.ModelPolicy != null)
            {
                request.ModelPolicy = cmdletContext.ModelPolicy;
            }
            if (cmdletContext.RecognizerName != null)
            {
                request.RecognizerName = cmdletContext.RecognizerName;
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
        
        private Amazon.Comprehend.Model.CreateEntityRecognizerResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.CreateEntityRecognizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "CreateEntityRecognizer");
            try
            {
                #if DESKTOP
                return client.CreateEntityRecognizer(request);
                #elif CORECLR
                return client.CreateEntityRecognizerAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String Annotations_S3Uri { get; set; }
            public System.String Annotations_TestS3Uri { get; set; }
            public List<Amazon.Comprehend.Model.AugmentedManifestsListItem> InputDataConfig_AugmentedManifest { get; set; }
            public Amazon.Comprehend.EntityRecognizerDataFormat InputDataConfig_DataFormat { get; set; }
            public Amazon.Comprehend.InputFormat Documents_InputFormat { get; set; }
            public System.String Documents_S3Uri { get; set; }
            public System.String Documents_TestS3Uri { get; set; }
            public System.String EntityList_S3Uri { get; set; }
            public List<Amazon.Comprehend.Model.EntityTypesListItem> InputDataConfig_EntityType { get; set; }
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public System.String ModelKmsKeyId { get; set; }
            public System.String ModelPolicy { get; set; }
            public System.String RecognizerName { get; set; }
            public List<Amazon.Comprehend.Model.Tag> Tag { get; set; }
            public System.String VersionName { get; set; }
            public System.String VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.Comprehend.Model.CreateEntityRecognizerResponse, NewCOMPEntityRecognizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EntityRecognizerArn;
        }
        
    }
}
