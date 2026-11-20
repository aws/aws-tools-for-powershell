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
using Amazon.Textract;
using Amazon.Textract.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Creates a project that groups the configuration used to run document insights jobs.
    /// </summary>
    [Cmdlet("New", "TXTProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Textract.Model.CreateProjectResponse")]
    [AWSCmdlet("Calls the Amazon Textract CreateProject API operation.", Operation = new[] {"CreateProject"}, SelectReturnType = typeof(Amazon.Textract.Model.CreateProjectResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.CreateProjectResponse",
        "This cmdlet returns an Amazon.Textract.Model.CreateProjectResponse object containing multiple properties."
    )]
    public partial class NewTXTProjectCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomConfiguration_Blueprint
        /// <summary>
        /// <para>
        /// <para>The blueprints used to extract custom structured output.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomConfiguration_Blueprints")]
        public Amazon.Textract.Model.BlueprintItem[] CustomConfiguration_Blueprint { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If you use the same token for a request that matches
        /// a previous request, the service ignores the request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SensitiveDataConfiguration_DetectionMode
        /// <summary>
        /// <para>
        /// <para>The detection mode. Valid values:</para><ul><li><para><c>DETECTION</c> - Only detects sensitive data.</para></li><li><para><c>DETECTION_AND_REDACTION</c> - Detects and redacts sensitive data in the output.</para></li><li><para><c>DISABLED</c> - Does not detect sensitive data.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.SensitiveDataDetectionMode")]
        public Amazon.Textract.SensitiveDataDetectionMode SensitiveDataConfiguration_DetectionMode { get; set; }
        #endregion
        
        #region Parameter CustomConfiguration_FallbackBlueprint
        /// <summary>
        /// <para>
        /// <para>The blueprint used when a document does not match any of the primary blueprints. Requires
        /// at least one blueprint in <c>Blueprints</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomConfiguration_FallbackBlueprints")]
        public Amazon.Textract.Model.BlueprintItem[] CustomConfiguration_FallbackBlueprint { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that Amazon Textract includes as the AWS KMS encryption context
        /// when encrypting and decrypting the resource.</para><para>On <c>UpdateProject</c> and <c>UpdateBlueprint</c>, this member is the one exception
        /// to replacing a supplied configuration whole. If you omit it, the stored encryption
        /// context is kept. To clear a custom encryption context, specify an empty map (<c>{}</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AWS KMS key to use for encryption. This can be a key ID, key
        /// ARN, alias name, or alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType
        /// <summary>
        /// <para>
        /// <para>The list of PII entity types to detect. Each type can appear only once.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes")]
        public System.String[] SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType { get; set; }
        #endregion
        
        #region Parameter ProjectDescription
        /// <summary>
        /// <para>
        /// <para>A description of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectDescription { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>A unique name for the project.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode
        /// <summary>
        /// <para>
        /// <para>How detected PII is masked in the redacted output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.PIIRedactionMaskMode")]
        public Amazon.Textract.PIIRedactionMaskMode SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
        #endregion
        
        #region Parameter ExtractionConfiguration_BoundingBox_State
        /// <summary>
        /// <para>
        /// <para>Set to <c>ENABLED</c> to return bounding box geometry, or <c>DISABLED</c> to omit
        /// it.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Textract.State")]
        public Amazon.Textract.State ExtractionConfiguration_BoundingBox_State { get; set; }
        #endregion
        
        #region Parameter ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State
        /// <summary>
        /// <para>
        /// <para>Set to <c>ENABLED</c> to produce an additional file format, or <c>DISABLED</c> to
        /// omit it.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Textract.State")]
        public Amazon.Textract.State ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State { get; set; }
        #endregion
        
        #region Parameter GenerativeConfiguration_FigureCaption_State
        /// <summary>
        /// <para>
        /// <para>Set to <c>ENABLED</c> to produce figure captions, or <c>DISABLED</c> to omit them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.State")]
        public Amazon.Textract.State GenerativeConfiguration_FigureCaption_State { get; set; }
        #endregion
        
        #region Parameter GenerativeConfiguration_Summarization_State
        /// <summary>
        /// <para>
        /// <para>Set to <c>ENABLED</c> to produce a summary, or <c>DISABLED</c> to omit it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.State")]
        public Amazon.Textract.State GenerativeConfiguration_Summarization_State { get; set; }
        #endregion
        
        #region Parameter SplitterConfiguration_State
        /// <summary>
        /// <para>
        /// <para>Set to <c>ENABLED</c> to split multi-document packets, or <c>DISABLED</c> to treat
        /// the input as a single document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.State")]
        public Amazon.Textract.State SplitterConfiguration_State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags (key-value pairs) to assign to the project.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ExtractionConfiguration_Granularity_Type
        /// <summary>
        /// <para>
        /// <para>The granularity levels at which Amazon Textract extracts content, from the whole document
        /// down to individual lines of text. Each type can appear only once.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtractionConfiguration_Granularity_Types")]
        public System.String[] ExtractionConfiguration_Granularity_Type { get; set; }
        #endregion
        
        #region Parameter ExtractionConfiguration_OutputFormat_TextFormat_Type
        /// <summary>
        /// <para>
        /// <para>The text formats produced in the extraction output. Each type can appear only once,
        /// and <c>CSV</c> can't be the only type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtractionConfiguration_OutputFormat_TextFormat_Types")]
        public System.String[] ExtractionConfiguration_OutputFormat_TextFormat_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.CreateProjectResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.CreateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TXTProject (CreateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.CreateProjectResponse, NewTXTProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.CustomConfiguration_Blueprint != null)
            {
                context.CustomConfiguration_Blueprint = new List<Amazon.Textract.Model.BlueprintItem>(this.CustomConfiguration_Blueprint);
            }
            if (this.CustomConfiguration_FallbackBlueprint != null)
            {
                context.CustomConfiguration_FallbackBlueprint = new List<Amazon.Textract.Model.BlueprintItem>(this.CustomConfiguration_FallbackBlueprint);
            }
            if (this.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                context.EncryptionConfiguration_KmsEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionConfiguration_KmsEncryptionContext.Keys)
                {
                    context.EncryptionConfiguration_KmsEncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionConfiguration_KmsEncryptionContext[hashKey]));
                }
            }
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.ExtractionConfiguration_BoundingBox_State = this.ExtractionConfiguration_BoundingBox_State;
            #if MODULAR
            if (this.ExtractionConfiguration_BoundingBox_State == null && ParameterWasBound(nameof(this.ExtractionConfiguration_BoundingBox_State)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtractionConfiguration_BoundingBox_State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExtractionConfiguration_Granularity_Type != null)
            {
                context.ExtractionConfiguration_Granularity_Type = new List<System.String>(this.ExtractionConfiguration_Granularity_Type);
            }
            context.ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State = this.ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State;
            #if MODULAR
            if (this.ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State == null && ParameterWasBound(nameof(this.ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExtractionConfiguration_OutputFormat_TextFormat_Type != null)
            {
                context.ExtractionConfiguration_OutputFormat_TextFormat_Type = new List<System.String>(this.ExtractionConfiguration_OutputFormat_TextFormat_Type);
            }
            context.GenerativeConfiguration_FigureCaption_State = this.GenerativeConfiguration_FigureCaption_State;
            context.GenerativeConfiguration_Summarization_State = this.GenerativeConfiguration_Summarization_State;
            context.ProjectDescription = this.ProjectDescription;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SensitiveDataConfiguration_DetectionMode = this.SensitiveDataConfiguration_DetectionMode;
            if (this.SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType != null)
            {
                context.SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType = new List<System.String>(this.SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType);
            }
            context.SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = this.SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            context.SplitterConfiguration_State = this.SplitterConfiguration_State;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Textract.Model.CreateProjectRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate CustomConfiguration
            var requestCustomConfigurationIsNull = true;
            request.CustomConfiguration = new Amazon.Textract.Model.CustomConfiguration();
            List<Amazon.Textract.Model.BlueprintItem> requestCustomConfiguration_customConfiguration_Blueprint = null;
            if (cmdletContext.CustomConfiguration_Blueprint != null)
            {
                requestCustomConfiguration_customConfiguration_Blueprint = cmdletContext.CustomConfiguration_Blueprint;
            }
            if (requestCustomConfiguration_customConfiguration_Blueprint != null)
            {
                request.CustomConfiguration.Blueprints = requestCustomConfiguration_customConfiguration_Blueprint;
                requestCustomConfigurationIsNull = false;
            }
            List<Amazon.Textract.Model.BlueprintItem> requestCustomConfiguration_customConfiguration_FallbackBlueprint = null;
            if (cmdletContext.CustomConfiguration_FallbackBlueprint != null)
            {
                requestCustomConfiguration_customConfiguration_FallbackBlueprint = cmdletContext.CustomConfiguration_FallbackBlueprint;
            }
            if (requestCustomConfiguration_customConfiguration_FallbackBlueprint != null)
            {
                request.CustomConfiguration.FallbackBlueprints = requestCustomConfiguration_customConfiguration_FallbackBlueprint;
                requestCustomConfigurationIsNull = false;
            }
             // determine if request.CustomConfiguration should be set to null
            if (requestCustomConfigurationIsNull)
            {
                request.CustomConfiguration = null;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.Textract.Model.EncryptionConfiguration();
            Dictionary<System.String, System.String> requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = null;
            if (cmdletContext.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = cmdletContext.EncryptionConfiguration_KmsEncryptionContext;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext != null)
            {
                request.EncryptionConfiguration.KmsEncryptionContext = requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate ExtractionConfiguration
            var requestExtractionConfigurationIsNull = true;
            request.ExtractionConfiguration = new Amazon.Textract.Model.ExtractionConfiguration();
            Amazon.Textract.Model.BoundingBoxConfiguration requestExtractionConfiguration_extractionConfiguration_BoundingBox = null;
            
             // populate BoundingBox
            var requestExtractionConfiguration_extractionConfiguration_BoundingBoxIsNull = true;
            requestExtractionConfiguration_extractionConfiguration_BoundingBox = new Amazon.Textract.Model.BoundingBoxConfiguration();
            Amazon.Textract.State requestExtractionConfiguration_extractionConfiguration_BoundingBox_extractionConfiguration_BoundingBox_State = null;
            if (cmdletContext.ExtractionConfiguration_BoundingBox_State != null)
            {
                requestExtractionConfiguration_extractionConfiguration_BoundingBox_extractionConfiguration_BoundingBox_State = cmdletContext.ExtractionConfiguration_BoundingBox_State;
            }
            if (requestExtractionConfiguration_extractionConfiguration_BoundingBox_extractionConfiguration_BoundingBox_State != null)
            {
                requestExtractionConfiguration_extractionConfiguration_BoundingBox.State = requestExtractionConfiguration_extractionConfiguration_BoundingBox_extractionConfiguration_BoundingBox_State;
                requestExtractionConfiguration_extractionConfiguration_BoundingBoxIsNull = false;
            }
             // determine if requestExtractionConfiguration_extractionConfiguration_BoundingBox should be set to null
            if (requestExtractionConfiguration_extractionConfiguration_BoundingBoxIsNull)
            {
                requestExtractionConfiguration_extractionConfiguration_BoundingBox = null;
            }
            if (requestExtractionConfiguration_extractionConfiguration_BoundingBox != null)
            {
                request.ExtractionConfiguration.BoundingBox = requestExtractionConfiguration_extractionConfiguration_BoundingBox;
                requestExtractionConfigurationIsNull = false;
            }
            Amazon.Textract.Model.ExtractionGranularity requestExtractionConfiguration_extractionConfiguration_Granularity = null;
            
             // populate Granularity
            var requestExtractionConfiguration_extractionConfiguration_GranularityIsNull = true;
            requestExtractionConfiguration_extractionConfiguration_Granularity = new Amazon.Textract.Model.ExtractionGranularity();
            List<System.String> requestExtractionConfiguration_extractionConfiguration_Granularity_extractionConfiguration_Granularity_Type = null;
            if (cmdletContext.ExtractionConfiguration_Granularity_Type != null)
            {
                requestExtractionConfiguration_extractionConfiguration_Granularity_extractionConfiguration_Granularity_Type = cmdletContext.ExtractionConfiguration_Granularity_Type;
            }
            if (requestExtractionConfiguration_extractionConfiguration_Granularity_extractionConfiguration_Granularity_Type != null)
            {
                requestExtractionConfiguration_extractionConfiguration_Granularity.Types = requestExtractionConfiguration_extractionConfiguration_Granularity_extractionConfiguration_Granularity_Type;
                requestExtractionConfiguration_extractionConfiguration_GranularityIsNull = false;
            }
             // determine if requestExtractionConfiguration_extractionConfiguration_Granularity should be set to null
            if (requestExtractionConfiguration_extractionConfiguration_GranularityIsNull)
            {
                requestExtractionConfiguration_extractionConfiguration_Granularity = null;
            }
            if (requestExtractionConfiguration_extractionConfiguration_Granularity != null)
            {
                request.ExtractionConfiguration.Granularity = requestExtractionConfiguration_extractionConfiguration_Granularity;
                requestExtractionConfigurationIsNull = false;
            }
            Amazon.Textract.Model.OutputFormat requestExtractionConfiguration_extractionConfiguration_OutputFormat = null;
            
             // populate OutputFormat
            var requestExtractionConfiguration_extractionConfiguration_OutputFormatIsNull = true;
            requestExtractionConfiguration_extractionConfiguration_OutputFormat = new Amazon.Textract.Model.OutputFormat();
            Amazon.Textract.Model.OutputAdditionalFileFormat requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat = null;
            
             // populate AdditionalFileFormat
            var requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormatIsNull = true;
            requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat = new Amazon.Textract.Model.OutputAdditionalFileFormat();
            Amazon.Textract.State requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_State = null;
            if (cmdletContext.ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State != null)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_State = cmdletContext.ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State;
            }
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_State != null)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat.State = requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat_State;
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormatIsNull = false;
            }
             // determine if requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat should be set to null
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormatIsNull)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat = null;
            }
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat != null)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat.AdditionalFileFormat = requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_AdditionalFileFormat;
                requestExtractionConfiguration_extractionConfiguration_OutputFormatIsNull = false;
            }
            Amazon.Textract.Model.OutputTextFormat requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat = null;
            
             // populate TextFormat
            var requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormatIsNull = true;
            requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat = new Amazon.Textract.Model.OutputTextFormat();
            List<System.String> requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat_extractionConfiguration_OutputFormat_TextFormat_Type = null;
            if (cmdletContext.ExtractionConfiguration_OutputFormat_TextFormat_Type != null)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat_extractionConfiguration_OutputFormat_TextFormat_Type = cmdletContext.ExtractionConfiguration_OutputFormat_TextFormat_Type;
            }
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat_extractionConfiguration_OutputFormat_TextFormat_Type != null)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat.Types = requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat_extractionConfiguration_OutputFormat_TextFormat_Type;
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormatIsNull = false;
            }
             // determine if requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat should be set to null
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormatIsNull)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat = null;
            }
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat != null)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat.TextFormat = requestExtractionConfiguration_extractionConfiguration_OutputFormat_extractionConfiguration_OutputFormat_TextFormat;
                requestExtractionConfiguration_extractionConfiguration_OutputFormatIsNull = false;
            }
             // determine if requestExtractionConfiguration_extractionConfiguration_OutputFormat should be set to null
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormatIsNull)
            {
                requestExtractionConfiguration_extractionConfiguration_OutputFormat = null;
            }
            if (requestExtractionConfiguration_extractionConfiguration_OutputFormat != null)
            {
                request.ExtractionConfiguration.OutputFormat = requestExtractionConfiguration_extractionConfiguration_OutputFormat;
                requestExtractionConfigurationIsNull = false;
            }
             // determine if request.ExtractionConfiguration should be set to null
            if (requestExtractionConfigurationIsNull)
            {
                request.ExtractionConfiguration = null;
            }
            
             // populate GenerativeConfiguration
            var requestGenerativeConfigurationIsNull = true;
            request.GenerativeConfiguration = new Amazon.Textract.Model.GenerativeConfiguration();
            Amazon.Textract.Model.FigureCaptionConfiguration requestGenerativeConfiguration_generativeConfiguration_FigureCaption = null;
            
             // populate FigureCaption
            var requestGenerativeConfiguration_generativeConfiguration_FigureCaptionIsNull = true;
            requestGenerativeConfiguration_generativeConfiguration_FigureCaption = new Amazon.Textract.Model.FigureCaptionConfiguration();
            Amazon.Textract.State requestGenerativeConfiguration_generativeConfiguration_FigureCaption_generativeConfiguration_FigureCaption_State = null;
            if (cmdletContext.GenerativeConfiguration_FigureCaption_State != null)
            {
                requestGenerativeConfiguration_generativeConfiguration_FigureCaption_generativeConfiguration_FigureCaption_State = cmdletContext.GenerativeConfiguration_FigureCaption_State;
            }
            if (requestGenerativeConfiguration_generativeConfiguration_FigureCaption_generativeConfiguration_FigureCaption_State != null)
            {
                requestGenerativeConfiguration_generativeConfiguration_FigureCaption.State = requestGenerativeConfiguration_generativeConfiguration_FigureCaption_generativeConfiguration_FigureCaption_State;
                requestGenerativeConfiguration_generativeConfiguration_FigureCaptionIsNull = false;
            }
             // determine if requestGenerativeConfiguration_generativeConfiguration_FigureCaption should be set to null
            if (requestGenerativeConfiguration_generativeConfiguration_FigureCaptionIsNull)
            {
                requestGenerativeConfiguration_generativeConfiguration_FigureCaption = null;
            }
            if (requestGenerativeConfiguration_generativeConfiguration_FigureCaption != null)
            {
                request.GenerativeConfiguration.FigureCaption = requestGenerativeConfiguration_generativeConfiguration_FigureCaption;
                requestGenerativeConfigurationIsNull = false;
            }
            Amazon.Textract.Model.SummarizationConfiguration requestGenerativeConfiguration_generativeConfiguration_Summarization = null;
            
             // populate Summarization
            var requestGenerativeConfiguration_generativeConfiguration_SummarizationIsNull = true;
            requestGenerativeConfiguration_generativeConfiguration_Summarization = new Amazon.Textract.Model.SummarizationConfiguration();
            Amazon.Textract.State requestGenerativeConfiguration_generativeConfiguration_Summarization_generativeConfiguration_Summarization_State = null;
            if (cmdletContext.GenerativeConfiguration_Summarization_State != null)
            {
                requestGenerativeConfiguration_generativeConfiguration_Summarization_generativeConfiguration_Summarization_State = cmdletContext.GenerativeConfiguration_Summarization_State;
            }
            if (requestGenerativeConfiguration_generativeConfiguration_Summarization_generativeConfiguration_Summarization_State != null)
            {
                requestGenerativeConfiguration_generativeConfiguration_Summarization.State = requestGenerativeConfiguration_generativeConfiguration_Summarization_generativeConfiguration_Summarization_State;
                requestGenerativeConfiguration_generativeConfiguration_SummarizationIsNull = false;
            }
             // determine if requestGenerativeConfiguration_generativeConfiguration_Summarization should be set to null
            if (requestGenerativeConfiguration_generativeConfiguration_SummarizationIsNull)
            {
                requestGenerativeConfiguration_generativeConfiguration_Summarization = null;
            }
            if (requestGenerativeConfiguration_generativeConfiguration_Summarization != null)
            {
                request.GenerativeConfiguration.Summarization = requestGenerativeConfiguration_generativeConfiguration_Summarization;
                requestGenerativeConfigurationIsNull = false;
            }
             // determine if request.GenerativeConfiguration should be set to null
            if (requestGenerativeConfigurationIsNull)
            {
                request.GenerativeConfiguration = null;
            }
            if (cmdletContext.ProjectDescription != null)
            {
                request.ProjectDescription = cmdletContext.ProjectDescription;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
             // populate SensitiveDataConfiguration
            var requestSensitiveDataConfigurationIsNull = true;
            request.SensitiveDataConfiguration = new Amazon.Textract.Model.SensitiveDataConfiguration();
            Amazon.Textract.SensitiveDataDetectionMode requestSensitiveDataConfiguration_sensitiveDataConfiguration_DetectionMode = null;
            if (cmdletContext.SensitiveDataConfiguration_DetectionMode != null)
            {
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_DetectionMode = cmdletContext.SensitiveDataConfiguration_DetectionMode;
            }
            if (requestSensitiveDataConfiguration_sensitiveDataConfiguration_DetectionMode != null)
            {
                request.SensitiveDataConfiguration.DetectionMode = requestSensitiveDataConfiguration_sensitiveDataConfiguration_DetectionMode;
                requestSensitiveDataConfigurationIsNull = false;
            }
            Amazon.Textract.Model.PIIEntitiesConfiguration requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            
             // populate PiiEntitiesConfiguration
            var requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = true;
            requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration = new Amazon.Textract.Model.PIIEntitiesConfiguration();
            List<System.String> requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType = null;
            if (cmdletContext.SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType != null)
            {
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType = cmdletContext.SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType;
            }
            if (requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType != null)
            {
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration.PiiEntityTypes = requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType;
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
            Amazon.Textract.PIIRedactionMaskMode requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = null;
            if (cmdletContext.SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = cmdletContext.SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            }
            if (requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration.RedactionMaskMode = requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
             // determine if requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration should be set to null
            if (requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfigurationIsNull)
            {
                requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            }
            if (requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration != null)
            {
                request.SensitiveDataConfiguration.PiiEntitiesConfiguration = requestSensitiveDataConfiguration_sensitiveDataConfiguration_PiiEntitiesConfiguration;
                requestSensitiveDataConfigurationIsNull = false;
            }
             // determine if request.SensitiveDataConfiguration should be set to null
            if (requestSensitiveDataConfigurationIsNull)
            {
                request.SensitiveDataConfiguration = null;
            }
            
             // populate SplitterConfiguration
            var requestSplitterConfigurationIsNull = true;
            request.SplitterConfiguration = new Amazon.Textract.Model.SplitterConfiguration();
            Amazon.Textract.State requestSplitterConfiguration_splitterConfiguration_State = null;
            if (cmdletContext.SplitterConfiguration_State != null)
            {
                requestSplitterConfiguration_splitterConfiguration_State = cmdletContext.SplitterConfiguration_State;
            }
            if (requestSplitterConfiguration_splitterConfiguration_State != null)
            {
                request.SplitterConfiguration.State = requestSplitterConfiguration_splitterConfiguration_State;
                requestSplitterConfigurationIsNull = false;
            }
             // determine if request.SplitterConfiguration should be set to null
            if (requestSplitterConfigurationIsNull)
            {
                request.SplitterConfiguration = null;
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
        
        private Amazon.Textract.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "CreateProject");
            try
            {
                return client.CreateProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Textract.Model.BlueprintItem> CustomConfiguration_Blueprint { get; set; }
            public List<Amazon.Textract.Model.BlueprintItem> CustomConfiguration_FallbackBlueprint { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.Textract.State ExtractionConfiguration_BoundingBox_State { get; set; }
            public List<System.String> ExtractionConfiguration_Granularity_Type { get; set; }
            public Amazon.Textract.State ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State { get; set; }
            public List<System.String> ExtractionConfiguration_OutputFormat_TextFormat_Type { get; set; }
            public Amazon.Textract.State GenerativeConfiguration_FigureCaption_State { get; set; }
            public Amazon.Textract.State GenerativeConfiguration_Summarization_State { get; set; }
            public System.String ProjectDescription { get; set; }
            public System.String ProjectName { get; set; }
            public Amazon.Textract.SensitiveDataDetectionMode SensitiveDataConfiguration_DetectionMode { get; set; }
            public List<System.String> SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityType { get; set; }
            public Amazon.Textract.PIIRedactionMaskMode SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
            public Amazon.Textract.State SplitterConfiguration_State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Textract.Model.CreateProjectResponse, NewTXTProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
