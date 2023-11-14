/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// The <code>Scan</code> operation returns one or more items and item attributes by accessing
    /// every item in a table or a secondary index. To have DynamoDB return fewer items, you
    /// can provide a <code>FilterExpression</code> operation.
    /// 
    ///  
    /// <para>
    /// If the total size of scanned items exceeds the maximum dataset size limit of 1 MB,
    /// the scan completes and results are returned to the user. The <code>LastEvaluatedKey</code>
    /// value is also returned and the requestor can use the <code>LastEvaluatedKey</code>
    /// to continue the scan in a subsequent operation. Each scan response also includes number
    /// of items that were scanned (ScannedCount) as part of the request. If using a <code>FilterExpression</code>,
    /// a scan result can result in no items meeting the criteria and the <code>Count</code>
    /// will result in zero. If you did not use a <code>FilterExpression</code> in the scan
    /// request, then <code>Count</code> is the same as <code>ScannedCount</code>.
    /// </para><note><para><code>Count</code> and <code>ScannedCount</code> only return the count of items specific
    /// to a single scan request and, unless the table is less than 1MB, do not represent
    /// the total number of items in the table. 
    /// </para></note><para>
    /// A single <code>Scan</code> operation first reads up to the maximum number of items
    /// set (if using the <code>Limit</code> parameter) or a maximum of 1 MB of data and then
    /// applies any filtering to the results if a <code>FilterExpression</code> is provided.
    /// If <code>LastEvaluatedKey</code> is present in the response, pagination is required
    /// to complete the full table scan. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Scan.html#Scan.Pagination">Paginating
    /// the Results</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para><para><code>Scan</code> operations proceed sequentially; however, for faster performance
    /// on a large table or secondary index, applications can request a parallel <code>Scan</code>
    /// operation by providing the <code>Segment</code> and <code>TotalSegments</code> parameters.
    /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Scan.html#Scan.ParallelScan">Parallel
    /// Scan</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para><para>
    /// By default, a <code>Scan</code> uses eventually consistent reads when accessing the
    /// items in a table. Therefore, the results from an eventually consistent <code>Scan</code>
    /// may not include the latest item changes at the time the scan iterates through each
    /// item in the table. If you require a strongly consistent read of each item as the scan
    /// iterates through the items in the table, you can set the <code>ConsistentRead</code>
    /// parameter to true. Strong consistency only relates to the consistency of the read
    /// at the item level.
    /// </para><note><para>
    ///  DynamoDB does not provide snapshot isolation for a scan operation when the <code>ConsistentRead</code>
    /// parameter is set to true. Thus, a DynamoDB scan operation does not guarantee that
    /// all reads in a scan see a consistent snapshot of the table when the scan operation
    /// was requested. 
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Invoke", "DDBScan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Collections.Generic.Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>")]
    [AWSCmdlet("Calls the Amazon DynamoDB Scan API operation.", Operation = new[] {"Scan"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.ScanResponse))]
    [AWSCmdletOutput("System.Collections.Generic.Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> or Amazon.DynamoDBv2.Model.ScanResponse",
        "This cmdlet returns a collection of Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.ScanResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeDDBScanCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributesToGet
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <code>ProjectionExpression</code> instead. For more
        /// information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.AttributesToGet.html">AttributesToGet</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AttributesToGet { get; set; }
        #endregion
        
        #region Parameter ConditionalOperator
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <code>FilterExpression</code> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.ConditionalOperator.html">ConditionalOperator</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ConditionalOperator")]
        public Amazon.DynamoDBv2.ConditionalOperator ConditionalOperator { get; set; }
        #endregion
        
        #region Parameter ConsistentRead
        /// <summary>
        /// <para>
        /// <para>A Boolean value that determines the read consistency model during the scan:</para><ul><li><para>If <code>ConsistentRead</code> is <code>false</code>, then the data returned from
        /// <code>Scan</code> might not contain the results from other recently completed write
        /// operations (<code>PutItem</code>, <code>UpdateItem</code>, or <code>DeleteItem</code>).</para></li><li><para>If <code>ConsistentRead</code> is <code>true</code>, then all of the write operations
        /// that completed before the <code>Scan</code> began are guaranteed to be contained in
        /// the <code>Scan</code> response.</para></li></ul><para>The default setting for <code>ConsistentRead</code> is <code>false</code>.</para><para>The <code>ConsistentRead</code> parameter is not supported on global secondary indexes.
        /// If you scan a global secondary index with <code>ConsistentRead</code> set to true,
        /// you will receive a <code>ValidationException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConsistentRead { get; set; }
        #endregion
        
        #region Parameter ExpressionAttributeName
        /// <summary>
        /// <para>
        /// <para>One or more substitution tokens for attribute names in an expression. The following
        /// are some use cases for using <code>ExpressionAttributeNames</code>:</para><ul><li><para>To access an attribute whose name conflicts with a DynamoDB reserved word.</para></li><li><para>To create a placeholder for repeating occurrences of an attribute name in an expression.</para></li><li><para>To prevent special characters in an attribute name from being misinterpreted in an
        /// expression.</para></li></ul><para>Use the <b>#</b> character in an expression to dereference an attribute name. For
        /// example, consider the following attribute name:</para><ul><li><para><code>Percentile</code></para></li></ul><para>The name of this attribute conflicts with a reserved word, so it cannot be used directly
        /// in an expression. (For the complete list of reserved words, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ReservedWords.html">Reserved
        /// Words</a> in the <i>Amazon DynamoDB Developer Guide</i>). To work around this, you
        /// could specify the following for <code>ExpressionAttributeNames</code>:</para><ul><li><para><code>{"#P":"Percentile"}</code></para></li></ul><para>You could then use this substitution in an expression, as in this example:</para><ul><li><para><code>#P = :val</code></para></li></ul><note><para>Tokens that begin with the <b>:</b> character are <i>expression attribute values</i>,
        /// which are placeholders for the actual value at runtime.</para></note><para>For more information on expression attribute names, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.AccessingItemAttributes.html">Specifying
        /// Item Attributes</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpressionAttributeNames")]
        public System.Collections.Hashtable ExpressionAttributeName { get; set; }
        #endregion
        
        #region Parameter ExpressionAttributeValue
        /// <summary>
        /// <para>
        /// <para>One or more values that can be substituted in an expression.</para><para>Use the <b>:</b> (colon) character in an expression to dereference an attribute value.
        /// For example, suppose that you wanted to check whether the value of the <code>ProductStatus</code>
        /// attribute was one of the following: </para><para><code>Available | Backordered | Discontinued</code></para><para>You would first need to specify <code>ExpressionAttributeValues</code> as follows:</para><para><code>{ ":avail":{"S":"Available"}, ":back":{"S":"Backordered"}, ":disc":{"S":"Discontinued"}
        /// }</code></para><para>You could then use these values in an expression, such as this:</para><para><code>ProductStatus IN (:avail, :back, :disc)</code></para><para>For more information on expression attribute values, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.SpecifyingConditions.html">Condition
        /// Expressions</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpressionAttributeValues")]
        public System.Collections.Hashtable ExpressionAttributeValue { get; set; }
        #endregion
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>A string that contains conditions that DynamoDB applies after the <code>Scan</code>
        /// operation, but before the data is returned to you. Items that do not satisfy the <code>FilterExpression</code>
        /// criteria are not returned.</para><note><para>A <code>FilterExpression</code> is applied after the items have already been read;
        /// the process of filtering does not consume any additional read capacity units.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Scan.html#Scan.FilterExpression">Filter
        /// Expressions</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of a secondary index to scan. This index can be any local secondary index
        /// or global secondary index. Note that if you use the <code>IndexName</code> parameter,
        /// you must also provide <code>TableName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter IsLimitSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.DynamoDBv2.Model.ScanRequest.Limit" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLimitSet { get; set; }
        #endregion
        
        #region Parameter IsSegmentSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.DynamoDBv2.Model.ScanRequest.Segment" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsSegmentSet { get; set; }
        #endregion
        
        #region Parameter IsTotalSegmentsSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.DynamoDBv2.Model.ScanRequest.TotalSegments" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsTotalSegmentsSet { get; set; }
        #endregion
        
        #region Parameter ProjectionExpression
        /// <summary>
        /// <para>
        /// <para>A string that identifies one or more attributes to retrieve from the specified table
        /// or index. These attributes can include scalars, sets, or elements of a JSON document.
        /// The attributes in the expression must be separated by commas.</para><para>If no attribute names are specified, then all attributes will be returned. If any
        /// of the requested attributes are not found, they will not appear in the result.</para><para>For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.AccessingItemAttributes.html">Specifying
        /// Item Attributes</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectionExpression { get; set; }
        #endregion
        
        #region Parameter ReturnConsumedCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnConsumedCapacity")]
        public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
        #endregion
        
        #region Parameter ScanFilter
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <code>FilterExpression</code> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.ScanFilter.html">ScanFilter</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ScanFilter { get; set; }
        #endregion
        
        #region Parameter Segment
        /// <summary>
        /// <para>
        /// <para>For a parallel <code>Scan</code> request, <code>Segment</code> identifies an individual
        /// segment to be scanned by an application worker.</para><para>Segment IDs are zero-based, so the first segment is always 0. For example, if you
        /// want to use four application threads to scan a table or an index, then the first thread
        /// specifies a <code>Segment</code> value of 0, the second thread specifies 1, and so
        /// on.</para><para>The value of <code>LastEvaluatedKey</code> returned from a parallel <code>Scan</code>
        /// request must be used as <code>ExclusiveStartKey</code> with the same segment ID in
        /// a subsequent <code>Scan</code> operation.</para><para>The value for <code>Segment</code> must be greater than or equal to 0, and less than
        /// the value provided for <code>TotalSegments</code>.</para><para>If you provide <code>Segment</code>, you must also provide <code>TotalSegments</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Segment { get; set; }
        #endregion
        
        #region Parameter SelectItem
        /// <summary>
        /// <para>
        /// <para>The attributes to be returned in the result. You can retrieve all item attributes,
        /// specific item attributes, the count of matching items, or in the case of an index,
        /// some or all of the attributes projected into the index.</para><ul><li><para><code>ALL_ATTRIBUTES</code> - Returns all of the item attributes from the specified
        /// table or index. If you query a local secondary index, then for each matching item
        /// in the index, DynamoDB fetches the entire item from the parent table. If the index
        /// is configured to project all item attributes, then all of the data can be obtained
        /// from the local secondary index, and no fetching is required.</para></li><li><para><code>ALL_PROJECTED_ATTRIBUTES</code> - Allowed only when querying an index. Retrieves
        /// all attributes that have been projected into the index. If the index is configured
        /// to project all attributes, this return value is equivalent to specifying <code>ALL_ATTRIBUTES</code>.</para></li><li><para><code>COUNT</code> - Returns the number of matching items, rather than the matching
        /// items themselves. Note that this uses the same quantity of read capacity units as
        /// getting the items, and is subject to the same item size calculations.</para></li><li><para><code>SPECIFIC_ATTRIBUTES</code> - Returns only the attributes listed in <code>ProjectionExpression</code>.
        /// This return value is equivalent to specifying <code>ProjectionExpression</code> without
        /// specifying any value for <code>Select</code>.</para><para>If you query or scan a local secondary index and request only attributes that are
        /// projected into that index, the operation reads only the index and not the table. If
        /// any of the requested attributes are not projected into the local secondary index,
        /// DynamoDB fetches each of these attributes from the parent table. This extra fetching
        /// incurs additional throughput cost and latency.</para><para>If you query or scan a global secondary index, you can only request attributes that
        /// are projected into the index. Global secondary index queries cannot fetch attributes
        /// from the parent table.</para></li></ul><para>If neither <code>Select</code> nor <code>ProjectionExpression</code> are specified,
        /// DynamoDB defaults to <code>ALL_ATTRIBUTES</code> when accessing a table, and <code>ALL_PROJECTED_ATTRIBUTES</code>
        /// when accessing an index. You cannot use both <code>Select</code> and <code>ProjectionExpression</code>
        /// together in a single request, unless the value for <code>Select</code> is <code>SPECIFIC_ATTRIBUTES</code>.
        /// (This usage is equivalent to specifying <code>ProjectionExpression</code> without
        /// any value for <code>Select</code>.)</para><note><para>If you use the <code>ProjectionExpression</code> parameter, then the value for <code>Select</code>
        /// can only be <code>SPECIFIC_ATTRIBUTES</code>. Any other value for <code>Select</code>
        /// will return an error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.Select")]
        public Amazon.DynamoDBv2.Select SelectItem { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table containing the requested items; or, if you provide <code>IndexName</code>,
        /// the name of the table to which that index belongs.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter TotalSegment
        /// <summary>
        /// <para>
        /// <para>For a parallel <code>Scan</code> request, <code>TotalSegments</code> represents the
        /// total number of segments into which the <code>Scan</code> operation will be divided.
        /// The value of <code>TotalSegments</code> corresponds to the number of application workers
        /// that will perform the parallel scan. For example, if you want to use four application
        /// threads to scan a table or an index, specify a <code>TotalSegments</code> value of
        /// 4.</para><para>The value for <code>TotalSegments</code> must be greater than or equal to 1, and less
        /// than or equal to 1000000. If you specify a <code>TotalSegments</code> value of 1,
        /// the <code>Scan</code> operation will be sequential rather than parallel.</para><para>If you specify <code>TotalSegments</code>, you must also specify <code>Segment</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TotalSegments")]
        public System.Int32? TotalSegment { get; set; }
        #endregion
        
        #region Parameter ExclusiveStartKey
        /// <summary>
        /// <para>
        /// <para>The primary key of the first item that this operation will evaluate. Use the value
        /// that was returned for <code>LastEvaluatedKey</code> in the previous operation.</para><para>The data type for <code>ExclusiveStartKey</code> must be String, Number or Binary.
        /// No set data types are allowed.</para><para>In a parallel scan, a <code>Scan</code> request that includes <code>ExclusiveStartKey</code>
        /// must specify the same segment whose previous <code>Scan</code> returned the corresponding
        /// value of <code>LastEvaluatedKey</code>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-ExclusiveStartKey $null' for the first call and '-ExclusiveStartKey $AWSHistory.LastServiceResponse.LastEvaluatedKey' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.Collections.Hashtable ExclusiveStartKey { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to evaluate (not necessarily the number of matching items).
        /// If DynamoDB processes the number of items up to the limit while processing the results,
        /// it stops the operation and returns the matching values up to that point, and a key
        /// in <code>LastEvaluatedKey</code> to apply in a subsequent operation, so that you can
        /// pick up where you left off. Also, if the processed dataset size exceeds 1 MB before
        /// DynamoDB reaches this limit, it stops the operation and returns the matching values
        /// up to the limit, and a key in <code>LastEvaluatedKey</code> to apply in a subsequent
        /// operation to continue the operation. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/QueryAndScan.html">Working
        /// with Queries</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.ScanResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.ScanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.")]
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of ExclusiveStartKey
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-DDBScan (Scan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.ScanResponse, InvokeDDBScanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AttributesToGet != null)
            {
                context.AttributesToGet = new List<System.String>(this.AttributesToGet);
            }
            context.ConditionalOperator = this.ConditionalOperator;
            context.ConsistentRead = this.ConsistentRead;
            if (this.ExclusiveStartKey != null)
            {
                context.ExclusiveStartKey = new Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExclusiveStartKey.Keys)
                {
                    context.ExclusiveStartKey.Add((String)hashKey, (AttributeValue)(this.ExclusiveStartKey[hashKey]));
                }
            }
            if (this.ExpressionAttributeName != null)
            {
                context.ExpressionAttributeName = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExpressionAttributeName.Keys)
                {
                    context.ExpressionAttributeName.Add((String)hashKey, (String)(this.ExpressionAttributeName[hashKey]));
                }
            }
            if (this.ExpressionAttributeValue != null)
            {
                context.ExpressionAttributeValue = new Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExpressionAttributeValue.Keys)
                {
                    context.ExpressionAttributeValue.Add((String)hashKey, (AttributeValue)(this.ExpressionAttributeValue[hashKey]));
                }
            }
            context.FilterExpression = this.FilterExpression;
            context.IndexName = this.IndexName;
            context.Limit = this.Limit;
            context.IsLimitSet = this.IsLimitSet;
            context.ProjectionExpression = this.ProjectionExpression;
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            if (this.ScanFilter != null)
            {
                context.ScanFilter = new Dictionary<System.String, Amazon.DynamoDBv2.Model.Condition>(StringComparer.Ordinal);
                foreach (var hashKey in this.ScanFilter.Keys)
                {
                    context.ScanFilter.Add((String)hashKey, (Condition)(this.ScanFilter[hashKey]));
                }
            }
            context.Segment = this.Segment;
            context.IsSegmentSet = this.IsSegmentSet;
            context.SelectItem = this.SelectItem;
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TotalSegment = this.TotalSegment;
            context.IsTotalSegmentsSet = this.IsTotalSegmentsSet;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.DynamoDBv2.Model.ScanRequest();
            
            if (cmdletContext.AttributesToGet != null)
            {
                request.AttributesToGet = cmdletContext.AttributesToGet;
            }
            if (cmdletContext.ConditionalOperator != null)
            {
                request.ConditionalOperator = cmdletContext.ConditionalOperator;
            }
            if (cmdletContext.ConsistentRead != null)
            {
                request.ConsistentRead = cmdletContext.ConsistentRead.Value;
            }
            if (cmdletContext.ExpressionAttributeName != null)
            {
                request.ExpressionAttributeNames = cmdletContext.ExpressionAttributeName;
            }
            if (cmdletContext.ExpressionAttributeValue != null)
            {
                request.ExpressionAttributeValues = cmdletContext.ExpressionAttributeValue;
            }
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.IsLimitSet != null)
            {
                request.IsLimitSet = cmdletContext.IsLimitSet.Value;
            }
            if (cmdletContext.ProjectionExpression != null)
            {
                request.ProjectionExpression = cmdletContext.ProjectionExpression;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.ScanFilter != null)
            {
                request.ScanFilter = cmdletContext.ScanFilter;
            }
            if (cmdletContext.Segment != null)
            {
                request.Segment = cmdletContext.Segment.Value;
            }
            if (cmdletContext.IsSegmentSet != null)
            {
                request.IsSegmentSet = cmdletContext.IsSegmentSet.Value;
            }
            if (cmdletContext.SelectItem != null)
            {
                request.Select = cmdletContext.SelectItem;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.TotalSegment != null)
            {
                request.TotalSegments = cmdletContext.TotalSegment.Value;
            }
            if (cmdletContext.IsTotalSegmentsSet != null)
            {
                request.IsTotalSegmentsSet = cmdletContext.IsTotalSegmentsSet.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.ExclusiveStartKey;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ExclusiveStartKey));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.ExclusiveStartKey = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.LastEvaluatedKey;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DynamoDBv2.Model.ScanResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.ScanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "Scan");
            try
            {
                #if DESKTOP
                return client.Scan(request);
                #elif CORECLR
                return client.ScanAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributesToGet { get; set; }
            public Amazon.DynamoDBv2.ConditionalOperator ConditionalOperator { get; set; }
            public System.Boolean? ConsistentRead { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> ExclusiveStartKey { get; set; }
            public Dictionary<System.String, System.String> ExpressionAttributeName { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> ExpressionAttributeValue { get; set; }
            public System.String FilterExpression { get; set; }
            public System.String IndexName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.Boolean? IsLimitSet { get; set; }
            public System.String ProjectionExpression { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.Condition> ScanFilter { get; set; }
            public System.Int32? Segment { get; set; }
            public System.Boolean? IsSegmentSet { get; set; }
            public Amazon.DynamoDBv2.Select SelectItem { get; set; }
            public System.String TableName { get; set; }
            public System.Int32? TotalSegment { get; set; }
            public System.Boolean? IsTotalSegmentsSet { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.ScanResponse, InvokeDDBScanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
