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
    /// <code>TransactGetItems</code> is a synchronous operation that atomically retrieves
    /// multiple items from one or more tables (but not from indexes) in a single account
    /// and Region. A <code>TransactGetItems</code> call can contain up to 25 <code>TransactGetItem</code>
    /// objects, each of which contains a <code>Get</code> structure that specifies an item
    /// to retrieve from a table in the account and Region. A call to <code>TransactGetItems</code>
    /// cannot retrieve items from tables in more than one AWS account or Region. The aggregate
    /// size of the items in the transaction cannot exceed 4 MB.
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
    /// </para></li><li><para>
    /// The aggregate size of the items in the transaction cannot exceed 4 MB.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "DDBItemTransactionally")]
    [OutputType("Amazon.DynamoDBv2.Model.TransactGetItemsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB TransactGetItems API operation.", Operation = new[] {"TransactGetItems"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.TransactGetItemsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TransactGetItemsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TransactGetItemsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ReturnConsumedCapacity")]
        public Amazon.DynamoDBv2.ReturnConsumedCapacity ReturnConsumedCapacity { get; set; }
        #endregion
        
        #region Parameter TransactItem
        /// <summary>
        /// <para>
        /// <para>An ordered array of up to 25 <code>TransactGetItem</code> objects, each of which contains
        /// a <code>Get</code> structure.</para>
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
        public Amazon.DynamoDBv2.Model.TransactGetItem[] TransactItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.TransactGetItemsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.TransactGetItemsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.TransactGetItemsResponse, GetDDBItemTransactionallyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReturnConsumedCapacity = this.ReturnConsumedCapacity;
            if (this.TransactItem != null)
            {
                context.TransactItem = new List<Amazon.DynamoDBv2.Model.TransactGetItem>(this.TransactItem);
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
            var request = new Amazon.DynamoDBv2.Model.TransactGetItemsRequest();
            
            if (cmdletContext.ReturnConsumedCapacity != null)
            {
                request.ReturnConsumedCapacity = cmdletContext.ReturnConsumedCapacity;
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
            public List<Amazon.DynamoDBv2.Model.TransactGetItem> TransactItem { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.TransactGetItemsResponse, GetDDBItemTransactionallyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
