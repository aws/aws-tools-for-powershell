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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates a knowledge base.
    /// 
    ///  <note><para>
    /// When using this API, you cannot reuse <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/Welcome.html">Amazon
    /// AppIntegrations</a> DataIntegrations with external knowledge bases such as Salesforce
    /// and ServiceNow. If you do, you'll get an <c>InvalidRequestException</c> error. 
    /// </para><para>
    /// For example, you're programmatically managing your external knowledge base, and you
    /// want to add or remove one of the fields that is being ingested from Salesforce. Do
    /// the following:
    /// </para><ol><li><para>
    /// Call <a href="https://docs.aws.amazon.com/amazon-q-connect/latest/APIReference/API_DeleteKnowledgeBase.html">DeleteKnowledgeBase</a>.
    /// </para></li><li><para>
    /// Call <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/API_DeleteDataIntegration.html">DeleteDataIntegration</a>.
    /// </para></li><li><para>
    /// Call <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/API_CreateDataIntegration.html">CreateDataIntegration</a>
    /// to recreate the DataIntegration or a create different one.
    /// </para></li><li><para>
    /// Call CreateKnowledgeBase.
    /// </para></li></ol></note>
    /// </summary>
    [Cmdlet("New", "QCKnowledgeBase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.KnowledgeBaseData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateKnowledgeBase API operation.", Operation = new[] {"CreateKnowledgeBase"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateKnowledgeBaseResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.KnowledgeBaseData or Amazon.QConnect.Model.CreateKnowledgeBaseResponse",
        "This cmdlet returns an Amazon.QConnect.Model.KnowledgeBaseData object.",
        "The service call response (type Amazon.QConnect.Model.CreateKnowledgeBaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQCKnowledgeBaseCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppIntegrations_AppIntegrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AppIntegrations DataIntegration to use for ingesting
        /// content.</para><ul><li><para> For <a href="https://developer.salesforce.com/docs/atlas.en-us.knowledge_dev.meta/knowledge_dev/sforce_api_objects_knowledge__kav.htm">
        /// Salesforce</a>, your AppIntegrations DataIntegration must have an ObjectConfiguration
        /// if objectFields is not provided, including at least <c>Id</c>, <c>ArticleNumber</c>,
        /// <c>VersionNumber</c>, <c>Title</c>, <c>PublishStatus</c>, and <c>IsDeleted</c> as
        /// source fields. </para></li><li><para> For <a href="https://developer.servicenow.com/dev.do#!/reference/api/rome/rest/knowledge-management-api">
        /// ServiceNow</a>, your AppIntegrations DataIntegration must have an ObjectConfiguration
        /// if objectFields is not provided, including at least <c>number</c>, <c>short_description</c>,
        /// <c>sys_mod_count</c>, <c>workflow_state</c>, and <c>active</c> as source fields. </para></li><li><para> For <a href="https://developer.zendesk.com/api-reference/help_center/help-center-api/articles/">
        /// Zendesk</a>, your AppIntegrations DataIntegration must have an ObjectConfiguration
        /// if <c>objectFields</c> is not provided, including at least <c>id</c>, <c>title</c>,
        /// <c>updated_at</c>, and <c>draft</c> as source fields. </para></li><li><para> For <a href="https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/sharepoint-net-server-csom-jsom-and-rest-api-index">SharePoint</a>,
        /// your AppIntegrations DataIntegration must have a FileConfiguration, including only
        /// file extensions that are among <c>docx</c>, <c>pdf</c>, <c>html</c>, <c>htm</c>, and
        /// <c>txt</c>. </para></li><li><para> For <a href="http://aws.amazon.com/s3/">Amazon S3</a>, the ObjectConfiguration and
        /// FileConfiguration of your AppIntegrations DataIntegration must be null. The <c>SourceURI</c>
        /// of your DataIntegration must use the following format: <c>s3://your_s3_bucket_name</c>.</para><important><para>The bucket policy of the corresponding S3 bucket must allow the Amazon Web Services
        /// principal <c>app-integrations.amazonaws.com</c> to perform <c>s3:ListBucket</c>, <c>s3:GetObject</c>,
        /// and <c>s3:GetBucketLocation</c> against the bucket.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_AppIntegrations_AppIntegrationArn")]
        public System.String AppIntegrations_AppIntegrationArn { get; set; }
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
        /// <para>Knowledge base can split your source data into chunks. A chunk refers to an excerpt
        /// from a data source that is returned when the knowledge base that it belongs to is
        /// queried. You have the following options for chunking your data. If you opt for <c>NONE</c>,
        /// then you may want to pre-process your files by splitting them up such that each file
        /// corresponds to a chunk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_ChunkingStrategy")]
        [AWSConstantClassSource("Amazon.QConnect.ChunkingStrategy")]
        public Amazon.QConnect.ChunkingStrategy ChunkingConfiguration_ChunkingStrategy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter WebCrawlerConfiguration_ExclusionFilter
        /// <summary>
        /// <para>
        /// <para>A list of one or more exclusion regular expression patterns to exclude certain URLs.
        /// If you specify an inclusion and exclusion filter/pattern and both match a URL, the
        /// exclusion filter takes precedence and the web content of the URL isn’t crawled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_ExclusionFilters")]
        public System.String[] WebCrawlerConfiguration_ExclusionFilter { get; set; }
        #endregion
        
        #region Parameter WebCrawlerConfiguration_InclusionFilter
        /// <summary>
        /// <para>
        /// <para>A list of one or more inclusion regular expression patterns to include certain URLs.
        /// If you specify an inclusion and exclusion filter/pattern and both match a URL, the
        /// exclusion filter takes precedence and the web content of the URL isn’t crawled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_InclusionFilters")]
        public System.String[] WebCrawlerConfiguration_InclusionFilter { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The customer managed key used for encryption. For more information about setting up
        /// a customer managed key for Amazon Q in Connect, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-q.html">Enable
        /// Amazon Q in Connect for your instance</a>. For information about valid ID values,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// identifiers (KeyId)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseType
        /// <summary>
        /// <para>
        /// <para>The type of knowledge base. Only CUSTOM knowledge bases allow you to upload your own
        /// content. EXTERNAL knowledge bases support integrations with third-party systems whose
        /// content is synchronized automatically. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.KnowledgeBaseType")]
        public Amazon.QConnect.KnowledgeBaseType KnowledgeBaseType { get; set; }
        #endregion
        
        #region Parameter HierarchicalChunkingConfiguration_LevelConfiguration
        /// <summary>
        /// <para>
        /// <para>Token settings for each layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_LevelConfigurations")]
        public Amazon.QConnect.Model.HierarchicalChunkingLevelConfiguration[] HierarchicalChunkingConfiguration_LevelConfiguration { get; set; }
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
        /// <para>The ARN of the foundation model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ModelArn")]
        public System.String BedrockFoundationModelConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the knowledge base.</para>
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
        
        #region Parameter AppIntegrations_ObjectField
        /// <summary>
        /// <para>
        /// <para>The fields from the source that are made available to your agents in Amazon Q in Connect.
        /// Optional if ObjectConfiguration is included in the provided DataIntegration. </para><ul><li><para> For <a href="https://developer.salesforce.com/docs/atlas.en-us.knowledge_dev.meta/knowledge_dev/sforce_api_objects_knowledge__kav.htm">
        /// Salesforce</a>, you must include at least <c>Id</c>, <c>ArticleNumber</c>, <c>VersionNumber</c>,
        /// <c>Title</c>, <c>PublishStatus</c>, and <c>IsDeleted</c>. </para></li><li><para>For <a href="https://developer.servicenow.com/dev.do#!/reference/api/rome/rest/knowledge-management-api">
        /// ServiceNow</a>, you must include at least <c>number</c>, <c>short_description</c>,
        /// <c>sys_mod_count</c>, <c>workflow_state</c>, and <c>active</c>. </para></li><li><para>For <a href="https://developer.zendesk.com/api-reference/help_center/help-center-api/articles/">
        /// Zendesk</a>, you must include at least <c>id</c>, <c>title</c>, <c>updated_at</c>,
        /// and <c>draft</c>. </para></li></ul><para>Make sure to include additional fields. These fields are indexed and used to source
        /// recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_AppIntegrations_ObjectFields")]
        public System.String[] AppIntegrations_ObjectField { get; set; }
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
        [AWSConstantClassSource("Amazon.QConnect.ParsingStrategy")]
        public Amazon.QConnect.ParsingStrategy ParsingConfiguration_ParsingStrategy { get; set; }
        #endregion
        
        #region Parameter CrawlerLimits_RateLimit
        /// <summary>
        /// <para>
        /// <para>Rate of web URLs retrieved per minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits_RateLimit")]
        public System.Int32? CrawlerLimits_RateLimit { get; set; }
        #endregion
        
        #region Parameter WebCrawlerConfiguration_Scope
        /// <summary>
        /// <para>
        /// <para>The scope of what is crawled for your URLs. You can choose to crawl only web pages
        /// that belong to the same host or primary domain. For example, only web pages that contain
        /// the seed URL <c>https://docs.aws.amazon.com/bedrock/latest/userguide/</c> and no other
        /// domains. You can choose to include sub domains in addition to the host or primary
        /// domain. For example, web pages that contain <c>aws.amazon.com</c> can also include
        /// sub domain <c>docs.aws.amazon.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_Scope")]
        [AWSConstantClassSource("Amazon.QConnect.WebScopeType")]
        public Amazon.QConnect.WebScopeType WebCrawlerConfiguration_Scope { get; set; }
        #endregion
        
        #region Parameter UrlConfiguration_SeedUrl
        /// <summary>
        /// <para>
        /// <para>List of URLs for crawling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration_SeedUrls")]
        public Amazon.QConnect.Model.SeedUrl[] UrlConfiguration_SeedUrl { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RenderingConfiguration_TemplateUri
        /// <summary>
        /// <para>
        /// <para>A URI template containing exactly one variable in <c>${variableName} </c>format. This
        /// can only be set for <c>EXTERNAL</c> knowledge bases. For Salesforce, ServiceNow, and
        /// Zendesk, the variable must be one of the following:</para><ul><li><para>Salesforce: <c>Id</c>, <c>ArticleNumber</c>, <c>VersionNumber</c>, <c>Title</c>, <c>PublishStatus</c>,
        /// or <c>IsDeleted</c></para></li><li><para>ServiceNow: <c>number</c>, <c>short_description</c>, <c>sys_mod_count</c>, <c>workflow_state</c>,
        /// or <c>active</c></para></li><li><para>Zendesk: <c>id</c>, <c>title</c>, <c>updated_at</c>, or <c>draft</c></para></li></ul><para>The variable is replaced with the actual value for a piece of content when calling
        /// <a href="https://docs.aws.amazon.com/amazon-q-connect/latest/APIReference/API_GetContent.html">GetContent</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RenderingConfiguration_TemplateUri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="http://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KnowledgeBase'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateKnowledgeBaseResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateKnowledgeBaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KnowledgeBase";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KnowledgeBaseType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCKnowledgeBase (CreateKnowledgeBase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateKnowledgeBaseResponse, NewQCKnowledgeBaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KnowledgeBaseType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KnowledgeBaseType = this.KnowledgeBaseType;
            #if MODULAR
            if (this.KnowledgeBaseType == null && ParameterWasBound(nameof(this.KnowledgeBaseType)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RenderingConfiguration_TemplateUri = this.RenderingConfiguration_TemplateUri;
            context.ServerSideEncryptionConfiguration_KmsKeyId = this.ServerSideEncryptionConfiguration_KmsKeyId;
            context.AppIntegrations_AppIntegrationArn = this.AppIntegrations_AppIntegrationArn;
            if (this.AppIntegrations_ObjectField != null)
            {
                context.AppIntegrations_ObjectField = new List<System.String>(this.AppIntegrations_ObjectField);
            }
            context.CrawlerLimits_RateLimit = this.CrawlerLimits_RateLimit;
            if (this.WebCrawlerConfiguration_ExclusionFilter != null)
            {
                context.WebCrawlerConfiguration_ExclusionFilter = new List<System.String>(this.WebCrawlerConfiguration_ExclusionFilter);
            }
            if (this.WebCrawlerConfiguration_InclusionFilter != null)
            {
                context.WebCrawlerConfiguration_InclusionFilter = new List<System.String>(this.WebCrawlerConfiguration_InclusionFilter);
            }
            context.WebCrawlerConfiguration_Scope = this.WebCrawlerConfiguration_Scope;
            if (this.UrlConfiguration_SeedUrl != null)
            {
                context.UrlConfiguration_SeedUrl = new List<Amazon.QConnect.Model.SeedUrl>(this.UrlConfiguration_SeedUrl);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.ChunkingConfiguration_ChunkingStrategy = this.ChunkingConfiguration_ChunkingStrategy;
            context.FixedSizeChunkingConfiguration_MaxToken = this.FixedSizeChunkingConfiguration_MaxToken;
            context.FixedSizeChunkingConfiguration_OverlapPercentage = this.FixedSizeChunkingConfiguration_OverlapPercentage;
            if (this.HierarchicalChunkingConfiguration_LevelConfiguration != null)
            {
                context.HierarchicalChunkingConfiguration_LevelConfiguration = new List<Amazon.QConnect.Model.HierarchicalChunkingLevelConfiguration>(this.HierarchicalChunkingConfiguration_LevelConfiguration);
            }
            context.HierarchicalChunkingConfiguration_OverlapToken = this.HierarchicalChunkingConfiguration_OverlapToken;
            context.SemanticChunkingConfiguration_BreakpointPercentileThreshold = this.SemanticChunkingConfiguration_BreakpointPercentileThreshold;
            context.SemanticChunkingConfiguration_BufferSize = this.SemanticChunkingConfiguration_BufferSize;
            context.SemanticChunkingConfiguration_MaxToken = this.SemanticChunkingConfiguration_MaxToken;
            context.BedrockFoundationModelConfiguration_ModelArn = this.BedrockFoundationModelConfiguration_ModelArn;
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
            var request = new Amazon.QConnect.Model.CreateKnowledgeBaseRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KnowledgeBaseType != null)
            {
                request.KnowledgeBaseType = cmdletContext.KnowledgeBaseType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RenderingConfiguration
            var requestRenderingConfigurationIsNull = true;
            request.RenderingConfiguration = new Amazon.QConnect.Model.RenderingConfiguration();
            System.String requestRenderingConfiguration_renderingConfiguration_TemplateUri = null;
            if (cmdletContext.RenderingConfiguration_TemplateUri != null)
            {
                requestRenderingConfiguration_renderingConfiguration_TemplateUri = cmdletContext.RenderingConfiguration_TemplateUri;
            }
            if (requestRenderingConfiguration_renderingConfiguration_TemplateUri != null)
            {
                request.RenderingConfiguration.TemplateUri = requestRenderingConfiguration_renderingConfiguration_TemplateUri;
                requestRenderingConfigurationIsNull = false;
            }
             // determine if request.RenderingConfiguration should be set to null
            if (requestRenderingConfigurationIsNull)
            {
                request.RenderingConfiguration = null;
            }
            
             // populate ServerSideEncryptionConfiguration
            var requestServerSideEncryptionConfigurationIsNull = true;
            request.ServerSideEncryptionConfiguration = new Amazon.QConnect.Model.ServerSideEncryptionConfiguration();
            System.String requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.ServerSideEncryptionConfiguration_KmsKeyId != null)
            {
                requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId = cmdletContext.ServerSideEncryptionConfiguration_KmsKeyId;
            }
            if (requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId != null)
            {
                request.ServerSideEncryptionConfiguration.KmsKeyId = requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyId;
                requestServerSideEncryptionConfigurationIsNull = false;
            }
             // determine if request.ServerSideEncryptionConfiguration should be set to null
            if (requestServerSideEncryptionConfigurationIsNull)
            {
                request.ServerSideEncryptionConfiguration = null;
            }
            
             // populate SourceConfiguration
            var requestSourceConfigurationIsNull = true;
            request.SourceConfiguration = new Amazon.QConnect.Model.SourceConfiguration();
            Amazon.QConnect.Model.ManagedSourceConfiguration requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration = null;
            
             // populate ManagedSourceConfiguration
            var requestSourceConfiguration_sourceConfiguration_ManagedSourceConfigurationIsNull = true;
            requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration = new Amazon.QConnect.Model.ManagedSourceConfiguration();
            Amazon.QConnect.Model.WebCrawlerConfiguration requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration = null;
            
             // populate WebCrawlerConfiguration
            var requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull = true;
            requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration = new Amazon.QConnect.Model.WebCrawlerConfiguration();
            List<System.String> requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_ExclusionFilter = null;
            if (cmdletContext.WebCrawlerConfiguration_ExclusionFilter != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_ExclusionFilter = cmdletContext.WebCrawlerConfiguration_ExclusionFilter;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_ExclusionFilter != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration.ExclusionFilters = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_ExclusionFilter;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull = false;
            }
            List<System.String> requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_InclusionFilter = null;
            if (cmdletContext.WebCrawlerConfiguration_InclusionFilter != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_InclusionFilter = cmdletContext.WebCrawlerConfiguration_InclusionFilter;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_InclusionFilter != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration.InclusionFilters = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_InclusionFilter;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull = false;
            }
            Amazon.QConnect.WebScopeType requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_Scope = null;
            if (cmdletContext.WebCrawlerConfiguration_Scope != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_Scope = cmdletContext.WebCrawlerConfiguration_Scope;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_Scope != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration.Scope = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_webCrawlerConfiguration_Scope;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.WebCrawlerLimits requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits = null;
            
             // populate CrawlerLimits
            var requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimitsIsNull = true;
            requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits = new Amazon.QConnect.Model.WebCrawlerLimits();
            System.Int32? requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit = null;
            if (cmdletContext.CrawlerLimits_RateLimit != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit = cmdletContext.CrawlerLimits_RateLimit.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits.RateLimit = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits_crawlerLimits_RateLimit.Value;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimitsIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits should be set to null
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimitsIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration.CrawlerLimits = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_CrawlerLimits;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.UrlConfiguration requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration = null;
            
             // populate UrlConfiguration
            var requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfigurationIsNull = true;
            requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration = new Amazon.QConnect.Model.UrlConfiguration();
            List<Amazon.QConnect.Model.SeedUrl> requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration_urlConfiguration_SeedUrl = null;
            if (cmdletContext.UrlConfiguration_SeedUrl != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration_urlConfiguration_SeedUrl = cmdletContext.UrlConfiguration_SeedUrl;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration_urlConfiguration_SeedUrl != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration.SeedUrls = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration_urlConfiguration_SeedUrl;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfigurationIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration should be set to null
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfigurationIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration.UrlConfiguration = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration_UrlConfiguration;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration should be set to null
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfigurationIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration != null)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration.WebCrawlerConfiguration = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration_WebCrawlerConfiguration;
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfigurationIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration should be set to null
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfigurationIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration != null)
            {
                request.SourceConfiguration.ManagedSourceConfiguration = requestSourceConfiguration_sourceConfiguration_ManagedSourceConfiguration;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.AppIntegrationsConfiguration requestSourceConfiguration_sourceConfiguration_AppIntegrations = null;
            
             // populate AppIntegrations
            var requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull = true;
            requestSourceConfiguration_sourceConfiguration_AppIntegrations = new Amazon.QConnect.Model.AppIntegrationsConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn = null;
            if (cmdletContext.AppIntegrations_AppIntegrationArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn = cmdletContext.AppIntegrations_AppIntegrationArn;
            }
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations.AppIntegrationArn = requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_AppIntegrationArn;
                requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull = false;
            }
            List<System.String> requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField = null;
            if (cmdletContext.AppIntegrations_ObjectField != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField = cmdletContext.AppIntegrations_ObjectField;
            }
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField != null)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations.ObjectFields = requestSourceConfiguration_sourceConfiguration_AppIntegrations_appIntegrations_ObjectField;
                requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_AppIntegrations should be set to null
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrationsIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_AppIntegrations = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_AppIntegrations != null)
            {
                request.SourceConfiguration.AppIntegrations = requestSourceConfiguration_sourceConfiguration_AppIntegrations;
                requestSourceConfigurationIsNull = false;
            }
             // determine if request.SourceConfiguration should be set to null
            if (requestSourceConfigurationIsNull)
            {
                request.SourceConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VectorIngestionConfiguration
            var requestVectorIngestionConfigurationIsNull = true;
            request.VectorIngestionConfiguration = new Amazon.QConnect.Model.VectorIngestionConfiguration();
            Amazon.QConnect.Model.ParsingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration = null;
            
             // populate ParsingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration = new Amazon.QConnect.Model.ParsingConfiguration();
            Amazon.QConnect.ParsingStrategy requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy = null;
            if (cmdletContext.ParsingConfiguration_ParsingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy = cmdletContext.ParsingConfiguration_ParsingStrategy;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration.ParsingStrategy = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_parsingConfiguration_ParsingStrategy;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.BedrockFoundationModelConfigurationForParsing requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration = null;
            
             // populate BedrockFoundationModelConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration = new Amazon.QConnect.Model.BedrockFoundationModelConfigurationForParsing();
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
            Amazon.QConnect.Model.ParsingPrompt requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt = null;
            
             // populate ParsingPrompt
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPromptIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ParsingConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_vectorIngestionConfiguration_ParsingConfiguration_BedrockFoundationModelConfiguration_ParsingPrompt = new Amazon.QConnect.Model.ParsingPrompt();
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
            Amazon.QConnect.Model.ChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration = null;
            
             // populate ChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration = new Amazon.QConnect.Model.ChunkingConfiguration();
            Amazon.QConnect.ChunkingStrategy requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy = null;
            if (cmdletContext.ChunkingConfiguration_ChunkingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy = cmdletContext.ChunkingConfiguration_ChunkingStrategy;
            }
            if (requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy != null)
            {
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration.ChunkingStrategy = requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_chunkingConfiguration_ChunkingStrategy;
                requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.FixedSizeChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration = null;
            
             // populate FixedSizeChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_FixedSizeChunkingConfiguration = new Amazon.QConnect.Model.FixedSizeChunkingConfiguration();
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
            Amazon.QConnect.Model.HierarchicalChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration = null;
            
             // populate HierarchicalChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration = new Amazon.QConnect.Model.HierarchicalChunkingConfiguration();
            List<Amazon.QConnect.Model.HierarchicalChunkingLevelConfiguration> requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_HierarchicalChunkingConfiguration_hierarchicalChunkingConfiguration_LevelConfiguration = null;
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
            Amazon.QConnect.Model.SemanticChunkingConfiguration requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration = null;
            
             // populate SemanticChunkingConfiguration
            var requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfigurationIsNull = true;
            requestVectorIngestionConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_vectorIngestionConfiguration_ChunkingConfiguration_SemanticChunkingConfiguration = new Amazon.QConnect.Model.SemanticChunkingConfiguration();
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
        
        private Amazon.QConnect.Model.CreateKnowledgeBaseResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateKnowledgeBaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateKnowledgeBase");
            try
            {
                #if DESKTOP
                return client.CreateKnowledgeBase(request);
                #elif CORECLR
                return client.CreateKnowledgeBaseAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.QConnect.KnowledgeBaseType KnowledgeBaseType { get; set; }
            public System.String Name { get; set; }
            public System.String RenderingConfiguration_TemplateUri { get; set; }
            public System.String ServerSideEncryptionConfiguration_KmsKeyId { get; set; }
            public System.String AppIntegrations_AppIntegrationArn { get; set; }
            public List<System.String> AppIntegrations_ObjectField { get; set; }
            public System.Int32? CrawlerLimits_RateLimit { get; set; }
            public List<System.String> WebCrawlerConfiguration_ExclusionFilter { get; set; }
            public List<System.String> WebCrawlerConfiguration_InclusionFilter { get; set; }
            public Amazon.QConnect.WebScopeType WebCrawlerConfiguration_Scope { get; set; }
            public List<Amazon.QConnect.Model.SeedUrl> UrlConfiguration_SeedUrl { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.QConnect.ChunkingStrategy ChunkingConfiguration_ChunkingStrategy { get; set; }
            public System.Int32? FixedSizeChunkingConfiguration_MaxToken { get; set; }
            public System.Int32? FixedSizeChunkingConfiguration_OverlapPercentage { get; set; }
            public List<Amazon.QConnect.Model.HierarchicalChunkingLevelConfiguration> HierarchicalChunkingConfiguration_LevelConfiguration { get; set; }
            public System.Int32? HierarchicalChunkingConfiguration_OverlapToken { get; set; }
            public System.Int32? SemanticChunkingConfiguration_BreakpointPercentileThreshold { get; set; }
            public System.Int32? SemanticChunkingConfiguration_BufferSize { get; set; }
            public System.Int32? SemanticChunkingConfiguration_MaxToken { get; set; }
            public System.String BedrockFoundationModelConfiguration_ModelArn { get; set; }
            public System.String ParsingPrompt_ParsingPromptText { get; set; }
            public Amazon.QConnect.ParsingStrategy ParsingConfiguration_ParsingStrategy { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateKnowledgeBaseResponse, NewQCKnowledgeBaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KnowledgeBase;
        }
        
    }
}
