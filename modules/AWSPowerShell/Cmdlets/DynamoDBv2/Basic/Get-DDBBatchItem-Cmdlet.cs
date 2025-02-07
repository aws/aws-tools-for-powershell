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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// The <c>BatchGetItem</c> operation returns the attributes of one or more items from
    /// one or more tables. You identify requested items by primary key.
    /// 
    ///  
    /// <para>
    /// A single operation can retrieve up to 16 MB of data, which can contain as many as
    /// 100 items. <c>BatchGetItem</c> returns a partial result if the response size limit
    /// is exceeded, the table's provisioned throughput is exceeded, more than 1MB per partition
    /// is requested, or an internal processing failure occurs. If a partial result is returned,
    /// the operation returns a value for <c>UnprocessedKeys</c>. You can use this value to
    /// retry the operation starting with the next item to get.
    /// </para><important><para>
    /// If you request more than 100 items, <c>BatchGetItem</c> returns a <c>ValidationException</c>
    /// with the message "Too many items requested for the BatchGetItem call."
    /// </para></important><para>
    /// For example, if you ask to retrieve 100 items, but each individual item is 300 KB
    /// in size, the system returns 52 items (so as not to exceed the 16 MB limit). It also
    /// returns an appropriate <c>UnprocessedKeys</c> value so you can get the next page of
    /// results. If desired, your application can include its own logic to assemble the pages
    /// of results into one dataset.
    /// </para><para>
    /// If <i>none</i> of the items can be processed due to insufficient provisioned throughput
    /// on all of the tables in the request, then <c>BatchGetItem</c> returns a <c>ProvisionedThroughputExceededException</c>.
    /// If <i>at least one</i> of the items is successfully processed, then <c>BatchGetItem</c>
    /// completes successfully, while returning the keys of the unread items in <c>UnprocessedKeys</c>.
    /// </para><important><para>
    /// If DynamoDB returns any unprocessed items, you should retry the batch operation on
    /// those items. However, <i>we strongly recommend that you use an exponential backoff
    /// algorithm</i>. If you retry the batch operation immediately, the underlying read or
    /// write requests can still fail due to throttling on the individual tables. If you delay
    /// the batch operation using exponential backoff, the individual requests in the batch
    /// are much more likely to succeed.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ErrorHandling.html#BatchOperations">Batch
    /// Operations and Error Handling</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para></important><para>
    /// By default, <c>BatchGetItem</c> performs eventually consistent reads on every table
    /// in the request. If you want strongly consistent reads instead, you can set <c>ConsistentRead</c>
    /// to <c>true</c> for any or all tables.
    /// </para><para>
    /// In order to minimize response latency, <c>BatchGetItem</c> may retrieve items in parallel.
    /// </para><para>
    /// When designing your application, keep in mind that DynamoDB does not return items
    /// in any particular order. To help parse the response by item, include the primary key
    /// values for the items in your request in the <c>ProjectionExpression</c> parameter.
    /// </para><para>
    /// If a requested item does not exist, it is not returned in the result. Requests for
    /// nonexistent items consume the minimum read capacity units according to the type of
    /// read. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithTables.html#CapacityUnitCalculations">Working
    /// with Tables</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBBatchItem")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DynamoDB BatchGetItem API operation.", Operation = new[] {"BatchGetItem"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.BatchGetItemResponse))]
    [AWSCmdletOutput("System.String or Amazon.DynamoDBv2.Model.BatchGetItemResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.BatchGetItemResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDDBBatchItemCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RequestItem
        /// <summary>
        /// <para>
        /// <para>A map of one or more table names or table ARNs and, for each table, a map that describes
        /// one or more items to retrieve from that table. Each table name or ARN can be used
        /// only once per <c>BatchGetItem</c> request.</para><para>Each element in the map of items to retrieve consists of the following:</para><ul><li><para><c>ConsistentRead</c> - If <c>true</c>, a strongly consistent read is used; if <c>false</c>
        /// (the default), an eventually consistent read is used.</para></li><li><para><c>ExpressionAttributeNames</c> - One or more substitution tokens for attribute names
        /// in the <c>ProjectionExpression</c> parameter. The following are some use cases for
        /// using <c>ExpressionAttributeNames</c>:</para><ul><li><para>To access an attribute whose name conflicts with a DynamoDB reserved word.</para></li><li><para>To create a placeholder for repeating occurrences of an attribute name in an expression.</para></li><li><para>To prevent special characters in an attribute name from being misinterpreted in an
        /// expression.</para></li></ul><para>Use the <b>#</b> character in an expression to dereference an attribute name. For
        /// example, consider the following attribute name:</para><ul><li><para><c>Percentile</c></para></li></ul><para>The name of this attribute conflicts with a reserved word, so it cannot be used directly
        /// in an expression. (For the complete list of reserved words, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ReservedWords.html">Reserved
        /// Words</a> in the <i>Amazon DynamoDB Developer Guide</i>). To work around this, you
        /// could specify the following for <c>ExpressionAttributeNames</c>:</para><ul><li><para><c>{"#P":"Percentile"}</c></para></li></ul><para>You could then use this substitution in an expression, as in this example:</para><ul><li><para><c>#P = :val</c></para></li></ul><note><para>Tokens that begin with the <b>:</b> character are <i>expression attribute values</i>,
        /// which are placeholders for the actual value at runtime.</para></note><para>For more information about expression attribute names, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.AccessingItemAttributes.html">Accessing
        /// Item Attributes</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para></li><li><para><c>Keys</c> - An array of primary key attribute values that define specific items
        /// in the table. For each primary key, you must provide <i>all</i> of the key attributes.
        /// For example, with a simple primary key, you only need to provide the partition key
        /// value. For a composite key, you must provide <i>both</i> the partition key value and
        /// the sort key value.</para></li><li><para><c>ProjectionExpression</c> - A string that identifies one or more attributes to
        /// retrieve from the table. These attributes can include scalars, sets, or elements of
        /// a JSON document. The attributes in the expression must be separated by commas.</para><para>If no attribute names are specified, then all attributes are returned. If any of the
        /// requested attributes are not found, they do not appear in the result.</para><para>For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.AccessingItemAttributes.html">Accessing
        /// Item Attributes</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para></li><li><para><c>AttributesToGet</c> - This is a legacy parameter. Use <c>ProjectionExpression</c>
        /// instead. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.AttributesToGet.html">AttributesToGet</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RequestItems")]
        public System.Collections.Hashtable RequestItem { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Responses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.BatchGetItemResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.BatchGetItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Responses";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.BatchGetItemResponse, GetDDBBatchItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.RequestItem != null)
            {
                context.RequestItem = new Dictionary<System.String, Amazon.DynamoDBv2.Model.KeysAndAttributes>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestItem.Keys)
                {
                    context.RequestItem.Add((String)hashKey, (Amazon.DynamoDBv2.Model.KeysAndAttributes)(this.RequestItem[hashKey]));
                }
            }
            #if MODULAR
            if (this.RequestItem == null && ParameterWasBound(nameof(this.RequestItem)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            
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
            var request = new Amazon.DynamoDBv2.Model.BatchGetItemRequest();
            
            if (cmdletContext.RequestItem != null)
            {
                request.RequestItems = cmdletContext.RequestItem;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
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
        
        private Amazon.DynamoDBv2.Model.BatchGetItemResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.BatchGetItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "BatchGetItem");
            try
            {
                #if DESKTOP
                return client.BatchGetItem(request);
                #elif CORECLR
                return client.BatchGetItemAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.KeysAndAttributes> RequestItem { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.BatchGetItemResponse, GetDDBBatchItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Responses;
        }
        
    }
}
