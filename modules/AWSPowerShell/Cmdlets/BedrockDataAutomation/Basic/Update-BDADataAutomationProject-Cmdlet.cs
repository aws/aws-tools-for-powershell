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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Updates an existing Amazon Bedrock Data Automation Project
    /// </summary>
    [Cmdlet("Update", "BDADataAutomationProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock UpdateDataAutomationProject API operation.", Operation = new[] {"UpdateDataAutomationProject"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse",
        "This cmdlet returns an Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse object containing multiple properties."
    )]
    public partial class UpdateBDADataAutomationProjectCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode
        /// <summary>
        /// <para>
        /// <para>Mode for sensitive data detection</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.SensitiveDataDetectionMode")]
        public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode
        /// <summary>
        /// <para>
        /// <para>Mode for sensitive data detection</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.SensitiveDataDetectionMode")]
        public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode
        /// <summary>
        /// <para>
        /// <para>Mode for sensitive data detection</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.SensitiveDataDetectionMode")]
        public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode
        /// <summary>
        /// <para>
        /// <para>Mode for sensitive data detection</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.SensitiveDataDetectionMode")]
        public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope
        /// <summary>
        /// <para>
        /// <para>Scope of detection - what types of sensitive data to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope
        /// <summary>
        /// <para>
        /// <para>Scope of detection - what types of sensitive data to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope
        /// <summary>
        /// <para>
        /// <para>Scope of detection - what types of sensitive data to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope
        /// <summary>
        /// <para>
        /// <para>Scope of detection - what types of sensitive data to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope { get; set; }
        #endregion
        
        #region Parameter LanguageConfiguration_GenerativeOutputLanguage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_Audio_LanguageConfiguration_GenerativeOutputLanguage")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.AudioGenerativeOutputLanguage")]
        public Amazon.BedrockDataAutomation.AudioGenerativeOutputLanguage LanguageConfiguration_GenerativeOutputLanguage { get; set; }
        #endregion
        
        #region Parameter LanguageConfiguration_IdentifyMultipleLanguage
        /// <summary>
        /// <para>
        /// <para>Enable multiple language identification in audio</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_Audio_LanguageConfiguration_IdentifyMultipleLanguages")]
        public System.Boolean? LanguageConfiguration_IdentifyMultipleLanguage { get; set; }
        #endregion
        
        #region Parameter LanguageConfiguration_InputLanguage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_Audio_LanguageConfiguration_InputLanguages")]
        public System.String[] LanguageConfiguration_InputLanguage { get; set; }
        #endregion
        
        #region Parameter ModalityRouting_Jpeg
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_ModalityRouting_Jpeg")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DesiredModality")]
        public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Jpeg { get; set; }
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
        
        #region Parameter ModalityRouting_Mov
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_ModalityRouting_Mov")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DesiredModality")]
        public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Mov { get; set; }
        #endregion
        
        #region Parameter ModalityRouting_Mp4
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_ModalityRouting_Mp4")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DesiredModality")]
        public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Mp4 { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes
        /// <summary>
        /// <para>
        /// <para>Types of PII entities to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes
        /// <summary>
        /// <para>
        /// <para>Types of PII entities to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes
        /// <summary>
        /// <para>
        /// <para>Types of PII entities to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes
        /// <summary>
        /// <para>
        /// <para>Types of PII entities to detect</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
        #endregion
        
        #region Parameter ModalityRouting_Png
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideConfiguration_ModalityRouting_Png")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DesiredModality")]
        public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Png { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>ARN generated at the server side when a DataAutomationProject is created</para>
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
        public System.String ProjectArn { get; set; }
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
        
        #region Parameter OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode
        /// <summary>
        /// <para>
        /// <para>Mode for redacting detected PII</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.PIIRedactionMaskMode")]
        public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode
        /// <summary>
        /// <para>
        /// <para>Mode for redacting detected PII</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.PIIRedactionMaskMode")]
        public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode
        /// <summary>
        /// <para>
        /// <para>Mode for redacting detected PII</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.PIIRedactionMaskMode")]
        public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode
        /// <summary>
        /// <para>
        /// <para>Mode for redacting detected PII</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.PIIRedactionMaskMode")]
        public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Audio_ModalityProcessing_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State OverrideConfiguration_Audio_ModalityProcessing_State { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Document_ModalityProcessing_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State OverrideConfiguration_Document_ModalityProcessing_State { get; set; }
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
        
        #region Parameter OverrideConfiguration_Image_ModalityProcessing_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State OverrideConfiguration_Image_ModalityProcessing_State { get; set; }
        #endregion
        
        #region Parameter OverrideConfiguration_Video_ModalityProcessing_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State OverrideConfiguration_Video_ModalityProcessing_State { get; set; }
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
        
        #region Parameter ChannelLabeling_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StandardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling_State")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State ChannelLabeling_State { get; set; }
        #endregion
        
        #region Parameter SpeakerLabeling_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StandardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling_State")]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.State")]
        public Amazon.BedrockDataAutomation.State SpeakerLabeling_State { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDADataAutomationProject (UpdateDataAutomationProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse, UpdateBDADataAutomationProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.LanguageConfiguration_GenerativeOutputLanguage = this.LanguageConfiguration_GenerativeOutputLanguage;
            context.LanguageConfiguration_IdentifyMultipleLanguage = this.LanguageConfiguration_IdentifyMultipleLanguage;
            if (this.LanguageConfiguration_InputLanguage != null)
            {
                context.LanguageConfiguration_InputLanguage = new List<System.String>(this.LanguageConfiguration_InputLanguage);
            }
            context.OverrideConfiguration_Audio_ModalityProcessing_State = this.OverrideConfiguration_Audio_ModalityProcessing_State;
            context.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode = this.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode;
            if (this.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope != null)
            {
                context.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope = new List<System.String>(this.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope);
            }
            if (this.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                context.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = new List<System.String>(this.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes);
            }
            context.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = this.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            context.OverrideConfiguration_Document_ModalityProcessing_State = this.OverrideConfiguration_Document_ModalityProcessing_State;
            context.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode = this.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode;
            if (this.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope != null)
            {
                context.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope = new List<System.String>(this.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope);
            }
            if (this.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                context.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = new List<System.String>(this.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes);
            }
            context.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = this.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            context.Splitter_State = this.Splitter_State;
            context.OverrideConfiguration_Image_ModalityProcessing_State = this.OverrideConfiguration_Image_ModalityProcessing_State;
            context.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode = this.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode;
            if (this.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope != null)
            {
                context.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope = new List<System.String>(this.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope);
            }
            if (this.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                context.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = new List<System.String>(this.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes);
            }
            context.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = this.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            context.ModalityRouting_Jpeg = this.ModalityRouting_Jpeg;
            context.ModalityRouting_Mov = this.ModalityRouting_Mov;
            context.ModalityRouting_Mp4 = this.ModalityRouting_Mp4;
            context.ModalityRouting_Png = this.ModalityRouting_Png;
            context.OverrideConfiguration_Video_ModalityProcessing_State = this.OverrideConfiguration_Video_ModalityProcessing_State;
            context.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode = this.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode;
            if (this.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope != null)
            {
                context.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope = new List<System.String>(this.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope);
            }
            if (this.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                context.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = new List<System.String>(this.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes);
            }
            context.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = this.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectDescription = this.ProjectDescription;
            context.ProjectStage = this.ProjectStage;
            context.StandardOutputConfiguration_Audio_Extraction_Category_State = this.StandardOutputConfiguration_Audio_Extraction_Category_State;
            context.ChannelLabeling_State = this.ChannelLabeling_State;
            context.SpeakerLabeling_State = this.SpeakerLabeling_State;
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
            var request = new Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectRequest();
            
            
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
            Amazon.BedrockDataAutomation.Model.ImageOverrideConfiguration requestOverrideConfiguration_overrideConfiguration_Image = null;
            
             // populate Image
            var requestOverrideConfiguration_overrideConfiguration_ImageIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Image = new Amazon.BedrockDataAutomation.Model.ImageOverrideConfiguration();
            Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing = null;
            
             // populate ModalityProcessing
            var requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessingIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing = new Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration();
            Amazon.BedrockDataAutomation.State requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing_overrideConfiguration_Image_ModalityProcessing_State = null;
            if (cmdletContext.OverrideConfiguration_Image_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing_overrideConfiguration_Image_ModalityProcessing_State = cmdletContext.OverrideConfiguration_Image_ModalityProcessing_State;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing_overrideConfiguration_Image_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing.State = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing_overrideConfiguration_Image_ModalityProcessing_State;
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessingIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessingIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image.ModalityProcessing = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_ModalityProcessing;
                requestOverrideConfiguration_overrideConfiguration_ImageIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration = null;
            
             // populate SensitiveDataConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration = new Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration();
            Amazon.BedrockDataAutomation.SensitiveDataDetectionMode requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode = null;
            if (cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode = cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration.DetectionMode = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode;
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfigurationIsNull = false;
            }
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope = null;
            if (cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope = cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration.DetectionScope = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope;
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            
             // populate PiiEntitiesConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration = new Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration();
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = null;
            if (cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration.PiiEntityTypes = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.PIIRedactionMaskMode requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = null;
            if (cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = cmdletContext.OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration.RedactionMaskMode = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration.PiiEntitiesConfiguration = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration_overrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration;
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Image.SensitiveDataConfiguration = requestOverrideConfiguration_overrideConfiguration_Image_overrideConfiguration_Image_SensitiveDataConfiguration;
                requestOverrideConfiguration_overrideConfiguration_ImageIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Image should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_ImageIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Image = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Image != null)
            {
                request.OverrideConfiguration.Image = requestOverrideConfiguration_overrideConfiguration_Image;
                requestOverrideConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.VideoOverrideConfiguration requestOverrideConfiguration_overrideConfiguration_Video = null;
            
             // populate Video
            var requestOverrideConfiguration_overrideConfiguration_VideoIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Video = new Amazon.BedrockDataAutomation.Model.VideoOverrideConfiguration();
            Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing = null;
            
             // populate ModalityProcessing
            var requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessingIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing = new Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration();
            Amazon.BedrockDataAutomation.State requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing_overrideConfiguration_Video_ModalityProcessing_State = null;
            if (cmdletContext.OverrideConfiguration_Video_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing_overrideConfiguration_Video_ModalityProcessing_State = cmdletContext.OverrideConfiguration_Video_ModalityProcessing_State;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing_overrideConfiguration_Video_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing.State = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing_overrideConfiguration_Video_ModalityProcessing_State;
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessingIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessingIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video.ModalityProcessing = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_ModalityProcessing;
                requestOverrideConfiguration_overrideConfiguration_VideoIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration = null;
            
             // populate SensitiveDataConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration = new Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration();
            Amazon.BedrockDataAutomation.SensitiveDataDetectionMode requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode = null;
            if (cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode = cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration.DetectionMode = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode;
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfigurationIsNull = false;
            }
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope = null;
            if (cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope = cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration.DetectionScope = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope;
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            
             // populate PiiEntitiesConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration = new Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration();
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = null;
            if (cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration.PiiEntityTypes = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.PIIRedactionMaskMode requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = null;
            if (cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = cmdletContext.OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration.RedactionMaskMode = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration.PiiEntitiesConfiguration = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration_overrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration;
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Video.SensitiveDataConfiguration = requestOverrideConfiguration_overrideConfiguration_Video_overrideConfiguration_Video_SensitiveDataConfiguration;
                requestOverrideConfiguration_overrideConfiguration_VideoIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Video should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_VideoIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Video = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Video != null)
            {
                request.OverrideConfiguration.Video = requestOverrideConfiguration_overrideConfiguration_Video;
                requestOverrideConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.AudioOverrideConfiguration requestOverrideConfiguration_overrideConfiguration_Audio = null;
            
             // populate Audio
            var requestOverrideConfiguration_overrideConfiguration_AudioIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Audio = new Amazon.BedrockDataAutomation.Model.AudioOverrideConfiguration();
            Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing = null;
            
             // populate ModalityProcessing
            var requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessingIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing = new Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration();
            Amazon.BedrockDataAutomation.State requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing_overrideConfiguration_Audio_ModalityProcessing_State = null;
            if (cmdletContext.OverrideConfiguration_Audio_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing_overrideConfiguration_Audio_ModalityProcessing_State = cmdletContext.OverrideConfiguration_Audio_ModalityProcessing_State;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing_overrideConfiguration_Audio_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing.State = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing_overrideConfiguration_Audio_ModalityProcessing_State;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessingIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessingIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio.ModalityProcessing = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_ModalityProcessing;
                requestOverrideConfiguration_overrideConfiguration_AudioIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.AudioLanguageConfiguration requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration = null;
            
             // populate LanguageConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration = new Amazon.BedrockDataAutomation.Model.AudioLanguageConfiguration();
            Amazon.BedrockDataAutomation.AudioGenerativeOutputLanguage requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_GenerativeOutputLanguage = null;
            if (cmdletContext.LanguageConfiguration_GenerativeOutputLanguage != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_GenerativeOutputLanguage = cmdletContext.LanguageConfiguration_GenerativeOutputLanguage;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_GenerativeOutputLanguage != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration.GenerativeOutputLanguage = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_GenerativeOutputLanguage;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfigurationIsNull = false;
            }
            System.Boolean? requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_IdentifyMultipleLanguage = null;
            if (cmdletContext.LanguageConfiguration_IdentifyMultipleLanguage != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_IdentifyMultipleLanguage = cmdletContext.LanguageConfiguration_IdentifyMultipleLanguage.Value;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_IdentifyMultipleLanguage != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration.IdentifyMultipleLanguages = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_IdentifyMultipleLanguage.Value;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfigurationIsNull = false;
            }
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_InputLanguage = null;
            if (cmdletContext.LanguageConfiguration_InputLanguage != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_InputLanguage = cmdletContext.LanguageConfiguration_InputLanguage;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_InputLanguage != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration.InputLanguages = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration_languageConfiguration_InputLanguage;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio.LanguageConfiguration = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_LanguageConfiguration;
                requestOverrideConfiguration_overrideConfiguration_AudioIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration = null;
            
             // populate SensitiveDataConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration = new Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration();
            Amazon.BedrockDataAutomation.SensitiveDataDetectionMode requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode = null;
            if (cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode = cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration.DetectionMode = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfigurationIsNull = false;
            }
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope = null;
            if (cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope = cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration.DetectionScope = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            
             // populate PiiEntitiesConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration = new Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration();
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = null;
            if (cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration.PiiEntityTypes = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.PIIRedactionMaskMode requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = null;
            if (cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = cmdletContext.OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration.RedactionMaskMode = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration.PiiEntitiesConfiguration = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration_overrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration;
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio.SensitiveDataConfiguration = requestOverrideConfiguration_overrideConfiguration_Audio_overrideConfiguration_Audio_SensitiveDataConfiguration;
                requestOverrideConfiguration_overrideConfiguration_AudioIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Audio should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_AudioIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Audio = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Audio != null)
            {
                request.OverrideConfiguration.Audio = requestOverrideConfiguration_overrideConfiguration_Audio;
                requestOverrideConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DocumentOverrideConfiguration requestOverrideConfiguration_overrideConfiguration_Document = null;
            
             // populate Document
            var requestOverrideConfiguration_overrideConfiguration_DocumentIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Document = new Amazon.BedrockDataAutomation.Model.DocumentOverrideConfiguration();
            Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing = null;
            
             // populate ModalityProcessing
            var requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessingIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing = new Amazon.BedrockDataAutomation.Model.ModalityProcessingConfiguration();
            Amazon.BedrockDataAutomation.State requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing_overrideConfiguration_Document_ModalityProcessing_State = null;
            if (cmdletContext.OverrideConfiguration_Document_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing_overrideConfiguration_Document_ModalityProcessing_State = cmdletContext.OverrideConfiguration_Document_ModalityProcessing_State;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing_overrideConfiguration_Document_ModalityProcessing_State != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing.State = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing_overrideConfiguration_Document_ModalityProcessing_State;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessingIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessingIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document.ModalityProcessing = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_ModalityProcessing;
                requestOverrideConfiguration_overrideConfiguration_DocumentIsNull = false;
            }
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
            Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration = null;
            
             // populate SensitiveDataConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration = new Amazon.BedrockDataAutomation.Model.SensitiveDataConfiguration();
            Amazon.BedrockDataAutomation.SensitiveDataDetectionMode requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode = null;
            if (cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode = cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration.DetectionMode = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfigurationIsNull = false;
            }
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope = null;
            if (cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope = cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration.DetectionScope = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            
             // populate PiiEntitiesConfiguration
            var requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration = new Amazon.BedrockDataAutomation.Model.PIIEntitiesConfiguration();
            List<System.String> requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = null;
            if (cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes = cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration.PiiEntityTypes = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.PIIRedactionMaskMode requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = null;
            if (cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode = cmdletContext.OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration.RedactionMaskMode = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration.PiiEntitiesConfiguration = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration_overrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration;
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfigurationIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfigurationIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration != null)
            {
                requestOverrideConfiguration_overrideConfiguration_Document.SensitiveDataConfiguration = requestOverrideConfiguration_overrideConfiguration_Document_overrideConfiguration_Document_SensitiveDataConfiguration;
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
            Amazon.BedrockDataAutomation.Model.ModalityRoutingConfiguration requestOverrideConfiguration_overrideConfiguration_ModalityRouting = null;
            
             // populate ModalityRouting
            var requestOverrideConfiguration_overrideConfiguration_ModalityRoutingIsNull = true;
            requestOverrideConfiguration_overrideConfiguration_ModalityRouting = new Amazon.BedrockDataAutomation.Model.ModalityRoutingConfiguration();
            Amazon.BedrockDataAutomation.DesiredModality requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Jpeg = null;
            if (cmdletContext.ModalityRouting_Jpeg != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Jpeg = cmdletContext.ModalityRouting_Jpeg;
            }
            if (requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Jpeg != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting.Jpeg = requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Jpeg;
                requestOverrideConfiguration_overrideConfiguration_ModalityRoutingIsNull = false;
            }
            Amazon.BedrockDataAutomation.DesiredModality requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mov = null;
            if (cmdletContext.ModalityRouting_Mov != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mov = cmdletContext.ModalityRouting_Mov;
            }
            if (requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mov != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting.Mov = requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mov;
                requestOverrideConfiguration_overrideConfiguration_ModalityRoutingIsNull = false;
            }
            Amazon.BedrockDataAutomation.DesiredModality requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mp4 = null;
            if (cmdletContext.ModalityRouting_Mp4 != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mp4 = cmdletContext.ModalityRouting_Mp4;
            }
            if (requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mp4 != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting.Mp4 = requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Mp4;
                requestOverrideConfiguration_overrideConfiguration_ModalityRoutingIsNull = false;
            }
            Amazon.BedrockDataAutomation.DesiredModality requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Png = null;
            if (cmdletContext.ModalityRouting_Png != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Png = cmdletContext.ModalityRouting_Png;
            }
            if (requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Png != null)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting.Png = requestOverrideConfiguration_overrideConfiguration_ModalityRouting_modalityRouting_Png;
                requestOverrideConfiguration_overrideConfiguration_ModalityRoutingIsNull = false;
            }
             // determine if requestOverrideConfiguration_overrideConfiguration_ModalityRouting should be set to null
            if (requestOverrideConfiguration_overrideConfiguration_ModalityRoutingIsNull)
            {
                requestOverrideConfiguration_overrideConfiguration_ModalityRouting = null;
            }
            if (requestOverrideConfiguration_overrideConfiguration_ModalityRouting != null)
            {
                request.OverrideConfiguration.ModalityRouting = requestOverrideConfiguration_overrideConfiguration_ModalityRouting;
                requestOverrideConfigurationIsNull = false;
            }
             // determine if request.OverrideConfiguration should be set to null
            if (requestOverrideConfigurationIsNull)
            {
                request.OverrideConfiguration = null;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.ProjectDescription != null)
            {
                request.ProjectDescription = cmdletContext.ProjectDescription;
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
            Amazon.BedrockDataAutomation.Model.AudioExtractionCategoryTypeConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration = null;
            
             // populate TypeConfiguration
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfigurationIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration = new Amazon.BedrockDataAutomation.Model.AudioExtractionCategoryTypeConfiguration();
            Amazon.BedrockDataAutomation.Model.TranscriptConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript = null;
            
             // populate Transcript
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_TranscriptIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript = new Amazon.BedrockDataAutomation.Model.TranscriptConfiguration();
            Amazon.BedrockDataAutomation.Model.ChannelLabelingConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling = null;
            
             // populate ChannelLabeling
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabelingIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling = new Amazon.BedrockDataAutomation.Model.ChannelLabelingConfiguration();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling_channelLabeling_State = null;
            if (cmdletContext.ChannelLabeling_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling_channelLabeling_State = cmdletContext.ChannelLabeling_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling_channelLabeling_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling.State = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling_channelLabeling_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabelingIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabelingIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript.ChannelLabeling = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_ChannelLabeling;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_TranscriptIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.SpeakerLabelingConfiguration requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling = null;
            
             // populate SpeakerLabeling
            var requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabelingIsNull = true;
            requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling = new Amazon.BedrockDataAutomation.Model.SpeakerLabelingConfiguration();
            Amazon.BedrockDataAutomation.State requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling_speakerLabeling_State = null;
            if (cmdletContext.SpeakerLabeling_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling_speakerLabeling_State = cmdletContext.SpeakerLabeling_State;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling_speakerLabeling_State != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling.State = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling_speakerLabeling_State;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabelingIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabelingIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript.SpeakerLabeling = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript_SpeakerLabeling;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_TranscriptIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_TranscriptIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration.Transcript = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration_Transcript;
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfigurationIsNull = false;
            }
             // determine if requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration should be set to null
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfigurationIsNull)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration = null;
            }
            if (requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration != null)
            {
                requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category.TypeConfiguration = requestStandardOutputConfiguration_standardOutputConfiguration_Audio_standardOutputConfiguration_Audio_Extraction_standardOutputConfiguration_Audio_Extraction_Category_standardOutputConfiguration_Audio_Extraction_Category_TypeConfiguration;
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
        
        private Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "UpdateDataAutomationProject");
            try
            {
                #if DESKTOP
                return client.UpdateDataAutomationProject(request);
                #elif CORECLR
                return client.UpdateDataAutomationProjectAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockDataAutomation.Model.BlueprintItem> CustomOutputConfiguration_Blueprint { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.BedrockDataAutomation.AudioGenerativeOutputLanguage LanguageConfiguration_GenerativeOutputLanguage { get; set; }
            public System.Boolean? LanguageConfiguration_IdentifyMultipleLanguage { get; set; }
            public List<System.String> LanguageConfiguration_InputLanguage { get; set; }
            public Amazon.BedrockDataAutomation.State OverrideConfiguration_Audio_ModalityProcessing_State { get; set; }
            public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode { get; set; }
            public List<System.String> OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope { get; set; }
            public List<System.String> OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
            public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
            public Amazon.BedrockDataAutomation.State OverrideConfiguration_Document_ModalityProcessing_State { get; set; }
            public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode { get; set; }
            public List<System.String> OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope { get; set; }
            public List<System.String> OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
            public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
            public Amazon.BedrockDataAutomation.State Splitter_State { get; set; }
            public Amazon.BedrockDataAutomation.State OverrideConfiguration_Image_ModalityProcessing_State { get; set; }
            public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode { get; set; }
            public List<System.String> OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope { get; set; }
            public List<System.String> OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
            public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
            public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Jpeg { get; set; }
            public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Mov { get; set; }
            public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Mp4 { get; set; }
            public Amazon.BedrockDataAutomation.DesiredModality ModalityRouting_Png { get; set; }
            public Amazon.BedrockDataAutomation.State OverrideConfiguration_Video_ModalityProcessing_State { get; set; }
            public Amazon.BedrockDataAutomation.SensitiveDataDetectionMode OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode { get; set; }
            public List<System.String> OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope { get; set; }
            public List<System.String> OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes { get; set; }
            public Amazon.BedrockDataAutomation.PIIRedactionMaskMode OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode { get; set; }
            public System.String ProjectArn { get; set; }
            public System.String ProjectDescription { get; set; }
            public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectStage { get; set; }
            public Amazon.BedrockDataAutomation.State StandardOutputConfiguration_Audio_Extraction_Category_State { get; set; }
            public Amazon.BedrockDataAutomation.State ChannelLabeling_State { get; set; }
            public Amazon.BedrockDataAutomation.State SpeakerLabeling_State { get; set; }
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
            public System.Func<Amazon.BedrockDataAutomation.Model.UpdateDataAutomationProjectResponse, UpdateBDADataAutomationProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
