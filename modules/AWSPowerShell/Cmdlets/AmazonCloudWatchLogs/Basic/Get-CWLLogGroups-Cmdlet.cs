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
    /// Returns all the log groups that are associated with the AWS account making the request.
    /// The list returned in the response is ASCII-sorted by log group name.
    /// 
    ///  
    /// <para>
    /// By default, this operation returns up to 50 log groups. If there are more log groups
    /// to list, the response would contain a <code>nextToken</code> value in the response
    /// body. You can also limit the number of log groups returned in the response by specifying
    /// the <code>limit</code> parameter in the request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLLogGroups")]
    [OutputType("Amazon.CloudWatchLogs.Model.LogGroup")]
    [AWSCmdlet("Invokes the DescribeLogGroups operation against Amazon CloudWatch Logs.", Operation = new[] {"DescribeLogGroups"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.LogGroup",
        "This cmdlet returns a collection of LogGroup objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCWLLogGroupsCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter LogGroupNamePrefix
        /// <summary>
        /// <para>
        /// <para>Will only return log groups that match the provided logGroupNamePrefix. If you don't
        /// specify a value, no prefix filter is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String LogGroupNamePrefix { get; set; }
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
        /// be a value obtained from the response of the previous <code>DescribeLogGroups</code>
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
            
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupNamePrefix = this.LogGroupNamePrefix;
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchLogs.Model.DescribeLogGroupsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LogGroupNamePrefix != null)
            {
                request.LogGroupNamePrefix = cmdletContext.LogGroupNamePrefix;
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
                object pipelineOutput = response.LogGroups;
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
        
        private static Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeLogGroupsRequest request)
        {
            return client.DescribeLogGroups(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public int? Limit { get; set; }
            public System.String LogGroupNamePrefix { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
