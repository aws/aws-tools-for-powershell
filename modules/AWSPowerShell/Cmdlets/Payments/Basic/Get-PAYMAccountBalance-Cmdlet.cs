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
    /// Retrieves one balance of your account, selected by balance type, as one amount for
    /// each merchant of record and currency. Each amount is the sum of the outstanding balances
    /// of your invoices or credit memos that have the status <c>OUTSTANDING</c>. Amounts
    /// are never added together across merchants of record or currencies. This operation
    /// is eventually consistent. Results are paginated. Use <c>nextToken</c> to retrieve
    /// more results.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have Amazon Web Services Identity and Access Management
    /// (IAM) permission for both <c>payments:GetAccountBalance</c> and <c>payments:GetPaymentStatus</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PAYMAccountBalance")]
    [OutputType("Amazon.Payments.Model.AccountBalance")]
    [AWSCmdlet("Calls the AWS Payments GetAccountBalance API operation.", Operation = new[] {"GetAccountBalance"}, SelectReturnType = typeof(Amazon.Payments.Model.GetAccountBalanceResponse))]
    [AWSCmdletOutput("Amazon.Payments.Model.AccountBalance or Amazon.Payments.Model.GetAccountBalanceResponse",
        "This cmdlet returns a collection of Amazon.Payments.Model.AccountBalance objects.",
        "The service call response (type Amazon.Payments.Model.GetAccountBalanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPAYMAccountBalanceCmdlet : AmazonPaymentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BalanceType
        /// <summary>
        /// <para>
        /// <para>The balance to retrieve. You can specify only one balance type in a single request.
        /// Each balance adds up the <c>outstanding</c> balance of the records that have the status
        /// <c>OUTSTANDING</c>. A record that is <c>PROCESSING</c>, <c>SETTLED</c>, or <c>CANCELED</c>
        /// isn't included, even when part of its amount is outstanding. The following values
        /// are valid:</para><ul><li><para><c>INVOICES_DUE</c> – The outstanding balance of your <c>OUTSTANDING</c> invoices
        /// that aren't past their due date, where <c>dueStatus</c> is <c>DUE</c>.</para></li><li><para><c>INVOICES_PAST_DUE</c> – The outstanding balance of your <c>OUTSTANDING</c> invoices
        /// that are past their due date, where <c>dueStatus</c> is <c>PAST_DUE</c>.</para></li><li><para><c>OUTSTANDING_CREDIT_MEMOS</c> – The outstanding balance of your <c>OUTSTANDING</c>
        /// credit memos: the credit that isn't yet applied to an invoice.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Payments.BalanceType")]
        public Amazon.Payments.BalanceType BalanceType { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountBalances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Payments.Model.GetAccountBalanceResponse).
        /// Specifying the name of a property of type Amazon.Payments.Model.GetAccountBalanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountBalances";
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
                context.Select = CreateSelectDelegate<Amazon.Payments.Model.GetAccountBalanceResponse, GetPAYMAccountBalanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BalanceType = this.BalanceType;
            #if MODULAR
            if (this.BalanceType == null && ParameterWasBound(nameof(this.BalanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter BalanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Payments.Model.GetAccountBalanceRequest();
            
            if (cmdletContext.BalanceType != null)
            {
                request.BalanceType = cmdletContext.BalanceType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        
        private Amazon.Payments.Model.GetAccountBalanceResponse CallAWSServiceOperation(IAmazonPayments client, Amazon.Payments.Model.GetAccountBalanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Payments", "GetAccountBalance");
            try
            {
                return client.GetAccountBalanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Payments.BalanceType BalanceType { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Payments.Model.GetAccountBalanceResponse, GetPAYMAccountBalanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountBalances;
        }
        
    }
}
