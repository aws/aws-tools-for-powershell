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
using Amazon.AgentRegistryControl;
using Amazon.AgentRegistryControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AGRC
{
    /// <summary>
    /// Updates a registry record. The update is asynchronous: the record is returned with
    /// the UPDATING status while it is processed. Fields that use update wrappers follow
    /// PATCH semantics: omit the field to leave it unchanged.
    /// </summary>
    [Cmdlet("Update", "AGRCRegistryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse")]
    [AWSCmdlet("Calls the Agent Registry Control UpdateRegistryRecord API operation.", Operation = new[] {"UpdateRegistryRecord"}, SelectReturnType = typeof(Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse))]
    [AWSCmdletOutput("Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse",
        "This cmdlet returns an Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse object containing multiple properties."
    )]
    public partial class UpdateAGRCRegistryRecordCmdlet : AmazonAgentRegistryControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the registry record. Omit to leave the name unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Description_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
        #endregion
        
        #region Parameter DisplayName_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The value to set for this field. Omit the wrapper to leave the field unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Provenance
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AgentRegistryControl.Model.Provenance[] Provenance { get; set; }
        #endregion
        
        #region Parameter RecordId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry record to update (ARN or ID)</para>
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
        public System.String RecordId { get; set; }
        #endregion
        
        #region Parameter RecordType
        /// <summary>
        /// <para>
        /// <para>The updated type of the registry record. Omit to leave the record type unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.RecordType")]
        public Amazon.AgentRegistryControl.RecordType RecordType { get; set; }
        #endregion
        
        #region Parameter RecordVersion
        /// <summary>
        /// <para>
        /// <para>The updated version of the registry record. Omit to leave the version unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordVersion { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry containing the record (ARN or ID)</para>
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
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter TriggerSynchronization
        /// <summary>
        /// <para>
        /// <para>Whether to trigger synchronization of the record's descriptor content from its source</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TriggerSynchronization { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse).
        /// Specifying the name of a property of type Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.RecordId),
                nameof(this.RegistryId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AGRCRegistryRecord (UpdateRegistryRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse, UpdateAGRCRegistryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description_OptionalValue = this.Description_OptionalValue;
            context.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue = this.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue;
            context.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue = this.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue;
            if (this.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url = this.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url;
            context.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue = this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue;
            context.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue = this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue;
            if (this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url = this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url;
            context.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue = this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue;
            context.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue = this.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue;
            if (this.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url = this.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url;
            context.Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue = this.Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue;
            if (this.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url = this.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url;
            context.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue = this.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue;
            context.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue = this.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue;
            context.Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue = this.Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue;
            context.Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue = this.Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue;
            if (this.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url = this.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url;
            context.DisplayName_OptionalValue = this.DisplayName_OptionalValue;
            context.Name = this.Name;
            if (this.Provenance != null)
            {
                context.Provenance = new List<Amazon.AgentRegistryControl.Model.Provenance>(this.Provenance);
            }
            context.RecordId = this.RecordId;
            #if MODULAR
            if (this.RecordId == null && ParameterWasBound(nameof(this.RecordId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordType = this.RecordType;
            context.RecordVersion = this.RecordVersion;
            context.RegistryId = this.RegistryId;
            #if MODULAR
            if (this.RegistryId == null && ParameterWasBound(nameof(this.RegistryId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TriggerSynchronization = this.TriggerSynchronization;
            
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
            var request = new Amazon.AgentRegistryControl.Model.UpdateRegistryRecordRequest();
            
            
             // populate Description
            var requestDescriptionIsNull = true;
            request.Description = new Amazon.AgentRegistryControl.Model.UpdatedDescription();
            System.String requestDescription_description_OptionalValue = null;
            if (cmdletContext.Description_OptionalValue != null)
            {
                requestDescription_description_OptionalValue = cmdletContext.Description_OptionalValue;
            }
            if (requestDescription_description_OptionalValue != null)
            {
                request.Description.OptionalValue = requestDescription_description_OptionalValue;
                requestDescriptionIsNull = false;
            }
             // determine if request.Description should be set to null
            if (requestDescriptionIsNull)
            {
                request.Description = null;
            }
            
             // populate Descriptors
            var requestDescriptorsIsNull = true;
            request.Descriptors = new Amazon.AgentRegistryControl.Model.UpdatedDescriptors();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorsFields requestDescriptors_descriptors_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorsFields();
            Amazon.AgentRegistryControl.Model.UpdatedA2aAgentCardDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard = null;
            
             // populate A2aAgentCard
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCardIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard = new Amazon.AgentRegistryControl.Model.UpdatedA2aAgentCardDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedA2aAgentCardDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedA2aAgentCardDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data = null;
            
             // populate Data
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorData();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue = cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue.Data = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion = null;
            
             // populate DataSchemaVersion
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion = new Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue = cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue.DataSchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source = null;
            
             // populate Source
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_SourceIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue = new Amazon.AgentRegistryControl.Model.DescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl = null;
            
             // populate FromUrl
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrlIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
            List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url = null;
            if (cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url = cmdletContext.Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl.Url = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrlIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue.FromUrl = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_SourceIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_SourceIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue.Source = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue_descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard_descriptors_OptionalValue_A2aAgentCard_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCardIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCardIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard != null)
            {
                requestDescriptors_descriptors_OptionalValue.A2aAgentCard = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aAgentCard;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsDefinitionDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition = null;
            
             // populate AgentSkillsDefinition
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinitionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition = new Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsDefinitionDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsDefinitionDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsDefinitionDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsAdditionalData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData = null;
            
             // populate AdditionalData
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalDataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData = new Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsAdditionalData();
            Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsAdditionalDataFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsAdditionalDataFields();
            Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsMdDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd = null;
            
             // populate SkillMd
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMdIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd = new Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsMdDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsMdDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedAgentSkillsMdDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data = null;
            
             // populate Data
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorData();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue = cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue.Data = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion = null;
            
             // populate DataSchemaVersion
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion = new Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue = cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue.DataSchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source = null;
            
             // populate Source
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_SourceIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue = new Amazon.AgentRegistryControl.Model.DescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl = null;
            
             // populate FromUrl
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrlIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
            List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url = cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl.Url = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrlIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue.FromUrl = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_SourceIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_SourceIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue.Source = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMdIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMdIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue.SkillMd = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalDataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalDataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue.AdditionalData = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data = null;
            
             // populate Data
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorData();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue = cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue.Data = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion = null;
            
             // populate DataSchemaVersion
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion = new Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue = cmdletContext.Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue.DataSchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition_descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinitionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinitionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition != null)
            {
                requestDescriptors_descriptors_OptionalValue.AgentSkillsDefinition = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsDefinition;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedAgUiDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui = null;
            
             // populate Agui
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AguiIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui = new Amazon.AgentRegistryControl.Model.UpdatedAgUiDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedAgUiDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedAgUiDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source = null;
            
             // populate Source
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_SourceIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue = new Amazon.AgentRegistryControl.Model.DescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl = null;
            
             // populate FromUrl
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrlIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
            List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url = null;
            if (cmdletContext.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url = cmdletContext.Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl.Url = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrlIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue.FromUrl = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source_descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_SourceIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_SourceIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue.Source = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue_descriptors_OptionalValue_Agui_OptionalValue_Source;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui_descriptors_OptionalValue_Agui_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AguiIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AguiIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui != null)
            {
                requestDescriptors_descriptors_OptionalValue.Agui = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Agui;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedCustomDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom = null;
            
             // populate Custom
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_CustomIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom = new Amazon.AgentRegistryControl.Model.UpdatedCustomDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedCustomDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedCustomDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data = null;
            
             // populate Data
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_DataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorData();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data_descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data_descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue = cmdletContext.Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data_descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data_descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_DataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_DataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue.Data = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_Data;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_CustomIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_CustomIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom != null)
            {
                requestDescriptors_descriptors_OptionalValue.Custom = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedHttpDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http = null;
            
             // populate Http
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_HttpIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http = new Amazon.AgentRegistryControl.Model.UpdatedHttpDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedHttpDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedHttpDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source = null;
            
             // populate Source
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_SourceIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue = new Amazon.AgentRegistryControl.Model.DescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl = null;
            
             // populate FromUrl
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrlIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
            List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url = null;
            if (cmdletContext.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url = cmdletContext.Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl.Url = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrlIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue.FromUrl = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source_descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_SourceIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_SourceIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue.Source = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue_descriptors_OptionalValue_Http_OptionalValue_Source;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http_descriptors_OptionalValue_Http_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_HttpIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_HttpIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http != null)
            {
                requestDescriptors_descriptors_OptionalValue.Http = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Http;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedMcpServerDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer = null;
            
             // populate McpServer
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServerIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer = new Amazon.AgentRegistryControl.Model.UpdatedMcpServerDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedMcpServerDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedMcpServerDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedMcpServerAdditionalData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData = null;
            
             // populate AdditionalData
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalDataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData = new Amazon.AgentRegistryControl.Model.UpdatedMcpServerAdditionalData();
            Amazon.AgentRegistryControl.Model.UpdatedMcpServerAdditionalDataFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedMcpServerAdditionalDataFields();
            Amazon.AgentRegistryControl.Model.UpdatedMcpToolsDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools = null;
            
             // populate Tools
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_ToolsIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools = new Amazon.AgentRegistryControl.Model.UpdatedMcpToolsDescriptor();
            Amazon.AgentRegistryControl.Model.UpdatedMcpToolsDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue = new Amazon.AgentRegistryControl.Model.UpdatedMcpToolsDescriptorFields();
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data = null;
            
             // populate Data
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorData();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue = cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue.Data = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion = null;
            
             // populate DataSchemaVersion
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion = new Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue = cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue.DataSchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_ToolsIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_ToolsIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue.Tools = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalDataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalDataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue.AdditionalData = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorData requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data = null;
            
             // populate Data
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorData();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue = cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data_descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue.Data = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Data;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion = null;
            
             // populate DataSchemaVersion
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion = new Amazon.AgentRegistryControl.Model.UpdatedDataSchemaVersion();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue = null;
            if (cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue = cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue.DataSchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValueIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source = null;
            
             // populate Source
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_SourceIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source = new Amazon.AgentRegistryControl.Model.UpdatedDescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue = new Amazon.AgentRegistryControl.Model.DescriptorSource();
            Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl = null;
            
             // populate FromUrl
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrlIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
            List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url = null;
            if (cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url = cmdletContext.Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl.Url = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrlIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrlIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue.FromUrl = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source_descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_SourceIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_SourceIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue.Source = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue_descriptors_OptionalValue_McpServer_OptionalValue_Source;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer_descriptors_OptionalValue_McpServer_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServerIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServerIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer != null)
            {
                requestDescriptors_descriptors_OptionalValue.McpServer = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpServer;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue != null)
            {
                request.Descriptors.OptionalValue = requestDescriptors_descriptors_OptionalValue;
                requestDescriptorsIsNull = false;
            }
             // determine if request.Descriptors should be set to null
            if (requestDescriptorsIsNull)
            {
                request.Descriptors = null;
            }
            
             // populate DisplayName
            var requestDisplayNameIsNull = true;
            request.DisplayName = new Amazon.AgentRegistryControl.Model.UpdatedDisplayName();
            System.String requestDisplayName_displayName_OptionalValue = null;
            if (cmdletContext.DisplayName_OptionalValue != null)
            {
                requestDisplayName_displayName_OptionalValue = cmdletContext.DisplayName_OptionalValue;
            }
            if (requestDisplayName_displayName_OptionalValue != null)
            {
                request.DisplayName.OptionalValue = requestDisplayName_displayName_OptionalValue;
                requestDisplayNameIsNull = false;
            }
             // determine if request.DisplayName should be set to null
            if (requestDisplayNameIsNull)
            {
                request.DisplayName = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Provenance != null)
            {
                request.Provenance = cmdletContext.Provenance;
            }
            if (cmdletContext.RecordId != null)
            {
                request.RecordId = cmdletContext.RecordId;
            }
            if (cmdletContext.RecordType != null)
            {
                request.RecordType = cmdletContext.RecordType;
            }
            if (cmdletContext.RecordVersion != null)
            {
                request.RecordVersion = cmdletContext.RecordVersion;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.TriggerSynchronization != null)
            {
                request.TriggerSynchronization = cmdletContext.TriggerSynchronization.Value;
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
        
        private Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse CallAWSServiceOperation(IAmazonAgentRegistryControl client, Amazon.AgentRegistryControl.Model.UpdateRegistryRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry Control", "UpdateRegistryRecord");
            try
            {
                return client.UpdateRegistryRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Data_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_A2aAgentCard_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_OptionalValue_A2aAgentCard_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Data_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_SkillMd_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_Data_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_OptionalValue_Agui_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
            public System.String Descriptors_OptionalValue_Custom_OptionalValue_Data_OptionalValue { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_OptionalValue_Http_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
            public System.String Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_Data_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_McpServer_OptionalValue_AdditionalData_OptionalValue_Tools_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_McpServer_OptionalValue_Data_OptionalValue { get; set; }
            public System.String Descriptors_OptionalValue_McpServer_OptionalValue_DataSchemaVersion_OptionalValue { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_OptionalValue_McpServer_OptionalValue_Source_OptionalValue_FromUrl_Url { get; set; }
            public System.String DisplayName_OptionalValue { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.AgentRegistryControl.Model.Provenance> Provenance { get; set; }
            public System.String RecordId { get; set; }
            public Amazon.AgentRegistryControl.RecordType RecordType { get; set; }
            public System.String RecordVersion { get; set; }
            public System.String RegistryId { get; set; }
            public System.Boolean? TriggerSynchronization { get; set; }
            public System.Func<Amazon.AgentRegistryControl.Model.UpdateRegistryRecordResponse, UpdateAGRCRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
