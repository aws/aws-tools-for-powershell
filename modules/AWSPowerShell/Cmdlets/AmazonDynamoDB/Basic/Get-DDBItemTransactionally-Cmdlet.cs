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
    /// <code>TransactGetItems</code> is a synchronous operation that atomically retrieves
    /// multiple items from one or more tables (but not from indexes) in a single account
    /// and region. A <code>TransactGetItems</code> call can contain up to 10 <code>TransactGetItem</code>
    /// objects, each of which contains a <code>Get</code> structure that specifies an item
    /// to retrieve from a table in the account and region. A call to <code>TransactGetItems</code>
    /// cannot retrieve items from tables in more than one AWS account or region.
    /// 
    ///  
    /// <para>
    /// DynamoDB rejects the entire <code>TransactGetItems</code> request if any of the following
    /// is true:
    /// </para><ul><li><para>
    /// A conflicting operation is in the process of updating an item to be read.
    /// </para></li><li><para>
    /// There is insufficient provisioned capacity for the transaction to be completed.
    /// </para></li><li><para>
    /// There is a user error, such as an invalid data format.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "DDBItemTransactionally")]
    [OutputType("Amazon.DynamoDBv2.Model.TransactGetItemsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB TransactGetItems API operation.", Operation = new[] {"TransactGetItems"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TransactGetItemsResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.TransactGetItemsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBItemTransactionallyCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter ReturnConsumedCapacity
        /// <summary>
        /// <para>
        /// <para>A value of <code>TOTAL</code> causes consumed capacity information to be returned,
        /// and a value of <code>NONE</code> prevents that information from being returned. No
        /// other value is valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnConsumedCapacity")]
        public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
        #endregion
        
        #region Parameter TransactItem
        /// <summary>
        /// <para>
        /// <para>An ordered array of up to 10 <code>TransactGetItem</code> objects, each of which contains
        /// a <code>Get</code> structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TransactItems")]
        public Amazon.DynamoDBv2.Model.TransactGetItem[] TransactItem { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            if (this.TransactItem != null)
            {
                context.TransactItems = new List<Amazon.DynamoDBv2.Model.TransactGetItem>(this.TransactItem);
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
            var request = new Amazon.DynamoDBv2.Model.TransactGetItemsRequest();
            
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
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
        
        private Amazon.DynamoDBv2.Model.TransactGetItemsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.TransactGetItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "TransactGetItems");
            try
            {
                #if DESKTOP
                return client.TransactGetItems(request);
                #elif CORECLR
                return client.TransactGetItemsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
            public List<Amazon.DynamoDBv2.Model.TransactGetItem> TransactItems { get; set; }
        }
        
    }
}
