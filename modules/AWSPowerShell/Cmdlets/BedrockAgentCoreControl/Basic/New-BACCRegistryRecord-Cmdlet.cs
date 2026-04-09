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
    /// Creates a new registry record within the specified registry. A registry record represents
    /// an individual AI resource's metadata in the registry. This could be an MCP server
    /// (and associated tools), A2A agent, agent skill, or a custom resource with a custom
    /// schema.
    /// 
    ///  
    /// <para>
    /// The record is processed asynchronously and returns HTTP 202 Accepted.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BACCRegistryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateRegistryRecord API operation.", Operation = new[] {"CreateRegistryRecord"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse object containing multiple properties."
    )]
    public partial class NewBACCRegistryRecordCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration
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
        [Alias("SynchronizationConfiguration_FromUrl_CredentialProviderConfigurations")]
        public Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration[] SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the registry record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DescriptorType
        /// <summary>
        /// <para>
        /// <para>The descriptor type of the registry record.</para><ul><li><para><c>MCP</c> - Model Context Protocol descriptor for MCP-compatible servers and tools.</para></li><li><para><c>A2A</c> - Agent-to-Agent protocol descriptor.</para></li><li><para><c>CUSTOM</c> - Custom descriptor type for resources such as APIs, Lambda functions,
        /// or servers not conforming to a standard protocol.</para></li><li><para><c>AGENT_SKILLS</c> - Agent skills descriptor for defining agent skill definitions.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.DescriptorType")]
        public Amazon.BedrockAgentCoreControl.DescriptorType DescriptorType { get; set; }
        #endregion
        
        #region Parameter Descriptors_A2a_AgentCard_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the A2A agent card definition, conforming to the A2A protocol
        /// specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_A2a_AgentCard_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkills_SkillDefinition_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the structured skill definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkills_SkillDefinition_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkills_SkillMd_InlineContent
        /// <summary>
        /// <para>
        /// <para>The markdown content describing the agent's skills in a human-readable format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkills_SkillMd_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_Custom_InlineContent
        /// <summary>
        /// <para>
        /// <para>The custom descriptor content as a valid JSON document. You can define any custom
        /// schema that describes your resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Custom_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_Mcp_Server_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the MCP server definition, conforming to the MCP protocol
        /// specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Mcp_Server_InlineContent { get; set; }
        #endregion
        
        #region Parameter Descriptors_Mcp_Tools_InlineContent
        /// <summary>
        /// <para>
        /// <para>The JSON content containing the MCP tools definition, conforming to the MCP protocol
        /// specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Mcp_Tools_InlineContent { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the registry record.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Descriptors_Mcp_Tools_ProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The protocol version of the tools definition based on the MCP protocol specification.
        /// If not specified, the version is auto-detected from the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Mcp_Tools_ProtocolVersion { get; set; }
        #endregion
        
        #region Parameter RecordVersion
        /// <summary>
        /// <para>
        /// <para>The version of the registry record. Use this to track different versions of the record's
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordVersion { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry where the record will be created. You can specify either
        /// the Amazon Resource Name (ARN) or the ID of the registry.</para>
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
        
        #region Parameter Descriptors_A2a_AgentCard_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the agent card based on the A2A protocol specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_A2a_AgentCard_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkills_SkillDefinition_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The version of the skill definition schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkills_SkillDefinition_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_Mcp_Server_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the server definition based on the MCP protocol specification.
        /// If not specified, the version is auto-detected from the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Mcp_Server_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter SynchronizationType
        /// <summary>
        /// <para>
        /// <para>The type of synchronization to use for keeping the record metadata up to date from
        /// an external source. Possible values include <c>FROM_URL</c> and <c>NONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SynchronizationType")]
        public Amazon.BedrockAgentCoreControl.SynchronizationType SynchronizationType { get; set; }
        #endregion
        
        #region Parameter SynchronizationConfiguration_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The HTTPS URL of the MCP server to synchronize from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SynchronizationConfiguration_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse will result in that property being returned.
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
                nameof(this.RegistryId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCRegistryRecord (CreateRegistryRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse, NewBACCRegistryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Descriptors_A2a_AgentCard_InlineContent = this.Descriptors_A2a_AgentCard_InlineContent;
            context.Descriptors_A2a_AgentCard_SchemaVersion = this.Descriptors_A2a_AgentCard_SchemaVersion;
            context.Descriptors_AgentSkills_SkillDefinition_InlineContent = this.Descriptors_AgentSkills_SkillDefinition_InlineContent;
            context.Descriptors_AgentSkills_SkillDefinition_SchemaVersion = this.Descriptors_AgentSkills_SkillDefinition_SchemaVersion;
            context.Descriptors_AgentSkills_SkillMd_InlineContent = this.Descriptors_AgentSkills_SkillMd_InlineContent;
            context.Descriptors_Custom_InlineContent = this.Descriptors_Custom_InlineContent;
            context.Descriptors_Mcp_Server_InlineContent = this.Descriptors_Mcp_Server_InlineContent;
            context.Descriptors_Mcp_Server_SchemaVersion = this.Descriptors_Mcp_Server_SchemaVersion;
            context.Descriptors_Mcp_Tools_InlineContent = this.Descriptors_Mcp_Tools_InlineContent;
            context.Descriptors_Mcp_Tools_ProtocolVersion = this.Descriptors_Mcp_Tools_ProtocolVersion;
            context.DescriptorType = this.DescriptorType;
            #if MODULAR
            if (this.DescriptorType == null && ParameterWasBound(nameof(this.DescriptorType)))
            {
                WriteWarning("You are passing $null as a value for parameter DescriptorType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration != null)
            {
                context.SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration = new List<Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration>(this.SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration);
            }
            context.SynchronizationConfiguration_FromUrl_Url = this.SynchronizationConfiguration_FromUrl_Url;
            context.SynchronizationType = this.SynchronizationType;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Descriptors
            var requestDescriptorsIsNull = true;
            request.Descriptors = new Amazon.BedrockAgentCoreControl.Model.Descriptors();
            Amazon.BedrockAgentCoreControl.Model.A2aDescriptor requestDescriptors_descriptors_A2a = null;
            
             // populate A2a
            var requestDescriptors_descriptors_A2aIsNull = true;
            requestDescriptors_descriptors_A2a = new Amazon.BedrockAgentCoreControl.Model.A2aDescriptor();
            Amazon.BedrockAgentCoreControl.Model.AgentCardDefinition requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard = null;
            
             // populate AgentCard
            var requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCardIsNull = true;
            requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard = new Amazon.BedrockAgentCoreControl.Model.AgentCardDefinition();
            System.String requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_InlineContent = null;
            if (cmdletContext.Descriptors_A2a_AgentCard_InlineContent != null)
            {
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_InlineContent = cmdletContext.Descriptors_A2a_AgentCard_InlineContent;
            }
            if (requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_InlineContent != null)
            {
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard.InlineContent = requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_InlineContent;
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCardIsNull = false;
            }
            System.String requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_SchemaVersion = null;
            if (cmdletContext.Descriptors_A2a_AgentCard_SchemaVersion != null)
            {
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_SchemaVersion = cmdletContext.Descriptors_A2a_AgentCard_SchemaVersion;
            }
            if (requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_SchemaVersion != null)
            {
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard.SchemaVersion = requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard_descriptors_A2a_AgentCard_SchemaVersion;
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCardIsNull = false;
            }
             // determine if requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard should be set to null
            if (requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCardIsNull)
            {
                requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard = null;
            }
            if (requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard != null)
            {
                requestDescriptors_descriptors_A2a.AgentCard = requestDescriptors_descriptors_A2a_descriptors_A2a_AgentCard;
                requestDescriptors_descriptors_A2aIsNull = false;
            }
             // determine if requestDescriptors_descriptors_A2a should be set to null
            if (requestDescriptors_descriptors_A2aIsNull)
            {
                requestDescriptors_descriptors_A2a = null;
            }
            if (requestDescriptors_descriptors_A2a != null)
            {
                request.Descriptors.A2a = requestDescriptors_descriptors_A2a;
                requestDescriptorsIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.CustomDescriptor requestDescriptors_descriptors_Custom = null;
            
             // populate Custom
            var requestDescriptors_descriptors_CustomIsNull = true;
            requestDescriptors_descriptors_Custom = new Amazon.BedrockAgentCoreControl.Model.CustomDescriptor();
            System.String requestDescriptors_descriptors_Custom_descriptors_Custom_InlineContent = null;
            if (cmdletContext.Descriptors_Custom_InlineContent != null)
            {
                requestDescriptors_descriptors_Custom_descriptors_Custom_InlineContent = cmdletContext.Descriptors_Custom_InlineContent;
            }
            if (requestDescriptors_descriptors_Custom_descriptors_Custom_InlineContent != null)
            {
                requestDescriptors_descriptors_Custom.InlineContent = requestDescriptors_descriptors_Custom_descriptors_Custom_InlineContent;
                requestDescriptors_descriptors_CustomIsNull = false;
            }
             // determine if requestDescriptors_descriptors_Custom should be set to null
            if (requestDescriptors_descriptors_CustomIsNull)
            {
                requestDescriptors_descriptors_Custom = null;
            }
            if (requestDescriptors_descriptors_Custom != null)
            {
                request.Descriptors.Custom = requestDescriptors_descriptors_Custom;
                requestDescriptorsIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.AgentSkillsDescriptor requestDescriptors_descriptors_AgentSkills = null;
            
             // populate AgentSkills
            var requestDescriptors_descriptors_AgentSkillsIsNull = true;
            requestDescriptors_descriptors_AgentSkills = new Amazon.BedrockAgentCoreControl.Model.AgentSkillsDescriptor();
            Amazon.BedrockAgentCoreControl.Model.SkillMdDefinition requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd = null;
            
             // populate SkillMd
            var requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMdIsNull = true;
            requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd = new Amazon.BedrockAgentCoreControl.Model.SkillMdDefinition();
            System.String requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd_descriptors_AgentSkills_SkillMd_InlineContent = null;
            if (cmdletContext.Descriptors_AgentSkills_SkillMd_InlineContent != null)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd_descriptors_AgentSkills_SkillMd_InlineContent = cmdletContext.Descriptors_AgentSkills_SkillMd_InlineContent;
            }
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd_descriptors_AgentSkills_SkillMd_InlineContent != null)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd.InlineContent = requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd_descriptors_AgentSkills_SkillMd_InlineContent;
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMdIsNull = false;
            }
             // determine if requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd should be set to null
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMdIsNull)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd = null;
            }
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd != null)
            {
                requestDescriptors_descriptors_AgentSkills.SkillMd = requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillMd;
                requestDescriptors_descriptors_AgentSkillsIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SkillDefinition requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition = null;
            
             // populate SkillDefinition
            var requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinitionIsNull = true;
            requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition = new Amazon.BedrockAgentCoreControl.Model.SkillDefinition();
            System.String requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_InlineContent = null;
            if (cmdletContext.Descriptors_AgentSkills_SkillDefinition_InlineContent != null)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_InlineContent = cmdletContext.Descriptors_AgentSkills_SkillDefinition_InlineContent;
            }
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_InlineContent != null)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition.InlineContent = requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_InlineContent;
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinitionIsNull = false;
            }
            System.String requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_SchemaVersion = null;
            if (cmdletContext.Descriptors_AgentSkills_SkillDefinition_SchemaVersion != null)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_SchemaVersion = cmdletContext.Descriptors_AgentSkills_SkillDefinition_SchemaVersion;
            }
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_SchemaVersion != null)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition.SchemaVersion = requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition_descriptors_AgentSkills_SkillDefinition_SchemaVersion;
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinitionIsNull = false;
            }
             // determine if requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition should be set to null
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinitionIsNull)
            {
                requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition = null;
            }
            if (requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition != null)
            {
                requestDescriptors_descriptors_AgentSkills.SkillDefinition = requestDescriptors_descriptors_AgentSkills_descriptors_AgentSkills_SkillDefinition;
                requestDescriptors_descriptors_AgentSkillsIsNull = false;
            }
             // determine if requestDescriptors_descriptors_AgentSkills should be set to null
            if (requestDescriptors_descriptors_AgentSkillsIsNull)
            {
                requestDescriptors_descriptors_AgentSkills = null;
            }
            if (requestDescriptors_descriptors_AgentSkills != null)
            {
                request.Descriptors.AgentSkills = requestDescriptors_descriptors_AgentSkills;
                requestDescriptorsIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.McpDescriptor requestDescriptors_descriptors_Mcp = null;
            
             // populate Mcp
            var requestDescriptors_descriptors_McpIsNull = true;
            requestDescriptors_descriptors_Mcp = new Amazon.BedrockAgentCoreControl.Model.McpDescriptor();
            Amazon.BedrockAgentCoreControl.Model.ServerDefinition requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server = null;
            
             // populate Server
            var requestDescriptors_descriptors_Mcp_descriptors_Mcp_ServerIsNull = true;
            requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server = new Amazon.BedrockAgentCoreControl.Model.ServerDefinition();
            System.String requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_InlineContent = null;
            if (cmdletContext.Descriptors_Mcp_Server_InlineContent != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_InlineContent = cmdletContext.Descriptors_Mcp_Server_InlineContent;
            }
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_InlineContent != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server.InlineContent = requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_InlineContent;
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_ServerIsNull = false;
            }
            System.String requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_SchemaVersion = null;
            if (cmdletContext.Descriptors_Mcp_Server_SchemaVersion != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_SchemaVersion = cmdletContext.Descriptors_Mcp_Server_SchemaVersion;
            }
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_SchemaVersion != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server.SchemaVersion = requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server_descriptors_Mcp_Server_SchemaVersion;
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_ServerIsNull = false;
            }
             // determine if requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server should be set to null
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_ServerIsNull)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server = null;
            }
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server != null)
            {
                requestDescriptors_descriptors_Mcp.Server = requestDescriptors_descriptors_Mcp_descriptors_Mcp_Server;
                requestDescriptors_descriptors_McpIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ToolsDefinition requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools = null;
            
             // populate Tools
            var requestDescriptors_descriptors_Mcp_descriptors_Mcp_ToolsIsNull = true;
            requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools = new Amazon.BedrockAgentCoreControl.Model.ToolsDefinition();
            System.String requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_InlineContent = null;
            if (cmdletContext.Descriptors_Mcp_Tools_InlineContent != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_InlineContent = cmdletContext.Descriptors_Mcp_Tools_InlineContent;
            }
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_InlineContent != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools.InlineContent = requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_InlineContent;
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_ToolsIsNull = false;
            }
            System.String requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_ProtocolVersion = null;
            if (cmdletContext.Descriptors_Mcp_Tools_ProtocolVersion != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_ProtocolVersion = cmdletContext.Descriptors_Mcp_Tools_ProtocolVersion;
            }
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_ProtocolVersion != null)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools.ProtocolVersion = requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools_descriptors_Mcp_Tools_ProtocolVersion;
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_ToolsIsNull = false;
            }
             // determine if requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools should be set to null
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_ToolsIsNull)
            {
                requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools = null;
            }
            if (requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools != null)
            {
                requestDescriptors_descriptors_Mcp.Tools = requestDescriptors_descriptors_Mcp_descriptors_Mcp_Tools;
                requestDescriptors_descriptors_McpIsNull = false;
            }
             // determine if requestDescriptors_descriptors_Mcp should be set to null
            if (requestDescriptors_descriptors_McpIsNull)
            {
                requestDescriptors_descriptors_Mcp = null;
            }
            if (requestDescriptors_descriptors_Mcp != null)
            {
                request.Descriptors.Mcp = requestDescriptors_descriptors_Mcp;
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
            request.SynchronizationConfiguration = new Amazon.BedrockAgentCoreControl.Model.SynchronizationConfiguration();
            Amazon.BedrockAgentCoreControl.Model.FromUrlSynchronizationConfiguration requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl = null;
            
             // populate FromUrl
            var requestSynchronizationConfiguration_synchronizationConfiguration_FromUrlIsNull = true;
            requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl = new Amazon.BedrockAgentCoreControl.Model.FromUrlSynchronizationConfiguration();
            List<Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration> requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_CredentialProviderConfiguration = null;
            if (cmdletContext.SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_CredentialProviderConfiguration = cmdletContext.SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_CredentialProviderConfiguration != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl.CredentialProviderConfigurations = requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_CredentialProviderConfiguration;
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrlIsNull = false;
            }
            System.String requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_Url = null;
            if (cmdletContext.SynchronizationConfiguration_FromUrl_Url != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_Url = cmdletContext.SynchronizationConfiguration_FromUrl_Url;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_Url != null)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl.Url = requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl_synchronizationConfiguration_FromUrl_Url;
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrlIsNull = false;
            }
             // determine if requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl should be set to null
            if (requestSynchronizationConfiguration_synchronizationConfiguration_FromUrlIsNull)
            {
                requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl = null;
            }
            if (requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl != null)
            {
                request.SynchronizationConfiguration.FromUrl = requestSynchronizationConfiguration_synchronizationConfiguration_FromUrl;
                requestSynchronizationConfigurationIsNull = false;
            }
             // determine if request.SynchronizationConfiguration should be set to null
            if (requestSynchronizationConfigurationIsNull)
            {
                request.SynchronizationConfiguration = null;
            }
            if (cmdletContext.SynchronizationType != null)
            {
                request.SynchronizationType = cmdletContext.SynchronizationType;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateRegistryRecord");
            try
            {
                return client.CreateRegistryRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Descriptors_A2a_AgentCard_InlineContent { get; set; }
            public System.String Descriptors_A2a_AgentCard_SchemaVersion { get; set; }
            public System.String Descriptors_AgentSkills_SkillDefinition_InlineContent { get; set; }
            public System.String Descriptors_AgentSkills_SkillDefinition_SchemaVersion { get; set; }
            public System.String Descriptors_AgentSkills_SkillMd_InlineContent { get; set; }
            public System.String Descriptors_Custom_InlineContent { get; set; }
            public System.String Descriptors_Mcp_Server_InlineContent { get; set; }
            public System.String Descriptors_Mcp_Server_SchemaVersion { get; set; }
            public System.String Descriptors_Mcp_Tools_InlineContent { get; set; }
            public System.String Descriptors_Mcp_Tools_ProtocolVersion { get; set; }
            public Amazon.BedrockAgentCoreControl.DescriptorType DescriptorType { get; set; }
            public System.String Name { get; set; }
            public System.String RecordVersion { get; set; }
            public System.String RegistryId { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.RegistryRecordCredentialProviderConfiguration> SynchronizationConfiguration_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String SynchronizationConfiguration_FromUrl_Url { get; set; }
            public Amazon.BedrockAgentCoreControl.SynchronizationType SynchronizationType { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateRegistryRecordResponse, NewBACCRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
