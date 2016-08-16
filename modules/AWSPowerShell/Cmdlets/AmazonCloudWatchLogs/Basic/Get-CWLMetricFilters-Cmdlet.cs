/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Returns all the metrics filters associated with the specified log group. The list
    /// returned in the response is ASCII-sorted by filter name.
    /// 
    ///  
    /// <para>
    /// By default, this operation returns up to 50 metric filters. If there are more metric
    /// filters to list, the response would contain a <code>nextToken</code> value in the
    /// response body. You can also limit the number of metric filters returned in the response
    /// by specifying the <code>limit</code> parameter in the request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLMetricFilters")]
    [OutputType("Amazon.CloudWatchLogs.Model.MetricFilter")]
    [AWSCmdlet("Invokes the DescribeMetricFilters operation against Amazon CloudWatch Logs.", Operation = new[] {"DescribeMetricFilters"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.MetricFilter",
        "This cmdlet returns a collection of MetricFilter objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeMetricFiltersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCWLMetricFiltersCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter FilterNamePrefix
        /// <summary>
        /// <para>
        /// <para>Will only return metric filters that match the provided filterNamePrefix. If you don't
        /// specify a value, no prefix filter is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilterNamePrefix { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group name for which metric filters are to be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items returned in the response. If you don't specify a value,
        /// the request would return up to 50 items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A string token used for pagination that points to the next page of results. It must
        /// be a value obtained from the response of the previous <code>DescribeMetricFilters</code>
        /// request.</para>
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
            
            context.FilterNamePrefix = this.FilterNamePrefix;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupName = this.LogGroupName;
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
            var request = new Amazon.CloudWatchLogs.Model.DescribeMetricFiltersRequest();
            
            if (cmdletContext.FilterNamePrefix != null)
            {
                request.FilterNamePrefix = cmdletContext.FilterNamePrefix;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
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
                object pipelineOutput = response.MetricFilters;
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
        
        private static Amazon.CloudWatchLogs.Model.DescribeMetricFiltersResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeMetricFiltersRequest request)
        {
            #if DESKTOP
            return client.DescribeMetricFilters(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeMetricFiltersAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FilterNamePrefix { get; set; }
            public int? Limit { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
