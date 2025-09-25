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
    /// Creates a dataset to upload training or test data for a model associated with a flywheel.
    /// For more information about datasets, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/flywheels-about.html">
    /// Flywheel overview</a> in the <i>Amazon Comprehend Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "COMPDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Comprehend CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.Comprehend.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("System.String or Amazon.Comprehend.Model.CreateDatasetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Comprehend.Model.CreateDatasetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCOMPDatasetCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputDataConfig_AugmentedManifest
        /// <summary>
        /// <para>
        /// <para>A list of augmented manifest files that provide training data for your custom model.
        /// An augmented manifest file is a labeled dataset that is produced by Amazon SageMaker
        /// Ground Truth. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_AugmentedManifests")]
        public Amazon.Comprehend.Model.DatasetAugmentedManifestsListItem[] InputDataConfig_AugmentedManifest { get; set; }
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
        
        #region Parameter InputDataConfig_DataFormat
        /// <summary>
        /// <para>
        /// <para><c>COMPREHEND_CSV</c>: The data format is a two-column CSV file, where the first
        /// column contains labels and the second column contains documents.</para><para><c>AUGMENTED_MANIFEST</c>: The data format </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DatasetDataFormat")]
        public Amazon.Comprehend.DatasetDataFormat InputDataConfig_DataFormat { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>Name of the dataset.</para>
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
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter DatasetType
        /// <summary>
        /// <para>
        /// <para>The dataset type. You can specify that the data in a dataset is for training the model
        /// or for testing the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DatasetType")]
        public Amazon.Comprehend.DatasetType DatasetType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FlywheelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the flywheel of the flywheel to receive the data.</para>
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
        public System.String FlywheelArn { get; set; }
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
        [Alias("InputDataConfig_EntityRecognizerInputDataConfig_Documents_InputFormat")]
        [AWSConstantClassSource("Amazon.Comprehend.InputFormat")]
        public Amazon.Comprehend.InputFormat Documents_InputFormat { get; set; }
        #endregion
        
        #region Parameter DocumentClassifierInputDataConfig_LabelDelimiter
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
        [Alias("InputDataConfig_DocumentClassifierInputDataConfig_LabelDelimiter")]
        public System.String DocumentClassifierInputDataConfig_LabelDelimiter { get; set; }
        #endregion
        
        #region Parameter DocumentClassifierInputDataConfig_S3Uri
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
        [Alias("InputDataConfig_DocumentClassifierInputDataConfig_S3Uri")]
        public System.String DocumentClassifierInputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter Annotations_S3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the training documents for an entity recognizer
        /// are located. The URI must be in the same Region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_EntityRecognizerInputDataConfig_Annotations_S3Uri")]
        public System.String Annotations_S3Uri { get; set; }
        #endregion
        
        #region Parameter Documents_S3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the documents for the dataset are located.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_EntityRecognizerInputDataConfig_Documents_S3Uri")]
        public System.String Documents_S3Uri { get; set; }
        #endregion
        
        #region Parameter EntityList_S3Uri
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 location where the entity list is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_EntityRecognizerInputDataConfig_EntityList_S3Uri")]
        public System.String EntityList_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Comprehend.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.CreateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlywheelArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlywheelArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlywheelArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COMPDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.CreateDatasetResponse, NewCOMPDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlywheelArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetType = this.DatasetType;
            context.Description = this.Description;
            context.FlywheelArn = this.FlywheelArn;
            #if MODULAR
            if (this.FlywheelArn == null && ParameterWasBound(nameof(this.FlywheelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlywheelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputDataConfig_AugmentedManifest != null)
            {
                context.InputDataConfig_AugmentedManifest = new List<Amazon.Comprehend.Model.DatasetAugmentedManifestsListItem>(this.InputDataConfig_AugmentedManifest);
            }
            context.InputDataConfig_DataFormat = this.InputDataConfig_DataFormat;
            context.DocumentClassifierInputDataConfig_LabelDelimiter = this.DocumentClassifierInputDataConfig_LabelDelimiter;
            context.DocumentClassifierInputDataConfig_S3Uri = this.DocumentClassifierInputDataConfig_S3Uri;
            context.Annotations_S3Uri = this.Annotations_S3Uri;
            context.Documents_InputFormat = this.Documents_InputFormat;
            context.Documents_S3Uri = this.Documents_S3Uri;
            context.EntityList_S3Uri = this.EntityList_S3Uri;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Comprehend.Model.Tag>(this.Tag);
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
            var request = new Amazon.Comprehend.Model.CreateDatasetRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.DatasetType != null)
            {
                request.DatasetType = cmdletContext.DatasetType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FlywheelArn != null)
            {
                request.FlywheelArn = cmdletContext.FlywheelArn;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.Comprehend.Model.DatasetInputDataConfig();
            List<Amazon.Comprehend.Model.DatasetAugmentedManifestsListItem> requestInputDataConfig_inputDataConfig_AugmentedManifest = null;
            if (cmdletContext.InputDataConfig_AugmentedManifest != null)
            {
                requestInputDataConfig_inputDataConfig_AugmentedManifest = cmdletContext.InputDataConfig_AugmentedManifest;
            }
            if (requestInputDataConfig_inputDataConfig_AugmentedManifest != null)
            {
                request.InputDataConfig.AugmentedManifests = requestInputDataConfig_inputDataConfig_AugmentedManifest;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.DatasetDataFormat requestInputDataConfig_inputDataConfig_DataFormat = null;
            if (cmdletContext.InputDataConfig_DataFormat != null)
            {
                requestInputDataConfig_inputDataConfig_DataFormat = cmdletContext.InputDataConfig_DataFormat;
            }
            if (requestInputDataConfig_inputDataConfig_DataFormat != null)
            {
                request.InputDataConfig.DataFormat = requestInputDataConfig_inputDataConfig_DataFormat;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DatasetDocumentClassifierInputDataConfig requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig = null;
            
             // populate DocumentClassifierInputDataConfig
            var requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfigIsNull = true;
            requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig = new Amazon.Comprehend.Model.DatasetDocumentClassifierInputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_LabelDelimiter = null;
            if (cmdletContext.DocumentClassifierInputDataConfig_LabelDelimiter != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_LabelDelimiter = cmdletContext.DocumentClassifierInputDataConfig_LabelDelimiter;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_LabelDelimiter != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig.LabelDelimiter = requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_LabelDelimiter;
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_S3Uri = null;
            if (cmdletContext.DocumentClassifierInputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_S3Uri = cmdletContext.DocumentClassifierInputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig_documentClassifierInputDataConfig_S3Uri;
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfigIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig should be set to null
            if (requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfigIsNull)
            {
                requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig = null;
            }
            if (requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig != null)
            {
                request.InputDataConfig.DocumentClassifierInputDataConfig = requestInputDataConfig_inputDataConfig_DocumentClassifierInputDataConfig;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DatasetEntityRecognizerInputDataConfig requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig = null;
            
             // populate EntityRecognizerInputDataConfig
            var requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfigIsNull = true;
            requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig = new Amazon.Comprehend.Model.DatasetEntityRecognizerInputDataConfig();
            Amazon.Comprehend.Model.DatasetEntityRecognizerAnnotations requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations = null;
            
             // populate Annotations
            var requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_AnnotationsIsNull = true;
            requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations = new Amazon.Comprehend.Model.DatasetEntityRecognizerAnnotations();
            System.String requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations_annotations_S3Uri = null;
            if (cmdletContext.Annotations_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations_annotations_S3Uri = cmdletContext.Annotations_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations_annotations_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations.S3Uri = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations_annotations_S3Uri;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_AnnotationsIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations should be set to null
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_AnnotationsIsNull)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations = null;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig.Annotations = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Annotations;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DatasetEntityRecognizerEntityList requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList = null;
            
             // populate EntityList
            var requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityListIsNull = true;
            requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList = new Amazon.Comprehend.Model.DatasetEntityRecognizerEntityList();
            System.String requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList_entityList_S3Uri = null;
            if (cmdletContext.EntityList_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList_entityList_S3Uri = cmdletContext.EntityList_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList_entityList_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList.S3Uri = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList_entityList_S3Uri;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityListIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList should be set to null
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityListIsNull)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList = null;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig.EntityList = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_EntityList;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.DatasetEntityRecognizerDocuments requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents = null;
            
             // populate Documents
            var requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_DocumentsIsNull = true;
            requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents = new Amazon.Comprehend.Model.DatasetEntityRecognizerDocuments();
            Amazon.Comprehend.InputFormat requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_InputFormat = null;
            if (cmdletContext.Documents_InputFormat != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_InputFormat = cmdletContext.Documents_InputFormat;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_InputFormat != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents.InputFormat = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_InputFormat;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_DocumentsIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_S3Uri = null;
            if (cmdletContext.Documents_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_S3Uri = cmdletContext.Documents_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents.S3Uri = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents_documents_S3Uri;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_DocumentsIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents should be set to null
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_DocumentsIsNull)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents = null;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents != null)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig.Documents = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig_Documents;
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfigIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig should be set to null
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfigIsNull)
            {
                requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig = null;
            }
            if (requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig != null)
            {
                request.InputDataConfig.EntityRecognizerInputDataConfig = requestInputDataConfig_inputDataConfig_EntityRecognizerInputDataConfig;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Comprehend.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "CreateDataset");
            try
            {
                #if DESKTOP
                return client.CreateDataset(request);
                #elif CORECLR
                return client.CreateDatasetAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetName { get; set; }
            public Amazon.Comprehend.DatasetType DatasetType { get; set; }
            public System.String Description { get; set; }
            public System.String FlywheelArn { get; set; }
            public List<Amazon.Comprehend.Model.DatasetAugmentedManifestsListItem> InputDataConfig_AugmentedManifest { get; set; }
            public Amazon.Comprehend.DatasetDataFormat InputDataConfig_DataFormat { get; set; }
            public System.String DocumentClassifierInputDataConfig_LabelDelimiter { get; set; }
            public System.String DocumentClassifierInputDataConfig_S3Uri { get; set; }
            public System.String Annotations_S3Uri { get; set; }
            public Amazon.Comprehend.InputFormat Documents_InputFormat { get; set; }
            public System.String Documents_S3Uri { get; set; }
            public System.String EntityList_S3Uri { get; set; }
            public List<Amazon.Comprehend.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Comprehend.Model.CreateDatasetResponse, NewCOMPDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetArn;
        }
        
    }
}
