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
    /// Gets the person tracking results of a Rekognition Video analysis started by .
    /// 
    ///  
    /// <para>
    /// The person detection operation is started by a call to <code>StartPersonTracking</code>
    /// which returns a job identifier (<code>JobId</code>). When the person detection operation
    /// finishes, Rekognition Video publishes a completion status to the Amazon Simple Notification
    /// Service topic registered in the initial call to <code>StartPersonTracking</code>.
    /// </para><para>
    /// To get the results of the person tracking operation, first check that the status value
    /// published to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call and pass
    /// the job identifier (<code>JobId</code>) from the initial call to <code>StartPersonTracking</code>.
    /// </para><para><code>GetPersonTracking</code> returns an array, <code>Persons</code>, of tracked
    /// persons and the time(s) they were tracked in the video. 
    /// </para><para>
    /// By default, the array is sorted by the time(s) a person is tracked in the video. You
    /// can sort by tracked persons by specifying <code>INDEX</code> for the <code>SortBy</code>
    /// input parameter.
    /// </para><para>
    /// Use the <code>MaxResults</code> parameter to limit the number of items returned. If
    /// there are more results than specified in <code>MaxResults</code>, the value of <code>NextToken</code>
    /// in the operation response contains a pagination token for getting the next set of
    /// results. To get the next page of results, call <code>GetPersonTracking</code> and
    /// populate the <code>NextToken</code> request parameter with the token value returned
    /// from the previous call to <code>GetPersonTracking</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "REKPersonTracking")]
    [OutputType("Amazon.Rekognition.Model.GetPersonTrackingResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetPersonTracking API operation.", Operation = new[] {"GetPersonTracking"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetPersonTrackingResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.GetPersonTrackingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKPersonTrackingCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The identifier for a job that tracks persons in a video. You get the <code>JobId</code>
        /// from a call to <code>StartPersonTracking</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort to use for elements in the <code>Persons</code> array. Use <code>TIMESTAMP</code>
        /// to sort array elements by the time persons are detected. Use <code>INDEX</code> to
        /// sort by the tracked persons. If you sort by <code>INDEX</code>, the array elements
        /// for each person are sorted by detection confidence. The default sort is by <code>TIMESTAMP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Rekognition.PersonTrackingSortBy")]
        public Amazon.Rekognition.PersonTrackingSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of tracked persons to return. The default is 1000. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there are more persons to retrieve),
        /// Rekognition Video returns a pagination token in the response. You can use this pagination
        /// token to retrieve the next set of persons. </para>
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
            var request = new Amazon.Rekognition.Model.GetPersonTrackingRequest();
            
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
        
        private Amazon.Rekognition.Model.GetPersonTrackingResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetPersonTrackingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetPersonTracking");
            try
            {
                #if DESKTOP
                return client.GetPersonTracking(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetPersonTrackingAsync(request);
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
            public Amazon.Rekognition.PersonTrackingSortBy SortBy { get; set; }
        }
        
    }
}
