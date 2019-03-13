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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// Gets detailed information about a specified number of requests--a sample--that AWS
    /// WAF randomly selects from among the first 5,000 requests that your AWS resource received
    /// during a time range that you choose. You can specify a sample size of up to 500 requests,
    /// and you can specify any time range in the previous three hours.
    /// 
    ///  
    /// <para><code>GetSampledRequests</code> returns a time range, which is usually the time range
    /// that you specified. However, if your resource (such as a CloudFront distribution)
    /// received 5,000 requests before the specified time range elapsed, <code>GetSampledRequests</code>
    /// returns an updated time range. This new time range indicates the actual period during
    /// which AWS WAF selected the requests in the sample.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAFRSampledRequestList")]
    [OutputType("Amazon.WAFRegional.Model.GetSampledRequestsResponse")]
    [AWSCmdlet("Calls the AWS WAF Regional GetSampledRequests API operation.", Operation = new[] {"GetSampledRequests"})]
    [AWSCmdletOutput("Amazon.WAFRegional.Model.GetSampledRequestsResponse",
        "This cmdlet returns a Amazon.WAFRegional.Model.GetSampledRequestsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWAFRSampledRequestListCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range from which you want <code>GetSampledRequests</code> to return
        /// a sample of the requests that your AWS resource received. Specify the date and time
        /// in the following format: <code>"2016-09-27T14:50Z"</code>. You can specify any time
        /// range in the previous three hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime TimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para><code>RuleId</code> is one of three values:</para><ul><li><para>The <code>RuleId</code> of the <code>Rule</code> or the <code>RuleGroupId</code> of
        /// the <code>RuleGroup</code> for which you want <code>GetSampledRequests</code> to return
        /// a sample of requests.</para></li><li><para><code>Default_Action</code>, which causes <code>GetSampledRequests</code> to return
        /// a sample of the requests that didn't match any of the rules in the specified <code>WebACL</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RuleId { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range from which you want <code>GetSampledRequests</code>
        /// to return a sample of the requests that your AWS resource received. Specify the date
        /// and time in the following format: <code>"2016-09-27T14:50Z"</code>. You can specify
        /// any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime TimeWindow_StartTime { get; set; }
        #endregion
        
        #region Parameter WebAclId
        /// <summary>
        /// <para>
        /// <para>The <code>WebACLId</code> of the <code>WebACL</code> for which you want <code>GetSampledRequests</code>
        /// to return a sample of requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String WebAclId { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The number of requests that you want AWS WAF to return from among the first 5,000
        /// requests that your AWS resource received during the time range. If your resource received
        /// fewer requests than the value of <code>MaxItems</code>, <code>GetSampledRequests</code>
        /// returns information about all of them. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int64 MaxItem { get; set; }
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
            
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.RuleId = this.RuleId;
            if (ParameterWasBound("TimeWindow_EndTime"))
                context.TimeWindow_EndTime = this.TimeWindow_EndTime;
            if (ParameterWasBound("TimeWindow_StartTime"))
                context.TimeWindow_StartTime = this.TimeWindow_StartTime;
            context.WebAclId = this.WebAclId;
            
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
            var request = new Amazon.WAFRegional.Model.GetSampledRequestsRequest();
            
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems.Value;
            }
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
            }
            
             // populate TimeWindow
            bool requestTimeWindowIsNull = true;
            request.TimeWindow = new Amazon.WAFRegional.Model.TimeWindow();
            System.DateTime? requestTimeWindow_timeWindow_EndTime = null;
            if (cmdletContext.TimeWindow_EndTime != null)
            {
                requestTimeWindow_timeWindow_EndTime = cmdletContext.TimeWindow_EndTime.Value;
            }
            if (requestTimeWindow_timeWindow_EndTime != null)
            {
                request.TimeWindow.EndTime = requestTimeWindow_timeWindow_EndTime.Value;
                requestTimeWindowIsNull = false;
            }
            System.DateTime? requestTimeWindow_timeWindow_StartTime = null;
            if (cmdletContext.TimeWindow_StartTime != null)
            {
                requestTimeWindow_timeWindow_StartTime = cmdletContext.TimeWindow_StartTime.Value;
            }
            if (requestTimeWindow_timeWindow_StartTime != null)
            {
                request.TimeWindow.StartTime = requestTimeWindow_timeWindow_StartTime.Value;
                requestTimeWindowIsNull = false;
            }
             // determine if request.TimeWindow should be set to null
            if (requestTimeWindowIsNull)
            {
                request.TimeWindow = null;
            }
            if (cmdletContext.WebAclId != null)
            {
                request.WebAclId = cmdletContext.WebAclId;
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
        
        private Amazon.WAFRegional.Model.GetSampledRequestsResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.GetSampledRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "GetSampledRequests");
            try
            {
                #if DESKTOP
                return client.GetSampledRequests(request);
                #elif CORECLR
                return client.GetSampledRequestsAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? MaxItems { get; set; }
            public System.String RuleId { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.String WebAclId { get; set; }
        }
        
    }
}
