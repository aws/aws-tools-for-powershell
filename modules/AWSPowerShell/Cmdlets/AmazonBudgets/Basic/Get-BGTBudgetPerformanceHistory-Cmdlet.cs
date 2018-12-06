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
using Amazon.Budgets;
using Amazon.Budgets.Model;

namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Describes the history for <code>DAILY</code>, <code>MONTHLY</code>, and <code>QUARTERLY</code>
    /// budgets. Budget history isn't available for <code>ANNUAL</code> budgets.
    /// </summary>
    [Cmdlet("Get", "BGTBudgetPerformanceHistory")]
    [OutputType("Amazon.Budgets.Model.BudgetPerformanceHistory")]
    [AWSCmdlet("Calls the AWS Budgets DescribeBudgetPerformanceHistory API operation.", Operation = new[] {"DescribeBudgetPerformanceHistory"})]
    [AWSCmdletOutput("Amazon.Budgets.Model.BudgetPerformanceHistory",
        "This cmdlet returns a BudgetPerformanceHistory object.",
        "The service call response (type Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetBGTBudgetPerformanceHistoryCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// <para>The end date for a budget. If you didn't specify an end date, AWS set your end date
        /// to <code>06/15/87 00:00 UTC</code>. The defaults are the same for the AWS Billing
        /// and Cost Management console and the API.</para><para>After the end date, AWS deletes the budget and all associated notifications and subscribers.
        /// You can change your end date with the <code>UpdateBudget</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// <para>The start date for a budget. If you created your budget and didn't specify a start
        /// date, AWS defaults to the start of your chosen time period (DAILY, MONTHLY, QUARTERLY,
        /// or ANNUALLY). For example, if you created your budget on January 24, 2018, chose <code>DAILY</code>,
        /// and didn't set a start date, AWS set your start date to <code>01/24/18 00:00 UTC</code>.
        /// If you chose <code>MONTHLY</code>, AWS set your start date to <code>01/01/18 00:00
        /// UTC</code>. The defaults are the same for the AWS Billing and Cost Management console
        /// and the API.</para><para>You can change your start date with the <code>UpdateBudget</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            context.AccountId = this.AccountId;
            context.BudgetName = this.BudgetName;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("TimePeriod_End"))
                context.TimePeriod_End = this.TimePeriod_End;
            if (ParameterWasBound("TimePeriod_Start"))
                context.TimePeriod_Start = this.TimePeriod_Start;
            
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
            var request = new Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate TimePeriod
            bool requestTimePeriodIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BudgetPerformanceHistory;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        private Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.DescribeBudgetPerformanceHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "DescribeBudgetPerformanceHistory");
            try
            {
                #if DESKTOP
                return client.DescribeBudgetPerformanceHistory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeBudgetPerformanceHistoryAsync(request);
                return task.Result;
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
            public System.String AccountId { get; set; }
            public System.String BudgetName { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? TimePeriod_End { get; set; }
            public System.DateTime? TimePeriod_Start { get; set; }
        }
        
    }
}
