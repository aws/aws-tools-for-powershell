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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Creates a new document classifier that you can use to categorize documents. To create
    /// a classifier, you provide a set of training documents that labeled with the categories
    /// that you want to use. After the classifier is trained you can use it to categorize
    /// a set of labeled documents into the categories. For more information, see <a>how-document-classification</a>.
    /// </summary>
    [Cmdlet("New", "COMPDocumentClassifier", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Comprehend CreateDocumentClassifier API operation.", Operation = new[] {"CreateDocumentClassifier"}, SelectReturnType = typeof(Amazon.Comprehend.Model.CreateDocumentClassifierResponse))]
    [AWSCmdletOutput("System.String or Amazon.Comprehend.Model.CreateDocumentClassifierResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Comprehend.Model.CreateDocumentClassifierResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCOMPDocumentClassifierCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter InputDataConfig_AugmentedManifest
        /// <summary>
        /// <para>
        /// <para>A list of augmented manifest files that provide training data for your custom model.
        /// An augmented manifest file is a labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth.</para><para>This parameter is required if you set <code>DataFormat</code> to <code>AUGMENTED_MANIFEST</code>.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Management (IAM) role that
        /// grants Amazon Comprehend read access to your input data.</para>
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
        /// <para>The format of your training data:</para><ul><li><para><code>COMPREHEND_CSV</code>: A two-column CSV file, where labels are provided in
        /// the first column, and documents are provided in the second. If you use this value,
        /// you must provide the <code>S3Uri</code> parameter in your request.</para></li><li><para><code>AUGMENTED_MANIFEST</code>: A labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth. This file is in JSON lines format. Each line is a complete JSON object
        /// that contains a training document and its associated labels. </para><para>If you use this value, you must provide the <code>AugmentedManifests</code> parameter
        /// in your request.</para></li></ul><para>If you don't specify a value, Amazon Comprehend uses <code>COMPREHEND_CSV</code> as
        /// the default.</para>
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
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the AWS Key Management Service (KMS) key that Amazon Comprehend uses to encrypt
        /// the output results from an analysis job. The KmsKeyId can be one of the following
        /// formats:</para><ul><li><para>KMS Key ID: <code>"1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <code>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li><li><para>KMS Key Alias: <code>"alias/ExampleAlias"</code></para></li><li><para>ARN of a KMS Key Alias: <code>"arn:aws:kms:us-west-2:111122223333:alias/ExampleAlias"</code></para></li></ul>
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
        /// <para>The language of the input documents. You can specify any of the following languages
        /// supported by Amazon Comprehend: German ("de"), English ("en"), Spanish ("es"), French
        /// ("fr"), Italian ("it"), or Portuguese ("pt"). All documents must be in the same language.</para>
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
        /// trained in multi-class mode, which identifies one and only one class for each document,
        /// or multi-label mode, which identifies one or more labels for each document. In multi-label
        /// mode, multiple labels for an individual document are separated by a delimiter. The
        /// default delimiter between labels is a pipe (|).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentClassifierMode")]
        public Amazon.Comprehend.DocumentClassifierMode Mode { get; set; }
        #endregion
        
        #region Parameter ModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the AWS Key Management Service (KMS) key that Amazon Comprehend uses to encrypt
        /// trained custom models. The ModelKmsKeyId can be either of the following formats:</para><ul><li><para>KMS Key ID: <code>"1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <code>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the input data. The S3 bucket must be in the same region as
        /// the API endpoint that you are calling. The URI can point to a single input file or
        /// it can provide the prefix for a collection of input files.</para><para>For example, if you use the URI <code>S3://bucketName/prefix</code>, if the prefix
        /// is a single file, Amazon Comprehend uses that file as input. If more than one file
        /// begins with the prefix, Amazon Comprehend uses all of them as input.</para><para>This parameter is required if you set <code>DataFormat</code> to <code>COMPREHEND_CSV</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>When you use the <code>OutputDataConfig</code> object while creating a custom classifier,
        /// you specify the Amazon S3 location where you want to write the confusion matrix. The
        /// URI must be in the same region as the API endpoint that you are calling. The location
        /// is used as the prefix for the actual location of this output file.</para><para>When the custom classifier job is finished, the service creates the output file in
        /// a directory specific to the job. The <code>S3Uri</code> field contains the location
        /// of the output file, called <code>output.tar.gz</code>. It is a compressed archive
        /// that contains the confusion matrix.</para>
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
        /// zone in the VPC’s region. This ID number is preceded by "subnet-", for instance: "subnet-04ccf456919e69055".
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
        /// <para>Tags to be associated with the document classifier being created. A tag is a key-value
        /// pair that adds as a metadata to a resource used by Amazon Comprehend. For example,
        /// a tag with "Sales" as the key might be added to a resource to indicate its use by
        /// the sales department. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Comprehend.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>ID for the AWS Key Management Service (KMS) key that Amazon Comprehend uses to encrypt
        /// data on the storage volume attached to the ML compute instance(s) that process the
        /// analysis job. The VolumeKmsKeyId can be either of the following formats:</para><ul><li><para>KMS Key ID: <code>"1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li><li><para>Amazon Resource Name (ARN) of a KMS Key: <code>"arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab"</code></para></li></ul>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DocumentClassifierName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DocumentClassifierName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DocumentClassifierName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DocumentClassifierName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COMPDocumentClassifier (CreateDocumentClassifier)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.CreateDocumentClassifierResponse, NewCOMPDocumentClassifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DocumentClassifierName;
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
            context.InputDataConfig_LabelDelimiter = this.InputDataConfig_LabelDelimiter;
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mode = this.Mode;
            context.ModelKmsKeyId = this.ModelKmsKeyId;
            context.OutputDataConfig_KmsKeyId = this.OutputDataConfig_KmsKeyId;
            context.OutputDataConfig_S3Uri = this.OutputDataConfig_S3Uri;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Comprehend.Model.Tag>(this.Tag);
            }
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
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Comprehend.Model.DocumentClassifierOutputDataConfig();
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
                #if DESKTOP
                return client.CreateDocumentClassifier(request);
                #elif CORECLR
                return client.CreateDocumentClassifierAsync(request).GetAwaiter().GetResult();
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
            public System.String DocumentClassifierName { get; set; }
            public List<Amazon.Comprehend.Model.AugmentedManifestsListItem> InputDataConfig_AugmentedManifest { get; set; }
            public Amazon.Comprehend.DocumentClassifierDataFormat InputDataConfig_DataFormat { get; set; }
            public System.String InputDataConfig_LabelDelimiter { get; set; }
            public System.String InputDataConfig_S3Uri { get; set; }
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public Amazon.Comprehend.DocumentClassifierMode Mode { get; set; }
            public System.String ModelKmsKeyId { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public List<Amazon.Comprehend.Model.Tag> Tag { get; set; }
            public System.String VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.Comprehend.Model.CreateDocumentClassifierResponse, NewCOMPDocumentClassifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DocumentClassifierArn;
        }
        
    }
}
