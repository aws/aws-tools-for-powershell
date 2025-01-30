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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Connects a knowledge base to a data source. You specify the configuration for the
    /// specific data source service in the <c>dataSourceConfiguration</c> field.
    /// 
    ///  <important><para>
    /// You can't change the <c>chunkingConfiguration</c> after you create the data source
    /// connector.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "AABDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.DataSource")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock CreateDataSource API operation.", Operation = new[] {"CreateDataSource"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.CreateDataSourceResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.DataSource or Amazon.BedrockAgent.Model.CreateDataSourceResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.DataSource object.",
        "The service call response (type Amazon.BedrockAgent.Model.CreateDataSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAABDataSourceCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType
        /// <summary>
        /// <para>
        /// <para>The supported authentication type to authenticate and connect to your Confluence instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.ConfluenceAuthType")]
        public Amazon.BedrockAgent.ConfluenceAuthType DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType
        /// <summary>
        /// <para>
        /// <para>The supported authentication type to authenticate and connect to your Salesforce instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.SalesforceAuthType")]
        public Amazon.BedrockAgent.SalesforceAuthType DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType
        /// <summary>
        /// <para>
        /// <para>The supported authentication type to authenticate and connect to your SharePoint site/sites.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.SharePointAuthType")]
        public Amazon.BedrockAgent.SharePointAuthType DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType { get; set; }
        #endregion
        
        #region Parameter SemanticChunkingConfiguration_BreakpointPercentileThreshold
        /// <summary>
        /// <para>
        /// <para>The dissimilarity threshold for splitting chunks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_BreakpointPercentileThreshold")]
        public System.Int32? SemanticChunkingConfiguration_BreakpointPercentileThreshold { get; set; }
        #endregion
        
        #region Parameter S3Configuration_BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the S3 bucket that contains your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_S3Configuration_BucketArn")]
        public System.String S3Configuration_BucketArn { get; set; }
        #endregion
        
        #region Parameter S3Configuration_BucketOwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID for the owner of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_S3Configuration_BucketOwnerAccountId")]
        public System.String S3Configuration_BucketOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter SemanticChunkingConfiguration_BufferSize
        /// <summary>
        /// <para>
        /// <para>The buffer size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_BufferSize")]
        public System.Int32? SemanticChunkingConfiguration_BufferSize { get; set; }
        #endregion
        
        #region Parameter ChunkingConfiguration_ChunkingStrategy
        /// <summary>
        /// <para>
        /// <para>Knowledge base can split your source data into chunks. A <i>chunk</i> refers to an
        /// excerpt from a data source that is returned when the knowledge base that it belongs
        /// to is queried. You have the following options for chunking your data. If you opt for
        /// <c>NONE</c>, then you may want to pre-process your files by splitting them up such
        /// that each file corresponds to a chunk.</para><ul><li><para><c>FIXED_SIZE</c> – Amazon Bedrock splits your source data into chunks of the approximate
        /// size that you set in the <c>fixedSizeChunkingConfiguration</c>.</para></li><li><para><c>HIERARCHICAL</c> – Split documents into layers of chunks where the first layer
        /// contains large chunks, and the second layer contains smaller chunks derived from the
        /// first layer.</para></li><li><para><c>SEMANTIC</c> – Split documents into chunks based on groups of similar content
        /// derived with natural language processing.</para></li><li><para><c>NONE</c> – Amazon Bedrock treats each file as one chunk. If you choose this option,
        /// you may want to pre-process your documents by splitting them into separate files.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_ChunkingStrategy")]
        [AWSConstantClassSource("Amazon.BedrockAgent.ChunkingStrategy")]
        public Amazon.BedrockAgent.ChunkingStrategy ChunkingConfiguration_ChunkingStrategy { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of an Secrets Manager secret that stores your authentication
        /// credentials for your Confluence instance URL. For more information on the key-value
        /// pairs that must be included in your secret, depending on your authentication type,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/confluence-data-source-connector.html#configuration-confluence-connector">Confluence
        /// connection configuration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of an Secrets Manager secret that stores your authentication
        /// credentials for your Salesforce instance URL. For more information on the key-value
        /// pairs that must be included in your secret, depending on your authentication type,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/salesforce-data-source-connector.html#configuration-salesforce-connector">Salesforce
        /// connection configuration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of an Secrets Manager secret that stores your authentication
        /// credentials for your SharePoint site/sites. For more information on the key-value
        /// pairs that must be included in your secret, depending on your authentication type,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/sharepoint-data-source-connector.html#configuration-sharepoint-connector">SharePoint
        /// connection configuration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter DataDeletionPolicy
        /// <summary>
        /// <para>
        /// <para>The data deletion policy for the data source.</para><para>You can set the data deletion policy to:</para><ul><li><para>DELETE: Deletes all data from your data source that’s converted into vector embeddings
        /// upon deletion of a knowledge base or data source resource. Note that the <b>vector
        /// store itself is not deleted</b>, only the data. This flag is ignored if an Amazon
        /// Web Services account is deleted.</para></li><li><para>RETAIN: Retains all data from your data source that’s converted into vector embeddings
        /// upon deletion of a knowledge base or data source resource. Note that the <b>vector
        /// store itself is not deleted</b> if you delete a knowledge base or data source resource.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.DataDeletionPolicy")]
        public Amazon.BedrockAgent.DataDeletionPolicy DataDeletionPolicy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_Domain
        /// <summary>
        /// <para>
        /// <para>The domain of your SharePoint instance or site URL/URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_Domain")]
        public System.String SourceConfiguration_Domain { get; set; }
        #endregion
        
        #region Parameter CrawlerConfiguration_ExclusionFilter
        /// <summary>
        /// <para>
        /// <para>A list of one or more exclusion regular expression patterns to exclude certain URLs.
        /// If you specify an inclusion and exclusion filter/pattern and both match a URL, the
        /// exclusion filter takes precedence and the web content of the URL isn’t crawled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_CrawlerConfiguration_ExclusionFilters")]
        public System.String[] CrawlerConfiguration_ExclusionFilter { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters
        /// <summary>
        /// <para>
        /// <para>The configuration of specific filters applied to your data source content. You can
        /// filter out or include certain content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgent.Model.PatternObjectFilter[] DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters
        /// <summary>
        /// <para>
        /// <para>The configuration of specific filters applied to your data source content. You can
        /// filter out or include certain content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgent.Model.PatternObjectFilter[] DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters
        /// <summary>
        /// <para>
        /// <para>The configuration of specific filters applied to your data source content. You can
        /// filter out or include certain content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgent.Model.PatternObjectFilter[] DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType
        /// <summary>
        /// <para>
        /// <para>The supported host type, whether online/cloud or server/on-premises.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.ConfluenceHostType")]
        public Amazon.BedrockAgent.ConfluenceHostType DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType
        /// <summary>
        /// <para>
        /// <para>The supported host type, whether online/cloud or server/on-premises.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.SharePointHostType")]
        public Amazon.BedrockAgent.SharePointHostType DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl
        /// <summary>
        /// <para>
        /// <para>The Confluence host URL or instance URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl
        /// <summary>
        /// <para>
        /// <para>The Salesforce host URL or instance URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl { get; set; }
        #endregion
        
        #region Parameter CrawlerConfiguration_InclusionFilter
        /// <summary>
        /// <para>
        /// <para>A list of one or more inclusion regular expression patterns to include certain URLs.
        /// If you specify an inclusion and exclusion filter/pattern and both match a URL, the
        /// exclusion filter takes precedence and the web content of the URL isn’t crawled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_CrawlerConfiguration_InclusionFilters")]
        public System.String[] CrawlerConfiguration_InclusionFilter { get; set; }
        #endregion
        
        #region Parameter S3Configuration_InclusionPrefix
        /// <summary>
        /// <para>
        /// <para>A list of S3 prefixes to include certain files or content. For more information, see
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-prefixes.html">Organizing
        /// objects using prefixes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_S3Configuration_InclusionPrefixes")]
        public System.String[] S3Configuration_InclusionPrefix { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the knowledge base to which to add the data source.</para>
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
        
        #region Parameter HierarchicalChunkingConfiguration_LevelConfiguration
        /// <summary>
        /// <para>
        /// <para>Token settings for each layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_LevelConfigurations")]
        public Amazon.BedrockAgent.Model.HierarchicalChunkingLevelConfiguration[] HierarchicalChunkingConfiguration_LevelConfiguration { get; set; }
        #endregion
        
        #region Parameter CrawlerLimits_MaxPage
        /// <summary>
        /// <para>
        /// <para> The max number of web pages crawled from your source URLs, up to 25,000 pages. If
        /// the web pages exceed this limit, the data source sync will fail and no web pages will
        /// be ingested. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_MaxPages")]
        public System.Int32? CrawlerLimits_MaxPage { get; set; }
        #endregion
        
        #region Parameter FixedSizeChunkingConfiguration_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to include in a chunk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_MaxTokens")]
        public System.Int32? FixedSizeChunkingConfiguration_MaxToken { get; set; }
        #endregion
        
        #region Parameter SemanticChunkingConfiguration_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens that a chunk can contain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_MaxTokens")]
        public System.Int32? SemanticChunkingConfiguration_MaxToken { get; set; }
        #endregion
        
        #region Parameter BedrockFoundationModelConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the foundation model or <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/cross-region-inference.html">inference
        /// profile</a> to use for parsing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ModelArn")]
        public System.String BedrockFoundationModelConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the data source.</para>
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
        
        #region Parameter FixedSizeChunkingConfiguration_OverlapPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of overlap between adjacent chunks of a data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_OverlapPercentage")]
        public System.Int32? FixedSizeChunkingConfiguration_OverlapPercentage { get; set; }
        #endregion
        
        #region Parameter HierarchicalChunkingConfiguration_OverlapToken
        /// <summary>
        /// <para>
        /// <para>The number of tokens to repeat across chunks in the same layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_OverlapTokens")]
        public System.Int32? HierarchicalChunkingConfiguration_OverlapToken { get; set; }
        #endregion
        
        #region Parameter BedrockDataAutomationConfiguration_ParsingModality
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable parsing of multimodal data, including both text and/or
        /// images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration_ParsingModality")]
        [AWSConstantClassSource("Amazon.BedrockAgent.ParsingModality")]
        public Amazon.BedrockAgent.ParsingModality BedrockDataAutomationConfiguration_ParsingModality { get; set; }
        #endregion
        
        #region Parameter BedrockFoundationModelConfiguration_ParsingModality
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable parsing of multimodal data, including both text and/or
        /// images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingModality")]
        [AWSConstantClassSource("Amazon.BedrockAgent.ParsingModality")]
        public Amazon.BedrockAgent.ParsingModality BedrockFoundationModelConfiguration_ParsingModality { get; set; }
        #endregion
        
        #region Parameter ParsingPrompt_ParsingPromptText
        /// <summary>
        /// <para>
        /// <para>Instructions for interpreting the contents of a document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt_ParsingPromptText")]
        public System.String ParsingPrompt_ParsingPromptText { get; set; }
        #endregion
        
        #region Parameter ParsingConfiguration_ParsingStrategy
        /// <summary>
        /// <para>
        /// <para>The parsing strategy for the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ParsingConfiguration_ParsingStrategy")]
        [AWSConstantClassSource("Amazon.BedrockAgent.ParsingStrategy")]
        public Amazon.BedrockAgent.ParsingStrategy ParsingConfiguration_ParsingStrategy { get; set; }
        #endregion
        
        #region Parameter CrawlerLimits_RateLimit
        /// <summary>
        /// <para>
        /// <para>The max rate at which pages are crawled, up to 300 per minute per host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_RateLimit")]
        public System.Int32? CrawlerLimits_RateLimit { get; set; }
        #endregion
        
        #region Parameter CrawlerConfiguration_Scope
        /// <summary>
        /// <para>
        /// <para>The scope of what is crawled for your URLs.</para><para>You can choose to crawl only web pages that belong to the same host or primary domain.
        /// For example, only web pages that contain the seed URL "https://docs.aws.amazon.com/bedrock/latest/userguide/"
        /// and no other domains. You can choose to include sub domains in addition to the host
        /// or primary domain. For example, web pages that contain "aws.amazon.com" can also include
        /// sub domain "docs.aws.amazon.com".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_CrawlerConfiguration_Scope")]
        [AWSConstantClassSource("Amazon.BedrockAgent.WebScopeType")]
        public Amazon.BedrockAgent.WebScopeType CrawlerConfiguration_Scope { get; set; }
        #endregion
        
        #region Parameter UrlConfiguration_SeedUrl
        /// <summary>
        /// <para>
        /// <para>One or more seed or starting point URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration_SeedUrls")]
        public Amazon.BedrockAgent.Model.SeedUrl[] UrlConfiguration_SeedUrl { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_SiteUrl
        /// <summary>
        /// <para>
        /// <para>A list of one or more SharePoint site URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_SiteUrls")]
        public System.String[] SourceConfiguration_SiteUrl { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_TenantId
        /// <summary>
        /// <para>
        /// <para>The identifier of your Microsoft 365 tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_TenantId")]
        public System.String SourceConfiguration_TenantId { get; set; }
        #endregion
        
        #region Parameter CustomTransformationConfiguration_Transformation
        /// <summary>
        /// <para>
        /// <para>A Lambda function that processes documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_CustomTransformationConfiguration_Transformations")]
        public Amazon.BedrockAgent.Model.Transformation[] CustomTransformationConfiguration_Transformation { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of filtering that you want to apply to certain objects or content of the
        /// data source. For example, the <c>PATTERN</c> type is regular expression patterns you
        /// can apply to filter your content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.CrawlFilterConfigurationType")]
        public Amazon.BedrockAgent.CrawlFilterConfigurationType DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of filtering that you want to apply to certain objects or content of the
        /// data source. For example, the <c>PATTERN</c> type is regular expression patterns you
        /// can apply to filter your content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.CrawlFilterConfigurationType")]
        public Amazon.BedrockAgent.CrawlFilterConfigurationType DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of filtering that you want to apply to certain objects or content of the
        /// data source. For example, the <c>PATTERN</c> type is regular expression patterns you
        /// can apply to filter your content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.CrawlFilterConfigurationType")]
        public Amazon.BedrockAgent.CrawlFilterConfigurationType DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of data source.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgent.DataSourceType")]
        public Amazon.BedrockAgent.DataSourceType DataSourceConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter S3Location_Uri
        /// <summary>
        /// <para>
        /// <para>The location's URI. For example, <c>s3://my-bucket/chunk-processor/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location_Uri")]
        public System.String S3Location_Uri { get; set; }
        #endregion
        
        #region Parameter CrawlerConfiguration_UserAgent
        /// <summary>
        /// <para>
        /// <para>A string used for identifying the crawler or a bot when it accesses a web server.
        /// By default, this is set to <c>bedrockbot_UUID</c> for your crawler. You can optionally
        /// append a custom string to <c>bedrockbot_UUID</c> to allowlist a specific user agent
        /// permitted to access your source URLs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_WebConfiguration_CrawlerConfiguration_UserAgent")]
        public System.String CrawlerConfiguration_UserAgent { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.CreateDataSourceResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.CreateDataSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSource";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KnowledgeBaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AABDataSource (CreateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.CreateDataSourceResponse, NewAABDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KnowledgeBaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DataDeletionPolicy = this.DataDeletionPolicy;
            if (this.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                context.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = new List<Amazon.BedrockAgent.Model.PatternObjectFilter>(this.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters);
            }
            context.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type = this.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
            context.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType = this.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType;
            context.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn = this.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn;
            context.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType = this.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType;
            context.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl = this.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl;
            context.S3Configuration_BucketArn = this.S3Configuration_BucketArn;
            context.S3Configuration_BucketOwnerAccountId = this.S3Configuration_BucketOwnerAccountId;
            if (this.S3Configuration_InclusionPrefix != null)
            {
                context.S3Configuration_InclusionPrefix = new List<System.String>(this.S3Configuration_InclusionPrefix);
            }
            if (this.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                context.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = new List<Amazon.BedrockAgent.Model.PatternObjectFilter>(this.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters);
            }
            context.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type = this.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
            context.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType = this.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType;
            context.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn = this.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn;
            context.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl = this.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl;
            if (this.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                context.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = new List<Amazon.BedrockAgent.Model.PatternObjectFilter>(this.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters);
            }
            context.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type = this.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
            context.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType = this.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType;
            context.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn = this.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn;
            context.SourceConfiguration_Domain = this.SourceConfiguration_Domain;
            context.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType = this.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType;
            if (this.SourceConfiguration_SiteUrl != null)
            {
                context.SourceConfiguration_SiteUrl = new List<System.String>(this.SourceConfiguration_SiteUrl);
            }
            context.SourceConfiguration_TenantId = this.SourceConfiguration_TenantId;
            context.DataSourceConfiguration_Type = this.DataSourceConfiguration_Type;
            #if MODULAR
            if (this.DataSourceConfiguration_Type == null && ParameterWasBound(nameof(this.DataSourceConfiguration_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceConfiguration_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CrawlerLimits_MaxPage = this.CrawlerLimits_MaxPage;
            context.CrawlerLimits_RateLimit = this.CrawlerLimits_RateLimit;
            if (this.CrawlerConfiguration_ExclusionFilter != null)
            {
                context.CrawlerConfiguration_ExclusionFilter = new List<System.String>(this.CrawlerConfiguration_ExclusionFilter);
            }
            if (this.CrawlerConfiguration_InclusionFilter != null)
            {
                context.CrawlerConfiguration_InclusionFilter = new List<System.String>(this.CrawlerConfiguration_InclusionFilter);
            }
            context.CrawlerConfiguration_Scope = this.CrawlerConfiguration_Scope;
            context.CrawlerConfiguration_UserAgent = this.CrawlerConfiguration_UserAgent;
            if (this.UrlConfiguration_SeedUrl != null)
            {
                context.UrlConfiguration_SeedUrl = new List<Amazon.BedrockAgent.Model.SeedUrl>(this.UrlConfiguration_SeedUrl);
            }
            context.Description = this.Description;
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerSideEncryptionConfiguration_KmsKeyArn = this.ServerSideEncryptionConfiguration_KmsKeyArn;
            context.ChunkingConfiguration_ChunkingStrategy = this.ChunkingConfiguration_ChunkingStrategy;
            context.FixedSizeChunkingConfiguration_MaxToken = this.FixedSizeChunkingConfiguration_MaxToken;
            context.FixedSizeChunkingConfiguration_OverlapPercentage = this.FixedSizeChunkingConfiguration_OverlapPercentage;
            if (this.HierarchicalChunkingConfiguration_LevelConfiguration != null)
            {
                context.HierarchicalChunkingConfiguration_LevelConfiguration = new List<Amazon.BedrockAgent.Model.HierarchicalChunkingLevelConfiguration>(this.HierarchicalChunkingConfiguration_LevelConfiguration);
            }
            context.HierarchicalChunkingConfiguration_OverlapToken = this.HierarchicalChunkingConfiguration_OverlapToken;
            context.SemanticChunkingConfiguration_BreakpointPercentileThreshold = this.SemanticChunkingConfiguration_BreakpointPercentileThreshold;
            context.SemanticChunkingConfiguration_BufferSize = this.SemanticChunkingConfiguration_BufferSize;
            context.SemanticChunkingConfiguration_MaxToken = this.SemanticChunkingConfiguration_MaxToken;
            context.S3Location_Uri = this.S3Location_Uri;
            if (this.CustomTransformationConfiguration_Transformation != null)
            {
                context.CustomTransformationConfiguration_Transformation = new List<Amazon.BedrockAgent.Model.Transformation>(this.CustomTransformationConfiguration_Transformation);
            }
            context.BedrockDataAutomationConfiguration_ParsingModality = this.BedrockDataAutomationConfiguration_ParsingModality;
            context.BedrockFoundationModelConfiguration_ModelArn = this.BedrockFoundationModelConfiguration_ModelArn;
            context.BedrockFoundationModelConfiguration_ParsingModality = this.BedrockFoundationModelConfiguration_ParsingModality;
            context.ParsingPrompt_ParsingPromptText = this.ParsingPrompt_ParsingPromptText;
            context.ParsingConfiguration_ParsingStrategy = this.ParsingConfiguration_ParsingStrategy;
            
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
            var request = new Amazon.BedrockAgent.Model.CreateDataSourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataDeletionPolicy != null)
            {
                request.DataDeletionPolicy = cmdletContext.DataDeletionPolicy;
            }
            
             // populate DataSourceConfiguration
            var requestDataSourceConfigurationIsNull = true;
            request.DataSourceConfiguration = new Amazon.BedrockAgent.Model.DataSourceConfiguration();
            Amazon.BedrockAgent.DataSourceType requestDataSourceConfiguration_dataSourceConfiguration_Type = null;
            if (cmdletContext.DataSourceConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_Type = cmdletContext.DataSourceConfiguration_Type;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_Type != null)
            {
                request.DataSourceConfiguration.Type = requestDataSourceConfiguration_dataSourceConfiguration_Type;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.ConfluenceDataSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration = null;
            
             // populate ConfluenceConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration = new Amazon.BedrockAgent.Model.ConfluenceDataSourceConfiguration();
            Amazon.BedrockAgent.Model.ConfluenceCrawlerConfiguration requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration = null;
            
             // populate CrawlerConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration = new Amazon.BedrockAgent.Model.ConfluenceCrawlerConfiguration();
            Amazon.BedrockAgent.Model.CrawlFilterConfiguration requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration = null;
            
             // populate FilterConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration = new Amazon.BedrockAgent.Model.CrawlFilterConfiguration();
            Amazon.BedrockAgent.CrawlFilterConfigurationType requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type = null;
            if (cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type = cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration.Type = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.PatternObjectFilterConfiguration requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = null;
            
             // populate PatternObjectFilter
            var requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = new Amazon.BedrockAgent.Model.PatternObjectFilterConfiguration();
            List<Amazon.BedrockAgent.Model.PatternObjectFilter> requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = null;
            if (cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter.Filters = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration.PatternObjectFilter = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration.FilterConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration.CrawlerConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.ConfluenceSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration = null;
            
             // populate SourceConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration = new Amazon.BedrockAgent.Model.ConfluenceSourceConfiguration();
            Amazon.BedrockAgent.ConfluenceAuthType requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType = null;
            if (cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType = cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration.AuthType = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn = cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration.CredentialsSecretArn = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.ConfluenceHostType requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType = null;
            if (cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType = cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration.HostType = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl = null;
            if (cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl = cmdletContext.DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration.HostUrl = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration.SourceConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_dataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration != null)
            {
                request.DataSourceConfiguration.ConfluenceConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_ConfluenceConfiguration;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SalesforceDataSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration = null;
            
             // populate SalesforceConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration = new Amazon.BedrockAgent.Model.SalesforceDataSourceConfiguration();
            Amazon.BedrockAgent.Model.SalesforceCrawlerConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration = null;
            
             // populate CrawlerConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration = new Amazon.BedrockAgent.Model.SalesforceCrawlerConfiguration();
            Amazon.BedrockAgent.Model.CrawlFilterConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration = null;
            
             // populate FilterConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration = new Amazon.BedrockAgent.Model.CrawlFilterConfiguration();
            Amazon.BedrockAgent.CrawlFilterConfigurationType requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type = null;
            if (cmdletContext.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type = cmdletContext.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration.Type = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.PatternObjectFilterConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = null;
            
             // populate PatternObjectFilter
            var requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = new Amazon.BedrockAgent.Model.PatternObjectFilterConfiguration();
            List<Amazon.BedrockAgent.Model.PatternObjectFilter> requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = null;
            if (cmdletContext.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = cmdletContext.DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter.Filters = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration.PatternObjectFilter = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration.FilterConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration.CrawlerConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SalesforceSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration = null;
            
             // populate SourceConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration = new Amazon.BedrockAgent.Model.SalesforceSourceConfiguration();
            Amazon.BedrockAgent.SalesforceAuthType requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType = null;
            if (cmdletContext.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType = cmdletContext.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration.AuthType = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn = cmdletContext.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration.CredentialsSecretArn = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl = null;
            if (cmdletContext.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl = cmdletContext.DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration.HostUrl = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration.SourceConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration_dataSourceConfiguration_SalesforceConfiguration_SourceConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration != null)
            {
                request.DataSourceConfiguration.SalesforceConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SalesforceConfiguration;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SharePointDataSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration = null;
            
             // populate SharePointConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration = new Amazon.BedrockAgent.Model.SharePointDataSourceConfiguration();
            Amazon.BedrockAgent.Model.SharePointCrawlerConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration = null;
            
             // populate CrawlerConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration = new Amazon.BedrockAgent.Model.SharePointCrawlerConfiguration();
            Amazon.BedrockAgent.Model.CrawlFilterConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration = null;
            
             // populate FilterConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration = new Amazon.BedrockAgent.Model.CrawlFilterConfiguration();
            Amazon.BedrockAgent.CrawlFilterConfigurationType requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type = null;
            if (cmdletContext.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type = cmdletContext.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration.Type = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.PatternObjectFilterConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = null;
            
             // populate PatternObjectFilter
            var requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = new Amazon.BedrockAgent.Model.PatternObjectFilterConfiguration();
            List<Amazon.BedrockAgent.Model.PatternObjectFilter> requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = null;
            if (cmdletContext.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters = cmdletContext.DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter.Filters = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilterIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration.PatternObjectFilter = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration.FilterConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration.CrawlerConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SharePointSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration = null;
            
             // populate SourceConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration = new Amazon.BedrockAgent.Model.SharePointSourceConfiguration();
            Amazon.BedrockAgent.SharePointAuthType requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType = null;
            if (cmdletContext.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType = cmdletContext.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration.AuthType = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn = cmdletContext.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration.CredentialsSecretArn = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_Domain = null;
            if (cmdletContext.SourceConfiguration_Domain != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_Domain = cmdletContext.SourceConfiguration_Domain;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_Domain != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration.Domain = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_Domain;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.SharePointHostType requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType = null;
            if (cmdletContext.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType = cmdletContext.DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration.HostType = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = false;
            }
            List<System.String> requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_SiteUrl = null;
            if (cmdletContext.SourceConfiguration_SiteUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_SiteUrl = cmdletContext.SourceConfiguration_SiteUrl;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_SiteUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration.SiteUrls = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_SiteUrl;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_TenantId = null;
            if (cmdletContext.SourceConfiguration_TenantId != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_TenantId = cmdletContext.SourceConfiguration_TenantId;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_TenantId != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration.TenantId = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration_sourceConfiguration_TenantId;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration.SourceConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration_dataSourceConfiguration_SharePointConfiguration_SourceConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration != null)
            {
                request.DataSourceConfiguration.SharePointConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_SharePointConfiguration;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.WebDataSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration = null;
            
             // populate WebConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_WebConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration = new Amazon.BedrockAgent.Model.WebDataSourceConfiguration();
            Amazon.BedrockAgent.Model.WebSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration = null;
            
             // populate SourceConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration = new Amazon.BedrockAgent.Model.WebSourceConfiguration();
            Amazon.BedrockAgent.Model.UrlConfiguration requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration = null;
            
             // populate UrlConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration = new Amazon.BedrockAgent.Model.UrlConfiguration();
            List<Amazon.BedrockAgent.Model.SeedUrl> requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration_urlConfiguration_SeedUrl = null;
            if (cmdletContext.UrlConfiguration_SeedUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration_urlConfiguration_SeedUrl = cmdletContext.UrlConfiguration_SeedUrl;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration_urlConfiguration_SeedUrl != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration.SeedUrls = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration_urlConfiguration_SeedUrl;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration.UrlConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration_UrlConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration.SourceConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_SourceConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.WebCrawlerConfiguration requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration = null;
            
             // populate CrawlerConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration = new Amazon.BedrockAgent.Model.WebCrawlerConfiguration();
            List<System.String> requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_ExclusionFilter = null;
            if (cmdletContext.CrawlerConfiguration_ExclusionFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_ExclusionFilter = cmdletContext.CrawlerConfiguration_ExclusionFilter;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_ExclusionFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration.ExclusionFilters = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_ExclusionFilter;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull = false;
            }
            List<System.String> requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_InclusionFilter = null;
            if (cmdletContext.CrawlerConfiguration_InclusionFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_InclusionFilter = cmdletContext.CrawlerConfiguration_InclusionFilter;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_InclusionFilter != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration.InclusionFilters = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_InclusionFilter;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.WebScopeType requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_Scope = null;
            if (cmdletContext.CrawlerConfiguration_Scope != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_Scope = cmdletContext.CrawlerConfiguration_Scope;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_Scope != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration.Scope = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_Scope;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_UserAgent = null;
            if (cmdletContext.CrawlerConfiguration_UserAgent != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_UserAgent = cmdletContext.CrawlerConfiguration_UserAgent;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_UserAgent != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration.UserAgent = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_crawlerConfiguration_UserAgent;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.WebCrawlerLimits requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits = null;
            
             // populate CrawlerLimits
            var requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimitsIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits = new Amazon.BedrockAgent.Model.WebCrawlerLimits();
            System.Int32? requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_MaxPage = null;
            if (cmdletContext.CrawlerLimits_MaxPage != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_MaxPage = cmdletContext.CrawlerLimits_MaxPage.Value;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_MaxPage != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits.MaxPages = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_MaxPage.Value;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimitsIsNull = false;
            }
            System.Int32? requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit = null;
            if (cmdletContext.CrawlerLimits_RateLimit != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit = cmdletContext.CrawlerLimits_RateLimit.Value;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits.RateLimit = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit.Value;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimitsIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimitsIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration.CrawlerLimits = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration_CrawlerLimits;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration.CrawlerConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration_dataSourceConfiguration_WebConfiguration_CrawlerConfiguration;
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration != null)
            {
                request.DataSourceConfiguration.WebConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_WebConfiguration;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.S3DataSourceConfiguration requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestDataSourceConfiguration_dataSourceConfiguration_S3ConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration = new Amazon.BedrockAgent.Model.S3DataSourceConfiguration();
            System.String requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketArn = null;
            if (cmdletContext.S3Configuration_BucketArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketArn = cmdletContext.S3Configuration_BucketArn;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketArn != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration.BucketArn = requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketArn;
                requestDataSourceConfiguration_dataSourceConfiguration_S3ConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketOwnerAccountId = null;
            if (cmdletContext.S3Configuration_BucketOwnerAccountId != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketOwnerAccountId = cmdletContext.S3Configuration_BucketOwnerAccountId;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketOwnerAccountId != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration.BucketOwnerAccountId = requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_BucketOwnerAccountId;
                requestDataSourceConfiguration_dataSourceConfiguration_S3ConfigurationIsNull = false;
            }
            List<System.String> requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_InclusionPrefix = null;
            if (cmdletContext.S3Configuration_InclusionPrefix != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_InclusionPrefix = cmdletContext.S3Configuration_InclusionPrefix;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_InclusionPrefix != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration.InclusionPrefixes = requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration_s3Configuration_InclusionPrefix;
                requestDataSourceConfiguration_dataSourceConfiguration_S3ConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_S3ConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration != null)
            {
                request.DataSourceConfiguration.S3Configuration = requestDataSourceConfiguration_dataSourceConfiguration_S3Configuration;
                requestDataSourceConfigurationIsNull = false;
            }
             // determine if request.DataSourceConfiguration should be set to null
            if (requestDataSourceConfigurationIsNull)
            {
                request.DataSourceConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ServerSideEncryptionConfiguration
            var requestServerSideEncryptionConfigurationIsNull = true;
            request.ServerSideEncryptionConfiguration = new Amazon.BedrockAgent.Model.ServerSideEncryptionConfiguration();
            System.String requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.ServerSideEncryptionConfiguration_KmsKeyArn != null)
            {
                requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn = cmdletContext.ServerSideEncryptionConfiguration_KmsKeyArn;
            }
            if (requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn != null)
            {
                request.ServerSideEncryptionConfiguration.KmsKeyArn = requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn;
                requestServerSideEncryptionConfigurationIsNull = false;
            }
             // determine if request.ServerSideEncryptionConfiguration should be set to null
            if (requestServerSideEncryptionConfigurationIsNull)
            {
                request.ServerSideEncryptionConfiguration = null;
            }
            
             // populate VectorIngestionConfiguration
            var requestVectorIngestionConfigurationIsNull = true;
            request.VectorIngestionConfiguration = new Amazon.BedrockAgent.Model.VectorIngestionConfiguration();
            Amazon.BedrockAgent.Model.CustomTransformationConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration = null;
            
             // populate CustomTransformationConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration = new Amazon.BedrockAgent.Model.CustomTransformationConfiguration();
            List<Amazon.BedrockAgent.Model.Transformation> requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_customTransformationConfiguration_Transformation = null;
            if (cmdletContext.CustomTransformationConfiguration_Transformation != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_customTransformationConfiguration_Transformation = cmdletContext.CustomTransformationConfiguration_Transformation;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_customTransformationConfiguration_Transformation != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration.Transformations = requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_customTransformationConfiguration_Transformation;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.IntermediateStorage requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage = null;
            
             // populate IntermediateStorage
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorageIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage = new Amazon.BedrockAgent.Model.IntermediateStorage();
            Amazon.BedrockAgent.Model.S3Location requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location = null;
            
             // populate S3Location
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3LocationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location = new Amazon.BedrockAgent.Model.S3Location();
            System.String requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location_s3Location_Uri = null;
            if (cmdletContext.S3Location_Uri != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location_s3Location_Uri = cmdletContext.S3Location_Uri;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location_s3Location_Uri != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location.Uri = requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location_s3Location_Uri;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3LocationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3LocationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage.S3Location = requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage_S3Location;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorageIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorageIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration.IntermediateStorage = requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration_IntermediateStorage;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration != null)
            {
                request.VectorIngestionConfiguration.CustomTransformationConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_CustomTransformationConfiguration;
                requestVectorIngestionConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.ParsingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration = null;
            
             // populate ParsingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration = new Amazon.BedrockAgent.Model.ParsingConfiguration();
            Amazon.BedrockAgent.ParsingStrategy requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy = null;
            if (cmdletContext.ParsingConfiguration_ParsingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy = cmdletContext.ParsingConfiguration_ParsingStrategy;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration.ParsingStrategy = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.BedrockDataAutomationConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration = null;
            
             // populate BedrockDataAutomationConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration = new Amazon.BedrockAgent.Model.BedrockDataAutomationConfiguration();
            Amazon.BedrockAgent.ParsingModality requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration_bedrockDataAutomationConfiguration_ParsingModality = null;
            if (cmdletContext.BedrockDataAutomationConfiguration_ParsingModality != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration_bedrockDataAutomationConfiguration_ParsingModality = cmdletContext.BedrockDataAutomationConfiguration_ParsingModality;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration_bedrockDataAutomationConfiguration_ParsingModality != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration.ParsingModality = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration_bedrockDataAutomationConfiguration_ParsingModality;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration.BedrockDataAutomationConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockDataAutomationConfiguration;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.BedrockFoundationModelConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration = null;
            
             // populate BedrockFoundationModelConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration = new Amazon.BedrockAgent.Model.BedrockFoundationModelConfiguration();
            System.String requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ModelArn = null;
            if (cmdletContext.BedrockFoundationModelConfiguration_ModelArn != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ModelArn = cmdletContext.BedrockFoundationModelConfiguration_ModelArn;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ModelArn != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration.ModelArn = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ModelArn;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.ParsingModality requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ParsingModality = null;
            if (cmdletContext.BedrockFoundationModelConfiguration_ParsingModality != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ParsingModality = cmdletContext.BedrockFoundationModelConfiguration_ParsingModality;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ParsingModality != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration.ParsingModality = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_bedrockFoundationModelConfiguration_ParsingModality;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.ParsingPrompt requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt = null;
            
             // populate ParsingPrompt
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPromptIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt = new Amazon.BedrockAgent.Model.ParsingPrompt();
            System.String requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt_parsingPrompt_ParsingPromptText = null;
            if (cmdletContext.ParsingPrompt_ParsingPromptText != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt_parsingPrompt_ParsingPromptText = cmdletContext.ParsingPrompt_ParsingPromptText;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt_parsingPrompt_ParsingPromptText != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt.ParsingPromptText = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt_parsingPrompt_ParsingPromptText;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPromptIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPromptIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration.ParsingPrompt = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration.BedrockFoundationModelConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration != null)
            {
                request.VectorIngestionConfiguration.ParsingConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration;
                requestVectorIngestionConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.ChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration = null;
            
             // populate ChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration = new Amazon.BedrockAgent.Model.ChunkingConfiguration();
            Amazon.BedrockAgent.ChunkingStrategy requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy = null;
            if (cmdletContext.ChunkingConfiguration_ChunkingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy = cmdletContext.ChunkingConfiguration_ChunkingStrategy;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration.ChunkingStrategy = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.FixedSizeChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration = null;
            
             // populate FixedSizeChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration = new Amazon.BedrockAgent.Model.FixedSizeChunkingConfiguration();
            System.Int32? requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_MaxToken = null;
            if (cmdletContext.FixedSizeChunkingConfiguration_MaxToken != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_MaxToken = cmdletContext.FixedSizeChunkingConfiguration_MaxToken.Value;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_MaxToken != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration.MaxTokens = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_MaxToken.Value;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfigurationIsNull = false;
            }
            System.Int32? requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_OverlapPercentage = null;
            if (cmdletContext.FixedSizeChunkingConfiguration_OverlapPercentage != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_OverlapPercentage = cmdletContext.FixedSizeChunkingConfiguration_OverlapPercentage.Value;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_OverlapPercentage != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration.OverlapPercentage = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration_fixedSizeChunkingConfiguration_OverlapPercentage.Value;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration.FixedSizeChunkingConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.HierarchicalChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration = null;
            
             // populate HierarchicalChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration = new Amazon.BedrockAgent.Model.HierarchicalChunkingConfiguration();
            List<Amazon.BedrockAgent.Model.HierarchicalChunkingLevelConfiguration> requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_LevelConfiguration = null;
            if (cmdletContext.HierarchicalChunkingConfiguration_LevelConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_LevelConfiguration = cmdletContext.HierarchicalChunkingConfiguration_LevelConfiguration;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_LevelConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration.LevelConfigurations = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_LevelConfiguration;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfigurationIsNull = false;
            }
            System.Int32? requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_OverlapToken = null;
            if (cmdletContext.HierarchicalChunkingConfiguration_OverlapToken != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_OverlapToken = cmdletContext.HierarchicalChunkingConfiguration_OverlapToken.Value;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_OverlapToken != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration.OverlapTokens = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_OverlapToken.Value;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration.HierarchicalChunkingConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SemanticChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration = null;
            
             // populate SemanticChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration = new Amazon.BedrockAgent.Model.SemanticChunkingConfiguration();
            System.Int32? requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BreakpointPercentileThreshold = null;
            if (cmdletContext.SemanticChunkingConfiguration_BreakpointPercentileThreshold != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BreakpointPercentileThreshold = cmdletContext.SemanticChunkingConfiguration_BreakpointPercentileThreshold.Value;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BreakpointPercentileThreshold != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration.BreakpointPercentileThreshold = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BreakpointPercentileThreshold.Value;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfigurationIsNull = false;
            }
            System.Int32? requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BufferSize = null;
            if (cmdletContext.SemanticChunkingConfiguration_BufferSize != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BufferSize = cmdletContext.SemanticChunkingConfiguration_BufferSize.Value;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BufferSize != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration.BufferSize = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_BufferSize.Value;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfigurationIsNull = false;
            }
            System.Int32? requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_MaxToken = null;
            if (cmdletContext.SemanticChunkingConfiguration_MaxToken != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_MaxToken = cmdletContext.SemanticChunkingConfiguration_MaxToken.Value;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_MaxToken != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration.MaxTokens = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration_semanticChunkingConfiguration_MaxToken.Value;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration.SemanticChunkingConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = false;
            }
             // determine if requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration should be set to null
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration = null;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration != null)
            {
                request.VectorIngestionConfiguration.ChunkingConfiguration = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration;
                requestVectorIngestionConfigurationIsNull = false;
            }
             // determine if request.VectorIngestionConfiguration should be set to null
            if (requestVectorIngestionConfigurationIsNull)
            {
                request.VectorIngestionConfiguration = null;
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
        
        private Amazon.BedrockAgent.Model.CreateDataSourceResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.CreateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "CreateDataSource");
            try
            {
                #if DESKTOP
                return client.CreateDataSource(request);
                #elif CORECLR
                return client.CreateDataSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.BedrockAgent.DataDeletionPolicy DataDeletionPolicy { get; set; }
            public List<Amazon.BedrockAgent.Model.PatternObjectFilter> DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters { get; set; }
            public Amazon.BedrockAgent.CrawlFilterConfigurationType DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type { get; set; }
            public Amazon.BedrockAgent.ConfluenceAuthType DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType { get; set; }
            public System.String DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn { get; set; }
            public Amazon.BedrockAgent.ConfluenceHostType DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType { get; set; }
            public System.String DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl { get; set; }
            public System.String S3Configuration_BucketArn { get; set; }
            public System.String S3Configuration_BucketOwnerAccountId { get; set; }
            public List<System.String> S3Configuration_InclusionPrefix { get; set; }
            public List<Amazon.BedrockAgent.Model.PatternObjectFilter> DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters { get; set; }
            public Amazon.BedrockAgent.CrawlFilterConfigurationType DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type { get; set; }
            public Amazon.BedrockAgent.SalesforceAuthType DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType { get; set; }
            public System.String DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn { get; set; }
            public System.String DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl { get; set; }
            public List<Amazon.BedrockAgent.Model.PatternObjectFilter> DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters { get; set; }
            public Amazon.BedrockAgent.CrawlFilterConfigurationType DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type { get; set; }
            public Amazon.BedrockAgent.SharePointAuthType DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType { get; set; }
            public System.String DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn { get; set; }
            public System.String SourceConfiguration_Domain { get; set; }
            public Amazon.BedrockAgent.SharePointHostType DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType { get; set; }
            public List<System.String> SourceConfiguration_SiteUrl { get; set; }
            public System.String SourceConfiguration_TenantId { get; set; }
            public Amazon.BedrockAgent.DataSourceType DataSourceConfiguration_Type { get; set; }
            public System.Int32? CrawlerLimits_MaxPage { get; set; }
            public System.Int32? CrawlerLimits_RateLimit { get; set; }
            public List<System.String> CrawlerConfiguration_ExclusionFilter { get; set; }
            public List<System.String> CrawlerConfiguration_InclusionFilter { get; set; }
            public Amazon.BedrockAgent.WebScopeType CrawlerConfiguration_Scope { get; set; }
            public System.String CrawlerConfiguration_UserAgent { get; set; }
            public List<Amazon.BedrockAgent.Model.SeedUrl> UrlConfiguration_SeedUrl { get; set; }
            public System.String Description { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String Name { get; set; }
            public System.String ServerSideEncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.BedrockAgent.ChunkingStrategy ChunkingConfiguration_ChunkingStrategy { get; set; }
            public System.Int32? FixedSizeChunkingConfiguration_MaxToken { get; set; }
            public System.Int32? FixedSizeChunkingConfiguration_OverlapPercentage { get; set; }
            public List<Amazon.BedrockAgent.Model.HierarchicalChunkingLevelConfiguration> HierarchicalChunkingConfiguration_LevelConfiguration { get; set; }
            public System.Int32? HierarchicalChunkingConfiguration_OverlapToken { get; set; }
            public System.Int32? SemanticChunkingConfiguration_BreakpointPercentileThreshold { get; set; }
            public System.Int32? SemanticChunkingConfiguration_BufferSize { get; set; }
            public System.Int32? SemanticChunkingConfiguration_MaxToken { get; set; }
            public System.String S3Location_Uri { get; set; }
            public List<Amazon.BedrockAgent.Model.Transformation> CustomTransformationConfiguration_Transformation { get; set; }
            public Amazon.BedrockAgent.ParsingModality BedrockDataAutomationConfiguration_ParsingModality { get; set; }
            public System.String BedrockFoundationModelConfiguration_ModelArn { get; set; }
            public Amazon.BedrockAgent.ParsingModality BedrockFoundationModelConfiguration_ParsingModality { get; set; }
            public System.String ParsingPrompt_ParsingPromptText { get; set; }
            public Amazon.BedrockAgent.ParsingStrategy ParsingConfiguration_ParsingStrategy { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.CreateDataSourceResponse, NewAABDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSource;
        }
        
    }
}
