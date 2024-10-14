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
    /// Lists all the transaction events for an address on the blockchain.
    /// 
    ///  <note><para>
    /// This operation is only supported on the Bitcoin networks.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MBCQFilteredTransactionEventList")]
    [OutputType("Amazon.ManagedBlockchainQuery.Model.TransactionEvent")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain Query ListFilteredTransactionEvents API operation.", Operation = new[] {"ListFilteredTransactionEvents"}, SelectReturnType = typeof(Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchainQuery.Model.TransactionEvent or Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse",
        "This cmdlet returns a collection of Amazon.ManagedBlockchainQuery.Model.TransactionEvent objects.",
        "The service call response (type Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMBCQFilteredTransactionEventListCmdlet : AmazonManagedBlockchainQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfirmationStatusFilter_Include
        /// <summary>
        /// <para>
        /// <para>The container to determine whether to list results that have only reached <a href="https://docs.aws.amazon.com/managed-blockchain/latest/ambq-dg/key-concepts.html#finality"><i>finality</i></a>. Transactions that have reached finality are always part of the
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ConfirmationStatusFilter_Include { get; set; }
        #endregion
        
        #region Parameter Network
        /// <summary>
        /// <para>
        /// <para>The blockchain network where the transaction occurred.</para><para>Valid Values: <c>BITCOIN_MAINNET</c> | <c>BITCOIN_TESTNET</c></para>
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
        public System.String Network { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>Container on how the results will be sorted by?</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.ListFilteredTransactionEventsSortBy")]
        public Amazon.ManagedBlockchainQuery.ListFilteredTransactionEventsSortBy Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The container for the <i>sort order</i> for <c>ListFilteredTransactionEvents</c>.
        /// The <c>SortOrder</c> field only accepts the values <c>ASCENDING</c> and <c>DESCENDING</c>.
        /// Not providing <c>SortOrder</c> will default to <c>ASCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedBlockchainQuery.SortOrder")]
        public Amazon.ManagedBlockchainQuery.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter From_Time
        /// <summary>
        /// <para>
        /// <para>The container of the <c>Timestamp</c> of the blockchain instant.</para><note><para>This <c>timestamp</c> will only be recorded up to the second.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeFilter_From_Time")]
        public System.DateTime? From_Time { get; set; }
        #endregion
        
        #region Parameter To_Time
        /// <summary>
        /// <para>
        /// <para>The container of the <c>Timestamp</c> of the blockchain instant.</para><note><para>This <c>timestamp</c> will only be recorded up to the second.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeFilter_To_Time")]
        public System.DateTime? To_Time { get; set; }
        #endregion
        
        #region Parameter AddressIdentifierFilter_TransactionEventToAddress
        /// <summary>
        /// <para>
        /// <para>The container for the recipient address of the transaction. </para>
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
        public System.String[] AddressIdentifierFilter_TransactionEventToAddress { get; set; }
        #endregion
        
        #region Parameter VoutFilter_VoutSpent
        /// <summary>
        /// <para>
        /// <para>Specifies if the transaction output is spent or unspent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VoutFilter_VoutSpent { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
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
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse, GetMBCQFilteredTransactionEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddressIdentifierFilter_TransactionEventToAddress != null)
            {
                context.AddressIdentifierFilter_TransactionEventToAddress = new List<System.String>(this.AddressIdentifierFilter_TransactionEventToAddress);
            }
            #if MODULAR
            if (this.AddressIdentifierFilter_TransactionEventToAddress == null && ParameterWasBound(nameof(this.AddressIdentifierFilter_TransactionEventToAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter AddressIdentifierFilter_TransactionEventToAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ConfirmationStatusFilter_Include != null)
            {
                context.ConfirmationStatusFilter_Include = new List<System.String>(this.ConfirmationStatusFilter_Include);
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
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            context.From_Time = this.From_Time;
            context.To_Time = this.To_Time;
            context.VoutFilter_VoutSpent = this.VoutFilter_VoutSpent;
            
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
            var request = new Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsRequest();
            
            
             // populate AddressIdentifierFilter
            var requestAddressIdentifierFilterIsNull = true;
            request.AddressIdentifierFilter = new Amazon.ManagedBlockchainQuery.Model.AddressIdentifierFilter();
            List<System.String> requestAddressIdentifierFilter_addressIdentifierFilter_TransactionEventToAddress = null;
            if (cmdletContext.AddressIdentifierFilter_TransactionEventToAddress != null)
            {
                requestAddressIdentifierFilter_addressIdentifierFilter_TransactionEventToAddress = cmdletContext.AddressIdentifierFilter_TransactionEventToAddress;
            }
            if (requestAddressIdentifierFilter_addressIdentifierFilter_TransactionEventToAddress != null)
            {
                request.AddressIdentifierFilter.TransactionEventToAddress = requestAddressIdentifierFilter_addressIdentifierFilter_TransactionEventToAddress;
                requestAddressIdentifierFilterIsNull = false;
            }
             // determine if request.AddressIdentifierFilter should be set to null
            if (requestAddressIdentifierFilterIsNull)
            {
                request.AddressIdentifierFilter = null;
            }
            
             // populate ConfirmationStatusFilter
            var requestConfirmationStatusFilterIsNull = true;
            request.ConfirmationStatusFilter = new Amazon.ManagedBlockchainQuery.Model.ConfirmationStatusFilter();
            List<System.String> requestConfirmationStatusFilter_confirmationStatusFilter_Include = null;
            if (cmdletContext.ConfirmationStatusFilter_Include != null)
            {
                requestConfirmationStatusFilter_confirmationStatusFilter_Include = cmdletContext.ConfirmationStatusFilter_Include;
            }
            if (requestConfirmationStatusFilter_confirmationStatusFilter_Include != null)
            {
                request.ConfirmationStatusFilter.Include = requestConfirmationStatusFilter_confirmationStatusFilter_Include;
                requestConfirmationStatusFilterIsNull = false;
            }
             // determine if request.ConfirmationStatusFilter should be set to null
            if (requestConfirmationStatusFilterIsNull)
            {
                request.ConfirmationStatusFilter = null;
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
            request.Sort = new Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsSort();
            Amazon.ManagedBlockchainQuery.ListFilteredTransactionEventsSortBy requestSort_sort_SortBy = null;
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
            
             // populate TimeFilter
            var requestTimeFilterIsNull = true;
            request.TimeFilter = new Amazon.ManagedBlockchainQuery.Model.TimeFilter();
            Amazon.ManagedBlockchainQuery.Model.BlockchainInstant requestTimeFilter_timeFilter_From = null;
            
             // populate From
            var requestTimeFilter_timeFilter_FromIsNull = true;
            requestTimeFilter_timeFilter_From = new Amazon.ManagedBlockchainQuery.Model.BlockchainInstant();
            System.DateTime? requestTimeFilter_timeFilter_From_from_Time = null;
            if (cmdletContext.From_Time != null)
            {
                requestTimeFilter_timeFilter_From_from_Time = cmdletContext.From_Time.Value;
            }
            if (requestTimeFilter_timeFilter_From_from_Time != null)
            {
                requestTimeFilter_timeFilter_From.Time = requestTimeFilter_timeFilter_From_from_Time.Value;
                requestTimeFilter_timeFilter_FromIsNull = false;
            }
             // determine if requestTimeFilter_timeFilter_From should be set to null
            if (requestTimeFilter_timeFilter_FromIsNull)
            {
                requestTimeFilter_timeFilter_From = null;
            }
            if (requestTimeFilter_timeFilter_From != null)
            {
                request.TimeFilter.From = requestTimeFilter_timeFilter_From;
                requestTimeFilterIsNull = false;
            }
            Amazon.ManagedBlockchainQuery.Model.BlockchainInstant requestTimeFilter_timeFilter_To = null;
            
             // populate To
            var requestTimeFilter_timeFilter_ToIsNull = true;
            requestTimeFilter_timeFilter_To = new Amazon.ManagedBlockchainQuery.Model.BlockchainInstant();
            System.DateTime? requestTimeFilter_timeFilter_To_to_Time = null;
            if (cmdletContext.To_Time != null)
            {
                requestTimeFilter_timeFilter_To_to_Time = cmdletContext.To_Time.Value;
            }
            if (requestTimeFilter_timeFilter_To_to_Time != null)
            {
                requestTimeFilter_timeFilter_To.Time = requestTimeFilter_timeFilter_To_to_Time.Value;
                requestTimeFilter_timeFilter_ToIsNull = false;
            }
             // determine if requestTimeFilter_timeFilter_To should be set to null
            if (requestTimeFilter_timeFilter_ToIsNull)
            {
                requestTimeFilter_timeFilter_To = null;
            }
            if (requestTimeFilter_timeFilter_To != null)
            {
                request.TimeFilter.To = requestTimeFilter_timeFilter_To;
                requestTimeFilterIsNull = false;
            }
             // determine if request.TimeFilter should be set to null
            if (requestTimeFilterIsNull)
            {
                request.TimeFilter = null;
            }
            
             // populate VoutFilter
            var requestVoutFilterIsNull = true;
            request.VoutFilter = new Amazon.ManagedBlockchainQuery.Model.VoutFilter();
            System.Boolean? requestVoutFilter_voutFilter_VoutSpent = null;
            if (cmdletContext.VoutFilter_VoutSpent != null)
            {
                requestVoutFilter_voutFilter_VoutSpent = cmdletContext.VoutFilter_VoutSpent.Value;
            }
            if (requestVoutFilter_voutFilter_VoutSpent != null)
            {
                request.VoutFilter.VoutSpent = requestVoutFilter_voutFilter_VoutSpent.Value;
                requestVoutFilterIsNull = false;
            }
             // determine if request.VoutFilter should be set to null
            if (requestVoutFilterIsNull)
            {
                request.VoutFilter = null;
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
        
        private Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse CallAWSServiceOperation(IAmazonManagedBlockchainQuery client, Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain Query", "ListFilteredTransactionEvents");
            try
            {
                #if DESKTOP
                return client.ListFilteredTransactionEvents(request);
                #elif CORECLR
                return client.ListFilteredTransactionEventsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AddressIdentifierFilter_TransactionEventToAddress { get; set; }
            public List<System.String> ConfirmationStatusFilter_Include { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String Network { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ManagedBlockchainQuery.ListFilteredTransactionEventsSortBy Sort_SortBy { get; set; }
            public Amazon.ManagedBlockchainQuery.SortOrder Sort_SortOrder { get; set; }
            public System.DateTime? From_Time { get; set; }
            public System.DateTime? To_Time { get; set; }
            public System.Boolean? VoutFilter_VoutSpent { get; set; }
            public System.Func<Amazon.ManagedBlockchainQuery.Model.ListFilteredTransactionEventsResponse, GetMBCQFilteredTransactionEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
