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
    /// Retrieves the reservation coverage for your account. This enables you to see how much
    /// of your Amazon Elastic Compute Cloud, Amazon ElastiCache, Amazon Relational Database
    /// Service, or Amazon Redshift usage is covered by a reservation. An organization's master
    /// account can see the coverage of the associated member accounts. For any time period,
    /// you can filter data about reservation usage by the following dimensions:
    /// 
    ///  <ul><li><para>
    /// AZ
    /// </para></li><li><para>
    /// CACHE_ENGINE
    /// </para></li><li><para>
    /// DATABASE_ENGINE
    /// </para></li><li><para>
    /// DEPLOYMENT_OPTION
    /// </para></li><li><para>
    /// INSTANCE_TYPE
    /// </para></li><li><para>
    /// LINKED_ACCOUNT
    /// </para></li><li><para>
    /// OPERATING_SYSTEM
    /// </para></li><li><para>
    /// PLATFORM
    /// </para></li><li><para>
    /// REGION
    /// </para></li><li><para>
    /// SERVICE
    /// </para></li><li><para>
    /// TAG
    /// </para></li><li><para>
    /// TENANCY
    /// </para></li></ul><para>
    /// To determine valid values for a dimension, use the <code>GetDimensionValues</code>
    /// operation. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CEReservationCoverage")]
    [OutputType("Amazon.CostExplorer.Model.GetReservationCoverageResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetReservationCoverage API operation.", Operation = new[] {"GetReservationCoverage"})]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetReservationCoverageResponse",
        "This cmdlet returns a Amazon.CostExplorer.Model.GetReservationCoverageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEReservationCoverageCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters utilization data by dimensions. You can filter by the following dimensions:</para><ul><li><para>AZ</para></li><li><para>CACHE_ENGINE</para></li><li><para>DATABASE_ENGINE</para></li><li><para>DEPLOYMENT_OPTION</para></li><li><para>INSTANCE_TYPE</para></li><li><para>LINKED_ACCOUNT</para></li><li><para>OPERATING_SYSTEM</para></li><li><para>PLATFORM</para></li><li><para>REGION</para></li><li><para>SERVICE</para></li><li><para>TAG</para></li><li><para>TENANCY</para></li></ul><para><code>GetReservationCoverage</code> uses the same <a href="http://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>
        /// object as the other operations, but only <code>AND</code> is supported among each
        /// dimension. You can nest only one level deep. If there are multiple values for a dimension,
        /// they are OR'd together.</para><para>If you don't provide a <code>SERVICE</code> filter, Cost Explorer defaults to EC2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The granularity of the AWS cost data for the reservation. Valid values are <code>MONTHLY</code>
        /// and <code>DAILY</code>.</para><para>If <code>GroupBy</code> is set, <code>Granularity</code> can't be set. If <code>Granularity</code>
        /// isn't set, the response object doesn't include <code>Granularity</code>, either <code>MONTHLY</code>
        /// or <code>DAILY</code>.</para><para>The <code>GetReservationCoverage</code> operation supports only <code>DAILY</code>
        /// and <code>MONTHLY</code> granularities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>You can group the data by the following attributes:</para><ul><li><para>AZ</para></li><li><para>CACHE_ENGINE</para></li><li><para>DATABASE_ENGINE</para></li><li><para>DEPLOYMENT_OPTION</para></li><li><para>INSTANCE_TYPE</para></li><li><para>LINKED_ACCOUNT</para></li><li><para>OPERATING_SYSTEM</para></li><li><para>PLATFORM</para></li><li><para>REGION</para></li><li><para>TAG</para></li><li><para>TENANCY</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CostExplorer.Model.GroupDefinition[] GroupBy { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Metrics")]
        public System.String[] Metric { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>The start and end dates of the period that you want to retrieve data about reservation
        /// coverage for. You can retrieve data for a maximum of 13 months: the last 12 months
        /// and the current month. The start date is inclusive, but the end date is exclusive.
        /// For example, if <code>start</code> is <code>2017-01-01</code> and <code>end</code>
        /// is <code>2017-05-01</code>, then the cost and usage data is retrieved from <code>2017-01-01</code>
        /// up to and including <code>2017-04-30</code> but not including <code>2017-05-01</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. AWS provides the token when the response
        /// from a previous call has more results than the maximum page size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextPageToken { get; set; }
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
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<Amazon.CostExplorer.Model.GroupDefinition>(this.GroupBy);
            }
            if (this.Metric != null)
            {
                context.Metrics = new List<System.String>(this.Metric);
            }
            context.NextPageToken = this.NextPageToken;
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
            var request = new Amazon.CostExplorer.Model.GetReservationCoverageRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.Metrics != null)
            {
                request.Metrics = cmdletContext.Metrics;
            }
            if (cmdletContext.NextPageToken != null)
            {
                request.NextPageToken = cmdletContext.NextPageToken;
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
        
        private Amazon.CostExplorer.Model.GetReservationCoverageResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetReservationCoverageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetReservationCoverage");
            try
            {
                #if DESKTOP
                return client.GetReservationCoverage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetReservationCoverageAsync(request);
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
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.Granularity Granularity { get; set; }
            public List<Amazon.CostExplorer.Model.GroupDefinition> GroupBy { get; set; }
            public List<System.String> Metrics { get; set; }
            public System.String NextPageToken { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        }
        
    }
}
