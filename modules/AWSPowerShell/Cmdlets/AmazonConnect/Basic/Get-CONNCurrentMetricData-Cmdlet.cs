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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// The <code>GetCurrentMetricData</code> operation retrieves current metric data from
    /// your Amazon Connect instance.
    /// 
    ///  
    /// <para>
    /// If you are using an IAM account, it must have permission to the <code>connect:GetCurrentMetricData</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CONNCurrentMetricData")]
    [OutputType("Amazon.Connect.Model.GetCurrentMetricDataResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service GetCurrentMetricData API operation.", Operation = new[] {"GetCurrentMetricData"})]
    [AWSCmdletOutput("Amazon.Connect.Model.GetCurrentMetricDataResponse",
        "This cmdlet returns a Amazon.Connect.Model.GetCurrentMetricDataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCONNCurrentMetricDataCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_Channel
        /// <summary>
        /// <para>
        /// <para>The Channel to use as a filter for the metrics returned. Only VOICE is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters_Channels")]
        public System.String[] Filters_Channel { get; set; }
        #endregion
        
        #region Parameter CurrentMetric
        /// <summary>
        /// <para>
        /// <para>A list of <code>CurrentMetric</code> objects for the metrics to retrieve. Each <code>CurrentMetric</code>
        /// includes a name of a metric to retrieve and the unit to use for it. You must list
        /// each metric to retrieve data for in the request.</para><para>The following metrics are available:</para><dl><dt>AGENTS_AVAILABLE</dt><dd><para>Unit: COUNT</para></dd><dt>AGENTS_ONLINE</dt><dd><para>Unit: COUNT</para></dd><dt>AGENTS_ON_CALL</dt><dd><para>Unit: COUNT</para></dd><dt>AGENTS_STAFFED</dt><dd><para>Unit: COUNT</para></dd><dt>AGENTS_AFTER_CONTACT_WORK</dt><dd><para>Unit: COUNT</para></dd><dt>AGENTS_NON_PRODUCTIVE</dt><dd><para>Unit: COUNT</para></dd><dt>AGENTS_ERROR</dt><dd><para>Unit: COUNT</para></dd><dt>CONTACTS_IN_QUEUE</dt><dd><para>Unit: COUNT</para></dd><dt>OLDEST_CONTACT_AGE</dt><dd><para>Unit: SECONDS</para></dd><dt>CONTACTS_SCHEDULED</dt><dd><para>Unit: COUNT</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CurrentMetrics")]
        public Amazon.Connect.Model.CurrentMetric[] CurrentMetric { get; set; }
        #endregion
        
        #region Parameter Grouping
        /// <summary>
        /// <para>
        /// <para>The grouping applied to the metrics returned. For example, when grouped by QUEUE,
        /// the metrics returned apply to each queue rather than aggregated for all queues. If
        /// you group by CHANNEL, you should include a Channels filter. The only supported channel
        /// is VOICE.</para><para>If no <code>Grouping</code> is included in the request, a summary of <code>CurrentMetrics</code>
        /// is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Groupings")]
        public System.String[] Grouping { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier for your Amazon Connect instance. To find the ID of your instance,
        /// open the AWS console and select Amazon Connect. Select the alias of the instance in
        /// the Instance alias column. The instance ID is displayed in the Overview section of
        /// your instance settings. For example, the instance ID is the set of characters at the
        /// end of the instance ARN, after instance/, such as 10a4c4eb-f57e-4d4c-b602-bf39176ced07.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Filters_Queue
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 queue IDs or queue ARNs to use to filter the metrics retrieved.
        /// You can include both IDs and ARNs in a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters_Queues")]
        public System.String[] Filters_Queue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para><code>MaxResults</code> indicates the maximum number of results to return per page
        /// in the response, between 1 and 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para><para>The token expires after 5 minutes from the time it is created. Subsequent requests
        /// that use the <a href="">NextToken</a> must use the same request parameters as the
        /// request that generated the token.</para>
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
            
            if (this.CurrentMetric != null)
            {
                context.CurrentMetrics = new List<Amazon.Connect.Model.CurrentMetric>(this.CurrentMetric);
            }
            if (this.Filters_Channel != null)
            {
                context.Filters_Channels = new List<System.String>(this.Filters_Channel);
            }
            if (this.Filters_Queue != null)
            {
                context.Filters_Queues = new List<System.String>(this.Filters_Queue);
            }
            if (this.Grouping != null)
            {
                context.Groupings = new List<System.String>(this.Grouping);
            }
            context.InstanceId = this.InstanceId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            // create request
            var request = new Amazon.Connect.Model.GetCurrentMetricDataRequest();
            
            if (cmdletContext.CurrentMetrics != null)
            {
                request.CurrentMetrics = cmdletContext.CurrentMetrics;
            }
            
             // populate Filters
            bool requestFiltersIsNull = true;
            request.Filters = new Amazon.Connect.Model.Filters();
            List<System.String> requestFilters_filters_Channel = null;
            if (cmdletContext.Filters_Channels != null)
            {
                requestFilters_filters_Channel = cmdletContext.Filters_Channels;
            }
            if (requestFilters_filters_Channel != null)
            {
                request.Filters.Channels = requestFilters_filters_Channel;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Queue = null;
            if (cmdletContext.Filters_Queues != null)
            {
                requestFilters_filters_Queue = cmdletContext.Filters_Queues;
            }
            if (requestFilters_filters_Queue != null)
            {
                request.Filters.Queues = requestFilters_filters_Queue;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Groupings != null)
            {
                request.Groupings = cmdletContext.Groupings;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Connect.Model.GetCurrentMetricDataResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.GetCurrentMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "GetCurrentMetricData");
            try
            {
                #if DESKTOP
                return client.GetCurrentMetricData(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetCurrentMetricDataAsync(request);
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
            public List<Amazon.Connect.Model.CurrentMetric> CurrentMetrics { get; set; }
            public List<System.String> Filters_Channels { get; set; }
            public List<System.String> Filters_Queues { get; set; }
            public List<System.String> Groupings { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
