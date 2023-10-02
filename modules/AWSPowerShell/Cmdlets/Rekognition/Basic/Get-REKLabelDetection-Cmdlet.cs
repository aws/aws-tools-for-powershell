/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// 
    /// </para><para>
    /// To get the results of the label detection operation, first check that the status value
    /// published to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call <a>GetLabelDetection</a>
    /// and pass the job identifier (<code>JobId</code>) from the initial call to <code>StartLabelDetection</code>.
    /// </para><para><code>GetLabelDetection</code> returns an array of detected labels (<code>Labels</code>)
    /// sorted by the time the labels were detected. You can also sort by the label name by
    /// specifying <code>NAME</code> for the <code>SortBy</code> input parameter. If there
    /// is no <code>NAME</code> specified, the default sort is by timestamp.
    /// </para><para>
    /// You can select how results are aggregated by using the <code>AggregateBy</code> input
    /// parameter. The default aggregation method is <code>TIMESTAMPS</code>. You can also
    /// aggregate by <code>SEGMENTS</code>, which aggregates all instances of labels detected
    /// in a given segment. 
    /// </para><para>
    /// The returned Labels array may include the following attributes:
    /// </para><ul><li><para>
    /// Name - The name of the detected label.
    /// </para></li><li><para>
    /// Confidence - The level of confidence in the label assigned to a detected object. 
    /// </para></li><li><para>
    /// Parents - The ancestor labels for a detected label. GetLabelDetection returns a hierarchical
    /// taxonomy of detected labels. For example, a detected car might be assigned the label
    /// car. The label car has two parent labels: Vehicle (its parent) and Transportation
    /// (its grandparent). The response includes the all ancestors for a label, where every
    /// ancestor is a unique label. In the previous example, Car, Vehicle, and Transportation
    /// are returned as unique labels in the response. 
    /// </para></li><li><para>
    ///  Aliases - Possible Aliases for the label. 
    /// </para></li><li><para>
    /// Categories - The label categories that the detected label belongs to.
    /// </para></li><li><para>
    /// BoundingBox — Bounding boxes are described for all instances of detected common object
    /// labels, returned in an array of Instance objects. An Instance object contains a BoundingBox
    /// object, describing the location of the label on the input image. It also includes
    /// the confidence for the accuracy of the detected bounding box.
    /// </para></li><li><para>
    /// Timestamp - Time, in milliseconds from the start of the video, that the label was
    /// detected. For aggregation by <code>SEGMENTS</code>, the <code>StartTimestampMillis</code>,
    /// <code>EndTimestampMillis</code>, and <code>DurationMillis</code> structures are what
    /// define a segment. Although the “Timestamp” structure is still returned with each label,
    /// its value is set to be the same as <code>StartTimestampMillis</code>.
    /// </para></li></ul><para>
    /// Timestamp and Bounding box information are returned for detected Instances, only if
    /// aggregation is done by <code>TIMESTAMPS</code>. If aggregating by <code>SEGMENTS</code>,
    /// information about detected instances isn’t returned. 
    /// </para><para>
    /// The version of the label model used for the detection is also returned.
    /// </para><para><b>Note <code>DominantColors</code> isn't returned for <code>Instances</code>, although
    /// it is shown as part of the response in the sample seen below.</b></para><para>
    /// Use <code>MaxResults</code> parameter to limit the number of labels returned. If there
    /// are more results than specified in <code>MaxResults</code>, the value of <code>NextToken</code>
    /// in the operation response contains a pagination token for getting the next set of
    /// results. To get the next page of results, call <code>GetlabelDetection</code> and
    /// populate the <code>NextToken</code> request parameter with the token value returned
    /// from the previous call to <code>GetLabelDetection</code>.
    /// </para><br/><br/>In the AWS.Tools.Rekognition module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "REKLabelDetection")]
    [OutputType("Amazon.Rekognition.Model.GetLabelDetectionResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetLabelDetection API operation.", Operation = new[] {"GetLabelDetection"}, SelectReturnType = typeof(Amazon.Rekognition.Model.GetLabelDetectionResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetLabelDetectionResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.GetLabelDetectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKLabelDetectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregateBy
        /// <summary>
        /// <para>
        /// <para>Defines how to aggregate the returned results. Results can be aggregated by timestamps
        /// or segments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Rekognition.LabelDetectionAggregateBy")]
        public Amazon.Rekognition.LabelDetectionAggregateBy AggregateBy { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>Job identifier for the label detection operation for which you want results returned.
        /// You get the job identifer from an initial call to <code>StartlabelDetection</code>.</para>
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
        /// <para>Sort to use for elements in the <code>Labels</code> array. Use <code>TIMESTAMP</code>
        /// to sort array elements by the time labels are detected. Use <code>NAME</code> to alphabetically
        /// group elements for a label together. Within each label group, the array element are
        /// sorted by detection confidence. The default sort is by <code>TIMESTAMP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there are more labels to retrieve),
        /// Amazon Rekognition Video returns a pagination token in the response. You can use this
        /// pagination token to retrieve the next set of labels. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.Rekognition module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.GetLabelDetectionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.GetLabelDetectionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.GetLabelDetectionResponse, GetREKLabelDetectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregateBy = this.AggregateBy;
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
            var request = new Amazon.Rekognition.Model.GetLabelDetectionRequest();
            
            if (cmdletContext.AggregateBy != null)
            {
                request.AggregateBy = cmdletContext.AggregateBy;
            }
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
            var request = new Amazon.Rekognition.Model.GetLabelDetectionRequest();
            
            if (cmdletContext.AggregateBy != null)
            {
                request.AggregateBy = cmdletContext.AggregateBy;
            }
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
        
        private Amazon.Rekognition.Model.GetLabelDetectionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetLabelDetectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetLabelDetection");
            try
            {
                #if DESKTOP
                return client.GetLabelDetection(request);
                #elif CORECLR
                return client.GetLabelDetectionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Rekognition.LabelDetectionAggregateBy AggregateBy { get; set; }
            public System.String JobId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Rekognition.LabelDetectionSortBy SortBy { get; set; }
            public System.Func<Amazon.Rekognition.Model.GetLabelDetectionResponse, GetREKLabelDetectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
