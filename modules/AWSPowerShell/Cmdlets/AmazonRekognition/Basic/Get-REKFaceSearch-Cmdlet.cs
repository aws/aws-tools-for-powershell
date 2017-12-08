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
    /// Gets the face search results for Rekognition Video face search started by . The search
    /// returns faces in a collection that match the faces of persons detected in a video.
    /// It also includes the time(s) that faces are matched in the video.
    /// 
    ///  
    /// <para>
    /// Face search in a video is an asynchronous operation. You start face search by calling
    /// to which returns a job identifier (<code>JobId</code>). When the search operation
    /// finishes, Rekognition Video publishes a completion status to the Amazon Simple Notification
    /// Service topic registered in the initial call to <code>StartFaceSearch</code>. To get
    /// the search results, first check that the status value published to the Amazon SNS
    /// topic is <code>SUCCEEDED</code>. If so, call <code>GetFaceSearch</code> and pass the
    /// job identifier (<code>JobId</code>) from the initial call to <code>StartFaceSearch</code>.
    /// For more information, see <a>collections</a>.
    /// </para><para>
    /// The search results are retured in an array, <code>Persons</code>, of objects. Each<code>PersonMatch</code>
    /// element contains details about the matching faces in the input collection, person
    /// information for the matched person, and the time the person was matched in the video.
    /// </para><para>
    /// By default, the <code>Persons</code> array is sorted by the time, in milliseconds
    /// from the start of the video, persons are matched. You can also sort by persons by
    /// specifying <code>INDEX</code> for the <code>SORTBY</code> input parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "REKFaceSearch")]
    [OutputType("Amazon.Rekognition.Model.GetFaceSearchResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetFaceSearch API operation.", Operation = new[] {"GetFaceSearch"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetFaceSearchResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.GetFaceSearchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKFaceSearchCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The job identifer for the search request. You get the job identifier from an initial
        /// call to <code>StartFaceSearch</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort to use for grouping faces in the response. Use <code>TIMESTAMP</code> to group
        /// faces by the time that they are recognized. Use <code>INDEX</code> to sort by recognized
        /// faces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Rekognition.FaceSearchSortBy")]
        public Amazon.Rekognition.FaceSearchSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of search results you want Rekognition Video to return in the response.
        /// The default is 1000.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there is more search results to retrieve),
        /// Rekognition Video returns a pagination token in the response. You can use this pagination
        /// token to retrieve the next set of search results. </para>
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
            var request = new Amazon.Rekognition.Model.GetFaceSearchRequest();
            
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
        
        private Amazon.Rekognition.Model.GetFaceSearchResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetFaceSearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetFaceSearch");
            try
            {
                #if DESKTOP
                return client.GetFaceSearch(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetFaceSearchAsync(request);
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
            public Amazon.Rekognition.FaceSearchSortBy SortBy { get; set; }
        }
        
    }
}
