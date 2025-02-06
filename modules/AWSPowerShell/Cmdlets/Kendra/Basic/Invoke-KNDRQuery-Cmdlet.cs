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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Searches an index given an input query.
    /// 
    ///  <note><para>
    /// If you are working with large language models (LLMs) or implementing retrieval augmented
    /// generation (RAG) systems, you can use Amazon Kendra's <a href="https://docs.aws.amazon.com/kendra/latest/APIReference/API_Retrieve.html">Retrieve</a>
    /// API, which can return longer semantically relevant passages. We recommend using the
    /// <c>Retrieve</c> API instead of filing a service limit increase to increase the <c>Query</c>
    /// API document excerpt length.
    /// </para></note><para>
    /// You can configure boosting or relevance tuning at the query level to override boosting
    /// at the index level, filter based on document fields/attributes and faceted search,
    /// and filter based on the user or their group access to documents. You can also include
    /// certain fields in the response that might provide useful additional information.
    /// </para><para>
    /// A query response contains three types of results.
    /// </para><ul><li><para>
    /// Relevant suggested answers. The answers can be either a text excerpt or table excerpt.
    /// The answer can be highlighted in the excerpt.
    /// </para></li><li><para>
    /// Matching FAQs or questions-answer from your FAQ file.
    /// </para></li><li><para>
    /// Relevant documents. This result type includes an excerpt of the document with the
    /// document title. The searched terms can be highlighted in the excerpt.
    /// </para></li></ul><para>
    /// You can specify that the query return only one type of result using the <c>QueryResultTypeFilter</c>
    /// parameter. Each query returns the 100 most relevant results. If you filter result
    /// type to only question-answers, a maximum of four results are returned. If you filter
    /// result type to only answers, a maximum of three results are returned.
    /// </para><important><para>
    /// If you're using an Amazon Kendra Gen AI Enterprise Edition index, you can only use
    /// <c>ATTRIBUTE_FILTER</c> to filter search results by user context. If you're using
    /// an Amazon Kendra Gen AI Enterprise Edition index and you try to use <c>USER_TOKEN</c>
    /// to configure user context policy, Amazon Kendra returns a <c>ValidationException</c>
    /// error.
    /// </para></important>
    /// </summary>
    [Cmdlet("Invoke", "KNDRQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kendra.Model.QueryResponse")]
    [AWSCmdlet("Calls the Amazon Kendra Query API operation.", Operation = new[] {"Query"}, SelectReturnType = typeof(Amazon.Kendra.Model.QueryResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.QueryResponse",
        "This cmdlet returns an Amazon.Kendra.Model.QueryResponse object containing multiple properties."
    )]
    public partial class InvokeKNDRQueryCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Filters search results by document fields/attributes. You can only provide one attribute
        /// filter; however, the <c>AndAllFilters</c>, <c>NotFilter</c>, and <c>OrAllFilters</c>
        /// parameters contain a list of other filters.</para><para>The <c>AttributeFilter</c> parameter means you can create a set of filtering rules
        /// that a document must satisfy to be included in the query results.</para><note><para>For Amazon Kendra Gen AI Enterprise Edition indices use <c>AttributeFilter</c> to
        /// enable document filtering for end users using <c>_email_id</c> or include public documents
        /// (<c>_email_id=null</c>).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kendra.Model.AttributeFilter AttributeFilter { get; set; }
        #endregion
        
        #region Parameter UserContext_DataSourceGroup
        /// <summary>
        /// <para>
        /// <para>The list of data source groups you want to filter search results based on groups'
        /// access to documents in that data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserContext_DataSourceGroups")]
        public Amazon.Kendra.Model.DataSourceGroup[] UserContext_DataSourceGroup { get; set; }
        #endregion
        
        #region Parameter CollapseConfiguration_DocumentAttributeKey
        /// <summary>
        /// <para>
        /// <para>The document attribute used to group search results. You can use any attribute that
        /// has the <c>Sortable</c> flag set to true. You can also sort by any of the following
        /// built-in attributes:"_category","_created_at", "_last_updated_at", "_version", "_view_count".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CollapseConfiguration_DocumentAttributeKey { get; set; }
        #endregion
        
        #region Parameter SortingConfiguration_DocumentAttributeKey
        /// <summary>
        /// <para>
        /// <para>The name of the document attribute used to sort the response. You can use any field
        /// that has the <c>Sortable</c> flag set to true.</para><para>You can also sort by any of the following built-in attributes:</para><ul><li><para>_category</para></li><li><para>_created_at</para></li><li><para>_last_updated_at</para></li><li><para>_version</para></li><li><para>_view_count</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortingConfiguration_DocumentAttributeKey { get; set; }
        #endregion
        
        #region Parameter DocumentRelevanceOverrideConfiguration
        /// <summary>
        /// <para>
        /// <para>Overrides relevance tuning configurations of fields/attributes set at the index level.</para><para>If you use this API to override the relevance tuning configured at the index level,
        /// but there is no relevance tuning configured at the index level, then Amazon Kendra
        /// does not apply any relevance tuning.</para><para>If there is relevance tuning configured for fields at the index level, and you use
        /// this API to override only some of these fields, then for the fields you did not override,
        /// the importance is set to 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentRelevanceOverrideConfigurations")]
        public Amazon.Kendra.Model.DocumentRelevanceConfiguration[] DocumentRelevanceOverrideConfiguration { get; set; }
        #endregion
        
        #region Parameter CollapseConfiguration_Expand
        /// <summary>
        /// <para>
        /// <para>Specifies whether to expand the collapsed results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CollapseConfiguration_Expand { get; set; }
        #endregion
        
        #region Parameter Facet
        /// <summary>
        /// <para>
        /// <para>An array of documents fields/attributes for faceted search. Amazon Kendra returns
        /// a count for each field key specified. This helps your users narrow their search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Facets")]
        public Amazon.Kendra.Model.Facet[] Facet { get; set; }
        #endregion
        
        #region Parameter UserContext_Group
        /// <summary>
        /// <para>
        /// <para>The list of groups you want to filter search results based on the groups' access to
        /// documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserContext_Groups")]
        public System.String[] UserContext_Group { get; set; }
        #endregion
        
        #region Parameter SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion
        /// <summary>
        /// <para>
        /// <para><c>TRUE</c> to suggest spell corrections for queries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestions")]
        public System.Boolean? SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index for the search.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter ExpandConfiguration_MaxExpandedResultsPerItem
        /// <summary>
        /// <para>
        /// <para>The number of expanded results to show per collapsed primary document. For instance,
        /// if you set this value to 3, then at most 3 results per collapsed group will be displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollapseConfiguration_ExpandConfiguration_MaxExpandedResultsPerItem")]
        public System.Int32? ExpandConfiguration_MaxExpandedResultsPerItem { get; set; }
        #endregion
        
        #region Parameter ExpandConfiguration_MaxResultItemsToExpand
        /// <summary>
        /// <para>
        /// <para>The number of collapsed search result groups to expand. If you set this value to 10,
        /// for example, only the first 10 out of 100 result groups will have expand functionality.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollapseConfiguration_ExpandConfiguration_MaxResultItemsToExpand")]
        public System.Int32? ExpandConfiguration_MaxResultItemsToExpand { get; set; }
        #endregion
        
        #region Parameter CollapseConfiguration_MissingAttributeKeyStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the behavior for documents without a value for the collapse attribute.</para><para>Amazon Kendra offers three customization options:</para><ul><li><para>Choose to <c>COLLAPSE</c> all documents with null or missing values in one group.
        /// This is the default configuration.</para></li><li><para>Choose to <c>IGNORE</c> documents with null or missing values. Ignored documents will
        /// not appear in query results.</para></li><li><para>Choose to <c>EXPAND</c> each document with a null or missing value into a group of
        /// its own.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.MissingAttributeKeyStrategy")]
        public Amazon.Kendra.MissingAttributeKeyStrategy CollapseConfiguration_MissingAttributeKeyStrategy { get; set; }
        #endregion
        
        #region Parameter PageNumber
        /// <summary>
        /// <para>
        /// <para>Query results are returned in pages the size of the <c>PageSize</c> parameter. By
        /// default, Amazon Kendra returns the first page of results. Use this parameter to get
        /// result pages after the first one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageNumber { get; set; }
        #endregion
        
        #region Parameter QueryResultTypeFilter
        /// <summary>
        /// <para>
        /// <para>Sets the type of query result or response. Only results for the specified type are
        /// returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.QueryResultType")]
        public Amazon.Kendra.QueryResultType QueryResultTypeFilter { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The input query text for the search. Amazon Kendra truncates queries at 30 token words,
        /// which excludes punctuation and stop words. Truncation still applies if you use Boolean
        /// or more advanced, complex queries. For example, <c>Timeoff AND October AND Category:HR</c>
        /// is counted as 3 tokens: <c>timeoff</c>, <c>october</c>, <c>hr</c>. For more information,
        /// see <a href="https://docs.aws.amazon.com/kendra/latest/dg/searching-example.html#searching-index-query-syntax">Searching
        /// with advanced query syntax</a> in the Amazon Kendra Developer Guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter RequestedDocumentAttribute
        /// <summary>
        /// <para>
        /// <para>An array of document fields/attributes to include in the response. You can limit the
        /// response to include certain document fields. By default, all document attributes are
        /// included in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedDocumentAttributes")]
        public System.String[] RequestedDocumentAttribute { get; set; }
        #endregion
        
        #region Parameter CollapseConfiguration_SortingConfiguration
        /// <summary>
        /// <para>
        /// <para>A prioritized list of document attributes/fields that determine the primary document
        /// among those in a collapsed group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollapseConfiguration_SortingConfigurations")]
        public Amazon.Kendra.Model.SortingConfiguration[] CollapseConfiguration_SortingConfiguration { get; set; }
        #endregion
        
        #region Parameter SortingConfiguration
        /// <summary>
        /// <para>
        /// <para>Provides configuration information to determine how the results of a query are sorted.</para><para>You can set upto 3 fields that Amazon Kendra should sort the results on, and specify
        /// whether the results should be sorted in ascending or descending order. The sort field
        /// quota can be increased.</para><para>If you don't provide a sorting configuration, the results are sorted by the relevance
        /// that Amazon Kendra determines for the result. In the case of ties in sorting the results,
        /// the results are sorted by relevance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SortingConfigurations")]
        public Amazon.Kendra.Model.SortingConfiguration[] SortingConfiguration { get; set; }
        #endregion
        
        #region Parameter SortingConfiguration_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order that the results should be returned in. In case of ties, the relevance assigned
        /// to the result by Amazon Kendra is used as the tie-breaker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.SortOrder")]
        public Amazon.Kendra.SortOrder SortingConfiguration_SortOrder { get; set; }
        #endregion
        
        #region Parameter UserContext_Token
        /// <summary>
        /// <para>
        /// <para>The user context token for filtering search results for a user. It must be a JWT or
        /// a JSON token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContext_Token { get; set; }
        #endregion
        
        #region Parameter UserContext_UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user you want to filter search results based on their access
        /// to documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContext_UserId { get; set; }
        #endregion
        
        #region Parameter VisitorId
        /// <summary>
        /// <para>
        /// <para>Provides an identifier for a specific user. The <c>VisitorId</c> should be a unique
        /// identifier, such as a GUID. Don't use personally identifiable information, such as
        /// the user's email address, as the <c>VisitorId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VisitorId { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>Sets the number of results that are returned in each page of results. The default
        /// page size is 10. The maximum number of results returned is 100. If you ask for more
        /// than 100 results, only 100 are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.QueryResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.QueryResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KNDRQuery (Query)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.QueryResponse, InvokeKNDRQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributeFilter = this.AttributeFilter;
            context.CollapseConfiguration_DocumentAttributeKey = this.CollapseConfiguration_DocumentAttributeKey;
            context.CollapseConfiguration_Expand = this.CollapseConfiguration_Expand;
            context.ExpandConfiguration_MaxExpandedResultsPerItem = this.ExpandConfiguration_MaxExpandedResultsPerItem;
            context.ExpandConfiguration_MaxResultItemsToExpand = this.ExpandConfiguration_MaxResultItemsToExpand;
            context.CollapseConfiguration_MissingAttributeKeyStrategy = this.CollapseConfiguration_MissingAttributeKeyStrategy;
            if (this.CollapseConfiguration_SortingConfiguration != null)
            {
                context.CollapseConfiguration_SortingConfiguration = new List<Amazon.Kendra.Model.SortingConfiguration>(this.CollapseConfiguration_SortingConfiguration);
            }
            if (this.DocumentRelevanceOverrideConfiguration != null)
            {
                context.DocumentRelevanceOverrideConfiguration = new List<Amazon.Kendra.Model.DocumentRelevanceConfiguration>(this.DocumentRelevanceOverrideConfiguration);
            }
            if (this.Facet != null)
            {
                context.Facet = new List<Amazon.Kendra.Model.Facet>(this.Facet);
            }
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PageNumber = this.PageNumber;
            context.PageSize = this.PageSize;
            context.QueryResultTypeFilter = this.QueryResultTypeFilter;
            context.QueryText = this.QueryText;
            if (this.RequestedDocumentAttribute != null)
            {
                context.RequestedDocumentAttribute = new List<System.String>(this.RequestedDocumentAttribute);
            }
            context.SortingConfiguration_DocumentAttributeKey = this.SortingConfiguration_DocumentAttributeKey;
            context.SortingConfiguration_SortOrder = this.SortingConfiguration_SortOrder;
            if (this.SortingConfiguration != null)
            {
                context.SortingConfiguration = new List<Amazon.Kendra.Model.SortingConfiguration>(this.SortingConfiguration);
            }
            context.SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion = this.SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion;
            if (this.UserContext_DataSourceGroup != null)
            {
                context.UserContext_DataSourceGroup = new List<Amazon.Kendra.Model.DataSourceGroup>(this.UserContext_DataSourceGroup);
            }
            if (this.UserContext_Group != null)
            {
                context.UserContext_Group = new List<System.String>(this.UserContext_Group);
            }
            context.UserContext_Token = this.UserContext_Token;
            context.UserContext_UserId = this.UserContext_UserId;
            context.VisitorId = this.VisitorId;
            
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
            var request = new Amazon.Kendra.Model.QueryRequest();
            
            if (cmdletContext.AttributeFilter != null)
            {
                request.AttributeFilter = cmdletContext.AttributeFilter;
            }
            
             // populate CollapseConfiguration
            var requestCollapseConfigurationIsNull = true;
            request.CollapseConfiguration = new Amazon.Kendra.Model.CollapseConfiguration();
            System.String requestCollapseConfiguration_collapseConfiguration_DocumentAttributeKey = null;
            if (cmdletContext.CollapseConfiguration_DocumentAttributeKey != null)
            {
                requestCollapseConfiguration_collapseConfiguration_DocumentAttributeKey = cmdletContext.CollapseConfiguration_DocumentAttributeKey;
            }
            if (requestCollapseConfiguration_collapseConfiguration_DocumentAttributeKey != null)
            {
                request.CollapseConfiguration.DocumentAttributeKey = requestCollapseConfiguration_collapseConfiguration_DocumentAttributeKey;
                requestCollapseConfigurationIsNull = false;
            }
            System.Boolean? requestCollapseConfiguration_collapseConfiguration_Expand = null;
            if (cmdletContext.CollapseConfiguration_Expand != null)
            {
                requestCollapseConfiguration_collapseConfiguration_Expand = cmdletContext.CollapseConfiguration_Expand.Value;
            }
            if (requestCollapseConfiguration_collapseConfiguration_Expand != null)
            {
                request.CollapseConfiguration.Expand = requestCollapseConfiguration_collapseConfiguration_Expand.Value;
                requestCollapseConfigurationIsNull = false;
            }
            Amazon.Kendra.MissingAttributeKeyStrategy requestCollapseConfiguration_collapseConfiguration_MissingAttributeKeyStrategy = null;
            if (cmdletContext.CollapseConfiguration_MissingAttributeKeyStrategy != null)
            {
                requestCollapseConfiguration_collapseConfiguration_MissingAttributeKeyStrategy = cmdletContext.CollapseConfiguration_MissingAttributeKeyStrategy;
            }
            if (requestCollapseConfiguration_collapseConfiguration_MissingAttributeKeyStrategy != null)
            {
                request.CollapseConfiguration.MissingAttributeKeyStrategy = requestCollapseConfiguration_collapseConfiguration_MissingAttributeKeyStrategy;
                requestCollapseConfigurationIsNull = false;
            }
            List<Amazon.Kendra.Model.SortingConfiguration> requestCollapseConfiguration_collapseConfiguration_SortingConfiguration = null;
            if (cmdletContext.CollapseConfiguration_SortingConfiguration != null)
            {
                requestCollapseConfiguration_collapseConfiguration_SortingConfiguration = cmdletContext.CollapseConfiguration_SortingConfiguration;
            }
            if (requestCollapseConfiguration_collapseConfiguration_SortingConfiguration != null)
            {
                request.CollapseConfiguration.SortingConfigurations = requestCollapseConfiguration_collapseConfiguration_SortingConfiguration;
                requestCollapseConfigurationIsNull = false;
            }
            Amazon.Kendra.Model.ExpandConfiguration requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration = null;
            
             // populate ExpandConfiguration
            var requestCollapseConfiguration_collapseConfiguration_ExpandConfigurationIsNull = true;
            requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration = new Amazon.Kendra.Model.ExpandConfiguration();
            System.Int32? requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxExpandedResultsPerItem = null;
            if (cmdletContext.ExpandConfiguration_MaxExpandedResultsPerItem != null)
            {
                requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxExpandedResultsPerItem = cmdletContext.ExpandConfiguration_MaxExpandedResultsPerItem.Value;
            }
            if (requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxExpandedResultsPerItem != null)
            {
                requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration.MaxExpandedResultsPerItem = requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxExpandedResultsPerItem.Value;
                requestCollapseConfiguration_collapseConfiguration_ExpandConfigurationIsNull = false;
            }
            System.Int32? requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxResultItemsToExpand = null;
            if (cmdletContext.ExpandConfiguration_MaxResultItemsToExpand != null)
            {
                requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxResultItemsToExpand = cmdletContext.ExpandConfiguration_MaxResultItemsToExpand.Value;
            }
            if (requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxResultItemsToExpand != null)
            {
                requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration.MaxResultItemsToExpand = requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration_expandConfiguration_MaxResultItemsToExpand.Value;
                requestCollapseConfiguration_collapseConfiguration_ExpandConfigurationIsNull = false;
            }
             // determine if requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration should be set to null
            if (requestCollapseConfiguration_collapseConfiguration_ExpandConfigurationIsNull)
            {
                requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration = null;
            }
            if (requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration != null)
            {
                request.CollapseConfiguration.ExpandConfiguration = requestCollapseConfiguration_collapseConfiguration_ExpandConfiguration;
                requestCollapseConfigurationIsNull = false;
            }
             // determine if request.CollapseConfiguration should be set to null
            if (requestCollapseConfigurationIsNull)
            {
                request.CollapseConfiguration = null;
            }
            if (cmdletContext.DocumentRelevanceOverrideConfiguration != null)
            {
                request.DocumentRelevanceOverrideConfigurations = cmdletContext.DocumentRelevanceOverrideConfiguration;
            }
            if (cmdletContext.Facet != null)
            {
                request.Facets = cmdletContext.Facet;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.PageNumber != null)
            {
                request.PageNumber = cmdletContext.PageNumber.Value;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.QueryResultTypeFilter != null)
            {
                request.QueryResultTypeFilter = cmdletContext.QueryResultTypeFilter;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
            }
            if (cmdletContext.RequestedDocumentAttribute != null)
            {
                request.RequestedDocumentAttributes = cmdletContext.RequestedDocumentAttribute;
            }
            
             // populate SortingConfiguration
            var requestSortingConfigurationIsNull = true;
            request.SortingConfiguration = new Amazon.Kendra.Model.SortingConfiguration();
            System.String requestSortingConfiguration_sortingConfiguration_DocumentAttributeKey = null;
            if (cmdletContext.SortingConfiguration_DocumentAttributeKey != null)
            {
                requestSortingConfiguration_sortingConfiguration_DocumentAttributeKey = cmdletContext.SortingConfiguration_DocumentAttributeKey;
            }
            if (requestSortingConfiguration_sortingConfiguration_DocumentAttributeKey != null)
            {
                request.SortingConfiguration.DocumentAttributeKey = requestSortingConfiguration_sortingConfiguration_DocumentAttributeKey;
                requestSortingConfigurationIsNull = false;
            }
            Amazon.Kendra.SortOrder requestSortingConfiguration_sortingConfiguration_SortOrder = null;
            if (cmdletContext.SortingConfiguration_SortOrder != null)
            {
                requestSortingConfiguration_sortingConfiguration_SortOrder = cmdletContext.SortingConfiguration_SortOrder;
            }
            if (requestSortingConfiguration_sortingConfiguration_SortOrder != null)
            {
                request.SortingConfiguration.SortOrder = requestSortingConfiguration_sortingConfiguration_SortOrder;
                requestSortingConfigurationIsNull = false;
            }
             // determine if request.SortingConfiguration should be set to null
            if (requestSortingConfigurationIsNull)
            {
                request.SortingConfiguration = null;
            }
            if (cmdletContext.SortingConfiguration != null)
            {
                request.SortingConfigurations = cmdletContext.SortingConfiguration;
            }
            
             // populate SpellCorrectionConfiguration
            var requestSpellCorrectionConfigurationIsNull = true;
            request.SpellCorrectionConfiguration = new Amazon.Kendra.Model.SpellCorrectionConfiguration();
            System.Boolean? requestSpellCorrectionConfiguration_spellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion = null;
            if (cmdletContext.SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion != null)
            {
                requestSpellCorrectionConfiguration_spellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion = cmdletContext.SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion.Value;
            }
            if (requestSpellCorrectionConfiguration_spellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion != null)
            {
                request.SpellCorrectionConfiguration.IncludeQuerySpellCheckSuggestions = requestSpellCorrectionConfiguration_spellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion.Value;
                requestSpellCorrectionConfigurationIsNull = false;
            }
             // determine if request.SpellCorrectionConfiguration should be set to null
            if (requestSpellCorrectionConfigurationIsNull)
            {
                request.SpellCorrectionConfiguration = null;
            }
            
             // populate UserContext
            var requestUserContextIsNull = true;
            request.UserContext = new Amazon.Kendra.Model.UserContext();
            List<Amazon.Kendra.Model.DataSourceGroup> requestUserContext_userContext_DataSourceGroup = null;
            if (cmdletContext.UserContext_DataSourceGroup != null)
            {
                requestUserContext_userContext_DataSourceGroup = cmdletContext.UserContext_DataSourceGroup;
            }
            if (requestUserContext_userContext_DataSourceGroup != null)
            {
                request.UserContext.DataSourceGroups = requestUserContext_userContext_DataSourceGroup;
                requestUserContextIsNull = false;
            }
            List<System.String> requestUserContext_userContext_Group = null;
            if (cmdletContext.UserContext_Group != null)
            {
                requestUserContext_userContext_Group = cmdletContext.UserContext_Group;
            }
            if (requestUserContext_userContext_Group != null)
            {
                request.UserContext.Groups = requestUserContext_userContext_Group;
                requestUserContextIsNull = false;
            }
            System.String requestUserContext_userContext_Token = null;
            if (cmdletContext.UserContext_Token != null)
            {
                requestUserContext_userContext_Token = cmdletContext.UserContext_Token;
            }
            if (requestUserContext_userContext_Token != null)
            {
                request.UserContext.Token = requestUserContext_userContext_Token;
                requestUserContextIsNull = false;
            }
            System.String requestUserContext_userContext_UserId = null;
            if (cmdletContext.UserContext_UserId != null)
            {
                requestUserContext_userContext_UserId = cmdletContext.UserContext_UserId;
            }
            if (requestUserContext_userContext_UserId != null)
            {
                request.UserContext.UserId = requestUserContext_userContext_UserId;
                requestUserContextIsNull = false;
            }
             // determine if request.UserContext should be set to null
            if (requestUserContextIsNull)
            {
                request.UserContext = null;
            }
            if (cmdletContext.VisitorId != null)
            {
                request.VisitorId = cmdletContext.VisitorId;
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
        
        private Amazon.Kendra.Model.QueryResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.QueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "Query");
            try
            {
                #if DESKTOP
                return client.Query(request);
                #elif CORECLR
                return client.QueryAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Kendra.Model.AttributeFilter AttributeFilter { get; set; }
            public System.String CollapseConfiguration_DocumentAttributeKey { get; set; }
            public System.Boolean? CollapseConfiguration_Expand { get; set; }
            public System.Int32? ExpandConfiguration_MaxExpandedResultsPerItem { get; set; }
            public System.Int32? ExpandConfiguration_MaxResultItemsToExpand { get; set; }
            public Amazon.Kendra.MissingAttributeKeyStrategy CollapseConfiguration_MissingAttributeKeyStrategy { get; set; }
            public List<Amazon.Kendra.Model.SortingConfiguration> CollapseConfiguration_SortingConfiguration { get; set; }
            public List<Amazon.Kendra.Model.DocumentRelevanceConfiguration> DocumentRelevanceOverrideConfiguration { get; set; }
            public List<Amazon.Kendra.Model.Facet> Facet { get; set; }
            public System.String IndexId { get; set; }
            public System.Int32? PageNumber { get; set; }
            public System.Int32? PageSize { get; set; }
            public Amazon.Kendra.QueryResultType QueryResultTypeFilter { get; set; }
            public System.String QueryText { get; set; }
            public List<System.String> RequestedDocumentAttribute { get; set; }
            public System.String SortingConfiguration_DocumentAttributeKey { get; set; }
            public Amazon.Kendra.SortOrder SortingConfiguration_SortOrder { get; set; }
            public List<Amazon.Kendra.Model.SortingConfiguration> SortingConfiguration { get; set; }
            public System.Boolean? SpellCorrectionConfiguration_IncludeQuerySpellCheckSuggestion { get; set; }
            public List<Amazon.Kendra.Model.DataSourceGroup> UserContext_DataSourceGroup { get; set; }
            public List<System.String> UserContext_Group { get; set; }
            public System.String UserContext_Token { get; set; }
            public System.String UserContext_UserId { get; set; }
            public System.String VisitorId { get; set; }
            public System.Func<Amazon.Kendra.Model.QueryResponse, InvokeKNDRQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
