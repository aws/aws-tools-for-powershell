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
using Amazon.PI;
using Amazon.PI.Model;

namespace Amazon.PowerShell.Cmdlets.PI
{
    /// <summary>
    /// Retrieve Performance Insights metrics for a set of data sources, over a time period.
    /// You can provide specific dimension groups and dimensions, and provide aggregation
    /// and filtering criteria for each group.
    /// </summary>
    [Cmdlet("Get", "PIResourceMetric")]
    [OutputType("Amazon.PI.Model.GetResourceMetricsResponse")]
    [AWSCmdlet("Calls the AWS Performance Insights GetResourceMetrics API operation.", Operation = new[] {"GetResourceMetrics"})]
    [AWSCmdletOutput("Amazon.PI.Model.GetResourceMetricsResponse",
        "This cmdlet returns a Amazon.PI.Model.GetResourceMetricsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPIResourceMetricCmdlet : AmazonPIClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time specifiying the end of the requested time series data. The value
        /// specified is <i>exclusive</i> - data points less than (but not equal to) <code>EndTime</code>
        /// will be returned.</para><para>The value for <code>EndTime</code> must be later than the value for <code>StartTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An immutable, AWS Region-unique identifier for a data source. Performance Insights
        /// gathers metrics from this data source.</para><para>To use an Amazon RDS instance as a data source, you specify its <code>DbiResourceId</code>
        /// value - for example: <code>db-FAIHNTYBKTGAUSUZQYPDS2GW4A</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter MetricQuery
        /// <summary>
        /// <para>
        /// <para>An array of one or more queries to perform. Each query must specify a Performance
        /// Insights metric, and can optionally specify aggregation and filtering criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MetricQueries")]
        public Amazon.PI.Model.MetricQuery[] MetricQuery { get; set; }
        #endregion
        
        #region Parameter PeriodInSecond
        /// <summary>
        /// <para>
        /// <para>The granularity, in seconds, of the data points returned from Performance Insights.
        /// A period can be as short as one second, or as long as one day (86400 seconds). Valid
        /// values are:</para><ul><li><para><code>1</code> (one second)</para></li><li><para><code>60</code> (one minute)</para></li><li><para><code>300</code> (five minutes)</para></li><li><para><code>3600</code> (one hour)</para></li><li><para><code>86400</code> (twenty-four hours)</para></li></ul><para>If you don't specify <code>PeriodInSeconds</code>, then Performance Insights will
        /// choose a value for you, with a goal of returning roughly 100-200 data points in the
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PeriodInSeconds")]
        public System.Int32 PeriodInSecond { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The AWS service for which Performance Insights will return metrics. The only valid
        /// value for <i>ServiceType</i> is: <code>RDS</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.PI.ServiceType")]
        public Amazon.PI.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time specifying the beginning of the requested time series data. You
        /// can't specify a <code>StartTime</code> that's earlier than 7 days ago. The value specified
        /// is <i>inclusive</i> - data points equal to or greater than <code>StartTime</code>
        /// will be returned.</para><para>The value for <code>StartTime</code> must be earlier than the value for <code>EndTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the response. If more items exist than the
        /// specified <code>MaxRecords</code> value, a pagination token is included in the response
        /// so that the remaining results can be retrieved. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the token, up to the value specified
        /// by <code>MaxRecords</code>.</para>
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.Identifier = this.Identifier;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            if (this.MetricQuery != null)
            {
                context.MetricQueries = new List<Amazon.PI.Model.MetricQuery>(this.MetricQuery);
            }
            context.NextToken = this.NextToken;
            if (ParameterWasBound("PeriodInSecond"))
                context.PeriodInSeconds = this.PeriodInSecond;
            context.ServiceType = this.ServiceType;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
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
            var request = new Amazon.PI.Model.GetResourceMetricsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.MetricQueries != null)
            {
                request.MetricQueries = cmdletContext.MetricQueries;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PeriodInSeconds != null)
            {
                request.PeriodInSeconds = cmdletContext.PeriodInSeconds.Value;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.PI.Model.GetResourceMetricsResponse CallAWSServiceOperation(IAmazonPI client, Amazon.PI.Model.GetResourceMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Performance Insights", "GetResourceMetrics");
            try
            {
                #if DESKTOP
                return client.GetResourceMetrics(request);
                #elif CORECLR
                return client.GetResourceMetricsAsync(request).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.Int32? MaxResults { get; set; }
            public List<Amazon.PI.Model.MetricQuery> MetricQueries { get; set; }
            public System.String NextToken { get; set; }
            public System.Int32? PeriodInSeconds { get; set; }
            public Amazon.PI.ServiceType ServiceType { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
