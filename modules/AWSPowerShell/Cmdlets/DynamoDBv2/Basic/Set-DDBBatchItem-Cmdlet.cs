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
    /// The <code>BatchWriteItem</code> operation puts or deletes multiple items in one or
    /// more tables. A single call to <code>BatchWriteItem</code> can transmit up to 16MB
    /// of data over the network, consisting of up to 25 item put or delete operations. While
    /// individual items can be up to 400 KB once stored, it's important to note that an item's
    /// representation might be greater than 400KB while being sent in DynamoDB's JSON format
    /// for the API call. For more details on this distinction, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.NamingRulesDataTypes.html">Naming
    /// Rules and Data Types</a>.
    /// 
    ///  <note><para><code>BatchWriteItem</code> cannot update items. If you perform a <code>BatchWriteItem</code>
    /// operation on an existing item, that item's values will be overwritten by the operation
    /// and it will appear like it was updated. To update items, we recommend you use the
    /// <code>UpdateItem</code> action.
    /// </para></note><para>
    /// The individual <code>PutItem</code> and <code>DeleteItem</code> operations specified
    /// in <code>BatchWriteItem</code> are atomic; however <code>BatchWriteItem</code> as
    /// a whole is not. If any requested operations fail because the table's provisioned throughput
    /// is exceeded or an internal processing failure occurs, the failed operations are returned
    /// in the <code>UnprocessedItems</code> response parameter. You can investigate and optionally
    /// resend the requests. Typically, you would call <code>BatchWriteItem</code> in a loop.
    /// Each iteration would check for unprocessed items and submit a new <code>BatchWriteItem</code>
    /// request with those unprocessed items until all items have been processed.
    /// </para><para>
    /// If <i>none</i> of the items can be processed due to insufficient provisioned throughput
    /// on all of the tables in the request, then <code>BatchWriteItem</code> returns a <code>ProvisionedThroughputExceededException</code>.
    /// </para><important><para>
    /// If DynamoDB returns any unprocessed items, you should retry the batch operation on
    /// those items. However, <i>we strongly recommend that you use an exponential backoff
    /// algorithm</i>. If you retry the batch operation immediately, the underlying read or
    /// write requests can still fail due to throttling on the individual tables. If you delay
    /// the batch operation using exponential backoff, the individual requests in the batch
    /// are much more likely to succeed.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ErrorHandling.html#Programming.Errors.BatchOperations">Batch
    /// Operations and Error Handling</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para></important><para>
    /// With <code>BatchWriteItem</code>, you can efficiently write or delete large amounts
    /// of data, such as from Amazon EMR, or copy data from another database into DynamoDB.
    /// In order to improve performance with these large-scale operations, <code>BatchWriteItem</code>
    /// does not behave in the same way as individual <code>PutItem</code> and <code>DeleteItem</code>
    /// calls would. For example, you cannot specify conditions on individual put and delete
    /// requests, and <code>BatchWriteItem</code> does not return deleted items in the response.
    /// </para><para>
    /// If you use a programming language that supports concurrency, you can use threads to
    /// write items in parallel. Your application must include the necessary logic to manage
    /// the threads. With languages that don't support threading, you must update or delete
    /// the specified items one at a time. In both situations, <code>BatchWriteItem</code>
    /// performs the specified put and delete operations in parallel, giving you the power
    /// of the thread pool approach without having to introduce complexity into your application.
    /// </para><para>
    /// Parallel processing reduces latency, but each specified put and delete request consumes
    /// the same number of write capacity units whether it is processed in parallel or not.
    /// Delete operations on nonexistent items consume one write capacity unit.
    /// </para><para>
    /// If one or more of the following is true, DynamoDB rejects the entire batch write operation:
    /// </para><ul><li><para>
    /// One or more tables specified in the <code>BatchWriteItem</code> request does not exist.
    /// </para></li><li><para>
    /// Primary key attributes specified on an item in the request do not match those in the
    /// corresponding table's primary key schema.
    /// </para></li><li><para>
    /// You try to perform multiple operations on the same item in the same <code>BatchWriteItem</code>
    /// request. For example, you cannot put and delete the same item in the same <code>BatchWriteItem</code>
    /// request. 
    /// </para></li><li><para>
    ///  Your request contains at least two items with identical hash and range keys (which
    /// essentially is two put operations). 
    /// </para></li><li><para>
    /// There are more than 25 requests in the batch.
    /// </para></li><li><para>
    /// Any individual item in a batch exceeds 400 KB.
    /// </para></li><li><para>
    /// The total request size exceeds 16 MB.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Set", "DDBBatchItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DynamoDB BatchWriteItem API operation.", Operation = new[] {"BatchWriteItem"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.BatchWriteItemResponse))]
    [AWSCmdletOutput("System.String or Amazon.DynamoDBv2.Model.BatchWriteItemResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.BatchWriteItemResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetDDBBatchItemCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter RequestItem
        /// <summary>
        /// <para>
        /// <para>A map of one or more table names and, for each table, a list of operations to be performed
        /// (<code>DeleteRequest</code> or <code>PutRequest</code>). Each element in the map consists
        /// of the following:</para><ul><li><para><code>DeleteRequest</code> - Perform a <code>DeleteItem</code> operation on the specified
        /// item. The item to be deleted is identified by a <code>Key</code> subelement:</para><ul><li><para><code>Key</code> - A map of primary key attribute values that uniquely identify the
        /// item. Each entry in this map consists of an attribute name and an attribute value.
        /// For each primary key, you must provide <i>all</i> of the key attributes. For example,
        /// with a simple primary key, you only need to provide a value for the partition key.
        /// For a composite primary key, you must provide values for <i>both</i> the partition
        /// key and the sort key.</para></li></ul></li><li><para><code>PutRequest</code> - Perform a <code>PutItem</code> operation on the specified
        /// item. The item to be put is identified by an <code>Item</code> subelement:</para><ul><li><para><code>Item</code> - A map of attributes and their values. Each entry in this map
        /// consists of an attribute name and an attribute value. Attribute values must not be
        /// null; string and binary type attributes must have lengths greater than zero; and set
        /// type attributes must not be empty. Requests that contain empty values are rejected
        /// with a <code>ValidationException</code> exception.</para><para>If you specify any attributes that are part of an index key, then the data types for
        /// those attributes must match those of the schema in the table's attribute definition.</para></li></ul></li></ul>
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
        
        #region Parameter ReturnItemCollectionMetric
        /// <summary>
        /// <para>
        /// <para>Determines whether item collection metrics are returned. If set to <code>SIZE</code>,
        /// the response includes statistics about item collections, if any, that were modified
        /// during the operation are returned in the response. If set to <code>NONE</code> (the
        /// default), no statistics are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReturnItemCollectionMetrics")]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnItemCollectionMetrics")]
        public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UnprocessedItems'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.BatchWriteItemResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.BatchWriteItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UnprocessedItems";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RequestItem parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RequestItem' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RequestItem' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RequestItem), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DDBBatchItem (BatchWriteItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.BatchWriteItemResponse, SetDDBBatchItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RequestItem;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.RequestItem != null)
            {
                context.RequestItem = new Dictionary<System.String, List<Amazon.DynamoDBv2.Model.WriteRequest>>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestItem.Keys)
                {
                    object hashValue = this.RequestItem[hashKey];
                    if (hashValue == null)
                    {
                        context.RequestItem.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.DynamoDBv2.Model.WriteRequest>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.DynamoDBv2.Model.WriteRequest)s);
                    }
                    context.RequestItem.Add((String)hashKey, valueSet);
                }
            }
            #if MODULAR
            if (this.RequestItem == null && ParameterWasBound(nameof(this.RequestItem)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            context.ReturnItemCollectionMetric = this.ReturnItemCollectionMetric;
            
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
            var request = new Amazon.DynamoDBv2.Model.BatchWriteItemRequest();
            
            if (cmdletContext.RequestItem != null)
            {
                request.RequestItems = cmdletContext.RequestItem;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.ReturnItemCollectionMetric != null)
            {
                request.ReturnItemCollectionMetrics = cmdletContext.ReturnItemCollectionMetric;
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
        
        private Amazon.DynamoDBv2.Model.BatchWriteItemResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.BatchWriteItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "BatchWriteItem");
            try
            {
                #if DESKTOP
                return client.BatchWriteItem(request);
                #elif CORECLR
                return client.BatchWriteItemAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<Amazon.DynamoDBv2.Model.WriteRequest>> RequestItem { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.BatchWriteItemResponse, SetDDBBatchItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UnprocessedItems;
        }
        
    }
}
