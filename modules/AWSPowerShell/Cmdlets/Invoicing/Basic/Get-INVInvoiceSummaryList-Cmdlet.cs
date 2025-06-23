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
using Amazon.Invoicing;
using Amazon.Invoicing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INV
{
    /// <summary>
    /// Retrieves your invoice details programmatically, without line item details.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "INVInvoiceSummaryList")]
    [OutputType("Amazon.Invoicing.Model.InvoiceSummary")]
    [AWSCmdlet("Calls the AWS Invoicing ListInvoiceSummaries API operation.", Operation = new[] {"ListInvoiceSummaries"}, SelectReturnType = typeof(Amazon.Invoicing.Model.ListInvoiceSummariesResponse))]
    [AWSCmdletOutput("Amazon.Invoicing.Model.InvoiceSummary or Amazon.Invoicing.Model.ListInvoiceSummariesResponse",
        "This cmdlet returns a collection of Amazon.Invoicing.Model.InvoiceSummary objects.",
        "The service call response (type Amazon.Invoicing.Model.ListInvoiceSummariesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINVInvoiceSummaryListCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TimeInterval_EndDate
        /// <summary>
        /// <para>
        /// <para> The end of the time period that you want invoice-related documents for. The end date
        /// is exclusive. For example, if <c>end</c> is <c>2019-01-10</c>, Amazon Web Services
        /// retrieves invoice-related documents from the start date up to, but not including,
        /// <c>2018-01-10</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TimeInterval_EndDate")]
        public System.DateTime? TimeInterval_EndDate { get; set; }
        #endregion
        
        #region Parameter Filter_InvoicingEntity
        /// <summary>
        /// <para>
        /// <para>The name of the entity that issues the Amazon Web Services invoice.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_InvoicingEntity { get; set; }
        #endregion
        
        #region Parameter BillingPeriod_Month
        /// <summary>
        /// <para>
        /// <para> The billing period month. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_BillingPeriod_Month")]
        public System.Int32? BillingPeriod_Month { get; set; }
        #endregion
        
        #region Parameter Selector_ResourceType
        /// <summary>
        /// <para>
        /// <para>The query identifier type (<c>INVOICE_ID</c> or <c>ACCOUNT_ID</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Invoicing.ListInvoiceSummariesResourceType")]
        public Amazon.Invoicing.ListInvoiceSummariesResourceType Selector_ResourceType { get; set; }
        #endregion
        
        #region Parameter TimeInterval_StartDate
        /// <summary>
        /// <para>
        /// <para> The beginning of the time period that you want invoice-related documents for. The
        /// start date is inclusive. For example, if <c>start</c> is <c>2019-01-01</c>, AWS retrieves
        /// invoices starting at <c>2019-01-01</c> up to the end date. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TimeInterval_StartDate")]
        public System.DateTime? TimeInterval_StartDate { get; set; }
        #endregion
        
        #region Parameter Selector_Value
        /// <summary>
        /// <para>
        /// <para>The value of the query identifier.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Selector_Value { get; set; }
        #endregion
        
        #region Parameter BillingPeriod_Year
        /// <summary>
        /// <para>
        /// <para> The billing period year. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_BillingPeriod_Year")]
        public System.Int32? BillingPeriod_Year { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of invoice summaries a paginated response can contain.</para>
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
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvoiceSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.ListInvoiceSummariesResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.ListInvoiceSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvoiceSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.ListInvoiceSummariesResponse, GetINVInvoiceSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod_Month = this.BillingPeriod_Month;
            context.BillingPeriod_Year = this.BillingPeriod_Year;
            context.Filter_InvoicingEntity = this.Filter_InvoicingEntity;
            context.TimeInterval_EndDate = this.TimeInterval_EndDate;
            context.TimeInterval_StartDate = this.TimeInterval_StartDate;
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
            context.Selector_ResourceType = this.Selector_ResourceType;
            #if MODULAR
            if (this.Selector_ResourceType == null && ParameterWasBound(nameof(this.Selector_ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter Selector_ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Selector_Value = this.Selector_Value;
            #if MODULAR
            if (this.Selector_Value == null && ParameterWasBound(nameof(this.Selector_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Selector_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Invoicing.Model.ListInvoiceSummariesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Invoicing.Model.InvoiceSummariesFilter();
            System.String requestFilter_filter_InvoicingEntity = null;
            if (cmdletContext.Filter_InvoicingEntity != null)
            {
                requestFilter_filter_InvoicingEntity = cmdletContext.Filter_InvoicingEntity;
            }
            if (requestFilter_filter_InvoicingEntity != null)
            {
                request.Filter.InvoicingEntity = requestFilter_filter_InvoicingEntity;
                requestFilterIsNull = false;
            }
            Amazon.Invoicing.Model.BillingPeriod requestFilter_filter_BillingPeriod = null;
            
             // populate BillingPeriod
            var requestFilter_filter_BillingPeriodIsNull = true;
            requestFilter_filter_BillingPeriod = new Amazon.Invoicing.Model.BillingPeriod();
            System.Int32? requestFilter_filter_BillingPeriod_billingPeriod_Month = null;
            if (cmdletContext.BillingPeriod_Month != null)
            {
                requestFilter_filter_BillingPeriod_billingPeriod_Month = cmdletContext.BillingPeriod_Month.Value;
            }
            if (requestFilter_filter_BillingPeriod_billingPeriod_Month != null)
            {
                requestFilter_filter_BillingPeriod.Month = requestFilter_filter_BillingPeriod_billingPeriod_Month.Value;
                requestFilter_filter_BillingPeriodIsNull = false;
            }
            System.Int32? requestFilter_filter_BillingPeriod_billingPeriod_Year = null;
            if (cmdletContext.BillingPeriod_Year != null)
            {
                requestFilter_filter_BillingPeriod_billingPeriod_Year = cmdletContext.BillingPeriod_Year.Value;
            }
            if (requestFilter_filter_BillingPeriod_billingPeriod_Year != null)
            {
                requestFilter_filter_BillingPeriod.Year = requestFilter_filter_BillingPeriod_billingPeriod_Year.Value;
                requestFilter_filter_BillingPeriodIsNull = false;
            }
             // determine if requestFilter_filter_BillingPeriod should be set to null
            if (requestFilter_filter_BillingPeriodIsNull)
            {
                requestFilter_filter_BillingPeriod = null;
            }
            if (requestFilter_filter_BillingPeriod != null)
            {
                request.Filter.BillingPeriod = requestFilter_filter_BillingPeriod;
                requestFilterIsNull = false;
            }
            Amazon.Invoicing.Model.DateInterval requestFilter_filter_TimeInterval = null;
            
             // populate TimeInterval
            var requestFilter_filter_TimeIntervalIsNull = true;
            requestFilter_filter_TimeInterval = new Amazon.Invoicing.Model.DateInterval();
            System.DateTime? requestFilter_filter_TimeInterval_timeInterval_EndDate = null;
            if (cmdletContext.TimeInterval_EndDate != null)
            {
                requestFilter_filter_TimeInterval_timeInterval_EndDate = cmdletContext.TimeInterval_EndDate.Value;
            }
            if (requestFilter_filter_TimeInterval_timeInterval_EndDate != null)
            {
                requestFilter_filter_TimeInterval.EndDate = requestFilter_filter_TimeInterval_timeInterval_EndDate.Value;
                requestFilter_filter_TimeIntervalIsNull = false;
            }
            System.DateTime? requestFilter_filter_TimeInterval_timeInterval_StartDate = null;
            if (cmdletContext.TimeInterval_StartDate != null)
            {
                requestFilter_filter_TimeInterval_timeInterval_StartDate = cmdletContext.TimeInterval_StartDate.Value;
            }
            if (requestFilter_filter_TimeInterval_timeInterval_StartDate != null)
            {
                requestFilter_filter_TimeInterval.StartDate = requestFilter_filter_TimeInterval_timeInterval_StartDate.Value;
                requestFilter_filter_TimeIntervalIsNull = false;
            }
             // determine if requestFilter_filter_TimeInterval should be set to null
            if (requestFilter_filter_TimeIntervalIsNull)
            {
                requestFilter_filter_TimeInterval = null;
            }
            if (requestFilter_filter_TimeInterval != null)
            {
                request.Filter.TimeInterval = requestFilter_filter_TimeInterval;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate Selector
            var requestSelectorIsNull = true;
            request.Selector = new Amazon.Invoicing.Model.InvoiceSummariesSelector();
            Amazon.Invoicing.ListInvoiceSummariesResourceType requestSelector_selector_ResourceType = null;
            if (cmdletContext.Selector_ResourceType != null)
            {
                requestSelector_selector_ResourceType = cmdletContext.Selector_ResourceType;
            }
            if (requestSelector_selector_ResourceType != null)
            {
                request.Selector.ResourceType = requestSelector_selector_ResourceType;
                requestSelectorIsNull = false;
            }
            System.String requestSelector_selector_Value = null;
            if (cmdletContext.Selector_Value != null)
            {
                requestSelector_selector_Value = cmdletContext.Selector_Value;
            }
            if (requestSelector_selector_Value != null)
            {
                request.Selector.Value = requestSelector_selector_Value;
                requestSelectorIsNull = false;
            }
             // determine if request.Selector should be set to null
            if (requestSelectorIsNull)
            {
                request.Selector = null;
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
        
        private Amazon.Invoicing.Model.ListInvoiceSummariesResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.ListInvoiceSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "ListInvoiceSummaries");
            try
            {
                return client.ListInvoiceSummariesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? BillingPeriod_Month { get; set; }
            public System.Int32? BillingPeriod_Year { get; set; }
            public System.String Filter_InvoicingEntity { get; set; }
            public System.DateTime? TimeInterval_EndDate { get; set; }
            public System.DateTime? TimeInterval_StartDate { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Invoicing.ListInvoiceSummariesResourceType Selector_ResourceType { get; set; }
            public System.String Selector_Value { get; set; }
            public System.Func<Amazon.Invoicing.Model.ListInvoiceSummariesResponse, GetINVInvoiceSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvoiceSummaries;
        }
        
    }
}
