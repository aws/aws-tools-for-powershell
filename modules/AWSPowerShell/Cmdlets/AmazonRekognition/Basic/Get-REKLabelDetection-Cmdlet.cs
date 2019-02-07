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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Gets the label detection results of a Amazon Rekognition Video analysis started by
    /// <a>StartLabelDetection</a>. 
    /// 
    ///  
    /// <para>
    /// The label detection operation is started by a call to <a>StartLabelDetection</a> which
    /// returns a job identifier (<code>JobId</code>). When the label detection operation
    /// finishes, Amazon Rekognition publishes a completion status to the Amazon Simple Notification
    /// Service topic registered in the initial call to <code>StartlabelDetection</code>.
    /// To get the results of the label detection operation, first check that the status value
    /// published to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call <a>GetLabelDetection</a>
    /// and pass the job identifier (<code>JobId</code>) from the initial call to <code>StartLabelDetection</code>.
    /// </para><para><code>GetLabelDetection</code> returns an array of detected labels (<code>Labels</code>)
    /// sorted by the time the labels were detected. You can also sort by the label name by
    /// specifying <code>NAME</code> for the <code>SortBy</code> input parameter.
    /// </para><para>
    /// The labels returned include the label name, the percentage confidence in the accuracy
    /// of the detected label, and the time the label was detected in the video.
    /// </para><para>
    /// The returned labels also include bounding box information for common objects, a hierarchical
    /// taxonomy of detected labels, and the version of the label model used for detection.
    /// </para><para>
    /// Use MaxResults parameter to limit the number of labels returned. If there are more
    /// results than specified in <code>MaxResults</code>, the value of <code>NextToken</code>
    /// in the operation response contains a pagination token for getting the next set of
    /// results. To get the next page of results, call <code>GetlabelDetection</code> and
    /// populate the <code>NextToken</code> request parameter with the token value returned
    /// from the previous call to <code>GetLabelDetection</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "REKLabelDetection")]
    [OutputType("Amazon.Rekognition.Model.GetLabelDetectionResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetLabelDetection API operation.", Operation = new[] {"GetLabelDetection"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetLabelDetectionResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.GetLabelDetectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKLabelDetectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>Job identifier for the label detection operation for which you want results returned.
        /// You get the job identifer from an initial call to <code>StartlabelDetection</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort to use for elements in the <code>Labels</code> array. Use <code>TIMESTAMP</code>
        /// to sort array elements by the time labels are detected. Use <code>NAME</code> to alphabetically
        /// group elements for a label together. Within each label group, the array element are
        /// sorted by detection confidence. The default sort is by <code>TIMESTAMP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Rekognition.LabelDetectionSortBy")]
        public Amazon.Rekognition.LabelDetectionSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return per paginated call. The largest value you can
        /// specify is 1000. If you specify a value greater than 1000, a maximum of 1000 results
        /// is returned. The default value is 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there are more labels to retrieve),
        /// Amazon Rekognition Video returns a pagination token in the response. You can use this
        /// pagination token to retrieve the next set of labels. </para>
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
            var request = new Amazon.Rekognition.Model.GetLabelDetectionRequest();
            
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
        
        private Amazon.Rekognition.Model.GetLabelDetectionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetLabelDetectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetLabelDetection");
            try
            {
                #if DESKTOP
                return client.GetLabelDetection(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetLabelDetectionAsync(request);
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
            public Amazon.Rekognition.LabelDetectionSortBy SortBy { get; set; }
        }
        
    }
}
