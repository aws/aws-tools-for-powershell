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
using Amazon.ManagedBlockchainQuery;
using Amazon.ManagedBlockchainQuery.Model;

namespace Amazon.PowerShell.Cmdlets.MBCQ
{
    /// <summary>
    /// Lists all of the transactions on a given wallet address or to a specific contract.
    /// </summary>
    [Cmdlet("Get", "MBCQTransactionList")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.TransactionOutputItem")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query ListTransactions API operation.", Operation = new[] {"ListTransactions"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.TransactionOutputItem or Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse",
        "This cmdlet returns a collection of Amazon.ManagedBlockchainQuery.Model.TransactionOutputItem objects.",
        "The service call response (type Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMBCQTransactionListCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Address
        /// <summary>
        /// <para>
        /// <para>The address (either a contract or wallet), whose transactions are being requested.</para>
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
        public System.String Address { get; set; }
        #endregion
        
        #region Parameter Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network where the transactions occurred.</para>
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
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>Defaults to the value <c>TRANSACTION_TIMESTAMP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.ListTransactionsSortBy")]
        public Amazon.ManagedBlockchainQuery.ListTransactionsSortBy Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The container for the <i>sort order</i> for <c>ListTransactions</c>. The <c>SortOrder</c>
        /// field only accepts the values <c>ASCENDING</c> and <c>DESCENDING</c>. Not providing
        /// <c>SortOrder</c> will default to <c>ASCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.SortOrder")]
        public Amazon.ManagedBlockchainQuery.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter FromBlockchainInstant_Time
        /// <summary>
        /// <para>
        /// <para>The container of the <c>Timestamp</c> of the blockchain instant.</para><note><para>This <c>timestamp</c> will only be recorded up to the second.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? FromBlockchainInstant_Time { get; set; }
        #endregion
        
        #region Parameter ToBlockchainInstant_Time
        /// <summary>
        /// <para>
        /// <para>The container of the <c>Timestamp</c> of the blockchain instant.</para><note><para>This <c>timestamp</c> will only be recorded up to the second.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ToBlockchainInstant_Time { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of transactions to list.</para><note><para>Even if additional results can be retrieved, the request can return less results than
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Transactions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Transactions";
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse, GetMBCQTransactionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Address = this.Address;
            #if MODULAR
            if (this.Address == null && ParameterWasBound(nameof(this.Address)))
            {
                WriteWarning("You are passing $null as a value for parameter Address which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FromBlockchainInstant_Time = this.FromBlockchainInstant_Time;
            context.MaxResult = this.MaxResult;
            context.Network = this.Network;
            #if MODULAR
            if (this.Network == null && ParameterWasBound(nameof(this.Network)))
            {
                WriteWarning("You are passing $null as a value for parameter Network which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            context.ToBlockchainInstant_Time = this.ToBlockchainInstant_Time;
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.ListTransactionsRequest();
            
            if (cmdletContext.Address != null)
            {
                request.Address = cmdletContext.Address;
            }
            
             // populate FromBlockchainInstant
            var requestFromBlockchainInstantIsNull = true;
            request.FromBlockchainInstant = new Amazon.ManagedBlockchainQuery.Model.BlockchainInstant();
            System.DateTime? requestFromBlockchainInstant_fromBlockchainInstant_Time = null;
            if (cmdletContext.FromBlockchainInstant_Time != null)
            {
                requestFromBlockchainInstant_fromBlockchainInstant_Time = cmdletContext.FromBlockchainInstant_Time.Value;
            }
            if (requestFromBlockchainInstant_fromBlockchainInstant_Time != null)
            {
                request.FromBlockchainInstant.Time = requestFromBlockchainInstant_fromBlockchainInstant_Time.Value;
                requestFromBlockchainInstantIsNull = false;
            }
             // determine if request.FromBlockchainInstant should be set to null
            if (requestFromBlockchainInstantIsNull)
            {
                request.FromBlockchainInstant = null;
            }
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
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.ManagedBlockchainQuery.Model.ListTransactionsSort();
            Amazon.ManagedBlockchainQuery.ListTransactionsSortBy requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.SortOrder requestSort_sort_SortOrder = null;
            if (cmdletContext.Sort_SortOrder != null)
            {
                requestSort_sort_SortOrder = cmdletContext.Sort_SortOrder;
            }
            if (requestSort_sort_SortOrder != null)
            {
                request.Sort.SortOrder = requestSort_sort_SortOrder;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            
             // populate ToBlockchainInstant
            var requestToBlockchainInstantIsNull = true;
            request.ToBlockchainInstant = new Amazon.ManagedBlockchainQuery.Model.BlockchainInstant();
            System.DateTime? requestToBlockchainInstant_toBlockchainInstant_Time = null;
            if (cmdletContext.ToBlockchainInstant_Time != null)
            {
                requestToBlockchainInstant_toBlockchainInstant_Time = cmdletContext.ToBlockchainInstant_Time.Value;
            }
            if (requestToBlockchainInstant_toBlockchainInstant_Time != null)
            {
                request.ToBlockchainInstant.Time = requestToBlockchainInstant_toBlockchainInstant_Time.Value;
                requestToBlockchainInstantIsNull = false;
            }
             // determine if request.ToBlockchainInstant should be set to null
            if (requestToBlockchainInstantIsNull)
            {
                request.ToBlockchainInstant = null;
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
        
        private Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.ListTransactionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "ListTransactions");
            try
            {
                #if DESKTOP
                return client.ListTransactions(request);
                #elif CORECLR
                return client.ListTransactionsAsync(request).GetAwaiter().GetResult();
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
            public System.String Address { get; set; }
            public System.DateTime? FromBlockchainInstant_Time { get; set; }
            public System.Int32? MaxResult { get; set; }
            public Amazon.ManagedBlockchainQuery.QueryNetwork Network { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ManagedBlockchainQuery.ListTransactionsSortBy Sort_SortBy { get; set; }
            public Amazon.ManagedBlockchainQuery.SortOrder Sort_SortOrder { get; set; }
            public System.DateTime? ToBlockchainInstant_Time { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.ListTransactionsResponse, GetMBCQTransactionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Transactions;
        }
        
    }
}
