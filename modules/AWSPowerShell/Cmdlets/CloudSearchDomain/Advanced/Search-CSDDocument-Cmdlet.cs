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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudSearchDomain;
using Amazon.CloudSearchDomain.Model;
using System.Threading;

namespace Amazon.PowerShell.Cmdlets.CSD
{
    /// <summary>
    /// Retrieves a list of documents that match the specified search criteria. How you specify
    /// the search criteria depends on which query parser you use. Amazon CloudSearch supports
    /// four query parsers:
    /// 
    ///       <ul><li><code>simple</code>: search all <code>text</code> and <code>text-array</code>
    /// fields for the specified string. Search for phrases, individual terms, and prefixes.
    /// </li><li><code>structured</code>: search specific fields, construct compound
    /// queries using Boolean operators, and use advanced features such as term boosting and
    /// proximity searching.</li><li><code>lucene</code>: specify search criteria
    /// using the Apache Lucene query parser syntax.</li><li><code>dismax</code>:
    /// specify search criteria using the simplified subset of the Apache Lucene query parser
    /// syntax defined by the DisMax query parser.</li></ul><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/searching.html">Searching
    /// Your Data</a> in the <i>Amazon CloudSearch Developer Guide</i>.
    /// </para><para>
    /// The endpoint for submitting <code>Search</code> requests is domain-specific. You submit
    /// search requests to a domain's search endpoint. To get the search endpoint for your
    /// domain, use the Amazon CloudSearch configuration service <code>DescribeDomains</code>
    /// action. A domain's endpoints are also displayed on the domain dashboard in the Amazon
    /// CloudSearch console. 
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Search-CSDDocuments</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "CSDDocument")]
    [OutputType("Amazon.CloudSearchDomain.Model.SearchResponse")]
    [AWSCmdlet("Calls the Amazon CloudSearchDomain Search API operation.", Operation = new[] { "Search" }, SelectReturnType = typeof(Amazon.CloudSearchDomain.Model.SearchResponse), LegacyAlias = "Search-CSDDocuments")]
    [AWSCmdletOutput("Amazon.CloudSearchDomain.Model.SearchResponse",
        "This cmdlet returns an Amazon.CloudSearchDomain.Model.SearchResponse object containing multiple properties. The object can be returned by specifying '-Select *'."
    )]
    public class SearchCSDDocumentCmdlet : AmazonCloudSearchDomainClientCmdlet, IExecutor
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #region Parameter ServiceUrl
        /// <summary>
        /// Specifies the Search or Document service endpoint.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceUrl { get; set; }
        #endregion

        #region Parameter Cursor
        /// <summary>
        /// Retrieves a cursor value you can use to page through large result sets.          Use
        /// the <code>size</code> parameter to control the number of hits to include in each response.
        /// You can specify either the <code>cursor</code> or         <code>start</code> parameter
        /// in a request; they are mutually exclusive. To get the first cursor, set the cursor
        /// value to <code>initial</code>. In subsequent requests, specify the cursor value returned
        /// in the hits section of the response. 
        /// <para>
        /// For more         information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/paginating-results.html">Paginating
        /// Results</a> in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cursor { get; set; }
        #endregion

        #region Parameter Expr
        /// <summary>
        /// <para>
        /// Defines one or more numeric expressions that can be used to sort results or specify
        /// search or filter         criteria. You can also specify expressions as return fields.
        /// </para>
        ///  
        /// <para>
        /// You specify the expressions in JSON using the form <code>{"EXPRESSIONNAME":"EXPRESSION"}</code>.
        /// You can define and use multiple expressions in a search request. For example:
        /// </para>
        /// 
        /// <para>
        /// <code> {"expression1":"_score*rating", "expression2":"(1/rank)*year"} </code> 
        /// </para>
        ///  
        /// <para>
        /// For information about the variables, operators, and functions you can use in expressions,
        /// see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-expressions.html#writing-expressions">Writing
        /// Expressions</a>         in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Expr { get; set; }
        #endregion

        #region Parameter Facet
        /// <summary>
        /// <para>
        /// Specifies one or more fields for which to get facet information, and options that
        /// control how the facet information is returned. Each specified field must be facet-enabled
        /// in the domain configuration. The fields and options are specified in JSON using the
        /// form <code>{"FIELD":{"OPTION":VALUE,"OPTION:"STRING"},"FIELD":{"OPTION":VALUE,"OPTION":"STRING"}}</code>.
        /// </para>
        ///  
        /// <para>
        /// You can specify the following faceting options:
        /// </para>
        ///  <ul> <li> 
        /// <para>
        /// <code>buckets</code> specifies an array of the facet values or ranges to count. Ranges
        /// are specified using the same syntax that you use to search for a range of values.
        /// For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/searching-ranges.html">
        /// Searching for a Range of Values</a> in the <i>Amazon CloudSearch Developer Guide</i>.
        /// Buckets are returned in the order they are specified in the request. The <code>sort</code>
        /// and <code>size</code> options are not valid if you specify <code>buckets</code>.
        /// </para>
        ///  </li> <li> 
        /// <para>
        /// <code>size</code> specifies the maximum number of facets to include in the results.
        /// By default, Amazon CloudSearch returns counts for the top 10. The <code>size</code>
        /// parameter is only valid when you specify the <code>sort</code> option; it cannot be
        /// used in conjunction with <code>buckets</code>.
        /// </para>
        ///  </li> <li> 
        /// <para>
        /// <code>sort</code> specifies how you want to sort the facets in the results: <code>bucket</code>
        /// or <code>count</code>. Specify <code>bucket</code> to sort alphabetically or numerically
        /// by facet value (in ascending order). Specify <code>count</code> to sort by the facet
        /// counts computed for each facet value (in descending order). To retrieve facet counts
        /// for particular values or ranges of values, use the <code>buckets</code> option instead
        /// of <code>sort</code>. 
        /// </para>
        ///  </li> </ul> 
        /// <para>
        /// If no facet options are specified, facet counts are computed for all field values,
        /// the facets are sorted by facet count, and the top 10 facets are returned in the results.
        /// </para>
        ///  
        /// <para>
        /// To count particular buckets of values, use the <code>buckets</code> option. For example,
        /// the following request uses the <code>buckets</code> option to calculate and return
        /// facet counts by decade.
        /// </para>
        ///  
        /// <para>
        /// <code> {"year":{"buckets":["[1970,1979]","[1980,1989]","[1990,1999]","[2000,2009]","[2010,}"]}}
        /// </code>
        /// </para>
        ///  
        /// <para>
        /// To sort facets by facet count, use the <code>count</code> option. For example, the
        /// following request sets the <code>sort</code> option to <code>count</code> to sort
        /// the facet values by facet count, with the facet values that have the most matching
        /// documents listed first. Setting the <code>size</code> option to 3 returns only the
        /// top three facet values.
        /// </para>
        ///  
        /// <para>
        /// <code> {"year":{"sort":"count","size":3}} </code>
        /// </para>
        ///  
        /// <para>
        /// To sort the facets by value, use the <code>bucket</code> option. For example, the
        /// following request sets the <code>sort</code> option to <code>bucket</code> to sort
        /// the facet values numerically by year, with earliest year listed first. 
        /// </para>
        ///  
        /// <para>
        /// <code> {"year":{"sort":"bucket"}} </code>
        /// </para>
        ///  
        /// <para>
        /// For more         information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/faceting.html">Getting
        /// and Using Facet Information</a>         in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Facet { get; set; }
        #endregion

        #region Parameter FilterQuery
        /// <summary>
        /// Specifies a structured query that filters the results of a search without affecting
        /// how the results are scored and sorted. You use <code>filterQuery</code> in conjunction
        /// with the <code>query</code> parameter to filter the documents that match the constraints
        /// specified in the <code>query</code> parameter. Specifying a filter controls only which
        /// matching documents are included in the results, it has no effect on how they are scored
        /// and sorted. The <code>filterQuery</code> parameter supports the full structured query
        /// syntax. 
        /// <para>
        /// For more information about using filters, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/filtering-results.html">Filtering
        /// Matching Documents</a>         in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterQuery { get; set; }
        #endregion

        #region Parameter Highlight
        /// <summary>
        /// <para>
        /// Retrieves highlights for matches in the specified <code>text</code> or         <code>text-array</code>
        /// fields. Each specified field must be highlight enabled in the domain configuration.
        /// The fields and options are specified in JSON using the form <code>{"FIELD":{"OPTION":VALUE,"OPTION:"STRING"},"FIELD":{"OPTION":VALUE,"OPTION":"STRING"}}</code>.
        /// </para>
        ///  
        /// <para>
        /// You can specify the following highlight options:
        /// </para>
        ///  <ul> <li> <code>format</code>: specifies the format of the data in the text field:
        /// <code>text</code> or <code>html</code>. When data is returned as HTML, all non-alphanumeric
        /// characters are encoded. The default is <code>html</code>. </li> <li> <code>max_phrases</code>:
        /// specifies the maximum number of occurrences of the search term(s) you want to highlight.
        /// By default, the first occurrence is highlighted. </li> <li> <code>pre_tag</code>:
        /// specifies the string to prepend to an occurrence of a search term. The default for
        /// HTML highlights is <code>&amp;lt;em&amp;gt;</code>. The default for text highlights
        /// is <code>*</code>. </li> <li> <code>post_tag</code>: specifies the string to append
        /// to an occurrence of a search term. The default for HTML highlights is <code>&amp;lt;/em&amp;gt;</code>.
        /// The default for text highlights is <code>*</code>. </li> </ul> 
        /// <para>
        /// If no highlight options are specified for a field, the returned field text is treated
        /// as HTML and the first match is            highlighted with emphasis tags:  <code>&amp;lt;em&gt;search-term&amp;lt;/em&amp;gt;</code>.
        /// </para>
        ///  
        /// <para>
        /// For example, the following request retrieves highlights for the <code>actors</code>
        /// and <code>title</code> fields.
        /// </para>
        ///  
        /// <para>
        ///  <code>{ "actors": {}, "title": {"format": "text","max_phrases": 2,"pre_tag": "<b>","post_tag":
        /// "</b>"} }</code>
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Highlight { get; set; }
        #endregion

        #region Parameter Partial
        /// <summary>
        /// Enables partial results to be returned if one or more index partitions are unavailable.
        /// When your search index is partitioned across multiple search instances, by default
        /// Amazon CloudSearch only returns results if every partition can be queried. This means
        /// that the failure of a single search instance can result in 5xx (internal server) errors.
        /// When you enable partial results, Amazon CloudSearch returns whatever results are available
        /// and includes the percentage of documents searched in the search results (percent-searched).
        /// This enables you to more gracefully degrade your users' search experience. For example,
        /// rather than displaying no results, you could display the partial results and a message
        /// indicating that the results might be incomplete due to a temporary system outage.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Partial { get; set; }
        #endregion

        #region Parameter Query
        /// <summary>
        /// Specifies the search criteria for the request. How you specify the search        
        /// criteria depends on the query parser used for the request and the parser options 
        ///        specified in the <code>queryOptions</code> parameter. By default,         the
        /// <code>simple</code> query parser is used to process requests. To use         the <code>structured</code>,
        /// <code>lucene</code>, or <code>dismax</code> query parser,          you must also specify
        /// the <code>queryParser</code> parameter. 
        /// <para>
        /// For more information about specifying search criteria, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/searching.html">Searching
        /// Your Data</a> in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Query { get; set; }
        #endregion

        #region Parameter QueryOption
        /// <summary>
        /// <para>
        /// Configures options for the query parser specified in the <code>queryParser</code>
        /// parameter. You specify the options in JSON using the following form <code>{"OPTION1":"VALUE1","OPTION2":VALUE2"..."OPTIONN":"VALUEN"}.</code>
        /// </para>
        ///  
        /// <para>
        /// The options you can configure vary according to which parser you use:
        /// </para>
        ///  <ul> <li> <code>defaultOperator</code>: The default operator used to combine individual
        /// terms in the search string. For example: <code>defaultOperator: 'or'</code>. For the
        /// <code>dismax</code> parser, you specify a percentage that represents the percentage
        /// of terms in the search string (rounded down) that must match, rather than a default
        /// operator. A value of <code>0%</code> is the equivalent to OR, and a value of <code>100%</code>
        /// is equivalent to AND. The percentage must be specified as a value in the range 0-100
        /// followed by the percent (%) symbol. For example, <code>defaultOperator: 50%</code>.
        /// Valid values: <code>and</code>, <code>or</code>, a percentage in the range 0%-100%
        /// (<code>dismax</code>). Default: <code>and</code> (<code>simple</code>, <code>structured</code>,
        /// <code>lucene</code>) or <code>100</code> (<code>dismax</code>). Valid for: <code>simple</code>,
        /// <code>structured</code>, <code>lucene</code>, and <code>dismax</code>.</li> <li> <code>fields</code>:
        /// An array of the fields to search when no fields are specified in a search. If no fields
        /// are specified in a search and this option is not specified, all text and text-array
        /// fields are searched. You can specify a weight for each field to control the relative
        /// importance of each field when Amazon CloudSearch calculates relevance scores. To specify
        /// a field weight, append a caret (<code>^</code>) symbol and the weight to the field
        /// name. For example, to boost the importance of the <code>title</code> field over the
        /// <code>description</code> field you could specify: <code>"fields":["title^5","description"]</code>.
        ///  Valid values: The name of any configured field and an optional numeric value greater
        /// than zero. Default: All <code>text</code> and <code>text-array</code> fields. Valid
        /// for: <code>simple</code>, <code>structured</code>, <code>lucene</code>, and <code>dismax</code>.</li>
        /// <li> <code>operators</code>: An array of the operators or special characters you want
        /// to disable for the simple query parser. If you disable the <code>and</code>, <code>or</code>,
        /// or <code>not</code> operators, the corresponding operators (<code>+</code>, <code>|</code>,
        /// <code>-</code>) have no special meaning and are dropped from the search string. Similarly,
        /// disabling <code>prefix</code> disables the wildcard operator (<code>*</code>) and
        /// disabling <code>phrase</code> disables the ability to search for phrases by enclosing
        /// phrases in double quotes. Disabling precedence disables the ability to control order
        /// of precedence using parentheses. Disabling <code>near</code> disables the ability
        /// to use the ~ operator to perform a sloppy phrase search. Disabling the <code>fuzzy</code>
        /// operator disables the ability to use the ~ operator to perform a fuzzy search. <code>escape</code>
        /// disables the ability to use a backslash (<code>\</code>) to escape special characters
        /// within the search string. Disabling whitespace is an advanced option that prevents
        /// the parser from tokenizing on whitespace, which can be useful for Vietnamese. (It
        /// prevents Vietnamese words from being split incorrectly.) For example, you could disable
        /// all operators other than the phrase operator to support just simple term and phrase
        /// queries: <code>"operators":["and","not","or", "prefix"]</code>. Valid values: <code>and</code>,
        /// <code>escape</code>, <code>fuzzy</code>, <code>near</code>, <code>not</code>, <code>or</code>,
        /// <code>phrase</code>, <code>precedence</code>, <code>prefix</code>, <code>whitespace</code>.
        /// Default: All operators and special characters are enabled. Valid for: <code>simple</code>.</li>
        /// <li> <code>phraseFields</code>: An array of the <code>text</code> or <code>text-array</code>
        /// fields you want to use for phrase searches. When the terms in the search string appear
        /// in close proximity within a field, the field scores higher. You can specify a weight
        /// for each field to boost that score. The <code>phraseSlop</code> option controls how
        /// much the matches can deviate from the search string and still be boosted. To specify
        /// a field weight, append a caret (<code>^</code>) symbol and the weight to the field
        /// name. For example, to boost phrase matches in the <code>title</code> field over the
        /// <code>abstract</code> field, you could specify: <code>"phraseFields":["title^3", "plot"]</code>
        /// Valid values: The name of any <code>text</code> or <code>text-array</code> field and
        /// an optional numeric value greater than zero. Default: No fields. If you don't specify
        /// any fields with <code>phraseFields</code>, proximity scoring is disabled even if <code>phraseSlop</code>
        /// is specified. Valid for: <code>dismax</code>.</li> <li> <code>phraseSlop</code>: An
        /// integer value that specifies how much matches can deviate from the search phrase and
        /// still be boosted according to the weights specified in the <code>phraseFields</code>
        /// option; for example, <code>phraseSlop: 2</code>. You must also specify <code>phraseFields</code>
        /// to enable proximity scoring. Valid values: positive integers. Default: 0. Valid for:
        /// <code>dismax</code>.</li> <li> <code>explicitPhraseSlop</code>: An integer value that
        /// specifies how much a match can deviate from the search phrase when the phrase is enclosed
        /// in double quotes in the search string. (Phrases that exceed this proximity distance
        /// are not considered a match.) For example, to specify a slop of three for dismax phrase
        /// queries, you would specify <code>"explicitPhraseSlop":3</code>. Valid values: positive
        /// integers. Default: 0. Valid for: <code>dismax</code>.</li> <li> <code>tieBreaker</code>:
        /// When a term in the search string is found in a document's field, a score is calculated
        /// for that field based on how common the word is in that field compared to other documents.
        /// If the term occurs in multiple fields within a document, by default only the highest
        /// scoring field contributes to the document's overall score. You can specify a <code>tieBreaker</code>
        /// value to enable the matches in lower-scoring fields to contribute to the document's
        /// score. That way, if two documents have the same max field score for a particular term,
        /// the score for the document that has matches in more fields will be higher. The formula
        /// for calculating the score with a tieBreaker is <code>(max field score) + (tieBreaker)
        /// * (sum of the scores for the rest of the matching fields)</code>. Set <code>tieBreaker</code>
        /// to 0 to disregard all but the highest scoring field (pure max): <code>"tieBreaker":0</code>.
        /// Set to 1 to sum the scores from all fields (pure sum): <code>"tieBreaker":1</code>.
        /// Valid values: 0.0 to 1.0. Default: 0.0. Valid for: <code>dismax</code>. </li> </ul>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryOptions")]
        public System.String QueryOption { get; set; }
        #endregion

        #region Parameter QueryParser
        /// <summary>
        /// <para>
        /// Specifies which         query parser to use to process the request. If <code>queryParser</code>
        /// is not specified, Amazon CloudSearch         uses the <code>simple</code> query parser.
        /// 
        /// </para><para>
        /// Amazon CloudSearch supports four query parsers:
        /// </para><ul><li><code>simple</code>: perform simple searches of
        /// <code>text</code> and               <code>text-array</code> fields. By default, the
        ///               <code>simple</code> query parser searches all               <code>text</code>
        /// and <code>text-array</code> fields. You               can specify which fields to
        /// search by with the               <code>queryOptions</code> parameter. If you prefix
        /// a search               term with a plus sign (+) documents must contain the term to
        /// be considered a match.                (This is the default, unless you configure the
        /// default operator with the <code>queryOptions</code> parameter.)               You
        /// can use the <code>-</code> (NOT), <code>|</code>               (OR), and <code>*</code>
        /// (wildcard) operators to exclude               particular terms, find results that
        /// match any of the specified               terms, or search for a prefix. To search
        /// for a phrase rather               than individual terms, enclose the phrase in double
        /// quotes. For               more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/searching-text.html">Searching
        /// for Text</a> in the <i>Amazon CloudSearch Developer Guide</i>.          </li><li><code>structured</code>: perform advanced searches by combining
        ///                multiple expressions to define the search criteria. You can also search
        ///                within particular fields, search for values and ranges of values, and
        /// use                advanced options such as term boosting, <code>matchall</code>,
        /// and <code>near</code>.                For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/searching-compound-queries.html">Constructing
        /// Compound Queries</a> in the <i>Amazon CloudSearch Developer Guide</i>.         </li><li><code>lucene</code>: search using the Apache Lucene query
        /// parser syntax.                For more information, see <a href="http://lucene.apache.org/core/4_6_0/queryparser/org/apache/lucene/queryparser/classic/package-summary.html#package_description">Apache
        /// Lucene Query Parser Syntax</a>.         </li><li><code>dismax</code>:
        /// search using the simplified subset of the Apache Lucene query parser syntax      
        ///         defined by the DisMax query parser.               For more information, see
        /// <a href="http://wiki.apache.org/solr/DisMaxQParserPlugin#Query_Syntax">DisMax Query
        /// Parser Syntax</a>.         </li></ul>
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudSearchDomain.QueryParser")]
        public Amazon.CloudSearchDomain.QueryParser QueryParser { get; set; }
        #endregion

        #region Parameter Return 
        /// <summary>
        /// Specifies the field and expression values to include in the response. Multiple fields
        /// or expressions are specified as a comma-separated list. By default, a search response
        /// includes all         return enabled fields (<code>_all_fields</code>).          To
        ///  return only the document IDs for the matching documents,          specify <code>_no_fields</code>.
        ///         To retrieve the relevance score calculated for each document,          specify
        /// <code>_score</code>.  
        /// </para>
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Return { get; set; }
        #endregion

        #region Parameter Size
        /// <summary>
        /// Specifies the maximum number of search hits to include in the response. 
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Size { get; set; }
        #endregion

        #region Parameter Sort
        /// <summary>
        /// Specifies the fields or custom expressions to use to sort the search         results.
        /// Multiple fields or expressions are specified as a comma-separated list.         You
        /// must specify the sort direction (<code>asc</code> or         <code>desc</code>) for
        /// each field; for example, <code>year            desc,title asc</code>. To use a field
        /// to sort results, the field must be sort-enabled in         the domain configuration.
        /// Array type fields cannot be used for sorting.         If no <code>sort</code> parameter
        /// is specified, results are sorted by         their default relevance scores in descending
        /// order: <code>_score            desc</code>. You can also sort by document ID     
        ///    (<code>_id asc</code>) and version (<code>_version desc</code>).
        /// <para>
        /// For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/sorting-results.html">Sorting
        /// Results</a> in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sort { get; set; }
        #endregion

        #region Parameter Start
        /// <summary>
        /// Specifies the offset of the first search hit you want to return. Note that the result
        /// set is zero-based; the first result is at index 0. You can specify either the <code>start</code>
        /// or <code>cursor</code> parameter in a request, they are mutually exclusive.  
        /// <para>
        /// For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/paginating-results.html">Paginating
        /// Results</a> in the <i>Amazon CloudSearch Developer Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Start { get; set; }
        #endregion

        #region Parameter UseAnonymousCredentials
        /// <summary>
        /// If set, the cmdlet calls the service operation using anonymous credentials.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseAnonymousCredentials { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudSearchDomain.Model.SearchResponse).
        /// Specifying the name of a property of type Amazon.CloudSearchDomain.Model.SearchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "*";
        #endregion

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            this._ExecuteWithAnonymousCredentials =
                this.UseAnonymousCredentials.IsPresent;

            base.ProcessRecord();

            var context = new CmdletContext();

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudSearchDomain.Model.SearchResponse, SearchCSDDocumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            context.ServiceUrl = this.ServiceUrl;
            context.Cursor = this.Cursor;
            context.Expr = this.Expr;
            context.Facet = this.Facet;
            context.FilterQuery = this.FilterQuery;
            context.Highlight = this.Highlight;
            context.Partial = this.Partial;
            context.Query = this.Query;
            context.QueryOptions = this.QueryOption;
            context.QueryParser = this.QueryParser;
            context.Return = this.Return;
            context.Size = this.Size;
            context.Sort = this.Sort;
            context.Start = this.Start;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SearchRequest();
            
            if (cmdletContext.Cursor != null)
            {
                request.Cursor = cmdletContext.Cursor;
            }
            if (cmdletContext.Expr != null)
            {
                request.Expr = cmdletContext.Expr;
            }
            if (cmdletContext.Facet != null)
            {
                request.Facet = cmdletContext.Facet;
            }
            if (cmdletContext.FilterQuery != null)
            {
                request.FilterQuery = cmdletContext.FilterQuery;
            }
            if (cmdletContext.Highlight != null)
            {
                request.Highlight = cmdletContext.Highlight;
            }
            if (cmdletContext.Partial != null)
            {
                request.Partial = cmdletContext.Partial.Value;
            }
            if (cmdletContext.Query != null)
            {
                request.Query = cmdletContext.Query;
            }
            if (cmdletContext.QueryOptions != null)
            {
                request.QueryOptions = cmdletContext.QueryOptions;
            }
            if (cmdletContext.QueryParser != null)
            {
                request.QueryParser = cmdletContext.QueryParser;
            }
            if (cmdletContext.Return != null)
            {
                request.Return = cmdletContext.Return;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
            }
            if (cmdletContext.Sort != null)
            {
                request.Sort = cmdletContext.Sort;
            }
            if (cmdletContext.Start != null)
            {
                request.Start = cmdletContext.Start.Value;
            }
            
            CmdletOutput output;

            // issue call
            using (var client = CreateClient(cmdletContext.ServiceUrl))
            {
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = cmdletContext.Select(response, this);
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
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.CloudSearchDomain.Model.SearchResponse CallAWSServiceOperation(IAmazonCloudSearchDomain client, Amazon.CloudSearchDomain.Model.SearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearchDomain", "Search");

            try
            {
                return client.SearchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public string ServiceUrl { get; set; }
            public String Cursor { get; set; }
            public String Expr { get; set; }
            public String Facet { get; set; }
            public String FilterQuery { get; set; }
            public String Highlight { get; set; }
            public Boolean? Partial { get; set; }
            public String Query { get; set; }
            public String QueryOptions { get; set; }
            public QueryParser QueryParser { get; set; }
            public String Return { get; set; }
            public Int64? Size { get; set; }
            public String Sort { get; set; }
            public Int64? Start { get; set; }
            public System.Func<Amazon.CloudSearchDomain.Model.SearchResponse, SearchCSDDocumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
