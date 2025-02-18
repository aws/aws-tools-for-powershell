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
using Amazon.Budgets;
using Amazon.Budgets.Model;

namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Describes the history for <c>DAILY</c>, <c>MONTHLY</c>, and <c>QUARTERLY</c> budgets.
    /// Budget history isn't available for <c>ANNUAL</c> budgets.<br/><br/>In the AWS.Tools.Budgets module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BGTBudgetPerformanceHistory")]
    [OutputType("Amazon.Budgets.Model.BudgetPerformanceHistory")]
    [AWSCmdlet("Calls the AWS Budgets DescribeBudgetPerformanceHistory API operation.", Operation = new[] {"DescribeBudgetPerformanceHistory"}, SelectReturnType = typeof(Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse))]
    [AWSCmdletOutput("Amazon.Budgets.Model.BudgetPerformanceHistory or Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse",
        "This cmdlet returns an Amazon.Budgets.Model.BudgetPerformanceHistory object.",
        "The service call response (type Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBGTBudgetPerformanceHistoryCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// <para>The end date for a budget. If you didn't specify an end date, Amazon Web Services
        /// set your end date to <c>06/15/87 00:00 UTC</c>. The defaults are the same for the
        /// Billing and Cost Management console and the API.</para><para>After the end date, Amazon Web Services deletes the budget and all the associated
        /// notifications and subscribers. You can change your end date with the <c>UpdateBudget</c>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// <para>The start date for a budget. If you created your budget and didn't specify a start
        /// date, Amazon Web Services defaults to the start of your chosen time period (DAILY,
        /// MONTHLY, QUARTERLY, or ANNUALLY). For example, if you created your budget on January
        /// 24, 2018, chose <c>DAILY</c>, and didn't set a start date, Amazon Web Services set
        /// your start date to <c>01/24/18 00:00 UTC</c>. If you chose <c>MONTHLY</c>, Amazon
        /// Web Services set your start date to <c>01/01/18 00:00 UTC</c>. The defaults are the
        /// same for the Billing and Cost Management console and the API.</para><para>You can change your start date with the <c>UpdateBudget</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.Budgets module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BudgetPerformanceHistory'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse).
        /// Specifying the name of a property of type Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BudgetPerformanceHistory";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
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
                context.Select = CreateSelectDelegate<Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse, GetBGTBudgetPerformanceHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BudgetName = this.BudgetName;
            #if MODULAR
            if (this.BudgetName == null && ParameterWasBound(nameof(this.BudgetName)))
            {
                WriteWarning("You are passing $null as a value for parameter BudgetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TimePeriod_End = this.TimePeriod_End;
            context.TimePeriod_Start = this.TimePeriod_Start;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate TimePeriod
            var requestTimePeriodIsNull = true;
            request.TimePeriod = new Amazon.Budgets.Model.TimePeriod();
            System.DateTime? requestTimePeriod_timePeriod_End = null;
            if (cmdletContext.TimePeriod_End != null)
            {
                requestTimePeriod_timePeriod_End = cmdletContext.TimePeriod_End.Value;
            }
            if (requestTimePeriod_timePeriod_End != null)
            {
                request.TimePeriod.End = requestTimePeriod_timePeriod_End.Value;
                requestTimePeriodIsNull = false;
            }
            System.DateTime? requestTimePeriod_timePeriod_Start = null;
            if (cmdletContext.TimePeriod_Start != null)
            {
                requestTimePeriod_timePeriod_Start = cmdletContext.TimePeriod_Start.Value;
            }
            if (requestTimePeriod_timePeriod_Start != null)
            {
                request.TimePeriod.Start = requestTimePeriod_timePeriod_Start.Value;
                requestTimePeriodIsNull = false;
            }
             // determine if request.TimePeriod should be set to null
            if (requestTimePeriodIsNull)
            {
                request.TimePeriod = null;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate TimePeriod
            var requestTimePeriodIsNull = true;
            request.TimePeriod = new Amazon.Budgets.Model.TimePeriod();
            System.DateTime? requestTimePeriod_timePeriod_End = null;
            if (cmdletContext.TimePeriod_End != null)
            {
                requestTimePeriod_timePeriod_End = cmdletContext.TimePeriod_End.Value;
            }
            if (requestTimePeriod_timePeriod_End != null)
            {
                request.TimePeriod.End = requestTimePeriod_timePeriod_End.Value;
                requestTimePeriodIsNull = false;
            }
            System.DateTime? requestTimePeriod_timePeriod_Start = null;
            if (cmdletContext.TimePeriod_Start != null)
            {
                requestTimePeriod_timePeriod_Start = cmdletContext.TimePeriod_Start.Value;
            }
            if (requestTimePeriod_timePeriod_Start != null)
            {
                request.TimePeriod.Start = requestTimePeriod_timePeriod_Start.Value;
                requestTimePeriodIsNull = false;
            }
             // determine if request.TimePeriod should be set to null
            if (requestTimePeriodIsNull)
            {
                request.TimePeriod = null;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "DescribeBudgetPerformanceHistory");
            try
            {
                return client.DescribeBudgetPerformanceHistoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String BudgetName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? TimePeriod_End { get; set; }
            public System.DateTime? TimePeriod_Start { get; set; }
            public System.Func<Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse, GetBGTBudgetPerformanceHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BudgetPerformanceHistory;
        }
        
    }
}
