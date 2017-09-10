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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Lists the configurations for DNS query logging that are associated with the current
    /// AWS account or the configuration that is associated with a specified hosted zone.
    /// 
    ///  
    /// <para>
    /// For more information about DNS query logs, see <a>CreateQueryLoggingConfig</a>. Additional
    /// information, including the format of DNS query logs, appears in <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/query-logs.html">Logging
    /// DNS Queries</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53QueryLoggingConfigList")]
    [OutputType("Amazon.Route53.Model.QueryLoggingConfig")]
    [AWSCmdlet("Invokes the ListQueryLoggingConfigs operation against Amazon Route 53.", Operation = new[] {"ListQueryLoggingConfigs"})]
    [AWSCmdletOutput("Amazon.Route53.Model.QueryLoggingConfig",
        "This cmdlet returns a collection of QueryLoggingConfig objects.",
        "The service call response (type Amazon.Route53.Model.ListQueryLoggingConfigsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetR53QueryLoggingConfigListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>(Optional) If you want to list the query logging configuration that is associated
        /// with a hosted zone, specify the ID in <code>HostedZoneId</code>. </para><para>If you don't specify a hosted zone ID, <code>ListQueryLoggingConfigs</code> returns
        /// all of the configurations that are associated with the current AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of query logging configurations that you want Amazon
        /// Route 53 to return in response to the current request. If the current AWS account
        /// has more than <code>MaxResults</code> configurations, use the value of <a>ListQueryLoggingConfigsResponse$NextToken</a>
        /// in the response to get the next page of results.</para><para>If you don't specify a value for <code>MaxResults</code>, Amazon Route 53 returns
        /// up to 100 configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.String MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>(Optional) If the current AWS account has more than <code>MaxResults</code> query
        /// logging configurations, use <code>NextToken</code> to get the second and subsequent
        /// pages of results.</para><para>For the first <code>ListQueryLoggingConfigs</code> request, omit this value.</para><para>For the second and subsequent requests, get the value of <code>NextToken</code> from
        /// the previous response and specify that value for <code>NextToken</code> in the request.</para>
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
            
            context.HostedZoneId = this.HostedZoneId;
            context.NextToken = this.NextToken;
            context.MaxResults = this.MaxResult;
            
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
            var request = new Amazon.Route53.Model.ListQueryLoggingConfigsRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.QueryLoggingConfigs;
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
        
        private Amazon.Route53.Model.ListQueryLoggingConfigsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListQueryLoggingConfigsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListQueryLoggingConfigs");
            try
            {
                #if DESKTOP
                return client.ListQueryLoggingConfigs(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListQueryLoggingConfigsAsync(request);
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
            public System.String HostedZoneId { get; set; }
            public System.String NextToken { get; set; }
            public System.String MaxResults { get; set; }
        }
        
    }
}
