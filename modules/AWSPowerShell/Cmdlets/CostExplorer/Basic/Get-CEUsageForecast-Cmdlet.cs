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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves a forecast for how much Amazon Web Services predicts that you will use over
    /// the forecast time period that you select, based on your past usage.
    /// </summary>
    [Cmdlet("Get", "CEUsageForecast")]
    [OutputType("Amazon.CostExplorer.Model.GetUsageForecastResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetUsageForecast API operation.", Operation = new[] {"GetUsageForecast"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetUsageForecastResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetUsageForecastResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetUsageForecastResponse object containing multiple properties."
    )]
    public partial class GetCEUsageForecastCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BillingViewArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies a specific billing view. The
        /// ARN is used to specify which particular billing view you want to interact with or
        /// retrieve information from when making API calls related to Amazon Web Services Billing
        /// and Cost Management features. The BillingViewArn can be retrieved by calling the ListBillingViews
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingViewArn { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters that you want to use to filter your forecast. The <c>GetUsageForecast</c>
        /// API supports filtering by the following dimensions:</para><ul><li><para><c>AZ</c></para></li><li><para><c>INSTANCE_TYPE</c></para></li><li><para><c>LINKED_ACCOUNT</c></para></li><li><para><c>LINKED_ACCOUNT_NAME</c></para></li><li><para><c>OPERATION</c></para></li><li><para><c>PURCHASE_TYPE</c></para></li><li><para><c>REGION</c></para></li><li><para><c>SERVICE</c></para></li><li><para><c>USAGE_TYPE</c></para></li><li><para><c>USAGE_TYPE_GROUP</c></para></li><li><para><c>RECORD_TYPE</c></para></li><li><para><c>OPERATING_SYSTEM</c></para></li><li><para><c>TENANCY</c></para></li><li><para><c>SCOPE</c></para></li><li><para><c>PLATFORM</c></para></li><li><para><c>SUBSCRIPTION_ID</c></para></li><li><para><c>LEGAL_ENTITY_NAME</c></para></li><li><para><c>DEPLOYMENT_OPTION</c></para></li><li><para><c>DATABASE_ENGINE</c></para></li><li><para><c>INSTANCE_TYPE_FAMILY</c></para></li><li><para><c>BILLING_ENTITY</c></para></li><li><para><c>RESERVATION_ID</c></para></li><li><para><c>SAVINGS_PLAN_ARN</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>How granular you want the forecast to be. You can get 3 months of <c>DAILY</c> forecasts
        /// or 12 months of <c>MONTHLY</c> forecasts.</para><para>The <c>GetUsageForecast</c> operation supports only <c>DAILY</c> and <c>MONTHLY</c>
        /// granularities.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>Which metric Cost Explorer uses to create your forecast.</para><para>Valid values for a <c>GetUsageForecast</c> call are the following:</para><ul><li><para>USAGE_QUANTITY</para></li><li><para>NORMALIZED_USAGE_AMOUNT</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Metric")]
        public Amazon.CostExplorer.Metric Metric { get; set; }
        #endregion
        
        #region Parameter PredictionIntervalLevel
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services Cost Explorer always returns the mean forecast as a single point.
        /// You can request a prediction interval around the mean by specifying a confidence level.
        /// The higher the confidence level, the more confident Cost Explorer is about the actual
        /// value falling in the prediction interval. Higher confidence levels result in wider
        /// prediction intervals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PredictionIntervalLevel { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>The start and end dates of the period that you want to retrieve usage forecast for.
        /// The start date is included in the period, but the end date isn't included in the period.
        /// For example, if <c>start</c> is <c>2017-01-01</c> and <c>end</c> is <c>2017-05-01</c>,
        /// then the cost and usage data is retrieved from <c>2017-01-01</c> up to and including
        /// <c>2017-04-30</c> but not including <c>2017-05-01</c>. The start date must be equal
        /// to or later than the current date to avoid a validation error.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetUsageForecastResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetUsageForecastResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetUsageForecastResponse, GetCEUsageForecastCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingViewArn = this.BillingViewArn;
            context.Filter = this.Filter;
            context.Granularity = this.Granularity;
            #if MODULAR
            if (this.Granularity == null && ParameterWasBound(nameof(this.Granularity)))
            {
                WriteWarning("You are passing $null as a value for parameter Granularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Metric = this.Metric;
            #if MODULAR
            if (this.Metric == null && ParameterWasBound(nameof(this.Metric)))
            {
                WriteWarning("You are passing $null as a value for parameter Metric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PredictionIntervalLevel = this.PredictionIntervalLevel;
            context.TimePeriod = this.TimePeriod;
            #if MODULAR
            if (this.TimePeriod == null && ParameterWasBound(nameof(this.TimePeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CostExplorer.Model.GetUsageForecastRequest();
            
            if (cmdletContext.BillingViewArn != null)
            {
                request.BillingViewArn = cmdletContext.BillingViewArn;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metric = cmdletContext.Metric;
            }
            if (cmdletContext.PredictionIntervalLevel != null)
            {
                request.PredictionIntervalLevel = cmdletContext.PredictionIntervalLevel.Value;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
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
        
        private Amazon.CostExplorer.Model.GetUsageForecastResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetUsageForecastRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetUsageForecast");
            try
            {
                return client.GetUsageForecastAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BillingViewArn { get; set; }
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.Granularity Granularity { get; set; }
            public Amazon.CostExplorer.Metric Metric { get; set; }
            public System.Int32? PredictionIntervalLevel { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetUsageForecastResponse, GetCEUsageForecastCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
