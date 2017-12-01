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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Gets the content moderation analysis results for a Rekognition Video analysis started
    /// by .
    /// 
    ///  
    /// <para>
    /// Content moderation analysis of a video is an asynchronous operation. You start analysis
    /// by calling . which returns a job identifier (<code>JobId</code>). When analysis finishes,
    /// Rekognition Video publishes a completion status to the Amazon Simple Notification
    /// Service topic registered in the initial call to <code>StartContentModeration</code>.
    /// To get the results of the content moderation analysis, first check that the status
    /// value published to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call <code>GetCelebrityDetection</code>
    /// and pass the job identifier (<code>JobId</code>) from the initial call to <code>StartCelebrityDetection</code>.
    /// For more information, see <a>video</a>. 
    /// </para><para><code>GetContentModeration</code> returns detected content moderation labels, and
    /// the time they are detected, in an array, <code>ModerationLabels</code>, of objects.
    /// 
    /// </para><para>
    /// By default, the moderated labels are returned sorted by time, in milliseconds from
    /// the start of the video. You can also sort them by moderated label by specifying <code>NAME</code>
    /// for the <code>SortBy</code> input parameter. 
    /// </para><para>
    /// Since video analysis can return a large number of results, use the <code>MaxResults</code>
    /// parameter to limit the number of labels returned in a single call to <code>GetContentModeration</code>.
    /// If there are more results than specified in <code>MaxResults</code>, the value of
    /// <code>NextToken</code> in the operation response contains a pagination token for getting
    /// the next set of results. To get the next page of results, call <code>GetContentModeration</code>
    /// and populate the <code>NextToken</code> request parameter with the value of <code>NextToken</code>
    /// returned from the previous call to <code>GetContentModeration</code>.
    /// </para><para>
    /// For more information, see <a>moderation</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "REKContentModeration")]
    [OutputType("Amazon.Rekognition.Model.GetContentModerationResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetContentModeration API operation.", Operation = new[] {"GetContentModeration"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetContentModerationResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.GetContentModerationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKContentModerationCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The identifier for the content moderation job. Use <code>JobId</code> to identify
        /// the job in a subsequent call to <code>GetContentModeration</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort to use for elements in the <code>ModerationLabelDetections</code> array. Use
        /// <code>TIMESTAMP</code> to sort array elements by the time labels are detected. Use
        /// <code>NAME</code> to alphabetically group elements for a label together. Within each
        /// label group, the array element are sorted by detection confidence. The default sort
        /// is by <code>TIMESTAMP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Rekognition.ContentModerationSortBy")]
        public Amazon.Rekognition.ContentModerationSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of content moderation labels to return. The default is 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there is more data to retrieve),
        /// Amazon Rekognition returns a pagination token in the response. You can use this pagination
        /// token to retrieve the next set of content moderation labels.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
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
            
            context.JobId = this.JobId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            
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
            var request = new Amazon.Rekognition.Model.GetContentModerationRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
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
        
        private Amazon.Rekognition.Model.GetContentModerationResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetContentModerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetContentModeration");
            try
            {
                #if DESKTOP
                return client.GetContentModeration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetContentModerationAsync(request);
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
            public System.String JobId { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Rekognition.ContentModerationSortBy SortBy { get; set; }
        }
        
    }
}
