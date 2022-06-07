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
        "This cmdlet returns an Amazon.CostExplorer.Model.GetUsageForecastResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEUsageForecastCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters that you want to use to filter your forecast. The <code>GetUsageForecast</code>
        /// API supports filtering by the following dimensions:</para><ul><li><para><code>AZ</code></para></li><li><para><code>INSTANCE_TYPE</code></para></li><li><para><code>LINKED_ACCOUNT</code></para></li><li><para><code>LINKED_ACCOUNT_NAME</code></para></li><li><para><code>OPERATION</code></para></li><li><para><code>PURCHASE_TYPE</code></para></li><li><para><code>REGION</code></para></li><li><para><code>SERVICE</code></para></li><li><para><code>USAGE_TYPE</code></para></li><li><para><code>USAGE_TYPE_GROUP</code></para></li><li><para><code>RECORD_TYPE</code></para></li><li><para><code>OPERATING_SYSTEM</code></para></li><li><para><code>TENANCY</code></para></li><li><para><code>SCOPE</code></para></li><li><para><code>PLATFORM</code></para></li><li><para><code>SUBSCRIPTION_ID</code></para></li><li><para><code>LEGAL_ENTITY_NAME</code></para></li><li><para><code>DEPLOYMENT_OPTION</code></para></li><li><para><code>DATABASE_ENGINE</code></para></li><li><para><code>INSTANCE_TYPE_FAMILY</code></para></li><li><para><code>BILLING_ENTITY</code></para></li><li><para><code>RESERVATION_ID</code></para></li><li><para><code>SAVINGS_PLAN_ARN</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>How granular you want the forecast to be. You can get 3 months of <code>DAILY</code>
        /// forecasts or 12 months of <code>MONTHLY</code> forecasts.</para><para>The <code>GetUsageForecast</code> operation supports only <code>DAILY</code> and <code>MONTHLY</code>
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
        /// <para>Which metric Cost Explorer uses to create your forecast.</para><para>Valid values for a <code>GetUsageForecast</code> call are the following:</para><ul><li><para>USAGE_QUANTITY</para></li><li><para>NORMALIZED_USAGE_AMOUNT</para></li></ul>
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
        /// For example, if <code>start</code> is <code>2017-01-01</code> and <code>end</code>
        /// is <code>2017-05-01</code>, then the cost and usage data is retrieved from <code>2017-01-01</code>
        /// up to and including <code>2017-04-30</code> but not including <code>2017-05-01</code>.
        /// The start date must be equal to or later than the current date to avoid a validation
        /// error.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Metric parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Metric' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Metric' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetUsageForecastResponse, GetCEUsageForecastCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Metric;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.GetUsageForecast(request);
                #elif CORECLR
                return client.GetUsageForecastAsync(request).GetAwaiter().GetResult();
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
