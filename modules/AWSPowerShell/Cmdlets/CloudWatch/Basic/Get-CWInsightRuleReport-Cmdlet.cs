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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// This operation returns the time series data collected by a Contributor Insights rule.
    /// The data includes the identity and number of contributors to the log group.
    /// 
    ///  
    /// <para>
    /// You can also optionally return one or more statistics about each data point in the
    /// time series. These statistics can include the following:
    /// </para><ul><li><para><c>UniqueContributors</c> -- the number of unique contributors for each data point.
    /// </para></li><li><para><c>MaxContributorValue</c> -- the value of the top contributor for each data point.
    /// The identity of the contributor might change for each data point in the graph.
    /// </para><para>
    /// If this rule aggregates by COUNT, the top contributor for each data point is the contributor
    /// with the most occurrences in that period. If the rule aggregates by SUM, the top contributor
    /// is the contributor with the highest sum in the log field specified by the rule's <c>Value</c>,
    /// during that period.
    /// </para></li><li><para><c>SampleCount</c> -- the number of data points matched by the rule.
    /// </para></li><li><para><c>Sum</c> -- the sum of the values from all contributors during the time period
    /// represented by that data point.
    /// </para></li><li><para><c>Minimum</c> -- the minimum value from a single observation during the time period
    /// represented by that data point.
    /// </para></li><li><para><c>Maximum</c> -- the maximum value from a single observation during the time period
    /// represented by that data point.
    /// </para></li><li><para><c>Average</c> -- the average value from all contributors during the time period
    /// represented by that data point.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "CWInsightRuleReport")]
    [OutputType("Amazon.CloudWatch.Model.GetInsightRuleReportResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetInsightRuleReport API operation.", Operation = new[] {"GetInsightRuleReport"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.GetInsightRuleReportResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetInsightRuleReportResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.GetInsightRuleReportResponse object containing multiple properties."
    )]
    public partial class GetCWInsightRuleReportCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the data to use in the report. When used in a raw HTTP Query API,
        /// it is formatted as <c>yyyy-MM-dd'T'HH:mm:ss</c>. For example, <c>2019-07-01T23:59:59</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter MaxContributorCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of contributors to include in the report. The range is 1 to 100.
        /// If you omit this, the default of 10 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxContributorCount { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>Specifies which metrics to use for aggregation of contributor values for the report.
        /// You can specify one or more of the following metrics:</para><ul><li><para><c>UniqueContributors</c> -- the number of unique contributors for each data point.</para></li><li><para><c>MaxContributorValue</c> -- the value of the top contributor for each data point.
        /// The identity of the contributor might change for each data point in the graph.</para><para>If this rule aggregates by COUNT, the top contributor for each data point is the contributor
        /// with the most occurrences in that period. If the rule aggregates by SUM, the top contributor
        /// is the contributor with the highest sum in the log field specified by the rule's <c>Value</c>,
        /// during that period.</para></li><li><para><c>SampleCount</c> -- the number of data points matched by the rule.</para></li><li><para><c>Sum</c> -- the sum of the values from all contributors during the time period
        /// represented by that data point.</para></li><li><para><c>Minimum</c> -- the minimum value from a single observation during the time period
        /// represented by that data point.</para></li><li><para><c>Maximum</c> -- the maximum value from a single observation during the time period
        /// represented by that data point.</para></li><li><para><c>Average</c> -- the average value from all contributors during the time period
        /// represented by that data point.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public System.String[] Metric { get; set; }
        #endregion
        
        #region Parameter OrderBy
        /// <summary>
        /// <para>
        /// <para>Determines what statistic to use to rank the contributors. Valid values are <c>Sum</c>
        /// and <c>Maximum</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrderBy { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The period, in seconds, to use for the statistics in the <c>InsightRuleMetricDatapoint</c>
        /// results.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the rule that you want to see data from.</para>
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
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the data to use in the report. When used in a raw HTTP Query API,
        /// it is formatted as <c>yyyy-MM-dd'T'HH:mm:ss</c>. For example, <c>2019-07-01T23:59:59</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.GetInsightRuleReportResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.GetInsightRuleReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.GetInsightRuleReportResponse, GetCWInsightRuleReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxContributorCount = this.MaxContributorCount;
            if (this.Metric != null)
            {
                context.Metric = new List<System.String>(this.Metric);
            }
            context.OrderBy = this.OrderBy;
            context.Period = this.Period;
            #if MODULAR
            if (this.Period == null && ParameterWasBound(nameof(this.Period)))
            {
                WriteWarning("You are passing $null as a value for parameter Period which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleName = this.RuleName;
            #if MODULAR
            if (this.RuleName == null && ParameterWasBound(nameof(this.RuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.GetInsightRuleReportRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxContributorCount != null)
            {
                request.MaxContributorCount = cmdletContext.MaxContributorCount.Value;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            if (cmdletContext.OrderBy != null)
            {
                request.OrderBy = cmdletContext.OrderBy;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.CloudWatch.Model.GetInsightRuleReportResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetInsightRuleReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetInsightRuleReport");
            try
            {
                #if DESKTOP
                return client.GetInsightRuleReport(request);
                #elif CORECLR
                return client.GetInsightRuleReportAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.Int32? MaxContributorCount { get; set; }
            public List<System.String> Metric { get; set; }
            public System.String OrderBy { get; set; }
            public System.Int32? Period { get; set; }
            public System.String RuleName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CloudWatch.Model.GetInsightRuleReportResponse, GetCWInsightRuleReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
