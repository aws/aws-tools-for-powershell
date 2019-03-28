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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves a forecast for how much Amazon Web Services predicts that you will spend
    /// over the forecast time period that you select, based on your past costs.
    /// </summary>
    [Cmdlet("Get", "CECostForecast")]
    [OutputType("Amazon.CostExplorer.Model.GetCostForecastResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetCostForecast API operation.", Operation = new[] {"GetCostForecast"})]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetCostForecastResponse",
        "This cmdlet returns a Amazon.CostExplorer.Model.GetCostForecastResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCECostForecastCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters that you want to use to filter your forecast. Cost Explorer API supports
        /// all of the Cost Explorer filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>How granular you want the forecast to be. You can get 3 months of <code>DAILY</code>
        /// forecasts or 12 months of <code>MONTHLY</code> forecasts.</para><para>The <code>GetCostForecast</code> operation supports only <code>DAILY</code> and <code>MONTHLY</code>
        /// granularities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>Which metric Cost Explorer uses to create your forecast. For more information about
        /// blended and unblended rates, see <a href="https://aws.amazon.com/premiumsupport/knowledge-center/blended-rates-intro/">Why
        /// does the "blended" annotation appear on some line items in my bill?</a>. </para><para>Valid values for a <code>GetCostForecast</code> call are the following:</para><ul><li><para>AmortizedCost</para></li><li><para>BlendedCost</para></li><li><para>NetAmortizedCost</para></li><li><para>NetUnblendedCost</para></li><li><para>UnblendedCost</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Metric")]
        public Amazon.CostExplorer.Metric Metric { get; set; }
        #endregion
        
        #region Parameter PredictionIntervalLevel
        /// <summary>
        /// <para>
        /// <para>Cost Explorer always returns the mean forecast as a single point. You can request
        /// a prediction interval around the mean by specifying a confidence level. The higher
        /// the confidence level, the more confident Cost Explorer is about the actual value falling
        /// in the prediction interval. Higher confidence levels result in wider prediction intervals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PredictionIntervalLevel { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>The period of time that you want the forecast to cover.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
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
            
            context.Filter = this.Filter;
            context.Granularity = this.Granularity;
            context.Metric = this.Metric;
            if (ParameterWasBound("PredictionIntervalLevel"))
                context.PredictionIntervalLevel = this.PredictionIntervalLevel;
            context.TimePeriod = this.TimePeriod;
            
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
            var request = new Amazon.CostExplorer.Model.GetCostForecastRequest();
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.CostExplorer.Model.GetCostForecastResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetCostForecastRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetCostForecast");
            try
            {
                #if DESKTOP
                return client.GetCostForecast(request);
                #elif CORECLR
                return client.GetCostForecastAsync(request).GetAwaiter().GetResult();
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
        }
        
    }
}
