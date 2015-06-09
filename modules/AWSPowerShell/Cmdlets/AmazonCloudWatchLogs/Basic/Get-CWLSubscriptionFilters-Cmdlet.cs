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
    /// Returns all the subscription filters associated with the specified log group. The
    /// list returned in the response is ASCII-sorted by filter name. 
    /// 
    ///  
    /// <para>
    ///  By default, this operation returns up to 50 subscription filters. If there are more
    /// subscription filters to list, the response would contain a <code class="code">nextToken</code>
    /// value in the response body. You can also limit the number of subscription filters
    /// returned in the response by specifying the <code class="code">limit</code> parameter
    /// in the request. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLSubscriptionFilters")]
    [OutputType("Amazon.CloudWatchLogs.Model.SubscriptionFilter")]
    [AWSCmdlet("Invokes the DescribeSubscriptionFilters operation against Amazon CloudWatch Logs.", Operation = new[] {"DescribeSubscriptionFilters"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.SubscriptionFilter",
        "This cmdlet returns a collection of SubscriptionFilter objects.",
        "The service call response (type DescribeSubscriptionFiltersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCWLSubscriptionFiltersCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Will only return subscription filters that match the provided filterNamePrefix. If
        /// you don't specify a value, no prefix filter is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String FilterNamePrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The log group name for which subscription filters are to be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String LogGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.FilterNamePrefix = this.FilterNamePrefix;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupName = this.LogGroupName;
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeSubscriptionFiltersRequest();
            
            if (cmdletContext.FilterNamePrefix != null)
            {
                request.FilterNamePrefix = cmdletContext.FilterNamePrefix;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
                var response = client.DescribeSubscriptionFilters(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SubscriptionFilters;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String FilterNamePrefix { get; set; }
            public Int32? Limit { get; set; }
            public String LogGroupName { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
