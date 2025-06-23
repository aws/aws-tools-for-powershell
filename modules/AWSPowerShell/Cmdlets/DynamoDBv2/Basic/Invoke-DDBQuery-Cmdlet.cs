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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// You must provide the name of the partition key attribute and a single value for that
    /// attribute. <c>Query</c> returns all items with that partition key value. Optionally,
    /// you can provide a sort key attribute and use a comparison operator to refine the search
    /// results.
    /// 
    ///  
    /// <para>
    /// Use the <c>KeyConditionExpression</c> parameter to provide a specific value for the
    /// partition key. The <c>Query</c> operation will return all of the items from the table
    /// or index with that partition key value. You can optionally narrow the scope of the
    /// <c>Query</c> operation by specifying a sort key value and a comparison operator in
    /// <c>KeyConditionExpression</c>. To further refine the <c>Query</c> results, you can
    /// optionally provide a <c>FilterExpression</c>. A <c>FilterExpression</c> determines
    /// which items within the results should be returned to you. All of the other results
    /// are discarded. 
    /// </para><para>
    ///  A <c>Query</c> operation always returns a result set. If no matching items are found,
    /// the result set will be empty. Queries that do not return results consume the minimum
    /// number of read capacity units for that type of read operation. 
    /// </para><note><para>
    ///  DynamoDB calculates the number of read capacity units consumed based on item size,
    /// not on the amount of data that is returned to an application. The number of capacity
    /// units consumed will be the same whether you request all of the attributes (the default
    /// behavior) or just some of them (using a projection expression). The number will also
    /// be the same whether or not you use a <c>FilterExpression</c>. 
    /// </para></note><para><c>Query</c> results are always sorted by the sort key value. If the data type of
    /// the sort key is Number, the results are returned in numeric order; otherwise, the
    /// results are returned in order of UTF-8 bytes. By default, the sort order is ascending.
    /// To reverse the order, set the <c>ScanIndexForward</c> parameter to false. 
    /// </para><para>
    ///  A single <c>Query</c> operation will read up to the maximum number of items set (if
    /// using the <c>Limit</c> parameter) or a maximum of 1 MB of data and then apply any
    /// filtering to the results using <c>FilterExpression</c>. If <c>LastEvaluatedKey</c>
    /// is present in the response, you will need to paginate the result set. For more information,
    /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Query.html#Query.Pagination">Paginating
    /// the Results</a> in the <i>Amazon DynamoDB Developer Guide</i>. 
    /// </para><para><c>FilterExpression</c> is applied after a <c>Query</c> finishes, but before the
    /// results are returned. A <c>FilterExpression</c> cannot contain partition key or sort
    /// key attributes. You need to specify those attributes in the <c>KeyConditionExpression</c>.
    /// 
    /// </para><note><para>
    ///  A <c>Query</c> operation can return an empty result set and a <c>LastEvaluatedKey</c>
    /// if all the items read for the page of results are filtered out. 
    /// </para></note><para>
    /// You can query a table, a local secondary index, or a global secondary index. For a
    /// query on a table or on a local secondary index, you can set the <c>ConsistentRead</c>
    /// parameter to <c>true</c> and obtain a strongly consistent result. Global secondary
    /// indexes support eventually consistent reads only, so do not specify <c>ConsistentRead</c>
    /// when querying a global secondary index.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Invoke", "DDBQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Collections.Generic.Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>")]
    [AWSCmdlet("Calls the Amazon DynamoDB Query API operation.", Operation = new[] {"Query"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.QueryResponse))]
    [AWSCmdletOutput("System.Collections.Generic.Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> or Amazon.DynamoDBv2.Model.QueryResponse",
        "This cmdlet returns a collection of Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.QueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeDDBQueryCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributesToGet
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <c>ProjectionExpression</c> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.AttributesToGet.html">AttributesToGet</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AttributesToGet { get; set; }
        #endregion
        
        #region Parameter ConditionalOperator
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <c>FilterExpression</c> instead. For more information,
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
        /// <para>Determines the read consistency model: If set to <c>true</c>, then the operation uses
        /// strongly consistent reads; otherwise, the operation uses eventually consistent reads.</para><para>Strongly consistent reads are not supported on global secondary indexes. If you query
        /// a global secondary index with <c>ConsistentRead</c> set to <c>true</c>, you will receive
        /// a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConsistentRead { get; set; }
        #endregion
        
        #region Parameter ExpressionAttributeName
        /// <summary>
        /// <para>
        /// <para>One or more substitution tokens for attribute names in an expression. The following
        /// are some use cases for using <c>ExpressionAttributeNames</c>:</para><ul><li><para>To access an attribute whose name conflicts with a DynamoDB reserved word.</para></li><li><para>To create a placeholder for repeating occurrences of an attribute name in an expression.</para></li><li><para>To prevent special characters in an attribute name from being misinterpreted in an
        /// expression.</para></li></ul><para>Use the <b>#</b> character in an expression to dereference an attribute name. For
        /// example, consider the following attribute name:</para><ul><li><para><c>Percentile</c></para></li></ul><para>The name of this attribute conflicts with a reserved word, so it cannot be used directly
        /// in an expression. (For the complete list of reserved words, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ReservedWords.html">Reserved
        /// Words</a> in the <i>Amazon DynamoDB Developer Guide</i>). To work around this, you
        /// could specify the following for <c>ExpressionAttributeNames</c>:</para><ul><li><para><c>{"#P":"Percentile"}</c></para></li></ul><para>You could then use this substitution in an expression, as in this example:</para><ul><li><para><c>#P = :val</c></para></li></ul><note><para>Tokens that begin with the <b>:</b> character are <i>expression attribute values</i>,
        /// which are placeholders for the actual value at runtime.</para></note><para>For more information on expression attribute names, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.AccessingItemAttributes.html">Specifying
        /// Item Attributes</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// For example, suppose that you wanted to check whether the value of the <i>ProductStatus</i>
        /// attribute was one of the following: </para><para><c>Available | Backordered | Discontinued</c></para><para>You would first need to specify <c>ExpressionAttributeValues</c> as follows:</para><para><c>{ ":avail":{"S":"Available"}, ":back":{"S":"Backordered"}, ":disc":{"S":"Discontinued"}
        /// }</c></para><para>You could then use these values in an expression, such as this:</para><para><c>ProductStatus IN (:avail, :back, :disc)</c></para><para>For more information on expression attribute values, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.SpecifyingConditions.html">Specifying
        /// Conditions</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpressionAttributeValues")]
        public System.Collections.Hashtable ExpressionAttributeValue { get; set; }
        #endregion
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>A string that contains conditions that DynamoDB applies after the <c>Query</c> operation,
        /// but before the data is returned to you. Items that do not satisfy the <c>FilterExpression</c>
        /// criteria are not returned.</para><para>A <c>FilterExpression</c> does not allow key attributes. You cannot define a filter
        /// expression based on a partition key or a sort key.</para><note><para>A <c>FilterExpression</c> is applied after the items have already been read; the process
        /// of filtering does not consume any additional read capacity units.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Query.FilterExpression.html">Filter
        /// Expressions</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of an index to query. This index can be any local secondary index or global
        /// secondary index on the table. Note that if you use the <c>IndexName</c> parameter,
        /// you must also provide <c>TableName.</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter IsLimitSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.DynamoDBv2.Model.QueryRequest.Limit" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// <para>If this property is set to false the property <seealso cref="P:Amazon.DynamoDBv2.Model.QueryRequest.Limit" /> will be reset to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLimitSet { get; set; }
        #endregion
        
        #region Parameter KeyConditionExpression
        /// <summary>
        /// <para>
        /// <para>The condition that specifies the key values for items to be retrieved by the <c>Query</c>
        /// action.</para><para>The condition must perform an equality test on a single partition key value.</para><para>The condition can optionally perform one of several comparison tests on a single sort
        /// key value. This allows <c>Query</c> to retrieve one item with a given partition key
        /// value and sort key value, or several items that have the same partition key value
        /// but different sort key values.</para><para>The partition key equality test is required, and must be specified in the following
        /// format:</para><para><c>partitionKeyName</c><i>=</i><c>:partitionkeyval</c></para><para>If you also want to provide a condition for the sort key, it must be combined using
        /// <c>AND</c> with the condition for the sort key. Following is an example, using the
        /// <b>=</b> comparison operator for the sort key:</para><para><c>partitionKeyName</c><c>=</c><c>:partitionkeyval</c><c>AND</c><c>sortKeyName</c><c>=</c><c>:sortkeyval</c></para><para>Valid comparisons for the sort key condition are as follows:</para><ul><li><para><c>sortKeyName</c><c>=</c><c>:sortkeyval</c> - true if the sort key value is equal
        /// to <c>:sortkeyval</c>.</para></li><li><para><c>sortKeyName</c><c>&lt;</c><c>:sortkeyval</c> - true if the sort key value is
        /// less than <c>:sortkeyval</c>.</para></li><li><para><c>sortKeyName</c><c>&lt;=</c><c>:sortkeyval</c> - true if the sort key value is
        /// less than or equal to <c>:sortkeyval</c>.</para></li><li><para><c>sortKeyName</c><c>&gt;</c><c>:sortkeyval</c> - true if the sort key value is
        /// greater than <c>:sortkeyval</c>.</para></li><li><para><c>sortKeyName</c><c>&gt;= </c><c>:sortkeyval</c> - true if the sort key value
        /// is greater than or equal to <c>:sortkeyval</c>.</para></li><li><para><c>sortKeyName</c><c>BETWEEN</c><c>:sortkeyval1</c><c>AND</c><c>:sortkeyval2</c>
        /// - true if the sort key value is greater than or equal to <c>:sortkeyval1</c>, and
        /// less than or equal to <c>:sortkeyval2</c>.</para></li><li><para><c>begins_with (</c><c>sortKeyName</c>, <c>:sortkeyval</c><c>)</c> - true if the
        /// sort key value begins with a particular operand. (You cannot use this function with
        /// a sort key that is of type Number.) Note that the function name <c>begins_with</c>
        /// is case-sensitive.</para></li></ul><para>Use the <c>ExpressionAttributeValues</c> parameter to replace tokens such as <c>:partitionval</c>
        /// and <c>:sortval</c> with actual values at runtime.</para><para>You can optionally use the <c>ExpressionAttributeNames</c> parameter to replace the
        /// names of the partition key and sort key with placeholder tokens. This option might
        /// be necessary if an attribute name conflicts with a DynamoDB reserved word. For example,
        /// the following <c>KeyConditionExpression</c> parameter causes an error because <i>Size</i>
        /// is a reserved word:</para><ul><li><para><c>Size = :myval</c></para></li></ul><para>To work around this, define a placeholder (such a <c>#S</c>) to represent the attribute
        /// name <i>Size</i>. <c>KeyConditionExpression</c> then is as follows:</para><ul><li><para><c>#S = :myval</c></para></li></ul><para>For a list of reserved words, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ReservedWords.html">Reserved
        /// Words</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>For more information on <c>ExpressionAttributeNames</c> and <c>ExpressionAttributeValues</c>,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ExpressionPlaceholders.html">Using
        /// Placeholders for Attribute Names and Values</a> in the <i>Amazon DynamoDB Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyConditionExpression { get; set; }
        #endregion
        
        #region Parameter KeyCondition
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <c>KeyConditionExpression</c> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.KeyConditions.html">KeyConditions</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyConditions")]
        public System.Collections.Hashtable KeyCondition { get; set; }
        #endregion
        
        #region Parameter ProjectionExpression
        /// <summary>
        /// <para>
        /// <para>A string that identifies one or more attributes to retrieve from the table. These
        /// attributes can include scalars, sets, or elements of a JSON document. The attributes
        /// in the expression must be separated by commas.</para><para>If no attribute names are specified, then all attributes will be returned. If any
        /// of the requested attributes are not found, they will not appear in the result.</para><para>For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.AccessingItemAttributes.html">Accessing
        /// Item Attributes</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectionExpression { get; set; }
        #endregion
        
        #region Parameter QueryFilter
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <c>FilterExpression</c> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.QueryFilter.html">QueryFilter</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable QueryFilter { get; set; }
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
        
        #region Parameter ScanIndexForward
        /// <summary>
        /// <para>
        /// <para>Specifies the order for index traversal: If <c>true</c> (default), the traversal is
        /// performed in ascending order; if <c>false</c>, the traversal is performed in descending
        /// order. </para><para>Items with the same partition key value are stored in sorted order by sort key. If
        /// the sort key data type is Number, the results are stored in numeric order. For type
        /// String, the results are stored in order of UTF-8 bytes. For type Binary, DynamoDB
        /// treats each byte of the binary data as unsigned.</para><para>If <c>ScanIndexForward</c> is <c>true</c>, DynamoDB returns the results in the order
        /// in which they are stored (by sort key value). This is the default behavior. If <c>ScanIndexForward</c>
        /// is <c>false</c>, DynamoDB reads the results in reverse order by sort key value, and
        /// then returns the results to the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ScanIndexForward { get; set; }
        #endregion
        
        #region Parameter SelectItem
        /// <summary>
        /// <para>
        /// <para>The attributes to be returned in the result. You can retrieve all item attributes,
        /// specific item attributes, the count of matching items, or in the case of an index,
        /// some or all of the attributes projected into the index.</para><ul><li><para><c>ALL_ATTRIBUTES</c> - Returns all of the item attributes from the specified table
        /// or index. If you query a local secondary index, then for each matching item in the
        /// index, DynamoDB fetches the entire item from the parent table. If the index is configured
        /// to project all item attributes, then all of the data can be obtained from the local
        /// secondary index, and no fetching is required.</para></li><li><para><c>ALL_PROJECTED_ATTRIBUTES</c> - Allowed only when querying an index. Retrieves
        /// all attributes that have been projected into the index. If the index is configured
        /// to project all attributes, this return value is equivalent to specifying <c>ALL_ATTRIBUTES</c>.</para></li><li><para><c>COUNT</c> - Returns the number of matching items, rather than the matching items
        /// themselves. Note that this uses the same quantity of read capacity units as getting
        /// the items, and is subject to the same item size calculations.</para></li><li><para><c>SPECIFIC_ATTRIBUTES</c> - Returns only the attributes listed in <c>ProjectionExpression</c>.
        /// This return value is equivalent to specifying <c>ProjectionExpression</c> without
        /// specifying any value for <c>Select</c>.</para><para>If you query or scan a local secondary index and request only attributes that are
        /// projected into that index, the operation will read only the index and not the table.
        /// If any of the requested attributes are not projected into the local secondary index,
        /// DynamoDB fetches each of these attributes from the parent table. This extra fetching
        /// incurs additional throughput cost and latency.</para><para>If you query or scan a global secondary index, you can only request attributes that
        /// are projected into the index. Global secondary index queries cannot fetch attributes
        /// from the parent table.</para></li></ul><para>If neither <c>Select</c> nor <c>ProjectionExpression</c> are specified, DynamoDB defaults
        /// to <c>ALL_ATTRIBUTES</c> when accessing a table, and <c>ALL_PROJECTED_ATTRIBUTES</c>
        /// when accessing an index. You cannot use both <c>Select</c> and <c>ProjectionExpression</c>
        /// together in a single request, unless the value for <c>Select</c> is <c>SPECIFIC_ATTRIBUTES</c>.
        /// (This usage is equivalent to specifying <c>ProjectionExpression</c> without any value
        /// for <c>Select</c>.)</para><note><para>If you use the <c>ProjectionExpression</c> parameter, then the value for <c>Select</c>
        /// can only be <c>SPECIFIC_ATTRIBUTES</c>. Any other value for <c>Select</c> will return
        /// an error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.Select")]
        public Amazon.DynamoDBv2.Select SelectItem { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table containing the requested items. You can also provide the Amazon
        /// Resource Name (ARN) of the table in this parameter.</para>
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
        
        #region Parameter ExclusiveStartKey
        /// <summary>
        /// <para>
        /// <para>The primary key of the first item that this operation will evaluate. Use the value
        /// that was returned for <c>LastEvaluatedKey</c> in the previous operation.</para><para>The data type for <c>ExclusiveStartKey</c> must be String, Number, or Binary. No set
        /// data types are allowed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'ExclusiveStartKey' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-ExclusiveStartKey' to null for the first call then set the 'ExclusiveStartKey' using the same property output from the previous call for subsequent calls.
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
        /// in <c>LastEvaluatedKey</c> to apply in a subsequent operation, so that you can pick
        /// up where you left off. Also, if the processed dataset size exceeds 1 MB before DynamoDB
        /// reaches this limit, it stops the operation and returns the matching values up to the
        /// limit, and a key in <c>LastEvaluatedKey</c> to apply in a subsequent operation to
        /// continue the operation. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/QueryAndScan.html">Query
        /// and Scan</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.QueryResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.QueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-DDBQuery (Query)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.QueryResponse, InvokeDDBQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
                    context.ExclusiveStartKey.Add((String)hashKey, (Amazon.DynamoDBv2.Model.AttributeValue)(this.ExclusiveStartKey[hashKey]));
                }
            }
            if (this.ExpressionAttributeName != null)
            {
                context.ExpressionAttributeName = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExpressionAttributeName.Keys)
                {
                    context.ExpressionAttributeName.Add((String)hashKey, (System.String)(this.ExpressionAttributeName[hashKey]));
                }
            }
            if (this.ExpressionAttributeValue != null)
            {
                context.ExpressionAttributeValue = new Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExpressionAttributeValue.Keys)
                {
                    context.ExpressionAttributeValue.Add((String)hashKey, (Amazon.DynamoDBv2.Model.AttributeValue)(this.ExpressionAttributeValue[hashKey]));
                }
            }
            context.FilterExpression = this.FilterExpression;
            context.IndexName = this.IndexName;
            context.KeyConditionExpression = this.KeyConditionExpression;
            if (this.KeyCondition != null)
            {
                context.KeyCondition = new Dictionary<System.String, Amazon.DynamoDBv2.Model.Condition>(StringComparer.Ordinal);
                foreach (var hashKey in this.KeyCondition.Keys)
                {
                    context.KeyCondition.Add((String)hashKey, (Amazon.DynamoDBv2.Model.Condition)(this.KeyCondition[hashKey]));
                }
            }
            context.Limit = this.Limit;
            context.IsLimitSet = this.IsLimitSet;
            context.ProjectionExpression = this.ProjectionExpression;
            if (this.QueryFilter != null)
            {
                context.QueryFilter = new Dictionary<System.String, Amazon.DynamoDBv2.Model.Condition>(StringComparer.Ordinal);
                foreach (var hashKey in this.QueryFilter.Keys)
                {
                    context.QueryFilter.Add((String)hashKey, (Amazon.DynamoDBv2.Model.Condition)(this.QueryFilter[hashKey]));
                }
            }
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            context.ScanIndexForward = this.ScanIndexForward;
            context.SelectItem = this.SelectItem;
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DynamoDBv2.Model.QueryRequest();
            
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
            if (cmdletContext.KeyConditionExpression != null)
            {
                request.KeyConditionExpression = cmdletContext.KeyConditionExpression;
            }
            if (cmdletContext.KeyCondition != null)
            {
                request.KeyConditions = cmdletContext.KeyCondition;
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
            if (cmdletContext.QueryFilter != null)
            {
                request.QueryFilter = cmdletContext.QueryFilter;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.ScanIndexForward != null)
            {
                request.ScanIndexForward = cmdletContext.ScanIndexForward.Value;
            }
            if (cmdletContext.SelectItem != null)
            {
                request.Select = cmdletContext.SelectItem;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.DynamoDBv2.Model.QueryResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.QueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "Query");
            try
            {
                return client.QueryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KeyConditionExpression { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.Condition> KeyCondition { get; set; }
            public System.Int32? Limit { get; set; }
            public System.Boolean? IsLimitSet { get; set; }
            public System.String ProjectionExpression { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.Condition> QueryFilter { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public System.Boolean? ScanIndexForward { get; set; }
            public Amazon.DynamoDBv2.Select SelectItem { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.QueryResponse, InvokeDDBQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
