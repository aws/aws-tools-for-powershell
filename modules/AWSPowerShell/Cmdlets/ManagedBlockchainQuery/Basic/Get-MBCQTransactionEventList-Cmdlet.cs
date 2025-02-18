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
using Amazon.ManagedBlockchainQuery;
using Amazon.ManagedBlockchainQuery.Model;

namespace Amazon.PowerShell.Cmdlets.MBCQ
{
    /// <summary>
    /// Lists all the transaction events for a transaction 
    /// 
    ///  <note><para>
    /// This action will return transaction details for all transactions that are <i>confirmed</i>
    /// on the blockchain, even if they have not reached <a href="https://docs.aws.amazon.com/managed-blockchain/latest/ambq-dg/key-concepts.html#finality">finality</a>.
    /// 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MBCQTransactionEventList")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.TransactionEvent")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query ListTransactionEvents API operation.", Operation = new[] {"ListTransactionEvents"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.TransactionEvent or Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse",
        "This cmdlet returns a collection of Amazon.ManagedBlockchainQuery.Model.TransactionEvent objects.",
        "The service call response (type Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMBCQTransactionEventListCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network where the transaction events occurred.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.QueryNetwork")]
        public Amazon.ManagedBlockchainQuery.QueryNetwork Network { get; set; }
        #endregion
        
        #region Parameter TransactionHash
        /// <summary>
        /// <para>
        /// <para>The hash of a transaction. It is generated when a transaction is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionHash { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The identifier of a Bitcoin transaction. It is generated when a transaction is created.</para><note><para><c>transactionId</c> is only supported on the Bitcoin networks.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of transaction events to list.</para><para>Default: <c>100</c></para><note><para>Even if additional results can be retrieved, the request can return less results than
        /// <c>maxResults</c> or an empty array of results.</para><para>To retrieve the next set of results, make another request with the returned <c>nextToken</c>
        /// value. The value of <c>nextToken</c> is <c>null</c> when there are no more results
        /// to return</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse, GetMBCQTransactionEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.Network = this.Network;
            #if MODULAR
            if (this.Network == null && ParameterWasBound(nameof(this.Network)))
            {
                WriteWarning("You are passing $null as a value for parameter Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.TransactionHash = this.TransactionHash;
            context.TransactionId = this.TransactionId;
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Network != null)
            {
                request.Network = cmdletContext.Network;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TransactionHash != null)
            {
                request.TransactionHash = cmdletContext.TransactionHash;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "ListTransactionEvents");
            try
            {
                return client.ListTransactionEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryNetwork Network { get; set; }
            public System.String NextToken { get; set; }
            public System.String TransactionHash { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.ListTransactionEventsResponse, GetMBCQTransactionEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
