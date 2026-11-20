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
using Amazon.Payments;
using Amazon.Payments.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYM
{
    /// <summary>
    /// Lists the financial records on your account, with the newest first by default. A financial
    /// record is an invoice or a credit memo. You must specify at least one record type in
    /// <c>types</c>. You can narrow the results further by settlement status and issue date.
    /// This operation returns summaries. To get the details that are specific to a record's
    /// type, use <c>GetFinancialRecord</c> or <c>BatchGetFinancialRecord</c>. Results are
    /// paginated. Use <c>nextToken</c> to retrieve more results.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have Amazon Web Services Identity and Access Management
    /// (IAM) permission for both <c>payments:ListFinancialRecords</c> and <c>payments:GetPaymentStatus</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PAYMFinancialRecordList")]
    [OutputType("Amazon.Payments.Model.FinancialRecordSummary")]
    [AWSCmdlet("Calls the AWS Payments ListFinancialRecords API operation.", Operation = new[] {"ListFinancialRecords"}, SelectReturnType = typeof(Amazon.Payments.Model.ListFinancialRecordsResponse))]
    [AWSCmdletOutput("Amazon.Payments.Model.FinancialRecordSummary or Amazon.Payments.Model.ListFinancialRecordsResponse",
        "This cmdlet returns a collection of Amazon.Payments.Model.FinancialRecordSummary objects.",
        "The service call response (type Amazon.Payments.Model.ListFinancialRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPAYMFinancialRecordListCmdlet : AmazonPaymentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IssuedAfter
        /// <summary>
        /// <para>
        /// <para>The earliest date and time to return records for, inclusive. The operation returns
        /// the records that were issued at or after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? IssuedAfter { get; set; }
        #endregion
        
        #region Parameter IssuedBefore
        /// <summary>
        /// <para>
        /// <para>The latest date and time to return records for, exclusive. The operation returns the
        /// records that were issued before this time. When you specify both <c>issuedAfter</c>
        /// and <c>issuedBefore</c>, <c>issuedBefore</c> must be later than <c>issuedAfter</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? IssuedBefore { get; set; }
        #endregion
        
        #region Parameter SettlementStatus
        /// <summary>
        /// <para>
        /// <para>The settlement statuses to filter by. <c>OPEN</c> returns records whose <c>status</c>
        /// is <c>OUTSTANDING</c> or <c>PROCESSING</c>. <c>CLOSED</c> returns records whose <c>status</c>
        /// is <c>SETTLED</c> or <c>CANCELED</c>. When you omit this member, the operation returns
        /// records with both settlement statuses.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SettlementStatuses")]
        public System.String[] SettlementStatus { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort the results by. The default is <c>ISSUED_AT</c>, the date and time
        /// when the record was issued.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Payments.FinancialRecordSortField")]
        public Amazon.Payments.FinancialRecordSortField SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort the results in. The default is <c>DESCENDING</c>, which returns
        /// the newest records first. <c>ASCENDING</c> returns the oldest records first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Payments.SortOrder")]
        public Amazon.Payments.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The financial record types to return. The following values are valid:</para><ul><li><para><c>INVOICE</c> – An invoice: a bill from Amazon Web Services. Payments and credit
        /// memos applied to the invoice settle it.</para></li><li><para><c>CREDIT_MEMO</c> – A credit memo: a credit issued to your account, for example
        /// for a billing correction or a service credit. Applying it to one or more invoices
        /// settles it.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Types")]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in one page. The default is 100. A page can
        /// contain fewer results even when more remain. Use <c>nextToken</c> to find out whether
        /// more results are available.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from the <c>nextToken</c> of the previous response. Omit it to
        /// get the first page. Tokens expire. If the token is malformed or expired, or doesn't
        /// match the original request, the request fails with <c>ValidationException</c> and
        /// the reason <c>INVALID_PAGINATION_TOKEN</c>. In that case, start again from the first
        /// page.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FinancialRecordSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Payments.Model.ListFinancialRecordsResponse).
        /// Specifying the name of a property of type Amazon.Payments.Model.ListFinancialRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FinancialRecordSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Payments.Model.ListFinancialRecordsResponse, GetPAYMFinancialRecordListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IssuedAfter = this.IssuedAfter;
            context.IssuedBefore = this.IssuedBefore;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            if (this.SettlementStatus != null)
            {
                context.SettlementStatus = new List<System.String>(this.SettlementStatus);
            }
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
            }
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Payments.Model.ListFinancialRecordsRequest();
            
            if (cmdletContext.IssuedAfter != null)
            {
                request.IssuedAfter = cmdletContext.IssuedAfter.Value;
            }
            if (cmdletContext.IssuedBefore != null)
            {
                request.IssuedBefore = cmdletContext.IssuedBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.SettlementStatus != null)
            {
                request.SettlementStatuses = cmdletContext.SettlementStatus;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.Type != null)
            {
                request.Types = cmdletContext.Type;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Payments.Model.ListFinancialRecordsResponse CallAWSServiceOperation(IAmazonPayments client, Amazon.Payments.Model.ListFinancialRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Payments", "ListFinancialRecords");
            try
            {
                return client.ListFinancialRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? IssuedAfter { get; set; }
            public System.DateTime? IssuedBefore { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> SettlementStatus { get; set; }
            public Amazon.Payments.FinancialRecordSortField SortBy { get; set; }
            public Amazon.Payments.SortOrder SortOrder { get; set; }
            public List<System.String> Type { get; set; }
            public System.Func<Amazon.Payments.Model.ListFinancialRecordsResponse, GetPAYMFinancialRecordListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FinancialRecordSummaries;
        }
        
    }
}
