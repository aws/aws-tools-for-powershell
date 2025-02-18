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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Creates an Amazon Bedrock Data Automation Project
    /// </summary>
    [Cmdlet("New", "BDADataAutomationProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock CreateDataAutomationProject API operation.", Operation = new[] {"CreateDataAutomationProject"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse",
        "This cmdlet returns an Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse object containing multiple properties."
    )]
    public partial class NewBDADataAutomationProjectCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomOutputConfiguration_Blueprint
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomOutputConfiguration_Blueprints")]
        public Amazon.BedrockDataAutomation.Model.BlueprintItem[] CustomOutputConfiguration_Blueprint { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ProjectDescription
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectDescription { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        
        #region Parameter ProjectStage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DataAutomationProjectStage")]
        public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectStage { get; set; }
        #endregion
        
        #region Parameter Splitter_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_Document_Splitter_State")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State Splitter_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Audio_Extraction_Category_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Audio_Extraction_Category_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Audio_GenerativeField_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Audio_GenerativeField_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Document_Extraction_BoundingBox_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Document_Extraction_BoundingBox_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Document_GenerativeField_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Document_GenerativeField_State { get; set; }
        #endregion
        
        #region Parameter AdditionalFileFormat_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StandardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat_State")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State AdditionalFileFormat_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Image_Extraction_BoundingBox_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Image_Extraction_BoundingBox_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Image_Extraction_Category_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Image_Extraction_Category_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Image_GenerativeField_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Image_GenerativeField_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Video_Extraction_BoundingBox_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Video_Extraction_BoundingBox_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Video_Extraction_Category_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Video_Extraction_Category_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Video_GenerativeField_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Video_GenerativeField_State { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Audio_Extraction_Category_Types
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StandardOutputConfiguration_Audio_Extraction_Category_Types { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Audio_GenerativeField_Types
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StandardOutputConfiguration_Audio_GenerativeField_Types { get; set; }
        #endregion
        
        #region Parameter Granularity_Type
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StandardOutputConfiguration_Document_Extraction_Granularity_Types")]
        public System.String[] Granularity_Type { get; set; }
        #endregion
        
        #region Parameter TextFormat_Type
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StandardOutputConfiguration_Document_OutputFormat_TextFormat_Types")]
        public System.String[] TextFormat_Type { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Image_Extraction_Category_Types
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StandardOutputConfiguration_Image_Extraction_Category_Types { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Image_GenerativeField_Types
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StandardOutputConfiguration_Image_GenerativeField_Types { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Video_Extraction_Category_Types
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StandardOutputConfiguration_Video_Extraction_Category_Types { get; set; }
        #endregion
        
        #region Parameter StandardOutputConfiguration_Video_GenerativeField_Types
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StandardOutputConfiguration_Video_GenerativeField_Types { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDADataAutomationProject (CreateDataAutomationProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse, NewBDADataAutomationProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CustomOutputConfiguration_Blueprint != null)
            {
                context.CustomOutputConfiguration_Blueprint = new List<Amazon.BedrockDataAutomation.Model.BlueprintItem>(this.CustomOutputConfiguration_Blueprint);
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
            context.Splitter_State = this.Splitter_State;
            context.ProjectDescription = this.ProjectDescription;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectStage = this.ProjectStage;
            context.StandardOutputConfiguration_Audio_Extraction_Category_State = this.StandardOutputConfiguration_Audio_Extraction_Category_State;
            if (this.StandardOutputConfiguration_Audio_Extraction_Category_Types != null)
            {
                context.StandardOutputConfiguration_Audio_Extraction_Category_Types = new List<System.String>(this.StandardOutputConfiguration_Audio_Extraction_Category_Types);
            }
            context.StandardOutputConfiguration_Audio_GenerativeField_State = this.StandardOutputConfiguration_Audio_GenerativeField_State;
            if (this.StandardOutputConfiguration_Audio_GenerativeField_Types != null)
            {
                context.StandardOutputConfiguration_Audio_GenerativeField_Types = new List<System.String>(this.StandardOutputConfiguration_Audio_GenerativeField_Types);
            }
            context.StandardOutputConfiguration_Document_Extraction_BoundingBox_State = this.StandardOutputConfiguration_Document_Extraction_BoundingBox_State;
            if (this.Granularity_Type != null)
            {
                context.Granularity_Type = new List<System.String>(this.Granularity_Type);
            }
            context.StandardOutputConfiguration_Document_GenerativeField_State = this.StandardOutputConfiguration_Document_GenerativeField_State;
            context.AdditionalFileFormat_State = this.AdditionalFileFormat_State;
            if (this.TextFormat_Type != null)
            {
                context.TextFormat_Type = new List<System.String>(this.TextFormat_Type);
            }
            context.StandardOutputConfiguration_Image_Extraction_BoundingBox_State = this.StandardOutputConfiguration_Image_Extraction_BoundingBox_State;
            context.StandardOutputConfiguration_Image_Extraction_Category_State = this.StandardOutputConfiguration_Image_Extraction_Category_State;
            if (this.StandardOutputConfiguration_Image_Extraction_Category_Types != null)
            {
                context.StandardOutputConfiguration_Image_Extraction_Category_Types = new List<System.String>(this.StandardOutputConfiguration_Image_Extraction_Category_Types);
            }
            context.StandardOutputConfiguration_Image_GenerativeField_State = this.StandardOutputConfiguration_Image_GenerativeField_State;
            if (this.StandardOutputConfiguration_Image_GenerativeField_Types != null)
            {
                context.StandardOutputConfiguration_Image_GenerativeField_Types = new List<System.String>(this.StandardOutputConfiguration_Image_GenerativeField_Types);
            }
            context.StandardOutputConfiguration_Video_Extraction_BoundingBox_State = this.StandardOutputConfiguration_Video_Extraction_BoundingBox_State;
            context.StandardOutputConfiguration_Video_Extraction_Category_State = this.StandardOutputConfiguration_Video_Extraction_Category_State;
            if (this.StandardOutputConfiguration_Video_Extraction_Category_Types != null)
            {
                context.StandardOutputConfiguration_Video_Extraction_Category_Types = new List<System.String>(this.StandardOutputConfiguration_Video_Extraction_Category_Types);
            }
            context.StandardOutputConfiguration_Video_GenerativeField_State = this.StandardOutputConfiguration_Video_GenerativeField_State;
            if (this.StandardOutputConfiguration_Video_GenerativeField_Types != null)
            {
                context.StandardOutputConfiguration_Video_GenerativeField_Types = new List<System.String>(this.StandardOutputConfiguration_Video_GenerativeField_Types);
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
            var request = new Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CustomOutputConfiguration
            var requestCustomOutputConfigurationIsNull = true;
            request.CustomOutputConfiguration = new Amazon.BedrockDataAutomation.Model.CustomOutputConfiguration();
            List<Amazon.BedrockDataAutomation.Model.BlueprintItem> requestCustomOutputConfiguration_customOutputConfiguration_Blueprint = null;
            if (cmdletContext.CustomOutputConfiguration_Blueprint != null)
            {
                requestCustomOutputConfiguration_customOutputConfiguration_Blueprint = cmdletContext.CustomOutputConfiguration_Blueprint;
            }
            if (requestCustomOutputConfiguration_customOutputConfiguration_Blueprint != null)
            {
                request.CustomOutputConfiguration.Blueprints = requestCustomOutputConfiguration_customOutputConfiguration_Blueprint;
                requestCustomOutputConfigurationIsNull = false;
            }
             // determine if request.CustomOutputConfiguration should be set to null
            if (requestCustomOutputConfigurationIsNull)
            {
                request.CustomOutputConfiguration = null;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.BedrockDataAutomation.Model.EncryptionConfiguration();
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
            
             // populate OverrideConfiguration
            var requestOverrideConfigurationIsNull = true;
            request.OverrideConfiguration = new Amazon.BedrockDataAutomation.Model.OverrideConfiguration();
            Amazon.BedrockDataAutomation.Model.DocumentOverrideConfiguration requestOverrideConfiguration_overrideConfiguration_Document = null;
            
             // populate Document
            var requestOverrideConfiguration_overrideConfiguration_DocumentIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Document = new Amazon.BedrockDataAutomation.Model.DocumentOverrideConfiguration();
            Amazon.BedrockDataAutomation.Model.SplitterConfiguration requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter = null;
            
             // populate Splitter
            var requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SplitterIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter = new Amazon.BedrockDataAutomation.Model.SplitterConfiguration();
            Amazon.BedrockDataAutomation.State requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter_splitter_State = null;
            if (cmdletContext.Splitter_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter_splitter_State = cmdletContext.Splitter_State;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter_splitter_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter.State = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter_splitter_State;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SplitterIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SplitterIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document.Splitter = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_Splitter;
                requestOverrideConfiguration_overrideConfiguration_DocumentIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Document should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_DocumentIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Document = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document != null)
            {
                request.OverrideConfiguration.Document = requestOverrideConfiguration_overrideConfiguration_Document;
                requestOverrideConfigurationIsNull = false;
            }
             // determine if request.OverrideConfiguration should be set to null
            if (requestOverrideConfigurationIsNull)
            {
                request.OverrideConfiguration = null;
            }
            if (cmdletContext.ProjectDescription != null)
            {
                request.ProjectDescription = cmdletContext.ProjectDescription;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            if (cmdletContext.ProjectStage != null)
            {
                request.ProjectStage = cmdletContext.ProjectStage;
            }
            
             // populate StandardOutputConfiguration
            var requestStandardOutputConfigurationIsNull = true;
            request.StandardOutputConfiguration = new Amazon.BedrockDataAutomation.Model.StandardOutputConfiguration();
            Amazon.BedrockDataAutomation.Model.AudioStandardOutputConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Audio = null;
            
             // populate Audio
            var requestStandardOutputConfiguration_standardOutputConfiguration_AudioIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio = new Amazon.BedrockDataAutomation.Model.AudioStandardOutputConfiguration();
            Amazon.BedrockDataAutomation.Model.AudioStandardExtraction requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction = null;
            
             // populate Extraction
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_ExtractionIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction = new Amazon.BedrockDataAutomation.Model.AudioStandardExtraction();
            Amazon.BedrockDataAutomation.Model.AudioExtractionCategory requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category = null;
            
             // populate Category
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_CategoryIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category = new Amazon.BedrockDataAutomation.Model.AudioExtractionCategory();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_State = null;
            if (cmdletContext.StandardOutputConfiguration_Audio_Extraction_Category_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_State = cmdletContext.StandardOutputConfiguration_Audio_Extraction_Category_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category.State = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_CategoryIsNull = false;
            }
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_Types = null;
            if (cmdletContext.StandardOutputConfiguration_Audio_Extraction_Category_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_Types = cmdletContext.StandardOutputConfiguration_Audio_Extraction_Category_Types;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_Types;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_CategoryIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_CategoryIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction.Category = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_ExtractionIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_ExtractionIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio.Extraction = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction;
                requestStandardOutputConfiguration_standardOutputConfiguration_AudioIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.AudioStandardGenerativeField requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField = null;
            
             // populate GenerativeField
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeFieldIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField = new Amazon.BedrockDataAutomation.Model.AudioStandardGenerativeField();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_State = null;
            if (cmdletContext.StandardOutputConfiguration_Audio_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_State = cmdletContext.StandardOutputConfiguration_Audio_GenerativeField_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField.State = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeFieldIsNull = false;
            }
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_Types = null;
            if (cmdletContext.StandardOutputConfiguration_Audio_GenerativeField_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_Types = cmdletContext.StandardOutputConfiguration_Audio_GenerativeField_Types;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField_standardOutputConfiguration_Audio_GenerativeField_Types;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeFieldIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeFieldIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio.GenerativeField = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_GenerativeField;
                requestStandardOutputConfiguration_standardOutputConfiguration_AudioIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_AudioIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio != null)
            {
                request.StandardOutputConfiguration.Audio = requestStandardOutputConfiguration_standardOutputConfiguration_Audio;
                requestStandardOutputConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.ImageStandardOutputConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Image = null;
            
             // populate Image
            var requestStandardOutputConfiguration_standardOutputConfiguration_ImageIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Image = new Amazon.BedrockDataAutomation.Model.ImageStandardOutputConfiguration();
            Amazon.BedrockDataAutomation.Model.ImageStandardExtraction requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction = null;
            
             // populate Extraction
            var requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_ExtractionIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction = new Amazon.BedrockDataAutomation.Model.ImageStandardExtraction();
            Amazon.BedrockDataAutomation.Model.ImageBoundingBox requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox = null;
            
             // populate BoundingBox
            var requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBoxIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox = new Amazon.BedrockDataAutomation.Model.ImageBoundingBox();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox_standardOutputConfiguration_Image_Extraction_BoundingBox_State = null;
            if (cmdletContext.StandardOutputConfiguration_Image_Extraction_BoundingBox_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox_standardOutputConfiguration_Image_Extraction_BoundingBox_State = cmdletContext.StandardOutputConfiguration_Image_Extraction_BoundingBox_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox_standardOutputConfiguration_Image_Extraction_BoundingBox_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox.State = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox_standardOutputConfiguration_Image_Extraction_BoundingBox_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBoxIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBoxIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction.BoundingBox = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_BoundingBox;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_ExtractionIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.ImageExtractionCategory requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category = null;
            
             // populate Category
            var requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_CategoryIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category = new Amazon.BedrockDataAutomation.Model.ImageExtractionCategory();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_State = null;
            if (cmdletContext.StandardOutputConfiguration_Image_Extraction_Category_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_State = cmdletContext.StandardOutputConfiguration_Image_Extraction_Category_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category.State = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_CategoryIsNull = false;
            }
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_Types = null;
            if (cmdletContext.StandardOutputConfiguration_Image_Extraction_Category_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_Types = cmdletContext.StandardOutputConfiguration_Image_Extraction_Category_Types;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category_standardOutputConfiguration_Image_Extraction_Category_Types;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_CategoryIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_CategoryIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction.Category = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction_standardOutputConfiguration_Image_Extraction_Category;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_ExtractionIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_ExtractionIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image.Extraction = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_Extraction;
                requestStandardOutputConfiguration_standardOutputConfiguration_ImageIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.ImageStandardGenerativeField requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField = null;
            
             // populate GenerativeField
            var requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeFieldIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField = new Amazon.BedrockDataAutomation.Model.ImageStandardGenerativeField();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_State = null;
            if (cmdletContext.StandardOutputConfiguration_Image_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_State = cmdletContext.StandardOutputConfiguration_Image_GenerativeField_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField.State = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeFieldIsNull = false;
            }
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_Types = null;
            if (cmdletContext.StandardOutputConfiguration_Image_GenerativeField_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_Types = cmdletContext.StandardOutputConfiguration_Image_GenerativeField_Types;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField_standardOutputConfiguration_Image_GenerativeField_Types;
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeFieldIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeFieldIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image.GenerativeField = requestStandardOutputConfiguration_standardOutputConfiguration_Image_standardOutputConfiguration_Image_GenerativeField;
                requestStandardOutputConfiguration_standardOutputConfiguration_ImageIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Image should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_ImageIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Image = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Image != null)
            {
                request.StandardOutputConfiguration.Image = requestStandardOutputConfiguration_standardOutputConfiguration_Image;
                requestStandardOutputConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.VideoStandardOutputConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Video = null;
            
             // populate Video
            var requestStandardOutputConfiguration_standardOutputConfiguration_VideoIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Video = new Amazon.BedrockDataAutomation.Model.VideoStandardOutputConfiguration();
            Amazon.BedrockDataAutomation.Model.VideoStandardExtraction requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction = null;
            
             // populate Extraction
            var requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_ExtractionIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction = new Amazon.BedrockDataAutomation.Model.VideoStandardExtraction();
            Amazon.BedrockDataAutomation.Model.VideoBoundingBox requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox = null;
            
             // populate BoundingBox
            var requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBoxIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox = new Amazon.BedrockDataAutomation.Model.VideoBoundingBox();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox_standardOutputConfiguration_Video_Extraction_BoundingBox_State = null;
            if (cmdletContext.StandardOutputConfiguration_Video_Extraction_BoundingBox_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox_standardOutputConfiguration_Video_Extraction_BoundingBox_State = cmdletContext.StandardOutputConfiguration_Video_Extraction_BoundingBox_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox_standardOutputConfiguration_Video_Extraction_BoundingBox_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox.State = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox_standardOutputConfiguration_Video_Extraction_BoundingBox_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBoxIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBoxIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction.BoundingBox = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_BoundingBox;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_ExtractionIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.VideoExtractionCategory requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category = null;
            
             // populate Category
            var requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_CategoryIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category = new Amazon.BedrockDataAutomation.Model.VideoExtractionCategory();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_State = null;
            if (cmdletContext.StandardOutputConfiguration_Video_Extraction_Category_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_State = cmdletContext.StandardOutputConfiguration_Video_Extraction_Category_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category.State = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_CategoryIsNull = false;
            }
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_Types = null;
            if (cmdletContext.StandardOutputConfiguration_Video_Extraction_Category_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_Types = cmdletContext.StandardOutputConfiguration_Video_Extraction_Category_Types;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category_standardOutputConfiguration_Video_Extraction_Category_Types;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_CategoryIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_CategoryIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction.Category = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction_standardOutputConfiguration_Video_Extraction_Category;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_ExtractionIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_ExtractionIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video.Extraction = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_Extraction;
                requestStandardOutputConfiguration_standardOutputConfiguration_VideoIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.VideoStandardGenerativeField requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField = null;
            
             // populate GenerativeField
            var requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeFieldIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField = new Amazon.BedrockDataAutomation.Model.VideoStandardGenerativeField();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_State = null;
            if (cmdletContext.StandardOutputConfiguration_Video_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_State = cmdletContext.StandardOutputConfiguration_Video_GenerativeField_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField.State = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeFieldIsNull = false;
            }
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_Types = null;
            if (cmdletContext.StandardOutputConfiguration_Video_GenerativeField_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_Types = cmdletContext.StandardOutputConfiguration_Video_GenerativeField_Types;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_Types != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField_standardOutputConfiguration_Video_GenerativeField_Types;
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeFieldIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeFieldIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video.GenerativeField = requestStandardOutputConfiguration_standardOutputConfiguration_Video_standardOutputConfiguration_Video_GenerativeField;
                requestStandardOutputConfiguration_standardOutputConfiguration_VideoIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Video should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_VideoIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Video = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Video != null)
            {
                request.StandardOutputConfiguration.Video = requestStandardOutputConfiguration_standardOutputConfiguration_Video;
                requestStandardOutputConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DocumentStandardOutputConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Document = null;
            
             // populate Document
            var requestStandardOutputConfiguration_standardOutputConfiguration_DocumentIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document = new Amazon.BedrockDataAutomation.Model.DocumentStandardOutputConfiguration();
            Amazon.BedrockDataAutomation.Model.DocumentStandardGenerativeField requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField = null;
            
             // populate GenerativeField
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeFieldIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField = new Amazon.BedrockDataAutomation.Model.DocumentStandardGenerativeField();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField_standardOutputConfiguration_Document_GenerativeField_State = null;
            if (cmdletContext.StandardOutputConfiguration_Document_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField_standardOutputConfiguration_Document_GenerativeField_State = cmdletContext.StandardOutputConfiguration_Document_GenerativeField_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField_standardOutputConfiguration_Document_GenerativeField_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField.State = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField_standardOutputConfiguration_Document_GenerativeField_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeFieldIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeFieldIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document.GenerativeField = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_GenerativeField;
                requestStandardOutputConfiguration_standardOutputConfiguration_DocumentIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DocumentStandardExtraction requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction = null;
            
             // populate Extraction
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_ExtractionIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction = new Amazon.BedrockDataAutomation.Model.DocumentStandardExtraction();
            Amazon.BedrockDataAutomation.Model.DocumentBoundingBox requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox = null;
            
             // populate BoundingBox
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBoxIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox = new Amazon.BedrockDataAutomation.Model.DocumentBoundingBox();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox_standardOutputConfiguration_Document_Extraction_BoundingBox_State = null;
            if (cmdletContext.StandardOutputConfiguration_Document_Extraction_BoundingBox_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox_standardOutputConfiguration_Document_Extraction_BoundingBox_State = cmdletContext.StandardOutputConfiguration_Document_Extraction_BoundingBox_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox_standardOutputConfiguration_Document_Extraction_BoundingBox_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox.State = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox_standardOutputConfiguration_Document_Extraction_BoundingBox_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBoxIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBoxIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction.BoundingBox = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_BoundingBox;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_ExtractionIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DocumentExtractionGranularity requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity = null;
            
             // populate Granularity
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_GranularityIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity = new Amazon.BedrockDataAutomation.Model.DocumentExtractionGranularity();
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity_granularity_Type = null;
            if (cmdletContext.Granularity_Type != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity_granularity_Type = cmdletContext.Granularity_Type;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity_granularity_Type != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity_granularity_Type;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_GranularityIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_GranularityIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction.Granularity = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction_standardOutputConfiguration_Document_Extraction_Granularity;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_ExtractionIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_ExtractionIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document.Extraction = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_Extraction;
                requestStandardOutputConfiguration_standardOutputConfiguration_DocumentIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DocumentOutputFormat requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat = null;
            
             // populate OutputFormat
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormatIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat = new Amazon.BedrockDataAutomation.Model.DocumentOutputFormat();
            Amazon.BedrockDataAutomation.Model.DocumentOutputAdditionalFileFormat requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat = null;
            
             // populate AdditionalFileFormat
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormatIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat = new Amazon.BedrockDataAutomation.Model.DocumentOutputAdditionalFileFormat();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat_additionalFileFormat_State = null;
            if (cmdletContext.AdditionalFileFormat_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat_additionalFileFormat_State = cmdletContext.AdditionalFileFormat_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat_additionalFileFormat_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat.State = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat_additionalFileFormat_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormatIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormatIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat.AdditionalFileFormat = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_AdditionalFileFormat;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormatIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DocumentOutputTextFormat requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat = null;
            
             // populate TextFormat
            var requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormatIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat = new Amazon.BedrockDataAutomation.Model.DocumentOutputTextFormat();
            List<System.String> requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat_textFormat_Type = null;
            if (cmdletContext.TextFormat_Type != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat_textFormat_Type = cmdletContext.TextFormat_Type;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat_textFormat_Type != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat.Types = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat_textFormat_Type;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormatIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormatIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat.TextFormat = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat_standardOutputConfiguration_Document_OutputFormat_TextFormat;
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormatIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormatIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document.OutputFormat = requestStandardOutputConfiguration_standardOutputConfiguration_Document_standardOutputConfiguration_Document_OutputFormat;
                requestStandardOutputConfiguration_standardOutputConfiguration_DocumentIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Document should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_DocumentIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Document = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Document != null)
            {
                request.StandardOutputConfiguration.Document = requestStandardOutputConfiguration_standardOutputConfiguration_Document;
                requestStandardOutputConfigurationIsNull = false;
            }
             // determine if request.StandardOutputConfiguration should be set to null
            if (requestStandardOutputConfigurationIsNull)
            {
                request.StandardOutputConfiguration = null;
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
        
        private Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "CreateDataAutomationProject");
            try
            {
                return client.CreateDataAutomationProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.BedrockDataAutomation.Model.BlueprintItem> CustomOutputConfiguration_Blueprint { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.BedrockDataAutomation.State Splitter_State { get; set; }
            public System.String ProjectDescription { get; set; }
            public System.String ProjectName { get; set; }
            public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectStage { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Audio_Extraction_Category_State { get; set; }
            public List<System.String> StandardOutputConfiguration_Audio_Extraction_Category_Types { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Audio_GenerativeField_State { get; set; }
            public List<System.String> StandardOutputConfiguration_Audio_GenerativeField_Types { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Document_Extraction_BoundingBox_State { get; set; }
            public List<System.String> Granularity_Type { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Document_GenerativeField_State { get; set; }
            public Amazon.BedrockDataAutomation.State AdditionalFileFormat_State { get; set; }
            public List<System.String> TextFormat_Type { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Image_Extraction_BoundingBox_State { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Image_Extraction_Category_State { get; set; }
            public List<System.String> StandardOutputConfiguration_Image_Extraction_Category_Types { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Image_GenerativeField_State { get; set; }
            public List<System.String> StandardOutputConfiguration_Image_GenerativeField_Types { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Video_Extraction_BoundingBox_State { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Video_Extraction_Category_State { get; set; }
            public List<System.String> StandardOutputConfiguration_Video_Extraction_Category_Types { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Video_GenerativeField_State { get; set; }
            public List<System.String> StandardOutputConfiguration_Video_GenerativeField_Types { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.CreateDataAutomationProjectResponse, NewBDADataAutomationProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
