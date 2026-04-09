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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates an existing registry record. This operation uses PATCH semantics, so you only
    /// need to specify the fields you want to change. The update is processed asynchronously
    /// and returns HTTP 202 Accepted.
    /// </summary>
    [Cmdlet("Update", "BACCRegistryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateRegistryRecord API operation.", Operation = new[] {"UpdateRegistryRecord"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse object containing multiple properties."
    )]
    public partial class UpdateBACCRegistryRecordCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>Optional list of credential provider configurations for authenticating with the MCP
        /// server. At most one credential provider configuration can be specified.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfigurations")]
        public Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration[] SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter DescriptorType
        /// <summary>
        /// <para>
        /// <para>The updated descriptor type for the registry record. Changing the descriptor type
        /// may require updating the <c>descriptors</c> field to match the new type's schema requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.DescriptorType")]
        public Amazon.BedrockAgentCoreControl.DescriptorType DescriptorType { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the A2A agent card definition, conforming to the A2A protocol
        /// specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the structured skill definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent
        /// <summary>
        /// <para>
        /// <para>The markdown content describing the agent's skills in a human-readable format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Custom_OptionalValue_InlineContent
        /// <summary>
        /// <para>
        /// <para>The custom descriptor content as a valid JSON document. You can define any custom
        /// schema that describes your resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Custom_OptionalValue_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the MCP server definition, conforming to the MCP protocol
        /// specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the MCP tools definition, conforming to the MCP protocol
        /// specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the registry record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Description_OptionalValue
        /// <summary>
        /// <para>
        /// <para>Represents an optional value that is used to update the human-readable description
        /// of the resource. If not specified, it will clear the current description of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_OptionalValue { get; set; }
        #endregion
        
        #region Parameter SynchronizationType_OptionalValue
        /// <summary>
        /// <para>
        /// <para>The updated synchronization type value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SynchronizationType")]
        public Amazon.BedrockAgentCoreControl.SynchronizationType SynchronizationType_OptionalValue { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The protocol version of the tools definition based on the MCP protocol specification.
        /// If not specified, the version is auto-detected from the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion { get; set; }
        #endregion
        
        #region Parameter RecordId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry record to update. You can specify either the Amazon
        /// Resource Name (ARN) or the ID of the record.</para>
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
        
        #region Parameter RecordVersion
        /// <summary>
        /// <para>
        /// <para>The version of the registry record for optimistic locking. If provided, it must match
        /// the current version of the record. The service automatically increments the version
        /// after a successful update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordVersion { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry containing the record. You can specify either the Amazon
        /// Resource Name (ARN) or the ID of the registry.</para>
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
        
        #region Parameter Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the agent card based on the A2A protocol specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The version of the skill definition schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the server definition based on the MCP protocol specification.
        /// If not specified, the version is auto-detected from the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter TriggerSynchronization
        /// <summary>
        /// <para>
        /// <para>Whether to trigger synchronization using the stored or provided configuration. When
        /// set to <c>true</c>, the service will synchronize the record metadata from the configured
        /// external source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TriggerSynchronization { get; set; }
        #endregion
        
        #region Parameter SynchronizationConfiguration_OptionalValue_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The HTTPS URL of the MCP server to synchronize from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SynchronizationConfiguration_OptionalValue_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCRegistryRecord (UpdateRegistryRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse, UpdateBACCRegistryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description_OptionalValue = this.Description_OptionalValue;
            context.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent = this.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent;
            context.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion = this.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion;
            context.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent = this.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent;
            context.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion = this.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion;
            context.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent = this.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent;
            context.Descriptors_OptionalValue_Custom_OptionalValue_InlineContent = this.Descriptors_OptionalValue_Custom_OptionalValue_InlineContent;
            context.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent = this.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent;
            context.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion = this.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion;
            context.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent = this.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent;
            context.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion = this.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion;
            context.DescriptorType = this.DescriptorType;
            context.Name = this.Name;
            context.RecordId = this.RecordId;
            #if MODULAR
            if (this.RecordId == null && ParameterWasBound(nameof(this.RecordId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordVersion = this.RecordVersion;
            context.RegistryId = this.RegistryId;
            #if MODULAR
            if (this.RegistryId == null && ParameterWasBound(nameof(this.RegistryId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                context.SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration = new List<Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration>(this.SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration);
            }
            context.SynchronizationConfiguration_OptionalValue_FromUrl_Url = this.SynchronizationConfiguration_OptionalValue_FromUrl_Url;
            context.SynchronizationType_OptionalValue = this.SynchronizationType_OptionalValue;
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordRequest();
            
            
             // populate Description
            var requestDescriptionIsNull = true;
            request.Description = new Amazon.BedrockAgentCoreControl.Model.UpdatedDescription();
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
            request.Descriptors = new Amazon.BedrockAgentCoreControl.Model.UpdatedDescriptors();
            Amazon.BedrockAgentCoreControl.Model.UpdatedDescriptorsUnion requestDescriptors_descriptors_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.UpdatedDescriptorsUnion();
            Amazon.BedrockAgentCoreControl.Model.UpdatedA2aDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a = null;
            
             // populate A2a
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a = new Amazon.BedrockAgentCoreControl.Model.UpdatedA2aDescriptor();
            Amazon.BedrockAgentCoreControl.Model.A2aDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.A2aDescriptor();
            Amazon.BedrockAgentCoreControl.Model.AgentCardDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard = null;
            
             // populate AgentCard
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCardIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard = new Amazon.BedrockAgentCoreControl.Model.AgentCardDefinition();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent = null;
            if (cmdletContext.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent = cmdletContext.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard.InlineContent = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCardIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion = null;
            if (cmdletContext.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion = cmdletContext.Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard.SchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCardIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCardIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue.AgentCard = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue_descriptors_OptionalValue_A2a_OptionalValue_AgentCard;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a_descriptors_OptionalValue_A2a_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2aIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a != null)
            {
                requestDescriptors_descriptors_OptionalValue.A2a = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_A2a;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.UpdatedAgentSkillsDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills = null;
            
             // populate AgentSkills
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills = new Amazon.BedrockAgentCoreControl.Model.UpdatedAgentSkillsDescriptor();
            Amazon.BedrockAgentCoreControl.Model.UpdatedAgentSkillsDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.UpdatedAgentSkillsDescriptorFields();
            Amazon.BedrockAgentCoreControl.Model.UpdatedSkillDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition = null;
            
             // populate SkillDefinition
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinitionIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition = new Amazon.BedrockAgentCoreControl.Model.UpdatedSkillDefinition();
            Amazon.BedrockAgentCoreControl.Model.SkillDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.SkillDefinition();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent = cmdletContext.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue.InlineContent = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValueIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion = cmdletContext.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue.SchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinitionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinitionIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue.SkillDefinition = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValueIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.UpdatedSkillMdDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd = null;
            
             // populate SkillMd
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMdIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd = new Amazon.BedrockAgentCoreControl.Model.UpdatedSkillMdDefinition();
            Amazon.BedrockAgentCoreControl.Model.SkillMdDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.SkillMdDefinition();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent = null;
            if (cmdletContext.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent = cmdletContext.Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue.InlineContent = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMdIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMdIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue.SkillMd = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue_descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills_descriptors_OptionalValue_AgentSkills_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkillsIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills != null)
            {
                requestDescriptors_descriptors_OptionalValue.AgentSkills = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_AgentSkills;
                requestDescriptors_descriptors_OptionalValueIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.UpdatedCustomDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom = null;
            
             // populate Custom
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_CustomIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom = new Amazon.BedrockAgentCoreControl.Model.UpdatedCustomDescriptor();
            Amazon.BedrockAgentCoreControl.Model.CustomDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.CustomDescriptor();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_InlineContent = null;
            if (cmdletContext.Descriptors_OptionalValue_Custom_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_InlineContent = cmdletContext.Descriptors_OptionalValue_Custom_OptionalValue_InlineContent;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue.InlineContent = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Custom_descriptors_OptionalValue_Custom_OptionalValue_descriptors_OptionalValue_Custom_OptionalValue_InlineContent;
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
            Amazon.BedrockAgentCoreControl.Model.UpdatedMcpDescriptor requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp = null;
            
             // populate Mcp
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp = new Amazon.BedrockAgentCoreControl.Model.UpdatedMcpDescriptor();
            Amazon.BedrockAgentCoreControl.Model.UpdatedMcpDescriptorFields requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.UpdatedMcpDescriptorFields();
            Amazon.BedrockAgentCoreControl.Model.UpdatedServerDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server = null;
            
             // populate Server
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_ServerIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server = new Amazon.BedrockAgentCoreControl.Model.UpdatedServerDefinition();
            Amazon.BedrockAgentCoreControl.Model.ServerDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.ServerDefinition();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent = null;
            if (cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent = cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue.InlineContent = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValueIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion = null;
            if (cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion = cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue.SchemaVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server_descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_ServerIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_ServerIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue.Server = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Server;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValueIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.UpdatedToolsDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools = null;
            
             // populate Tools
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_ToolsIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools = new Amazon.BedrockAgentCoreControl.Model.UpdatedToolsDefinition();
            Amazon.BedrockAgentCoreControl.Model.ToolsDefinition requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue = null;
            
             // populate OptionalValue
            var requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValueIsNull = true;
            requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.ToolsDefinition();
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent = null;
            if (cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent = cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue.InlineContent = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValueIsNull = false;
            }
            System.String requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion = null;
            if (cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion = cmdletContext.Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue.ProtocolVersion = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools_descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_ToolsIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_ToolsIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue.Tools = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue_descriptors_OptionalValue_Mcp_OptionalValue_Tools;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValueIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValueIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue != null)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp.OptionalValue = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp_descriptors_OptionalValue_Mcp_OptionalValue;
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpIsNull = false;
            }
             // determine if requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp should be set to null
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_McpIsNull)
            {
                requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp = null;
            }
            if (requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp != null)
            {
                requestDescriptors_descriptors_OptionalValue.Mcp = requestDescriptors_descriptors_OptionalValue_descriptors_OptionalValue_Mcp;
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
            if (cmdletContext.DescriptorType != null)
            {
                request.DescriptorType = cmdletContext.DescriptorType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RecordId != null)
            {
                request.RecordId = cmdletContext.RecordId;
            }
            if (cmdletContext.RecordVersion != null)
            {
                request.RecordVersion = cmdletContext.RecordVersion;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            
             // populate SynchronizationConfiguration
            var requestSynchronizationConfigurationIsNull = true;
            request.SynchronizationConfiguration = new Amazon.BedrockAgentCoreControl.Model.UpdatedSynchronizationConfiguration();
            Amazon.BedrockAgentCoreControl.Model.SynchronizationConfiguration requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue = null;
            
             // populate OptionalValue
            var requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValueIsNull = true;
            requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue = new Amazon.BedrockAgentCoreControl.Model.SynchronizationConfiguration();
            Amazon.BedrockAgentCoreControl.Model.FromUrlSynchronizationConfiguration requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl = null;
            
             // populate FromUrl
            var requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrlIsNull = true;
            requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl = new Amazon.BedrockAgentCoreControl.Model.FromUrlSynchronizationConfiguration();
            List<Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration> requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration = cmdletContext.SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl.CredentialProviderConfigurations = requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration;
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrlIsNull = false;
            }
            System.String requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_Url = null;
            if (cmdletContext.SynchronizationConfiguration_OptionalValue_FromUrl_Url != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_Url = cmdletContext.SynchronizationConfiguration_OptionalValue_FromUrl_Url;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_Url != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl.Url = requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl_synchronizationConfiguration_OptionalValue_FromUrl_Url;
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrlIsNull = false;
            }
             // determine if requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl should be set to null
            if (requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrlIsNull)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl = null;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue.FromUrl = requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue_synchronizationConfiguration_OptionalValue_FromUrl;
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValueIsNull = false;
            }
             // determine if requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue should be set to null
            if (requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValueIsNull)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue = null;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue != null)
            {
                request.SynchronizationConfiguration.OptionalValue = requestSynchronizationConfiguration_synchronizationConfiguration_OptionalValue;
                requestSynchronizationConfigurationIsNull = false;
            }
             // determine if request.SynchronizationConfiguration should be set to null
            if (requestSynchronizationConfigurationIsNull)
            {
                request.SynchronizationConfiguration = null;
            }
            
             // populate SynchronizationType
            var requestSynchronizationTypeIsNull = true;
            request.SynchronizationType = new Amazon.BedrockAgentCoreControl.Model.UpdatedSynchronizationType();
            Amazon.BedrockAgentCoreControl.SynchronizationType requestSynchronizationType_synchronizationType_OptionalValue = null;
            if (cmdletContext.SynchronizationType_OptionalValue != null)
            {
                requestSynchronizationType_synchronizationType_OptionalValue = cmdletContext.SynchronizationType_OptionalValue;
            }
            if (requestSynchronizationType_synchronizationType_OptionalValue != null)
            {
                request.SynchronizationType.OptionalValue = requestSynchronizationType_synchronizationType_OptionalValue;
                requestSynchronizationTypeIsNull = false;
            }
             // determine if request.SynchronizationType should be set to null
            if (requestSynchronizationTypeIsNull)
            {
                request.SynchronizationType = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateRegistryRecord");
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
            public System.String Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_InlineContent { get; set; }
            public System.String Descriptors_OptionalValue_A2a_OptionalValue_AgentCard_SchemaVersion { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_InlineContent { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillDefinition_OptionalValue_SchemaVersion { get; set; }
            public System.String Descriptors_OptionalValue_AgentSkills_OptionalValue_SkillMd_OptionalValue_InlineContent { get; set; }
            public System.String Descriptors_OptionalValue_Custom_OptionalValue_InlineContent { get; set; }
            public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_InlineContent { get; set; }
            public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Server_OptionalValue_SchemaVersion { get; set; }
            public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_InlineContent { get; set; }
            public System.String Descriptors_OptionalValue_Mcp_OptionalValue_Tools_OptionalValue_ProtocolVersion { get; set; }
            public Amazon.BedrockAgentCoreControl.DescriptorType DescriptorType { get; set; }
            public System.String Name { get; set; }
            public System.String RecordId { get; set; }
            public System.String RecordVersion { get; set; }
            public System.String RegistryId { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration> SynchronizationConfiguration_OptionalValue_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String SynchronizationConfiguration_OptionalValue_FromUrl_Url { get; set; }
            public Amazon.BedrockAgentCoreControl.SynchronizationType SynchronizationType_OptionalValue { get; set; }
            public System.Boolean? TriggerSynchronization { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateRegistryRecordResponse, UpdateBACCRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
