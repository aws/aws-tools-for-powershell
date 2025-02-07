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
    /// <c>TransactWriteItems</c> is a synchronous write operation that groups up to 100
    /// action requests. These actions can target items in different tables, but not in different
    /// Amazon Web Services accounts or Regions, and no two actions can target the same item.
    /// For example, you cannot both <c>ConditionCheck</c> and <c>Update</c> the same item.
    /// The aggregate size of the items in the transaction cannot exceed 4 MB.
    /// 
    ///  
    /// <para>
    /// The actions are completed atomically so that either all of them succeed, or all of
    /// them fail. They are defined by the following objects:
    /// </para><ul><li><para><c>Put</c>  —   Initiates a <c>PutItem</c> operation to write a new item. This structure
    /// specifies the primary key of the item to be written, the name of the table to write
    /// it in, an optional condition expression that must be satisfied for the write to succeed,
    /// a list of the item's attributes, and a field indicating whether to retrieve the item's
    /// attributes if the condition is not met.
    /// </para></li><li><para><c>Update</c>  —   Initiates an <c>UpdateItem</c> operation to update an existing
    /// item. This structure specifies the primary key of the item to be updated, the name
    /// of the table where it resides, an optional condition expression that must be satisfied
    /// for the update to succeed, an expression that defines one or more attributes to be
    /// updated, and a field indicating whether to retrieve the item's attributes if the condition
    /// is not met.
    /// </para></li><li><para><c>Delete</c>  —   Initiates a <c>DeleteItem</c> operation to delete an existing
    /// item. This structure specifies the primary key of the item to be deleted, the name
    /// of the table where it resides, an optional condition expression that must be satisfied
    /// for the deletion to succeed, and a field indicating whether to retrieve the item's
    /// attributes if the condition is not met.
    /// </para></li><li><para><c>ConditionCheck</c>  —   Applies a condition to an item that is not being modified
    /// by the transaction. This structure specifies the primary key of the item to be checked,
    /// the name of the table where it resides, a condition expression that must be satisfied
    /// for the transaction to succeed, and a field indicating whether to retrieve the item's
    /// attributes if the condition is not met.
    /// </para></li></ul><para>
    /// DynamoDB rejects the entire <c>TransactWriteItems</c> request if any of the following
    /// is true:
    /// </para><ul><li><para>
    /// A condition in one of the condition expressions is not met.
    /// </para></li><li><para>
    /// An ongoing operation is in the process of updating the same item.
    /// </para></li><li><para>
    /// There is insufficient provisioned capacity for the transaction to be completed.
    /// </para></li><li><para>
    /// An item size becomes too large (bigger than 400 KB), a local secondary index (LSI)
    /// becomes too large, or a similar validation error occurs because of changes made by
    /// the transaction.
    /// </para></li><li><para>
    /// The aggregate size of the items in the transaction exceeds 4 MB.
    /// </para></li><li><para>
    /// There is a user error, such as an invalid data format.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "DDBItemTransactionally", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TransactWriteItemsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB TransactWriteItems API operation.", Operation = new[] {"TransactWriteItems"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.TransactWriteItemsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TransactWriteItemsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TransactWriteItemsResponse object containing multiple properties."
    )]
    public partial class WriteDDBItemTransactionallyCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Providing a <c>ClientRequestToken</c> makes the call to <c>TransactWriteItems</c>
        /// idempotent, meaning that multiple identical calls have the same effect as one single
        /// call.</para><para>Although multiple identical calls using the same client request token produce the
        /// same result on the server (no side effects), the responses to the calls might not
        /// be the same. If the <c>ReturnConsumedCapacity</c> parameter is set, then the initial
        /// <c>TransactWriteItems</c> call returns the amount of write capacity units consumed
        /// in making the changes. Subsequent <c>TransactWriteItems</c> calls with the same client
        /// token return the number of read capacity units consumed in reading the item.</para><para>A client request token is valid for 10 minutes after the first request that uses it
        /// is completed. After 10 minutes, any request with the same client token is treated
        /// as a new request. Do not resubmit the same request with the same client token for
        /// more than 10 minutes, or the result might not be idempotent.</para><para>If you submit a request with the same client token but a change in other parameters
        /// within the 10-minute idempotency window, DynamoDB returns an <c>IdempotentParameterMismatch</c>
        /// exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
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
        /// response includes statistics about item collections (if any), that were modified during
        /// the operation and are returned in the response. If set to <c>NONE</c> (the default),
        /// no statistics are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReturnItemCollectionMetrics")]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnItemCollectionMetrics")]
        public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
        #endregion
        
        #region Parameter TransactItem
        /// <summary>
        /// <para>
        /// <para>An ordered array of up to 100 <c>TransactWriteItem</c> objects, each of which contains
        /// a <c>ConditionCheck</c>, <c>Put</c>, <c>Update</c>, or <c>Delete</c> object. These
        /// can operate on items in different tables, but the tables must reside in the same Amazon
        /// Web Services account and Region, and no two of them can operate on the same item.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TransactItems")]
        public Amazon.DynamoDBv2.Model.TransactWriteItem[] TransactItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.TransactWriteItemsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.TransactWriteItemsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-DDBItemTransactionally (TransactWriteItems)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.TransactWriteItemsResponse, WriteDDBItemTransactionallyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            context.ReturnItemCollectionMetric = this.ReturnItemCollectionMetric;
            if (this.TransactItem != null)
            {
                context.TransactItem = new List<Amazon.DynamoDBv2.Model.TransactWriteItem>(this.TransactItem);
            }
            #if MODULAR
            if (this.TransactItem == null && ParameterWasBound(nameof(this.TransactItem)))
            {
                WriteWarning("You are passing $null as a value for parameter TransactItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.TransactWriteItemsRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
            }
            if (cmdletContext.ReturnItemCollectionMetric != null)
            {
                request.ReturnItemCollectionMetrics = cmdletContext.ReturnItemCollectionMetric;
            }
            if (cmdletContext.TransactItem != null)
            {
                request.TransactItems = cmdletContext.TransactItem;
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
        
        private Amazon.DynamoDBv2.Model.TransactWriteItemsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.TransactWriteItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "TransactWriteItems");
            try
            {
                #if DESKTOP
                return client.TransactWriteItems(request);
                #elif CORECLR
                return client.TransactWriteItemsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
            public List<Amazon.DynamoDBv2.Model.TransactWriteItem> TransactItem { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.TransactWriteItemsResponse, WriteDDBItemTransactionallyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
