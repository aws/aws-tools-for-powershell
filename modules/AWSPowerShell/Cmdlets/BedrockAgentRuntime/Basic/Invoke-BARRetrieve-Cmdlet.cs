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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Queries a knowledge base and retrieves information from it.
    /// </summary>
    [Cmdlet("Invoke", "BARRetrieve", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.RetrieveResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime Retrieve API operation.", Operation = new[] {"Retrieve"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.RetrieveResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.RetrieveResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.RetrieveResponse object containing multiple properties."
    )]
    public partial class InvokeBARRetrieveCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ModelConfiguration_AdditionalModelRequestField
        /// <summary>
        /// <para>
        /// <para>A JSON object whose keys are request fields for the model and whose values are values
        /// for those fields.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_AdditionalModelRequestFields")]
        public System.Collections.Hashtable ModelConfiguration_AdditionalModelRequestField { get; set; }
        #endregion
        
        #region Parameter Filter_AndAll
        /// <summary>
        /// <para>
        /// <para>Knowledge base data sources are returned if their metadata attributes fulfill all
        /// the filter conditions inside this list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_AndAll")]
        public Amazon.BedrockAgentRuntime.Model.RetrievalFilter[] Filter_AndAll { get; set; }
        #endregion
        
        #region Parameter SelectiveModeConfiguration_FieldsToExclude
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which specifies a metadata field to exclude from consideration
        /// when reranking.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_FieldsToExclude")]
        public Amazon.BedrockAgentRuntime.Model.FieldForReranking[] SelectiveModeConfiguration_FieldsToExclude { get; set; }
        #endregion
        
        #region Parameter SelectiveModeConfiguration_FieldsToInclude
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which specifies a metadata field to include in consideration
        /// when reranking. The remaining metadata fields are ignored.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_FieldsToInclude")]
        public Amazon.BedrockAgentRuntime.Model.FieldForReranking[] SelectiveModeConfiguration_FieldsToInclude { get; set; }
        #endregion
        
        #region Parameter Image_Format
        /// <summary>
        /// <para>
        /// <para>The format of the input image. Supported formats include png, gif, jpeg, and webp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalQuery_Image_Format")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.InputImageFormat")]
        public Amazon.BedrockAgentRuntime.InputImageFormat Image_Format { get; set; }
        #endregion
        
        #region Parameter GuardrailConfiguration_GuardrailId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfiguration_GuardrailId { get; set; }
        #endregion
        
        #region Parameter GuardrailConfiguration_GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The version of the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfiguration_GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter Image_InlineContent
        /// <summary>
        /// <para>
        /// <para>The base64-encoded image data for inline image content. Maximum size is 5MB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalQuery_Image_InlineContent")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Image_InlineContent { get; set; }
        #endregion
        
        #region Parameter Equals_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_Equals_Key")]
        public System.String Equals_Key { get; set; }
        #endregion
        
        #region Parameter GreaterThan_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_Key")]
        public System.String GreaterThan_Key { get; set; }
        #endregion
        
        #region Parameter GreaterThanOrEquals_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_Key")]
        public System.String GreaterThanOrEquals_Key { get; set; }
        #endregion
        
        #region Parameter In_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_In_Key")]
        public System.String In_Key { get; set; }
        #endregion
        
        #region Parameter LessThan_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_Key")]
        public System.String LessThan_Key { get; set; }
        #endregion
        
        #region Parameter LessThanOrEquals_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_Key")]
        public System.String LessThanOrEquals_Key { get; set; }
        #endregion
        
        #region Parameter ListContains_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_Key")]
        public System.String ListContains_Key { get; set; }
        #endregion
        
        #region Parameter NotEquals_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_Key")]
        public System.String NotEquals_Key { get; set; }
        #endregion
        
        #region Parameter NotIn_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_Key")]
        public System.String NotIn_Key { get; set; }
        #endregion
        
        #region Parameter StartsWith_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_Key")]
        public System.String StartsWith_Key { get; set; }
        #endregion
        
        #region Parameter StringContains_Key
        /// <summary>
        /// <para>
        /// <para>The name that the metadata attribute must match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_Key")]
        public System.String StringContains_Key { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the knowledge base to query.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter ImplicitFilterConfiguration_MetadataAttribute
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used in a filter.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_MetadataAttributes")]
        public Amazon.BedrockAgentRuntime.Model.MetadataAttributeSchema[] ImplicitFilterConfiguration_MetadataAttribute { get; set; }
        #endregion
        
        #region Parameter ImplicitFilterConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The model that generates the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_ModelArn")]
        public System.String ImplicitFilterConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter ModelConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the reranker model to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_ModelArn")]
        public System.String ModelConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter BedrockRerankingConfiguration_NumberOfRerankedResult
        /// <summary>
        /// <para>
        /// <para>The number of results to return after reranking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_NumberOfRerankedResults")]
        public System.Int32? BedrockRerankingConfiguration_NumberOfRerankedResult { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_NumberOfResult
        /// <summary>
        /// <para>
        /// <para>The number of source chunks to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_NumberOfResults")]
        public System.Int32? VectorSearchConfiguration_NumberOfResult { get; set; }
        #endregion
        
        #region Parameter Filter_OrAll
        /// <summary>
        /// <para>
        /// <para>Knowledge base data sources are returned if their metadata attributes fulfill at least
        /// one of the filter conditions inside this list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_OrAll")]
        public Amazon.BedrockAgentRuntime.Model.RetrievalFilter[] Filter_OrAll { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_OverrideSearchType
        /// <summary>
        /// <para>
        /// <para>By default, Amazon Bedrock decides a search strategy for you. If you're using an Amazon
        /// OpenSearch Serverless vector store that contains a filterable text field, you can
        /// specify whether to query the knowledge base with a <c>HYBRID</c> search using both
        /// vector embeddings and raw text, or <c>SEMANTIC</c> search using only vector embeddings.
        /// For other vector store configurations, only <c>SEMANTIC</c> search is available. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-test.html">Test
        /// a knowledge base</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_OverrideSearchType")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.SearchType")]
        public Amazon.BedrockAgentRuntime.SearchType VectorSearchConfiguration_OverrideSearchType { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_SelectionMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether to consider all metadata when reranking, or only the metadata that
        /// you select. If you specify <c>SELECTIVE</c>, include the <c>selectiveModeConfiguration</c>
        /// field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectionMode")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.RerankingMetadataSelectionMode")]
        public Amazon.BedrockAgentRuntime.RerankingMetadataSelectionMode MetadataConfiguration_SelectionMode { get; set; }
        #endregion
        
        #region Parameter RetrievalQuery_Text
        /// <summary>
        /// <para>
        /// <para>The text of the query made to the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrievalQuery_Text { get; set; }
        #endregion
        
        #region Parameter RerankingConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of reranker model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_Type")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.VectorSearchRerankingConfigurationType")]
        public Amazon.BedrockAgentRuntime.VectorSearchRerankingConfigurationType RerankingConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter RetrievalQuery_Type
        /// <summary>
        /// <para>
        /// <para>The type of query being performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.KnowledgeBaseQueryType")]
        public Amazon.BedrockAgentRuntime.KnowledgeBaseQueryType RetrievalQuery_Type { get; set; }
        #endregion
        
        #region Parameter Equals_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_Equals_Value")]
        public System.Management.Automation.PSObject Equals_Value { get; set; }
        #endregion
        
        #region Parameter GreaterThan_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_Value")]
        public System.Management.Automation.PSObject GreaterThan_Value { get; set; }
        #endregion
        
        #region Parameter GreaterThanOrEquals_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_Value")]
        public System.Management.Automation.PSObject GreaterThanOrEquals_Value { get; set; }
        #endregion
        
        #region Parameter In_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_In_Value")]
        public System.Management.Automation.PSObject In_Value { get; set; }
        #endregion
        
        #region Parameter LessThan_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_Value")]
        public System.Management.Automation.PSObject LessThan_Value { get; set; }
        #endregion
        
        #region Parameter LessThanOrEquals_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_Value")]
        public System.Management.Automation.PSObject LessThanOrEquals_Value { get; set; }
        #endregion
        
        #region Parameter ListContains_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_Value")]
        public System.Management.Automation.PSObject ListContains_Value { get; set; }
        #endregion
        
        #region Parameter NotEquals_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_Value")]
        public System.Management.Automation.PSObject NotEquals_Value { get; set; }
        #endregion
        
        #region Parameter NotIn_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_Value")]
        public System.Management.Automation.PSObject NotIn_Value { get; set; }
        #endregion
        
        #region Parameter StartsWith_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_Value")]
        public System.Management.Automation.PSObject StartsWith_Value { get; set; }
        #endregion
        
        #region Parameter StringContains_Value
        /// <summary>
        /// <para>
        /// <para>The value to whcih to compare the value of the metadata attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_Value")]
        public System.Management.Automation.PSObject StringContains_Value { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If there are more results than can fit in the response, the response returns a <c>nextToken</c>.
        /// Use this token in the <c>nextToken</c> field of another request to retrieve the next
        /// batch of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.RetrieveResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.RetrieveResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARRetrieve (Retrieve)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.RetrieveResponse, InvokeBARRetrieveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GuardrailConfiguration_GuardrailId = this.GuardrailConfiguration_GuardrailId;
            context.GuardrailConfiguration_GuardrailVersion = this.GuardrailConfiguration_GuardrailVersion;
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            if (this.Filter_AndAll != null)
            {
                context.Filter_AndAll = new List<Amazon.BedrockAgentRuntime.Model.RetrievalFilter>(this.Filter_AndAll);
            }
            context.Equals_Key = this.Equals_Key;
            context.Equals_Value = this.Equals_Value;
            context.GreaterThan_Key = this.GreaterThan_Key;
            context.GreaterThan_Value = this.GreaterThan_Value;
            context.GreaterThanOrEquals_Key = this.GreaterThanOrEquals_Key;
            context.GreaterThanOrEquals_Value = this.GreaterThanOrEquals_Value;
            context.In_Key = this.In_Key;
            context.In_Value = this.In_Value;
            context.LessThan_Key = this.LessThan_Key;
            context.LessThan_Value = this.LessThan_Value;
            context.LessThanOrEquals_Key = this.LessThanOrEquals_Key;
            context.LessThanOrEquals_Value = this.LessThanOrEquals_Value;
            context.ListContains_Key = this.ListContains_Key;
            context.ListContains_Value = this.ListContains_Value;
            context.NotEquals_Key = this.NotEquals_Key;
            context.NotEquals_Value = this.NotEquals_Value;
            context.NotIn_Key = this.NotIn_Key;
            context.NotIn_Value = this.NotIn_Value;
            if (this.Filter_OrAll != null)
            {
                context.Filter_OrAll = new List<Amazon.BedrockAgentRuntime.Model.RetrievalFilter>(this.Filter_OrAll);
            }
            context.StartsWith_Key = this.StartsWith_Key;
            context.StartsWith_Value = this.StartsWith_Value;
            context.StringContains_Key = this.StringContains_Key;
            context.StringContains_Value = this.StringContains_Value;
            if (this.ImplicitFilterConfiguration_MetadataAttribute != null)
            {
                context.ImplicitFilterConfiguration_MetadataAttribute = new List<Amazon.BedrockAgentRuntime.Model.MetadataAttributeSchema>(this.ImplicitFilterConfiguration_MetadataAttribute);
            }
            context.ImplicitFilterConfiguration_ModelArn = this.ImplicitFilterConfiguration_ModelArn;
            context.VectorSearchConfiguration_NumberOfResult = this.VectorSearchConfiguration_NumberOfResult;
            context.VectorSearchConfiguration_OverrideSearchType = this.VectorSearchConfiguration_OverrideSearchType;
            context.MetadataConfiguration_SelectionMode = this.MetadataConfiguration_SelectionMode;
            if (this.SelectiveModeConfiguration_FieldsToExclude != null)
            {
                context.SelectiveModeConfiguration_FieldsToExclude = new List<Amazon.BedrockAgentRuntime.Model.FieldForReranking>(this.SelectiveModeConfiguration_FieldsToExclude);
            }
            if (this.SelectiveModeConfiguration_FieldsToInclude != null)
            {
                context.SelectiveModeConfiguration_FieldsToInclude = new List<Amazon.BedrockAgentRuntime.Model.FieldForReranking>(this.SelectiveModeConfiguration_FieldsToInclude);
            }
            if (this.ModelConfiguration_AdditionalModelRequestField != null)
            {
                context.ModelConfiguration_AdditionalModelRequestField = new Dictionary<System.String, Amazon.Runtime.Documents.Document>(StringComparer.Ordinal);
                foreach (var hashKey in this.ModelConfiguration_AdditionalModelRequestField.Keys)
                {
                    context.ModelConfiguration_AdditionalModelRequestField.Add((String)hashKey, Amazon.PowerShell.Common.DocumentHelper.ToDocument(this.ModelConfiguration_AdditionalModelRequestField[hashKey]));
                }
            }
            context.ModelConfiguration_ModelArn = this.ModelConfiguration_ModelArn;
            context.BedrockRerankingConfiguration_NumberOfRerankedResult = this.BedrockRerankingConfiguration_NumberOfRerankedResult;
            context.RerankingConfiguration_Type = this.RerankingConfiguration_Type;
            context.Image_Format = this.Image_Format;
            context.Image_InlineContent = this.Image_InlineContent;
            context.RetrievalQuery_Text = this.RetrievalQuery_Text;
            context.RetrievalQuery_Type = this.RetrievalQuery_Type;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Image_InlineContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BedrockAgentRuntime.Model.RetrieveRequest();
                
                
                 // populate GuardrailConfiguration
                var requestGuardrailConfigurationIsNull = true;
                request.GuardrailConfiguration = new Amazon.BedrockAgentRuntime.Model.GuardrailConfiguration();
                System.String requestGuardrailConfiguration_guardrailConfiguration_GuardrailId = null;
                if (cmdletContext.GuardrailConfiguration_GuardrailId != null)
                {
                    requestGuardrailConfiguration_guardrailConfiguration_GuardrailId = cmdletContext.GuardrailConfiguration_GuardrailId;
                }
                if (requestGuardrailConfiguration_guardrailConfiguration_GuardrailId != null)
                {
                    request.GuardrailConfiguration.GuardrailId = requestGuardrailConfiguration_guardrailConfiguration_GuardrailId;
                    requestGuardrailConfigurationIsNull = false;
                }
                System.String requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion = null;
                if (cmdletContext.GuardrailConfiguration_GuardrailVersion != null)
                {
                    requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion = cmdletContext.GuardrailConfiguration_GuardrailVersion;
                }
                if (requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion != null)
                {
                    request.GuardrailConfiguration.GuardrailVersion = requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion;
                    requestGuardrailConfigurationIsNull = false;
                }
                 // determine if request.GuardrailConfiguration should be set to null
                if (requestGuardrailConfigurationIsNull)
                {
                    request.GuardrailConfiguration = null;
                }
                if (cmdletContext.KnowledgeBaseId != null)
                {
                    request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
                }
                if (cmdletContext.NextToken != null)
                {
                    request.NextToken = cmdletContext.NextToken;
                }
                
                 // populate RetrievalConfiguration
                var requestRetrievalConfigurationIsNull = true;
                request.RetrievalConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrievalConfiguration();
                Amazon.BedrockAgentRuntime.Model.KnowledgeBaseVectorSearchConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration = null;
                
                 // populate VectorSearchConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseVectorSearchConfiguration();
                System.Int32? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult = null;
                if (cmdletContext.VectorSearchConfiguration_NumberOfResult != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult = cmdletContext.VectorSearchConfiguration_NumberOfResult.Value;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.NumberOfResults = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.SearchType requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType = null;
                if (cmdletContext.VectorSearchConfiguration_OverrideSearchType != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType = cmdletContext.VectorSearchConfiguration_OverrideSearchType;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.OverrideSearchType = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.ImplicitFilterConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration = null;
                
                 // populate ImplicitFilterConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration = new Amazon.BedrockAgentRuntime.Model.ImplicitFilterConfiguration();
                List<Amazon.BedrockAgentRuntime.Model.MetadataAttributeSchema> requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_MetadataAttribute = null;
                if (cmdletContext.ImplicitFilterConfiguration_MetadataAttribute != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_MetadataAttribute = cmdletContext.ImplicitFilterConfiguration_MetadataAttribute;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_MetadataAttribute != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration.MetadataAttributes = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_MetadataAttribute;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfigurationIsNull = false;
                }
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_ModelArn = null;
                if (cmdletContext.ImplicitFilterConfiguration_ModelArn != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_ModelArn = cmdletContext.ImplicitFilterConfiguration_ModelArn;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_ModelArn != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration.ModelArn = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration_implicitFilterConfiguration_ModelArn;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.ImplicitFilterConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_ImplicitFilterConfiguration;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.VectorSearchRerankingConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration = null;
                
                 // populate RerankingConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration = new Amazon.BedrockAgentRuntime.Model.VectorSearchRerankingConfiguration();
                Amazon.BedrockAgentRuntime.VectorSearchRerankingConfigurationType requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_rerankingConfiguration_Type = null;
                if (cmdletContext.RerankingConfiguration_Type != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_rerankingConfiguration_Type = cmdletContext.RerankingConfiguration_Type;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_rerankingConfiguration_Type != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration.Type = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_rerankingConfiguration_Type;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.VectorSearchBedrockRerankingConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration = null;
                
                 // populate BedrockRerankingConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration = new Amazon.BedrockAgentRuntime.Model.VectorSearchBedrockRerankingConfiguration();
                System.Int32? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfRerankedResult = null;
                if (cmdletContext.BedrockRerankingConfiguration_NumberOfRerankedResult != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfRerankedResult = cmdletContext.BedrockRerankingConfiguration_NumberOfRerankedResult.Value;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfRerankedResult != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration.NumberOfRerankedResults = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_bedrockRerankingConfiguration_NumberOfRerankedResult.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.MetadataConfigurationForReranking requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration = null;
                
                 // populate MetadataConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration = new Amazon.BedrockAgentRuntime.Model.MetadataConfigurationForReranking();
                Amazon.BedrockAgentRuntime.RerankingMetadataSelectionMode requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_metadataConfiguration_SelectionMode = null;
                if (cmdletContext.MetadataConfiguration_SelectionMode != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_metadataConfiguration_SelectionMode = cmdletContext.MetadataConfiguration_SelectionMode;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_metadataConfiguration_SelectionMode != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration.SelectionMode = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_metadataConfiguration_SelectionMode;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.RerankingMetadataSelectiveModeConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration = null;
                
                 // populate SelectiveModeConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration = new Amazon.BedrockAgentRuntime.Model.RerankingMetadataSelectiveModeConfiguration();
                List<Amazon.BedrockAgentRuntime.Model.FieldForReranking> requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToExclude = null;
                if (cmdletContext.SelectiveModeConfiguration_FieldsToExclude != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToExclude = cmdletContext.SelectiveModeConfiguration_FieldsToExclude;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToExclude != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration.FieldsToExclude = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToExclude;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfigurationIsNull = false;
                }
                List<Amazon.BedrockAgentRuntime.Model.FieldForReranking> requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToInclude = null;
                if (cmdletContext.SelectiveModeConfiguration_FieldsToInclude != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToInclude = cmdletContext.SelectiveModeConfiguration_FieldsToInclude;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToInclude != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration.FieldsToInclude = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration_selectiveModeConfiguration_FieldsToInclude;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration.SelectiveModeConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration_SelectiveModeConfiguration;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration.MetadataConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_MetadataConfiguration;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.VectorSearchBedrockRerankingModelConfiguration requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = null;
                
                 // populate ModelConfiguration
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = new Amazon.BedrockAgentRuntime.Model.VectorSearchBedrockRerankingModelConfiguration();
                Dictionary<System.String, Amazon.Runtime.Documents.Document> requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField = null;
                if (cmdletContext.ModelConfiguration_AdditionalModelRequestField != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField = cmdletContext.ModelConfiguration_AdditionalModelRequestField;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration.AdditionalModelRequestFields = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_AdditionalModelRequestField;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = false;
                }
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn = null;
                if (cmdletContext.ModelConfiguration_ModelArn != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn = cmdletContext.ModelConfiguration_ModelArn;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration.ModelArn = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration_modelConfiguration_ModelArn;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration.ModelConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration_ModelConfiguration;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration.BedrockRerankingConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration_BedrockRerankingConfiguration;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.RerankingConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_RerankingConfiguration;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.RetrievalFilter requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter = null;
                
                 // populate Filter
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter = new Amazon.BedrockAgentRuntime.Model.RetrievalFilter();
                List<Amazon.BedrockAgentRuntime.Model.RetrievalFilter> requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_AndAll = null;
                if (cmdletContext.Filter_AndAll != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_AndAll = cmdletContext.Filter_AndAll;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_AndAll != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.AndAll = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_AndAll;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                List<Amazon.BedrockAgentRuntime.Model.RetrievalFilter> requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_OrAll = null;
                if (cmdletContext.Filter_OrAll != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_OrAll = cmdletContext.Filter_OrAll;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_OrAll != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.OrAll = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_filter_OrAll;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals = null;
                
                 // populate Equals
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_EqualsIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Key = null;
                if (cmdletContext.Equals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Key = cmdletContext.Equals_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_EqualsIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Value = null;
                if (cmdletContext.Equals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Equals_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals_equals_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_EqualsIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_EqualsIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.Equals = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_Equals;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan = null;
                
                 // populate GreaterThan
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Key = null;
                if (cmdletContext.GreaterThan_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Key = cmdletContext.GreaterThan_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Value = null;
                if (cmdletContext.GreaterThan_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.GreaterThan_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan_greaterThan_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.GreaterThan = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThan;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals = null;
                
                 // populate GreaterThanOrEquals
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEqualsIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key = null;
                if (cmdletContext.GreaterThanOrEquals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key = cmdletContext.GreaterThanOrEquals_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEqualsIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value = null;
                if (cmdletContext.GreaterThanOrEquals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.GreaterThanOrEquals_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEqualsIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEqualsIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.GreaterThanOrEquals = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_GreaterThanOrEquals;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In = null;
                
                 // populate In
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_InIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Key = null;
                if (cmdletContext.In_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Key = cmdletContext.In_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_InIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Value = null;
                if (cmdletContext.In_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.In_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In_in_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_InIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_InIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.In = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_In;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan = null;
                
                 // populate LessThan
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Key = null;
                if (cmdletContext.LessThan_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Key = cmdletContext.LessThan_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Value = null;
                if (cmdletContext.LessThan_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.LessThan_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan_lessThan_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.LessThan = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThan;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals = null;
                
                 // populate LessThanOrEquals
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEqualsIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key = null;
                if (cmdletContext.LessThanOrEquals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key = cmdletContext.LessThanOrEquals_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEqualsIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value = null;
                if (cmdletContext.LessThanOrEquals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.LessThanOrEquals_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEqualsIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEqualsIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.LessThanOrEquals = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_LessThanOrEquals;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains = null;
                
                 // populate ListContains
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContainsIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Key = null;
                if (cmdletContext.ListContains_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Key = cmdletContext.ListContains_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContainsIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Value = null;
                if (cmdletContext.ListContains_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.ListContains_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains_listContains_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContainsIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContainsIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.ListContains = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_ListContains;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals = null;
                
                 // populate NotEquals
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEqualsIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Key = null;
                if (cmdletContext.NotEquals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Key = cmdletContext.NotEquals_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEqualsIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Value = null;
                if (cmdletContext.NotEquals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.NotEquals_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals_notEquals_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEqualsIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEqualsIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.NotEquals = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotEquals;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn = null;
                
                 // populate NotIn
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotInIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Key = null;
                if (cmdletContext.NotIn_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Key = cmdletContext.NotIn_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotInIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Value = null;
                if (cmdletContext.NotIn_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.NotIn_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn_notIn_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotInIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotInIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.NotIn = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_NotIn;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith = null;
                
                 // populate StartsWith
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWithIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Key = null;
                if (cmdletContext.StartsWith_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Key = cmdletContext.StartsWith_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWithIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Value = null;
                if (cmdletContext.StartsWith_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.StartsWith_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith_startsWith_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWithIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWithIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.StartsWith = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StartsWith;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains = null;
                
                 // populate StringContains
                var requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContainsIsNull = true;
                requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains = new Amazon.BedrockAgentRuntime.Model.FilterAttribute();
                System.String requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Key = null;
                if (cmdletContext.StringContains_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Key = cmdletContext.StringContains_Key;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Key != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains.Key = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Key;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContainsIsNull = false;
                }
                Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Value = null;
                if (cmdletContext.StringContains_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.StringContains_Value);
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Value != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains.Value = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains_stringContains_Value.Value;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContainsIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContainsIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter.StringContains = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter_retrievalConfiguration_VectorSearchConfiguration_Filter_StringContains;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_FilterIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter != null)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration.Filter = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration_retrievalConfiguration_VectorSearchConfiguration_Filter;
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull = false;
                }
                 // determine if requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration should be set to null
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfigurationIsNull)
                {
                    requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration = null;
                }
                if (requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration != null)
                {
                    request.RetrievalConfiguration.VectorSearchConfiguration = requestRetrievalConfiguration_retrievalConfiguration_VectorSearchConfiguration;
                    requestRetrievalConfigurationIsNull = false;
                }
                 // determine if request.RetrievalConfiguration should be set to null
                if (requestRetrievalConfigurationIsNull)
                {
                    request.RetrievalConfiguration = null;
                }
                
                 // populate RetrievalQuery
                var requestRetrievalQueryIsNull = true;
                request.RetrievalQuery = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseQuery();
                System.String requestRetrievalQuery_retrievalQuery_Text = null;
                if (cmdletContext.RetrievalQuery_Text != null)
                {
                    requestRetrievalQuery_retrievalQuery_Text = cmdletContext.RetrievalQuery_Text;
                }
                if (requestRetrievalQuery_retrievalQuery_Text != null)
                {
                    request.RetrievalQuery.Text = requestRetrievalQuery_retrievalQuery_Text;
                    requestRetrievalQueryIsNull = false;
                }
                Amazon.BedrockAgentRuntime.KnowledgeBaseQueryType requestRetrievalQuery_retrievalQuery_Type = null;
                if (cmdletContext.RetrievalQuery_Type != null)
                {
                    requestRetrievalQuery_retrievalQuery_Type = cmdletContext.RetrievalQuery_Type;
                }
                if (requestRetrievalQuery_retrievalQuery_Type != null)
                {
                    request.RetrievalQuery.Type = requestRetrievalQuery_retrievalQuery_Type;
                    requestRetrievalQueryIsNull = false;
                }
                Amazon.BedrockAgentRuntime.Model.InputImage requestRetrievalQuery_retrievalQuery_Image = null;
                
                 // populate Image
                var requestRetrievalQuery_retrievalQuery_ImageIsNull = true;
                requestRetrievalQuery_retrievalQuery_Image = new Amazon.BedrockAgentRuntime.Model.InputImage();
                Amazon.BedrockAgentRuntime.InputImageFormat requestRetrievalQuery_retrievalQuery_Image_image_Format = null;
                if (cmdletContext.Image_Format != null)
                {
                    requestRetrievalQuery_retrievalQuery_Image_image_Format = cmdletContext.Image_Format;
                }
                if (requestRetrievalQuery_retrievalQuery_Image_image_Format != null)
                {
                    requestRetrievalQuery_retrievalQuery_Image.Format = requestRetrievalQuery_retrievalQuery_Image_image_Format;
                    requestRetrievalQuery_retrievalQuery_ImageIsNull = false;
                }
                System.IO.MemoryStream requestRetrievalQuery_retrievalQuery_Image_image_InlineContent = null;
                if (cmdletContext.Image_InlineContent != null)
                {
                    _Image_InlineContentStream = new System.IO.MemoryStream(cmdletContext.Image_InlineContent);
                    requestRetrievalQuery_retrievalQuery_Image_image_InlineContent = _Image_InlineContentStream;
                }
                if (requestRetrievalQuery_retrievalQuery_Image_image_InlineContent != null)
                {
                    requestRetrievalQuery_retrievalQuery_Image.InlineContent = requestRetrievalQuery_retrievalQuery_Image_image_InlineContent;
                    requestRetrievalQuery_retrievalQuery_ImageIsNull = false;
                }
                 // determine if requestRetrievalQuery_retrievalQuery_Image should be set to null
                if (requestRetrievalQuery_retrievalQuery_ImageIsNull)
                {
                    requestRetrievalQuery_retrievalQuery_Image = null;
                }
                if (requestRetrievalQuery_retrievalQuery_Image != null)
                {
                    request.RetrievalQuery.Image = requestRetrievalQuery_retrievalQuery_Image;
                    requestRetrievalQueryIsNull = false;
                }
                 // determine if request.RetrievalQuery should be set to null
                if (requestRetrievalQueryIsNull)
                {
                    request.RetrievalQuery = null;
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
                if( _Image_InlineContentStream != null)
                {
                    _Image_InlineContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BedrockAgentRuntime.Model.RetrieveResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.RetrieveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "Retrieve");
            try
            {
                return client.RetrieveAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GuardrailConfiguration_GuardrailId { get; set; }
            public System.String GuardrailConfiguration_GuardrailVersion { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.RetrievalFilter> Filter_AndAll { get; set; }
            public System.String Equals_Key { get; set; }
            public System.Management.Automation.PSObject Equals_Value { get; set; }
            public System.String GreaterThan_Key { get; set; }
            public System.Management.Automation.PSObject GreaterThan_Value { get; set; }
            public System.String GreaterThanOrEquals_Key { get; set; }
            public System.Management.Automation.PSObject GreaterThanOrEquals_Value { get; set; }
            public System.String In_Key { get; set; }
            public System.Management.Automation.PSObject In_Value { get; set; }
            public System.String LessThan_Key { get; set; }
            public System.Management.Automation.PSObject LessThan_Value { get; set; }
            public System.String LessThanOrEquals_Key { get; set; }
            public System.Management.Automation.PSObject LessThanOrEquals_Value { get; set; }
            public System.String ListContains_Key { get; set; }
            public System.Management.Automation.PSObject ListContains_Value { get; set; }
            public System.String NotEquals_Key { get; set; }
            public System.Management.Automation.PSObject NotEquals_Value { get; set; }
            public System.String NotIn_Key { get; set; }
            public System.Management.Automation.PSObject NotIn_Value { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.RetrievalFilter> Filter_OrAll { get; set; }
            public System.String StartsWith_Key { get; set; }
            public System.Management.Automation.PSObject StartsWith_Value { get; set; }
            public System.String StringContains_Key { get; set; }
            public System.Management.Automation.PSObject StringContains_Value { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.MetadataAttributeSchema> ImplicitFilterConfiguration_MetadataAttribute { get; set; }
            public System.String ImplicitFilterConfiguration_ModelArn { get; set; }
            public System.Int32? VectorSearchConfiguration_NumberOfResult { get; set; }
            public Amazon.BedrockAgentRuntime.SearchType VectorSearchConfiguration_OverrideSearchType { get; set; }
            public Amazon.BedrockAgentRuntime.RerankingMetadataSelectionMode MetadataConfiguration_SelectionMode { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.FieldForReranking> SelectiveModeConfiguration_FieldsToExclude { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.FieldForReranking> SelectiveModeConfiguration_FieldsToInclude { get; set; }
            public Dictionary<System.String, Amazon.Runtime.Documents.Document> ModelConfiguration_AdditionalModelRequestField { get; set; }
            public System.String ModelConfiguration_ModelArn { get; set; }
            public System.Int32? BedrockRerankingConfiguration_NumberOfRerankedResult { get; set; }
            public Amazon.BedrockAgentRuntime.VectorSearchRerankingConfigurationType RerankingConfiguration_Type { get; set; }
            public Amazon.BedrockAgentRuntime.InputImageFormat Image_Format { get; set; }
            public byte[] Image_InlineContent { get; set; }
            public System.String RetrievalQuery_Text { get; set; }
            public Amazon.BedrockAgentRuntime.KnowledgeBaseQueryType RetrievalQuery_Type { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.RetrieveResponse, InvokeBARRetrieveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
