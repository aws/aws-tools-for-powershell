/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Gets the celebrity recognition results for a Amazon Rekognition Video analysis started
    /// by <a>StartCelebrityRecognition</a>.
    /// 
    ///  
    /// <para>
    /// Celebrity recognition in a video is an asynchronous operation. Analysis is started
    /// by a call to <a>StartCelebrityRecognition</a> which returns a job identifier (<c>JobId</c>).
    /// 
    /// </para><para>
    /// When the celebrity recognition operation finishes, Amazon Rekognition Video publishes
    /// a completion status to the Amazon Simple Notification Service topic registered in
    /// the initial call to <c>StartCelebrityRecognition</c>. To get the results of the celebrity
    /// recognition analysis, first check that the status value published to the Amazon SNS
    /// topic is <c>SUCCEEDED</c>. If so, call <c>GetCelebrityDetection</c> and pass the job
    /// identifier (<c>JobId</c>) from the initial call to <c>StartCelebrityDetection</c>.
    /// 
    /// </para><para>
    /// For more information, see Working With Stored Videos in the Amazon Rekognition Developer
    /// Guide.
    /// </para><para><c>GetCelebrityRecognition</c> returns detected celebrities and the time(s) they
    /// are detected in an array (<c>Celebrities</c>) of <a>CelebrityRecognition</a> objects.
    /// Each <c>CelebrityRecognition</c> contains information about the celebrity in a <a>CelebrityDetail</a>
    /// object and the time, <c>Timestamp</c>, the celebrity was detected. This <a>CelebrityDetail</a>
    /// object stores information about the detected celebrity's face attributes, a face bounding
    /// box, known gender, the celebrity's name, and a confidence estimate.
    /// </para><note><para><c>GetCelebrityRecognition</c> only returns the default facial attributes (<c>BoundingBox</c>,
    /// <c>Confidence</c>, <c>Landmarks</c>, <c>Pose</c>, and <c>Quality</c>). The <c>BoundingBox</c>
    /// field only applies to the detected face instance. The other facial attributes listed
    /// in the <c>Face</c> object of the following response syntax are not returned. For more
    /// information, see FaceDetail in the Amazon Rekognition Developer Guide. 
    /// </para></note><para>
    /// By default, the <c>Celebrities</c> array is sorted by time (milliseconds from the
    /// start of the video). You can also sort the array by celebrity by specifying the value
    /// <c>ID</c> in the <c>SortBy</c> input parameter.
    /// </para><para>
    /// The <c>CelebrityDetail</c> object includes the celebrity identifer and additional
    /// information urls. If you don't store the additional information urls, you can get
    /// them later by calling <a>GetCelebrityInfo</a> with the celebrity identifer.
    /// </para><para>
    /// No information is returned for faces not recognized as celebrities.
    /// </para><para>
    /// Use MaxResults parameter to limit the number of labels returned. If there are more
    /// results than specified in <c>MaxResults</c>, the value of <c>NextToken</c> in the
    /// operation response contains a pagination token for getting the next set of results.
    /// To get the next page of results, call <c>GetCelebrityDetection</c> and populate the
    /// <c>NextToken</c> request parameter with the token value returned from the previous
    /// call to <c>GetCelebrityRecognition</c>.
    /// </para><br/><br/>In the AWS.Tools.Rekognition module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "REKCelebrityRecognition")]
    [OutputType("Amazon.Rekognition.Model.GetCelebrityRecognitionResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetCelebrityRecognition API operation.", Operation = new[] {"GetCelebrityRecognition"}, SelectReturnType = typeof(Amazon.Rekognition.Model.GetCelebrityRecognitionResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetCelebrityRecognitionResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.GetCelebrityRecognitionResponse object containing multiple properties."
    )]
    public partial class GetREKCelebrityRecognitionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>Job identifier for the required celebrity recognition analysis. You can get the job
        /// identifer from a call to <c>StartCelebrityRecognition</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort to use for celebrities returned in <c>Celebrities</c> field. Specify <c>ID</c>
        /// to sort by the celebrity identifier, specify <c>TIMESTAMP</c> to sort by the time
        /// the celebrity was recognized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Rekognition.CelebrityRecognitionSortBy")]
        public Amazon.Rekognition.CelebrityRecognitionSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return per paginated call. The largest value you can
        /// specify is 1000. If you specify a value greater than 1000, a maximum of 1000 results
        /// is returned. The default value is 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there is more recognized celebrities
        /// to retrieve), Amazon Rekognition Video returns a pagination token in the response.
        /// You can use this pagination token to retrieve the next set of celebrities. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.Rekognition module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.GetCelebrityRecognitionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.GetCelebrityRecognitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.GetCelebrityRecognitionResponse, GetREKCelebrityRecognitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Rekognition.Model.GetCelebrityRecognitionRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Rekognition.Model.GetCelebrityRecognitionRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.GetCelebrityRecognitionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetCelebrityRecognitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetCelebrityRecognition");
            try
            {
                return client.GetCelebrityRecognitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Rekognition.CelebrityRecognitionSortBy SortBy { get; set; }
            public System.Func<Amazon.Rekognition.Model.GetCelebrityRecognitionResponse, GetREKCelebrityRecognitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
