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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Retrieves IDs and metadata for traces available for a specified time frame using an
    /// optional filter. To get the full traces, pass the trace IDs to <code>BatchGetTraces</code>.
    /// 
    ///  
    /// <para>
    /// A filter expression can target traced requests that hit specific service nodes or
    /// edges, have errors, or come from a known user. For example, the following filter expression
    /// targets traces that pass through <code>api.example.com</code>:
    /// </para><para><code>service("api.example.com")</code></para><para>
    /// This filter expression finds traces that have an annotation named <code>account</code>
    /// with the value <code>12345</code>:
    /// </para><para><code>annotation.account = "12345"</code></para><para>
    /// For a full list of indexed fields and keywords that you can use in filter expressions,
    /// see <a href="http://docs.aws.amazon.com/xray/latest/devguide/xray-console-filters.html">Using
    /// Filter Expressions</a> in the <i>AWS X-Ray Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "XRTraceSummary")]
    [OutputType("Amazon.XRay.Model.GetTraceSummariesResponse")]
    [AWSCmdlet("Calls the AWS X-Ray GetTraceSummaries API operation.", Operation = new[] {"GetTraceSummaries"})]
    [AWSCmdletOutput("Amazon.XRay.Model.GetTraceSummariesResponse",
        "This cmdlet returns a Amazon.XRay.Model.GetTraceSummariesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetXRTraceSummaryCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time frame for which to retrieve traces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>Specify a filter expression to retrieve trace summaries for services or requests that
        /// meet certain requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter Sampling
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to get summaries for only a subset of available traces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Sampling { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time frame for which to retrieve traces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token returned by a previous request to retrieve the next page
        /// of results.</para>
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
            context.FilterExpression = this.FilterExpression;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("Sampling"))
                context.Sampling = this.Sampling;
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
            var request = new Amazon.XRay.Model.GetTraceSummariesRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Sampling != null)
            {
                request.Sampling = cmdletContext.Sampling.Value;
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
        
        private Amazon.XRay.Model.GetTraceSummariesResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.GetTraceSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "GetTraceSummaries");
            try
            {
                #if DESKTOP
                return client.GetTraceSummaries(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetTraceSummariesAsync(request);
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
            public System.DateTime? EndTime { get; set; }
            public System.String FilterExpression { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? Sampling { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
