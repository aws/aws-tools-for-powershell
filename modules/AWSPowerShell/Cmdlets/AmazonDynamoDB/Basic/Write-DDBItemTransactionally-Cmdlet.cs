/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// <code>TransactWriteItems</code> is a synchronous write operation that groups up to
    /// 10 action requests. These actions can target items in different tables, but not in
    /// different AWS accounts or regions, and no two actions can target the same item. For
    /// example, you cannot both <code>ConditionCheck</code> and <code>Update</code> the same
    /// item.
    /// 
    ///  
    /// <para>
    /// The actions are completed atomically so that either all of them succeed, or all of
    /// them fail. They are defined by the following objects:
    /// </para><ul><li><para><code>Put</code>     Initiates a <code>PutItem</code> operation to write a
    /// new item. This structure specifies the primary key of the item to be written, the
    /// name of the table to write it in, an optional condition expression that must be satisfied
    /// for the write to succeed, a list of the item's attributes, and a field indicating
    /// whether or not to retrieve the item's attributes if the condition is not met.
    /// </para></li><li><para><code>Update</code>     Initiates an <code>UpdateItem</code> operation to update
    /// an existing item. This structure specifies the primary key of the item to be updated,
    /// the name of the table where it resides, an optional condition expression that must
    /// be satisfied for the update to succeed, an expression that defines one or more attributes
    /// to be updated, and a field indicating whether or not to retrieve the item's attributes
    /// if the condition is not met.
    /// </para></li><li><para><code>Delete</code>     Initiates a <code>DeleteItem</code> operation to delete
    /// an existing item. This structure specifies the primary key of the item to be deleted,
    /// the name of the table where it resides, an optional condition expression that must
    /// be satisfied for the deletion to succeed, and a field indicating whether or not to
    /// retrieve the item's attributes if the condition is not met.
    /// </para></li><li><para><code>ConditionCheck</code>     Applies a condition to an item that is not
    /// being modified by the transaction. This structure specifies the primary key of the
    /// item to be checked, the name of the table where it resides, a condition expression
    /// that must be satisfied for the transaction to succeed, and a field indicating whether
    /// or not to retrieve the item's attributes if the condition is not met.
    /// </para></li></ul><para>
    /// DynamoDB rejects the entire <code>TransactWriteItems</code> request if any of the
    /// following is true:
    /// </para><ul><li><para>
    /// A condition in one of the condition expressions is not met.
    /// </para></li><li><para>
    /// A conflicting operation is in the process of updating the same item.
    /// </para></li><li><para>
    /// There is insufficient provisioned capacity for the transaction to be completed.
    /// </para></li><li><para>
    /// An item size becomes too large (bigger than 400 KB), a Local Secondary Index (LSI)
    /// becomes too large, or a similar validation error occurs because of changes made by
    /// the transaction.
    /// </para></li><li><para>
    /// There is a user error, such as an invalid data format.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "DDBItemTransactionally", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TransactWriteItemsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB TransactWriteItems API operation.", Operation = new[] {"TransactWriteItems"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TransactWriteItemsResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.TransactWriteItemsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteDDBItemTransactionallyCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Providing a <code>ClientRequestToken</code> makes the call to <code>TransactWriteItems</code>
        /// idempotent, meaning that multiple identical calls have the same effect as one single
        /// call.</para><para>Although multiple identical calls using the same client request token produce the
        /// same result on the server (no side effects), the responses to the calls may not be
        /// the same. If the <code>ReturnConsumedCapacity&gt;</code> parameter is set, then the
        /// initial <code>TransactWriteItems</code> call returns the amount of write capacity
        /// units consumed in making the changes, and subsequent <code>TransactWriteItems</code>
        /// calls with the same client token return the amount of read capacity units consumed
        /// in reading the item.</para><para>A client request token is valid for 10 minutes after the first request that uses it
        /// completes. After 10 minutes, any request with the same client token is treated as
        /// a new request. Do not resubmit the same request with the same client token for more
        /// than 10 minutes or the result may not be idempotent.</para><para>If you submit a request with the same client token but a change in other parameters
        /// within the 10 minute idempotency window, DynamoDB returns an <code>IdempotentParameterMismatch</code>
        /// exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ReturnConsumedCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnConsumedCapacity")]
        public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
        #endregion
        
        #region Parameter ReturnItemCollectionMetric
        /// <summary>
        /// <para>
        /// <para>Determines whether item collection metrics are returned. If set to <code>SIZE</code>,
        /// the response includes statistics about item collections (if any), that were modified
        /// during the operation and are returned in the response. If set to <code>NONE</code>
        /// (the default), no statistics are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReturnItemCollectionMetrics")]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnItemCollectionMetrics")]
        public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetric { get; set; }
        #endregion
        
        #region Parameter TransactItem
        /// <summary>
        /// <para>
        /// <para>An ordered array of up to 10 <code>TransactWriteItem</code> objects, each of which
        /// contains a <code>ConditionCheck</code>, <code>Put</code>, <code>Update</code>, or
        /// <code>Delete</code> object. These can operate on items in different tables, but the
        /// tables must reside in the same AWS account and region, and no two of them can operate
        /// on the same item. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TransactItems")]
        public Amazon.DynamoDBv2.Model.TransactWriteItem[] TransactItem { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-DDBItemTransactionally (TransactWriteItems)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            context.ReturnItemCollectionMetrics = this.ReturnItemCollectionMetric;
            if (this.TransactItem != null)
            {
                context.TransactItems = new List<Amazon.DynamoDBv2.Model.TransactWriteItem>(this.TransactItem);
            }
            
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
            if (cmdletContext.ReturnItemCollectionMetrics != null)
            {
                request.ReturnItemCollectionMetrics = cmdletContext.ReturnItemCollectionMetrics;
            }
            if (cmdletContext.TransactItems != null)
            {
                request.TransactItems = cmdletContext.TransactItems;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public Amazon.DynamoDBv2.ReturnItemCollectionMetrics ReturnItemCollectionMetrics { get; set; }
            public List<Amazon.DynamoDBv2.Model.TransactWriteItem> TransactItems { get; set; }
        }
        
    }
}
