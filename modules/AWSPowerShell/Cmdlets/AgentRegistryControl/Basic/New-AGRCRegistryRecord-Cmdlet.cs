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
    /// Creates a registry record within a registry. A registry record describes a discoverable
    /// resource, such as an MCP server, an agent, an agent skill, or a custom resource. For
    /// an agent skill, you can upload a skill package in <c>artifact</c>, or synchronize
    /// the skill from an Amazon S3 or GitHub source. Creation is asynchronous: the operation
    /// returns the record with the <c>CREATING</c> status while the registry processes it.
    /// If a GitHub user must first authorize access to the source, the operation returns
    /// the record with the <c>CREATE_PENDING_AUTH</c> status instead.
    /// </summary>
    [Cmdlet("New", "AGRCRegistryRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse")]
    [AWSCmdlet("Calls the Agent Registry Control CreateRegistryRecord API operation.", Operation = new[] {"CreateRegistryRecord"}, SelectReturnType = typeof(Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse))]
    [AWSCmdletOutput("Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse",
        "This cmdlet returns an Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse object containing multiple properties."
    )]
    public partial class NewAGRCRegistryRecordCmdlet : AmazonAgentRegistryControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the source bucket. The registry
        /// checks that the bucket belongs to this account each time it reads the source. If you
        /// omit it for a source that uses an IAM role, the registry expects the bucket to be
        /// in the role's account. If you omit it for a source that has no credential provider,
        /// which the registry reads as a public object, the request fails with a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter Descriptors_SignatureAgentCard_AdditionalData_Category
        /// <summary>
        /// <para>
        /// <para>The bot category that describes the purpose of the web bot identified by the signature
        /// agent card descriptor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.BotCategory")]
        public Amazon.AgentRegistryControl.BotCategory Descriptors_SignatureAgentCard_AdditionalData_Category { get; set; }
        #endregion
        
        #region Parameter Artifact_Content
        /// <summary>
        /// <para>
        /// <para>The ZIP archive of the skill package, up to 5 MiB (5,242,880 bytes). In a JSON request,
        /// the content is base64-encoded. The Amazon Web Services SDKs encode it for you.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Artifact_Content { get; set; }
        #endregion
        
        #region Parameter Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_Agui_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_Http_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_McpServer_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The credential providers used to authenticate when fetching descriptor content from
        /// the source URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfigurations")]
        public Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration[] Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter CustomMetadata
        /// <summary>
        /// <para>
        /// <para>The custom metadata for the record. Values are strings or JSON booleans.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject CustomMetadata { get; set; }
        #endregion
        
        #region Parameter Descriptors_A2aAgentCard_Data
        /// <summary>
        /// <para>
        /// <para>The A2A agent card content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_A2aAgentCard_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data
        /// <summary>
        /// <para>
        /// <para>The agent skills markdown content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_Data
        /// <summary>
        /// <para>
        /// <para>The agent skills definition content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_Custom_Data
        /// <summary>
        /// <para>
        /// <para>The custom descriptor content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Custom_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_McpServer_AdditionalData_Tools_Data
        /// <summary>
        /// <para>
        /// <para>The MCP tools descriptor content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_McpServer_AdditionalData_Tools_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_McpServer_Data
        /// <summary>
        /// <para>
        /// <para>The MCP server descriptor content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_McpServer_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_SignatureAgentCard_Data
        /// <summary>
        /// <para>
        /// <para>The signature agent card content, serialized as descriptor payload data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_SignatureAgentCard_Data { get; set; }
        #endregion
        
        #region Parameter Descriptors_A2aAgentCard_DataSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the descriptor payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_A2aAgentCard_DataSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the descriptor payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_DataSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the descriptor payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_DataSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the descriptor payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_McpServer_DataSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the descriptor payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_McpServer_DataSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Descriptors_SignatureAgentCard_DataSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the descriptor payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_SignatureAgentCard_DataSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the registry record</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The human-readable display name of the registry record</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the registry record</para>
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
        
        #region Parameter Provenance
        /// <summary>
        /// <para>
        /// <para>The provenance lineage entries for the registry record. This field is reserved for
        /// the Amazon Web Services Agent Registry auto-detection service principal. Requests
        /// that include this field from other callers are rejected.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AgentRegistryControl.Model.Provenance[] Provenance { get; set; }
        #endregion
        
        #region Parameter RecordType
        /// <summary>
        /// <para>
        /// <para>The type of the registry record, which determines the descriptor format</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.RecordType")]
        public Amazon.AgentRegistryControl.RecordType RecordType { get; set; }
        #endregion
        
        #region Parameter RecordVersion
        /// <summary>
        /// <para>
        /// <para>The version of the registry record</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordVersion { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry in which to create the record (ARN or ID)</para>
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
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider
        /// <summary>
        /// <para>
        /// <para>The repository provider of the record's skill source. Set it to <c>GITHUB</c> when
        /// <c>skillMd.source</c> or <c>skillPackage.source</c> is a GitHub folder URL. The registry
        /// treats an <c>https://</c> source as a GitHub source only when this member is set.
        /// Don't set it for an Amazon S3 source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.AgentSkillsRepositoryProvider")]
        public Amazon.AgentRegistryControl.AgentSkillsRepositoryProvider Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider { get; set; }
        #endregion
        
        #region Parameter Artifact_Sha256
        /// <summary>
        /// <para>
        /// <para>The optional SHA-256 checksum of the ZIP archive, as 64 lowercase hexadecimal characters,
        /// computed over the archive's bytes rather than its base64 text. If it doesn't match
        /// the content, the request fails with a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifact_Sha256 { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the registry record</para><para />
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
        
        #region Parameter Descriptors_A2aAgentCard_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_A2aAgentCard_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_Agui_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Agui_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_Http_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_Http_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_McpServer_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_McpServer_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter Descriptors_SignatureAgentCard_Source_FromUrl_Url
        /// <summary>
        /// <para>
        /// <para>The URL from which the descriptor content is retrieved. For an agent skill source,
        /// specify an <c>s3://</c> URL of an object in a bucket in the same Amazon Web Services
        /// Region as the registry. For a GitHub skill source, specify a GitHub folder URL in
        /// the form <c>https://host/owner/repo/tree/branch-or-tag/path</c>. Other descriptor
        /// sources use <c>https://</c> URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Descriptors_SignatureAgentCard_Source_FromUrl_Url { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Client token for idempotency</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse).
        /// Specifying the name of a property of type Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGRCRegistryRecord (CreateRegistryRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse, NewAGRCRegistryRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Artifact_Content = this.Artifact_Content;
            context.Artifact_Sha256 = this.Artifact_Sha256;
            context.ClientToken = this.ClientToken;
            context.CustomMetadata = this.CustomMetadata;
            context.Description = this.Description;
            context.Descriptors_A2aAgentCard_Data = this.Descriptors_A2aAgentCard_Data;
            context.Descriptors_A2aAgentCard_DataSchemaVersion = this.Descriptors_A2aAgentCard_DataSchemaVersion;
            if (this.Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_A2aAgentCard_Source_FromUrl_Url = this.Descriptors_A2aAgentCard_Source_FromUrl_Url;
            context.Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider = this.Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider;
            context.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data = this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data;
            context.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion = this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion;
            if (this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url = this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url;
            if (this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url = this.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url;
            context.Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId = this.Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId;
            context.Descriptors_AgentSkillsDefinition_Data = this.Descriptors_AgentSkillsDefinition_Data;
            context.Descriptors_AgentSkillsDefinition_DataSchemaVersion = this.Descriptors_AgentSkillsDefinition_DataSchemaVersion;
            if (this.Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_Agui_Source_FromUrl_Url = this.Descriptors_Agui_Source_FromUrl_Url;
            context.Descriptors_Custom_Data = this.Descriptors_Custom_Data;
            if (this.Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_Http_Source_FromUrl_Url = this.Descriptors_Http_Source_FromUrl_Url;
            context.Descriptors_McpServer_AdditionalData_Tools_Data = this.Descriptors_McpServer_AdditionalData_Tools_Data;
            context.Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion = this.Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion;
            context.Descriptors_McpServer_Data = this.Descriptors_McpServer_Data;
            context.Descriptors_McpServer_DataSchemaVersion = this.Descriptors_McpServer_DataSchemaVersion;
            if (this.Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_McpServer_Source_FromUrl_Url = this.Descriptors_McpServer_Source_FromUrl_Url;
            context.Descriptors_SignatureAgentCard_AdditionalData_Category = this.Descriptors_SignatureAgentCard_AdditionalData_Category;
            context.Descriptors_SignatureAgentCard_Data = this.Descriptors_SignatureAgentCard_Data;
            context.Descriptors_SignatureAgentCard_DataSchemaVersion = this.Descriptors_SignatureAgentCard_DataSchemaVersion;
            if (this.Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration != null)
            {
                context.Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration = new List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration>(this.Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration);
            }
            context.Descriptors_SignatureAgentCard_Source_FromUrl_Url = this.Descriptors_SignatureAgentCard_Source_FromUrl_Url;
            context.DisplayName = this.DisplayName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Provenance != null)
            {
                context.Provenance = new List<Amazon.AgentRegistryControl.Model.Provenance>(this.Provenance);
            }
            context.RecordType = this.RecordType;
            #if MODULAR
            if (this.RecordType == null && ParameterWasBound(nameof(this.RecordType)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _Artifact_ContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.AgentRegistryControl.Model.CreateRegistryRecordRequest();
                
                
                 // populate Artifact
                var requestArtifactIsNull = true;
                request.Artifact = new Amazon.AgentRegistryControl.Model.RegistryRecordArtifactUpload();
                System.IO.MemoryStream requestArtifact_artifact_Content = null;
                if (cmdletContext.Artifact_Content != null)
                {
                    _Artifact_ContentStream = new System.IO.MemoryStream(cmdletContext.Artifact_Content);
                    requestArtifact_artifact_Content = _Artifact_ContentStream;
                }
                if (requestArtifact_artifact_Content != null)
                {
                    request.Artifact.Content = requestArtifact_artifact_Content;
                    requestArtifactIsNull = false;
                }
                System.String requestArtifact_artifact_Sha256 = null;
                if (cmdletContext.Artifact_Sha256 != null)
                {
                    requestArtifact_artifact_Sha256 = cmdletContext.Artifact_Sha256;
                }
                if (requestArtifact_artifact_Sha256 != null)
                {
                    request.Artifact.Sha256 = requestArtifact_artifact_Sha256;
                    requestArtifactIsNull = false;
                }
                 // determine if request.Artifact should be set to null
                if (requestArtifactIsNull)
                {
                    request.Artifact = null;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                if (cmdletContext.CustomMetadata != null)
                {
                    request.CustomMetadata = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.CustomMetadata);
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                
                 // populate Descriptors
                var requestDescriptorsIsNull = true;
                request.Descriptors = new Amazon.AgentRegistryControl.Model.Descriptors();
                Amazon.AgentRegistryControl.Model.AgUiDescriptor requestDescriptors_descriptors_Agui = null;
                
                 // populate Agui
                var requestDescriptors_descriptors_AguiIsNull = true;
                requestDescriptors_descriptors_Agui = new Amazon.AgentRegistryControl.Model.AgUiDescriptor();
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_Agui_descriptors_Agui_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_Agui_descriptors_Agui_SourceIsNull = true;
                requestDescriptors_descriptors_Agui_descriptors_Agui_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_Agui_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_Url = cmdletContext.Descriptors_Agui_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl.Url = requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl_descriptors_Agui_Source_FromUrl_Url;
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source.FromUrl = requestDescriptors_descriptors_Agui_descriptors_Agui_Source_descriptors_Agui_Source_FromUrl;
                    requestDescriptors_descriptors_Agui_descriptors_Agui_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_Agui_descriptors_Agui_Source should be set to null
                if (requestDescriptors_descriptors_Agui_descriptors_Agui_SourceIsNull)
                {
                    requestDescriptors_descriptors_Agui_descriptors_Agui_Source = null;
                }
                if (requestDescriptors_descriptors_Agui_descriptors_Agui_Source != null)
                {
                    requestDescriptors_descriptors_Agui.Source = requestDescriptors_descriptors_Agui_descriptors_Agui_Source;
                    requestDescriptors_descriptors_AguiIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_Agui should be set to null
                if (requestDescriptors_descriptors_AguiIsNull)
                {
                    requestDescriptors_descriptors_Agui = null;
                }
                if (requestDescriptors_descriptors_Agui != null)
                {
                    request.Descriptors.Agui = requestDescriptors_descriptors_Agui;
                    requestDescriptorsIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.CustomDescriptor requestDescriptors_descriptors_Custom = null;
                
                 // populate Custom
                var requestDescriptors_descriptors_CustomIsNull = true;
                requestDescriptors_descriptors_Custom = new Amazon.AgentRegistryControl.Model.CustomDescriptor();
                System.String requestDescriptors_descriptors_Custom_descriptors_Custom_Data = null;
                if (cmdletContext.Descriptors_Custom_Data != null)
                {
                    requestDescriptors_descriptors_Custom_descriptors_Custom_Data = cmdletContext.Descriptors_Custom_Data;
                }
                if (requestDescriptors_descriptors_Custom_descriptors_Custom_Data != null)
                {
                    requestDescriptors_descriptors_Custom.Data = requestDescriptors_descriptors_Custom_descriptors_Custom_Data;
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
                Amazon.AgentRegistryControl.Model.HttpDescriptor requestDescriptors_descriptors_Http = null;
                
                 // populate Http
                var requestDescriptors_descriptors_HttpIsNull = true;
                requestDescriptors_descriptors_Http = new Amazon.AgentRegistryControl.Model.HttpDescriptor();
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_Http_descriptors_Http_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_Http_descriptors_Http_SourceIsNull = true;
                requestDescriptors_descriptors_Http_descriptors_Http_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_Http_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_Url = cmdletContext.Descriptors_Http_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl.Url = requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl_descriptors_Http_Source_FromUrl_Url;
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source.FromUrl = requestDescriptors_descriptors_Http_descriptors_Http_Source_descriptors_Http_Source_FromUrl;
                    requestDescriptors_descriptors_Http_descriptors_Http_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_Http_descriptors_Http_Source should be set to null
                if (requestDescriptors_descriptors_Http_descriptors_Http_SourceIsNull)
                {
                    requestDescriptors_descriptors_Http_descriptors_Http_Source = null;
                }
                if (requestDescriptors_descriptors_Http_descriptors_Http_Source != null)
                {
                    requestDescriptors_descriptors_Http.Source = requestDescriptors_descriptors_Http_descriptors_Http_Source;
                    requestDescriptors_descriptors_HttpIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_Http should be set to null
                if (requestDescriptors_descriptors_HttpIsNull)
                {
                    requestDescriptors_descriptors_Http = null;
                }
                if (requestDescriptors_descriptors_Http != null)
                {
                    request.Descriptors.Http = requestDescriptors_descriptors_Http;
                    requestDescriptorsIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.A2aAgentCardDescriptor requestDescriptors_descriptors_A2aAgentCard = null;
                
                 // populate A2aAgentCard
                var requestDescriptors_descriptors_A2aAgentCardIsNull = true;
                requestDescriptors_descriptors_A2aAgentCard = new Amazon.AgentRegistryControl.Model.A2aAgentCardDescriptor();
                System.String requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Data = null;
                if (cmdletContext.Descriptors_A2aAgentCard_Data != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Data = cmdletContext.Descriptors_A2aAgentCard_Data;
                }
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Data != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard.Data = requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Data;
                    requestDescriptors_descriptors_A2aAgentCardIsNull = false;
                }
                System.String requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_DataSchemaVersion = null;
                if (cmdletContext.Descriptors_A2aAgentCard_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_DataSchemaVersion = cmdletContext.Descriptors_A2aAgentCard_DataSchemaVersion;
                }
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard.DataSchemaVersion = requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_DataSchemaVersion;
                    requestDescriptors_descriptors_A2aAgentCardIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_SourceIsNull = true;
                requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_A2aAgentCard_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_Url = cmdletContext.Descriptors_A2aAgentCard_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl.Url = requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl_descriptors_A2aAgentCard_Source_FromUrl_Url;
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source.FromUrl = requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source_descriptors_A2aAgentCard_Source_FromUrl;
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source should be set to null
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_SourceIsNull)
                {
                    requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source = null;
                }
                if (requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source != null)
                {
                    requestDescriptors_descriptors_A2aAgentCard.Source = requestDescriptors_descriptors_A2aAgentCard_descriptors_A2aAgentCard_Source;
                    requestDescriptors_descriptors_A2aAgentCardIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_A2aAgentCard should be set to null
                if (requestDescriptors_descriptors_A2aAgentCardIsNull)
                {
                    requestDescriptors_descriptors_A2aAgentCard = null;
                }
                if (requestDescriptors_descriptors_A2aAgentCard != null)
                {
                    request.Descriptors.A2aAgentCard = requestDescriptors_descriptors_A2aAgentCard;
                    requestDescriptorsIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.AgentSkillsDefinitionDescriptor requestDescriptors_descriptors_AgentSkillsDefinition = null;
                
                 // populate AgentSkillsDefinition
                var requestDescriptors_descriptors_AgentSkillsDefinitionIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition = new Amazon.AgentRegistryControl.Model.AgentSkillsDefinitionDescriptor();
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_Data = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_Data != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_Data = cmdletContext.Descriptors_AgentSkillsDefinition_Data;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_Data != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition.Data = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_Data;
                    requestDescriptors_descriptors_AgentSkillsDefinitionIsNull = false;
                }
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_DataSchemaVersion = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_DataSchemaVersion = cmdletContext.Descriptors_AgentSkillsDefinition_DataSchemaVersion;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition.DataSchemaVersion = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_DataSchemaVersion;
                    requestDescriptors_descriptors_AgentSkillsDefinitionIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.AgentSkillsAdditionalData requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData = null;
                
                 // populate AdditionalData
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalDataIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData = new Amazon.AgentRegistryControl.Model.AgentSkillsAdditionalData();
                Amazon.AgentRegistryControl.AgentSkillsRepositoryProvider requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData.RepositoryProvider = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalDataIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.AgentSkillsPackageDescriptor requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage = null;
                
                 // populate SkillPackage
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackageIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage = new Amazon.AgentRegistryControl.Model.AgentSkillsPackageDescriptor();
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_SourceIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl.Url = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source.FromUrl = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_SourceIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage.Source = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackageIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackageIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData.SkillPackage = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalDataIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.AgentSkillsSourceConfiguration requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration = null;
                
                 // populate SourceConfiguration
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfigurationIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration = new Amazon.AgentRegistryControl.Model.AgentSkillsSourceConfiguration();
                Amazon.AgentRegistryControl.Model.S3SourceConfiguration requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3 = null;
                
                 // populate S3
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3IsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3 = new Amazon.AgentRegistryControl.Model.S3SourceConfiguration();
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3.BucketOwnerAccountId = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3IsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3 should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3IsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3 = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3 != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration.S3 = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfigurationIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfigurationIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData.SourceConfiguration = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalDataIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.AgentSkillsMdDescriptor requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd = null;
                
                 // populate SkillMd
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMdIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd = new Amazon.AgentRegistryControl.Model.AgentSkillsMdDescriptor();
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd.Data = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMdIsNull = false;
                }
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd.DataSchemaVersion = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMdIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_SourceIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url = cmdletContext.Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl.Url = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source.FromUrl = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_SourceIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd.Source = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMdIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMdIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData.SkillMd = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData_descriptors_AgentSkillsDefinition_AdditionalData_SkillMd;
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalDataIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalDataIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData != null)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition.AdditionalData = requestDescriptors_descriptors_AgentSkillsDefinition_descriptors_AgentSkillsDefinition_AdditionalData;
                    requestDescriptors_descriptors_AgentSkillsDefinitionIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_AgentSkillsDefinition should be set to null
                if (requestDescriptors_descriptors_AgentSkillsDefinitionIsNull)
                {
                    requestDescriptors_descriptors_AgentSkillsDefinition = null;
                }
                if (requestDescriptors_descriptors_AgentSkillsDefinition != null)
                {
                    request.Descriptors.AgentSkillsDefinition = requestDescriptors_descriptors_AgentSkillsDefinition;
                    requestDescriptorsIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.McpServerDescriptor requestDescriptors_descriptors_McpServer = null;
                
                 // populate McpServer
                var requestDescriptors_descriptors_McpServerIsNull = true;
                requestDescriptors_descriptors_McpServer = new Amazon.AgentRegistryControl.Model.McpServerDescriptor();
                System.String requestDescriptors_descriptors_McpServer_descriptors_McpServer_Data = null;
                if (cmdletContext.Descriptors_McpServer_Data != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Data = cmdletContext.Descriptors_McpServer_Data;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_Data != null)
                {
                    requestDescriptors_descriptors_McpServer.Data = requestDescriptors_descriptors_McpServer_descriptors_McpServer_Data;
                    requestDescriptors_descriptors_McpServerIsNull = false;
                }
                System.String requestDescriptors_descriptors_McpServer_descriptors_McpServer_DataSchemaVersion = null;
                if (cmdletContext.Descriptors_McpServer_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_DataSchemaVersion = cmdletContext.Descriptors_McpServer_DataSchemaVersion;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_McpServer.DataSchemaVersion = requestDescriptors_descriptors_McpServer_descriptors_McpServer_DataSchemaVersion;
                    requestDescriptors_descriptors_McpServerIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.McpServerAdditionalData requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData = null;
                
                 // populate AdditionalData
                var requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalDataIsNull = true;
                requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData = new Amazon.AgentRegistryControl.Model.McpServerAdditionalData();
                Amazon.AgentRegistryControl.Model.McpToolsDescriptor requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools = null;
                
                 // populate Tools
                var requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_ToolsIsNull = true;
                requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools = new Amazon.AgentRegistryControl.Model.McpToolsDescriptor();
                System.String requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_Data = null;
                if (cmdletContext.Descriptors_McpServer_AdditionalData_Tools_Data != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_Data = cmdletContext.Descriptors_McpServer_AdditionalData_Tools_Data;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_Data != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools.Data = requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_Data;
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_ToolsIsNull = false;
                }
                System.String requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion = null;
                if (cmdletContext.Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion = cmdletContext.Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools.DataSchemaVersion = requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools_descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion;
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_ToolsIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools should be set to null
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_ToolsIsNull)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools = null;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData.Tools = requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData_descriptors_McpServer_AdditionalData_Tools;
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalDataIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData should be set to null
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalDataIsNull)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData = null;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData != null)
                {
                    requestDescriptors_descriptors_McpServer.AdditionalData = requestDescriptors_descriptors_McpServer_descriptors_McpServer_AdditionalData;
                    requestDescriptors_descriptors_McpServerIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_McpServer_descriptors_McpServer_SourceIsNull = true;
                requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_McpServer_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_Url = cmdletContext.Descriptors_McpServer_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl.Url = requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl_descriptors_McpServer_Source_FromUrl_Url;
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source.FromUrl = requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source_descriptors_McpServer_Source_FromUrl;
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source should be set to null
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_SourceIsNull)
                {
                    requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source = null;
                }
                if (requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source != null)
                {
                    requestDescriptors_descriptors_McpServer.Source = requestDescriptors_descriptors_McpServer_descriptors_McpServer_Source;
                    requestDescriptors_descriptors_McpServerIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_McpServer should be set to null
                if (requestDescriptors_descriptors_McpServerIsNull)
                {
                    requestDescriptors_descriptors_McpServer = null;
                }
                if (requestDescriptors_descriptors_McpServer != null)
                {
                    request.Descriptors.McpServer = requestDescriptors_descriptors_McpServer;
                    requestDescriptorsIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.SignatureAgentCardDescriptor requestDescriptors_descriptors_SignatureAgentCard = null;
                
                 // populate SignatureAgentCard
                var requestDescriptors_descriptors_SignatureAgentCardIsNull = true;
                requestDescriptors_descriptors_SignatureAgentCard = new Amazon.AgentRegistryControl.Model.SignatureAgentCardDescriptor();
                System.String requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Data = null;
                if (cmdletContext.Descriptors_SignatureAgentCard_Data != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Data = cmdletContext.Descriptors_SignatureAgentCard_Data;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Data != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard.Data = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Data;
                    requestDescriptors_descriptors_SignatureAgentCardIsNull = false;
                }
                System.String requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_DataSchemaVersion = null;
                if (cmdletContext.Descriptors_SignatureAgentCard_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_DataSchemaVersion = cmdletContext.Descriptors_SignatureAgentCard_DataSchemaVersion;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_DataSchemaVersion != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard.DataSchemaVersion = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_DataSchemaVersion;
                    requestDescriptors_descriptors_SignatureAgentCardIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.SignatureAgentCardAdditionalData requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData = null;
                
                 // populate AdditionalData
                var requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalDataIsNull = true;
                requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData = new Amazon.AgentRegistryControl.Model.SignatureAgentCardAdditionalData();
                Amazon.AgentRegistryControl.BotCategory requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData_descriptors_SignatureAgentCard_AdditionalData_Category = null;
                if (cmdletContext.Descriptors_SignatureAgentCard_AdditionalData_Category != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData_descriptors_SignatureAgentCard_AdditionalData_Category = cmdletContext.Descriptors_SignatureAgentCard_AdditionalData_Category;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData_descriptors_SignatureAgentCard_AdditionalData_Category != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData.Category = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData_descriptors_SignatureAgentCard_AdditionalData_Category;
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalDataIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData should be set to null
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalDataIsNull)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData = null;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard.AdditionalData = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_AdditionalData;
                    requestDescriptors_descriptors_SignatureAgentCardIsNull = false;
                }
                Amazon.AgentRegistryControl.Model.DescriptorSource requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source = null;
                
                 // populate Source
                var requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_SourceIsNull = true;
                requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source = new Amazon.AgentRegistryControl.Model.DescriptorSource();
                Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl = null;
                
                 // populate FromUrl
                var requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrlIsNull = true;
                requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl = new Amazon.AgentRegistryControl.Model.DescriptorSourceFromUrl();
                List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration = null;
                if (cmdletContext.Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration = cmdletContext.Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl.CredentialProviderConfigurations = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration;
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrlIsNull = false;
                }
                System.String requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_Url = null;
                if (cmdletContext.Descriptors_SignatureAgentCard_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_Url = cmdletContext.Descriptors_SignatureAgentCard_Source_FromUrl_Url;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_Url != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl.Url = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl_descriptors_SignatureAgentCard_Source_FromUrl_Url;
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrlIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl should be set to null
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrlIsNull)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl = null;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source.FromUrl = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source_descriptors_SignatureAgentCard_Source_FromUrl;
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_SourceIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source should be set to null
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_SourceIsNull)
                {
                    requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source = null;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source != null)
                {
                    requestDescriptors_descriptors_SignatureAgentCard.Source = requestDescriptors_descriptors_SignatureAgentCard_descriptors_SignatureAgentCard_Source;
                    requestDescriptors_descriptors_SignatureAgentCardIsNull = false;
                }
                 // determine if requestDescriptors_descriptors_SignatureAgentCard should be set to null
                if (requestDescriptors_descriptors_SignatureAgentCardIsNull)
                {
                    requestDescriptors_descriptors_SignatureAgentCard = null;
                }
                if (requestDescriptors_descriptors_SignatureAgentCard != null)
                {
                    request.Descriptors.SignatureAgentCard = requestDescriptors_descriptors_SignatureAgentCard;
                    requestDescriptorsIsNull = false;
                }
                 // determine if request.Descriptors should be set to null
                if (requestDescriptorsIsNull)
                {
                    request.Descriptors = null;
                }
                if (cmdletContext.DisplayName != null)
                {
                    request.DisplayName = cmdletContext.DisplayName;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.Provenance != null)
                {
                    request.Provenance = cmdletContext.Provenance;
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
            finally
            {
                if( _Artifact_ContentStream != null)
                {
                    _Artifact_ContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse CallAWSServiceOperation(IAmazonAgentRegistryControl client, Amazon.AgentRegistryControl.Model.CreateRegistryRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry Control", "CreateRegistryRecord");
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
            public byte[] Artifact_Content { get; set; }
            public System.String Artifact_Sha256 { get; set; }
            public System.String ClientToken { get; set; }
            public System.Management.Automation.PSObject CustomMetadata { get; set; }
            public System.String Description { get; set; }
            public System.String Descriptors_A2aAgentCard_Data { get; set; }
            public System.String Descriptors_A2aAgentCard_DataSchemaVersion { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_A2aAgentCard_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_A2aAgentCard_Source_FromUrl_Url { get; set; }
            public Amazon.AgentRegistryControl.AgentSkillsRepositoryProvider Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Data { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_DataSchemaVersion { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillMd_Source_FromUrl_Url { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SkillPackage_Source_FromUrl_Url { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_AdditionalData_SourceConfiguration_S3_BucketOwnerAccountId { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_Data { get; set; }
            public System.String Descriptors_AgentSkillsDefinition_DataSchemaVersion { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_Agui_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_Agui_Source_FromUrl_Url { get; set; }
            public System.String Descriptors_Custom_Data { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_Http_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_Http_Source_FromUrl_Url { get; set; }
            public System.String Descriptors_McpServer_AdditionalData_Tools_Data { get; set; }
            public System.String Descriptors_McpServer_AdditionalData_Tools_DataSchemaVersion { get; set; }
            public System.String Descriptors_McpServer_Data { get; set; }
            public System.String Descriptors_McpServer_DataSchemaVersion { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_McpServer_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_McpServer_Source_FromUrl_Url { get; set; }
            public Amazon.AgentRegistryControl.BotCategory Descriptors_SignatureAgentCard_AdditionalData_Category { get; set; }
            public System.String Descriptors_SignatureAgentCard_Data { get; set; }
            public System.String Descriptors_SignatureAgentCard_DataSchemaVersion { get; set; }
            public List<Amazon.AgentRegistryControl.Model.RegistryRecordCredentialProviderConfiguration> Descriptors_SignatureAgentCard_Source_FromUrl_CredentialProviderConfiguration { get; set; }
            public System.String Descriptors_SignatureAgentCard_Source_FromUrl_Url { get; set; }
            public System.String DisplayName { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.AgentRegistryControl.Model.Provenance> Provenance { get; set; }
            public Amazon.AgentRegistryControl.RecordType RecordType { get; set; }
            public System.String RecordVersion { get; set; }
            public System.String RegistryId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AgentRegistryControl.Model.CreateRegistryRecordResponse, NewAGRCRegistryRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
