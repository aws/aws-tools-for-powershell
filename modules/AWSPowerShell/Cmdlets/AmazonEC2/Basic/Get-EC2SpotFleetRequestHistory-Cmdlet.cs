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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the events for the specified Spot fleet request during the specified time.
    /// 
    ///  
    /// <para>
    /// Spot fleet events are delayed by up to 30 seconds before they can be described. This
    /// ensures that you can query by the last evaluated time and not miss a recorded event.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2SpotFleetRequestHistory")]
    [OutputType("Amazon.EC2.Model.DescribeSpotFleetRequestHistoryResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeSpotFleetRequestHistory API operation.", Operation = new[] {"DescribeSpotFleetRequestHistory"})]
    [AWSCmdletOutput("Amazon.EC2.Model.DescribeSpotFleetRequestHistoryResponse",
        "This cmdlet returns a Amazon.EC2.Model.DescribeSpotFleetRequestHistoryResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2SpotFleetRequestHistoryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter EventType
        /// <summary>
        /// <para>
        /// <para>The type of events to describe. By default, all events are described.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.EventType")]
        public Amazon.EC2.EventType EventType { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The starting date and time for the events, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. Specify a value between
        /// 1 and 1000. The default value is 1000. To retrieve the remaining results, make another
        /// call with the returned <code>NextToken</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestId
        /// <summary>
        /// <para>
        /// <para>The ID of the Spot fleet request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SpotFleetRequestId { get; set; }
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
            
            context.EventType = this.EventType;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SpotFleetRequestId = this.SpotFleetRequestId;
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
            var request = new Amazon.EC2.Model.DescribeSpotFleetRequestHistoryRequest();
            
            if (cmdletContext.EventType != null)
            {
                request.EventType = cmdletContext.EventType;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SpotFleetRequestId != null)
            {
                request.SpotFleetRequestId = cmdletContext.SpotFleetRequestId;
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
        
        private Amazon.EC2.Model.DescribeSpotFleetRequestHistoryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSpotFleetRequestHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeSpotFleetRequestHistory");
            try
            {
                #if DESKTOP
                return client.DescribeSpotFleetRequestHistory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeSpotFleetRequestHistoryAsync(request);
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
            public Amazon.EC2.EventType EventType { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String SpotFleetRequestId { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
