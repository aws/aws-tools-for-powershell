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
    /// Creates a new item, or replaces an old item with a new item. If an item that has the
    /// same primary key as the new item already exists in the specified table, the new item
    /// completely replaces the existing item. You can perform a conditional put operation
    /// (add a new item if one with the specified primary key doesn't exist), or replace an
    /// existing item if it has certain attribute values. You can return the item's attribute
    /// values in the same operation, using the <c>ReturnValues</c> parameter.
    /// 
    ///  
    /// <para>
    /// When you add an item, the primary key attributes are the only required attributes.
    /// 
    /// </para><para>
    /// Empty String and Binary attribute values are allowed. Attribute values of type String
    /// and Binary must have a length greater than zero if the attribute is used as a key
    /// attribute for a table or index. Set type attributes cannot be empty. 
    /// </para><para>
    /// Invalid Requests with empty values will be rejected with a <c>ValidationException</c>
    /// exception.
    /// </para><note><para>
    /// To prevent a new item from replacing an existing item, use a conditional expression
    /// that contains the <c>attribute_not_exists</c> function with the name of the attribute
    /// being used as the partition key for the table. Since every record must contain that
    /// attribute, the <c>attribute_not_exists</c> function will only succeed if no matching
    /// item exists.
    /// </para></note><para>
    /// For more information about <c>PutItem</c>, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithItems.html">Working
    /// with Items</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "DDBItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DynamoDB PutItem API operation.", Operation = new[] {"PutItem"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.PutItemResponse))]
    [AWSCmdletOutput("System.String or Amazon.DynamoDBv2.Model.PutItemResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.PutItemResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetDDBItemCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConditionalOperator
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <c>ConditionExpression</c> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.ConditionalOperator.html">ConditionalOperator</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ConditionalOperator")]
        public Amazon.DynamoDBv2.ConditionalOperator ConditionalOperator { get; set; }
        #endregion
        
        #region Parameter ConditionExpression
        /// <summary>
        /// <para>
        /// <para>A condition that must be satisfied in order for a conditional <c>PutItem</c> operation
        /// to succeed.</para><para>An expression can contain any of the following:</para><ul><li><para>Functions: <c>attribute_exists | attribute_not_exists | attribute_type | contains
        /// | begins_with | size</c></para><para>These function names are case-sensitive.</para></li><li><para>Comparison operators: <c>= | &lt;&gt; | &lt; | &gt; | &lt;= | &gt;= | BETWEEN | IN
        /// </c></para></li><li><para> Logical operators: <c>AND | OR | NOT</c></para></li></ul><para>For more information on condition expressions, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.SpecifyingConditions.html">Condition
        /// Expressions</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConditionExpression { get; set; }
        #endregion
        
        #region Parameter Expected
        /// <summary>
        /// <para>
        /// <para>This is a legacy parameter. Use <c>ConditionExpression</c> instead. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LegacyConditionalParameters.Expected.html">Expected</a>
        /// in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Expected { get; set; }
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
        /// For example, suppose that you wanted to check whether the value of the <i>ProductStatus</i>
        /// attribute was one of the following: </para><para><c>Available | Backordered | Discontinued</c></para><para>You would first need to specify <c>ExpressionAttributeValues</c> as follows:</para><para><c>{ ":avail":{"S":"Available"}, ":back":{"S":"Backordered"}, ":disc":{"S":"Discontinued"}
        /// }</c></para><para>You could then use these values in an expression, such as this:</para><para><c>ProductStatus IN (:avail, :back, :disc)</c></para><para>For more information on expression attribute values, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Expressions.SpecifyingConditions.html">Condition
        /// Expressions</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpressionAttributeValues")]
        public System.Collections.Hashtable ExpressionAttributeValue { get; set; }
        #endregion
        
        #region Parameter Item
        /// <summary>
        /// <para>
        /// <para>A map of attribute name/value pairs, one for each attribute. Only the primary key
        /// attributes are required; you can optionally provide other attribute name-value pairs
        /// for the item.</para><para>You must provide all of the attributes for the primary key. For example, with a simple
        /// primary key, you only need to provide a value for the partition key. For a composite
        /// primary key, you must provide both values for both the partition key and the sort
        /// key.</para><para>If you specify any attributes that are part of an index key, then the data types for
        /// those attributes must match those of the schema in the table's attribute definition.</para><para>Empty String and Binary attribute values are allowed. Attribute values of type String
        /// and Binary must have a length greater than zero if the attribute is used as a key
        /// attribute for a table or index.</para><para>For more information about primary keys, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.CoreComponents.html#HowItWorks.CoreComponents.PrimaryKey">Primary
        /// Key</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>Each element in the <c>Item</c> map is an <c>AttributeValue</c> object.</para>
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
        public System.Collections.Hashtable Item { get; set; }
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
        /// <para>Determines whether item collection metrics are returned. If set to <c>SIZE</c>, the
        /// response includes statistics about item collections, if any, that were modified during
        /// the operation are returned in the response. If set to <c>NONE</c> (the default), no
        /// statistics are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReturnItemCollectionMetrics")]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnItemCollectionMetrics")]
        public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
        #endregion
        
        #region Parameter ReturnValue
        /// <summary>
        /// <para>
        /// <para>Use <c>ReturnValues</c> if you want to get the item attributes as they appeared before
        /// they were updated with the <c>PutItem</c> request. For <c>PutItem</c>, the valid values
        /// are:</para><ul><li><para><c>NONE</c> - If <c>ReturnValues</c> is not specified, or if its value is <c>NONE</c>,
        /// then nothing is returned. (This setting is the default for <c>ReturnValues</c>.)</para></li><li><para><c>ALL_OLD</c> - If <c>PutItem</c> overwrote an attribute name-value pair, then the
        /// content of the old item is returned.</para></li></ul><para>The values returned are strongly consistent.</para><para>There is no additional cost associated with requesting a return value aside from the
        /// small network and processing overhead of receiving a larger response. No read capacity
        /// units are consumed.</para><note><para>The <c>ReturnValues</c> parameter is used by several DynamoDB operations; however,
        /// <c>PutItem</c> does not recognize any values other than <c>NONE</c> or <c>ALL_OLD</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReturnValues")]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnValue")]
        public Amazon.DynamoDBv2.ReturnValue ReturnValue { get; set; }
        #endregion
        
        #region Parameter ReturnValuesOnConditionCheckFailure
        /// <summary>
        /// <para>
        /// <para>An optional parameter that returns the item attributes for a <c>PutItem</c> operation
        /// that failed a condition check.</para><para>There is no additional cost associated with requesting a return value aside from the
        /// small network and processing overhead of receiving a larger response. No read capacity
        /// units are consumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure")]
        public Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure ReturnValuesOnConditionCheckFailure { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to contain the item. You can also provide the Amazon Resource
        /// Name (ARN) of the table in this parameter.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Attributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.PutItemResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.PutItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Attributes";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DDBItem (PutItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.PutItemResponse, SetDDBItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConditionalOperator = this.ConditionalOperator;
            context.ConditionExpression = this.ConditionExpression;
            if (this.Expected != null)
            {
                context.Expected = new Dictionary<System.String, Amazon.DynamoDBv2.Model.ExpectedAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Expected.Keys)
                {
                    context.Expected.Add((String)hashKey, (Amazon.DynamoDBv2.Model.ExpectedAttributeValue)(this.Expected[hashKey]));
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
            if (this.Item != null)
            {
                context.Item = new Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Item.Keys)
                {
                    context.Item.Add((String)hashKey, (Amazon.DynamoDBv2.Model.AttributeValue)(this.Item[hashKey]));
                }
            }
            #if MODULAR
            if (this.Item == null && ParameterWasBound(nameof(this.Item)))
            {
                WriteWarning("You are passing $null as a value for parameter Item which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            context.ReturnItemCollectionMetric = this.ReturnItemCollectionMetric;
            context.ReturnValue = this.ReturnValue;
            context.ReturnValuesOnConditionCheckFailure = this.ReturnValuesOnConditionCheckFailure;
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
            // create request
            var request = new Amazon.DynamoDBv2.Model.PutItemRequest();
            
            if (cmdletContext.ConditionalOperator != null)
            {
                request.ConditionalOperator = cmdletContext.ConditionalOperator;
            }
            if (cmdletContext.ConditionExpression != null)
            {
                request.ConditionExpression = cmdletContext.ConditionExpression;
            }
            if (cmdletContext.Expected != null)
            {
                request.Expected = cmdletContext.Expected;
            }
            if (cmdletContext.ExpressionAttributeName != null)
            {
                request.ExpressionAttributeNames = cmdletContext.ExpressionAttributeName;
            }
            if (cmdletContext.ExpressionAttributeValue != null)
            {
                request.ExpressionAttributeValues = cmdletContext.ExpressionAttributeValue;
            }
            if (cmdletContext.Item != null)
            {
                request.Item = cmdletContext.Item;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.ReturnItemCollectionMetric != null)
            {
                request.ReturnItemCollectionMetrics = cmdletContext.ReturnItemCollectionMetric;
            }
            if (cmdletContext.ReturnValue != null)
            {
                request.ReturnValues = cmdletContext.ReturnValue;
            }
            if (cmdletContext.ReturnValuesOnConditionCheckFailure != null)
            {
                request.ReturnValuesOnConditionCheckFailure = cmdletContext.ReturnValuesOnConditionCheckFailure;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.DynamoDBv2.Model.PutItemResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.PutItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "PutItem");
            try
            {
                #if DESKTOP
                return client.PutItem(request);
                #elif CORECLR
                return client.PutItemAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DynamoDBv2.ConditionalOperator ConditionalOperator { get; set; }
            public System.String ConditionExpression { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.ExpectedAttributeValue> Expected { get; set; }
            public Dictionary<System.String, System.String> ExpressionAttributeName { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> ExpressionAttributeValue { get; set; }
            public Dictionary<System.String, Amazon.DynamoDBv2.Model.AttributeValue> Item { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
            public Amazon.DynamoDBv2.ReturnValue ReturnValue { get; set; }
            public Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure ReturnValuesOnConditionCheckFailure { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.PutItemResponse, SetDDBItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Attributes;
        }
        
    }
}
