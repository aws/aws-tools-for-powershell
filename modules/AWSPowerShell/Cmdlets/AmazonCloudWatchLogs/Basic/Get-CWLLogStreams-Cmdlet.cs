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
    /// Returns all the log streams that are associated with the specified log group. The
    /// list returned in the response is ASCII-sorted by log stream name. 
    /// 
    ///  
    /// <para>
    ///  By default, this operation returns up to 50 log streams. If there are more log streams
    /// to list, the response would contain a <code class="code">nextToken</code> value in
    /// the response body. You can also limit the number of log streams returned in the response
    /// by specifying the <code class="code">limit</code> parameter in the request. This operation
    /// has a limit of five transactions per second, after which transactions are throttled.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLLogStreams")]
    [OutputType("Amazon.CloudWatchLogs.Model.LogStream")]
    [AWSCmdlet("Invokes the DescribeLogStreams operation against Amazon CloudWatch Logs.", Operation = new[] {"DescribeLogStreams"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.LogStream",
        "This cmdlet returns a collection of LogStream objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeLogStreamsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCWLLogStreamsCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter Descending
        /// <summary>
        /// <para>
        /// <para> If set to true, results are returned in descending order. If you don't specify a
        /// value or set it to false, results are returned in ascending order. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Descending { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group name for which log streams are to be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para> Will only return log streams that match the provided logStreamNamePrefix. If you
        /// don't specify a value, no prefix filter is applied. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter OrderBy
        /// <summary>
        /// <para>
        /// <para> Specifies what to order the returned log streams by. Valid arguments are 'LogStreamName'
        /// or 'LastEventTime'. If you don't specify a value, results are ordered by LogStreamName.
        /// If 'LastEventTime' is chosen, the request cannot also contain a logStreamNamePrefix.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.OrderBy")]
        public Amazon.CloudWatchLogs.OrderBy OrderBy { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para> The maximum number of items returned in the response. If you don't specify a value,
        /// the request would return up to 50 items. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A string token used for pagination that points to the next page of results. It must
        /// be a value obtained from the response of the previous <code class="code">DescribeLogStreams</code>
        /// request. </para>
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
            
            if (ParameterWasBound("Descending"))
                context.Descending = this.Descending;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupName = this.LogGroupName;
            context.LogStreamNamePrefix = this.LogStreamNamePrefix;
            context.NextToken = this.NextToken;
            context.OrderBy = this.OrderBy;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchLogs.Model.DescribeLogStreamsRequest();
            
            if (cmdletContext.Descending != null)
            {
                request.Descending = cmdletContext.Descending.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamNamePrefix != null)
            {
                request.LogStreamNamePrefix = cmdletContext.LogStreamNamePrefix;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.OrderBy != null)
            {
                request.OrderBy = cmdletContext.OrderBy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LogStreams;
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
        
        private static Amazon.CloudWatchLogs.Model.DescribeLogStreamsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeLogStreamsRequest request)
        {
            return client.DescribeLogStreams(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? Descending { get; set; }
            public int? Limit { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamNamePrefix { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CloudWatchLogs.OrderBy OrderBy { get; set; }
        }
        
    }
}
