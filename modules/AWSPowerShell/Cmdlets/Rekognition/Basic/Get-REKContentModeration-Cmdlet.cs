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
    /// Gets the inappropriate, unwanted, or offensive content analysis results for a Amazon
    /// Rekognition Video analysis started by <a>StartContentModeration</a>. For a list of
    /// moderation labels in Amazon Rekognition, see <a href="https://docs.aws.amazon.com/rekognition/latest/dg/moderation.html#moderation-api">Using
    /// the image and video moderation APIs</a>.
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition Video inappropriate or offensive content detection in a stored
    /// video is an asynchronous operation. You start analysis by calling <a>StartContentModeration</a>
    /// which returns a job identifier (<c>JobId</c>). When analysis finishes, Amazon Rekognition
    /// Video publishes a completion status to the Amazon Simple Notification Service topic
    /// registered in the initial call to <c>StartContentModeration</c>. To get the results
    /// of the content analysis, first check that the status value published to the Amazon
    /// SNS topic is <c>SUCCEEDED</c>. If so, call <c>GetContentModeration</c> and pass the
    /// job identifier (<c>JobId</c>) from the initial call to <c>StartContentModeration</c>.
    /// 
    /// </para><para>
    /// For more information, see Working with Stored Videos in the Amazon Rekognition Devlopers
    /// Guide.
    /// </para><para><c>GetContentModeration</c> returns detected inappropriate, unwanted, or offensive
    /// content moderation labels, and the time they are detected, in an array, <c>ModerationLabels</c>,
    /// of <a>ContentModerationDetection</a> objects. 
    /// </para><para>
    /// By default, the moderated labels are returned sorted by time, in milliseconds from
    /// the start of the video. You can also sort them by moderated label by specifying <c>NAME</c>
    /// for the <c>SortBy</c> input parameter. 
    /// </para><para>
    /// Since video analysis can return a large number of results, use the <c>MaxResults</c>
    /// parameter to limit the number of labels returned in a single call to <c>GetContentModeration</c>.
    /// If there are more results than specified in <c>MaxResults</c>, the value of <c>NextToken</c>
    /// in the operation response contains a pagination token for getting the next set of
    /// results. To get the next page of results, call <c>GetContentModeration</c> and populate
    /// the <c>NextToken</c> request parameter with the value of <c>NextToken</c> returned
    /// from the previous call to <c>GetContentModeration</c>.
    /// </para><para>
    /// For more information, see moderating content in the Amazon Rekognition Developer Guide.
    /// </para><br/><br/>In the AWS.Tools.Rekognition module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "REKContentModeration")]
    [OutputType("Amazon.Rekognition.Model.GetContentModerationResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition GetContentModeration API operation.", Operation = new[] {"GetContentModeration"}, SelectReturnType = typeof(Amazon.Rekognition.Model.GetContentModerationResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.GetContentModerationResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.GetContentModerationResponse object containing multiple properties."
    )]
    public partial class GetREKContentModerationCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregateBy
        /// <summary>
        /// <para>
        /// <para>Defines how to aggregate results of the StartContentModeration request. Default aggregation
        /// option is TIMESTAMPS. SEGMENTS mode aggregates moderation labels over time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Rekognition.ContentModerationAggregateBy")]
        public Amazon.Rekognition.ContentModerationAggregateBy AggregateBy { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The identifier for the inappropriate, unwanted, or offensive content moderation job.
        /// Use <c>JobId</c> to identify the job in a subsequent call to <c>GetContentModeration</c>.</para>
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
        /// <para>Sort to use for elements in the <c>ModerationLabelDetections</c> array. Use <c>TIMESTAMP</c>
        /// to sort array elements by the time labels are detected. Use <c>NAME</c> to alphabetically
        /// group elements for a label together. Within each label group, the array element are
        /// sorted by detection confidence. The default sort is by <c>TIMESTAMP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Rekognition.ContentModerationSortBy")]
        public Amazon.Rekognition.ContentModerationSortBy SortBy { get; set; }
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
        /// <para>If the previous response was incomplete (because there is more data to retrieve),
        /// Amazon Rekognition returns a pagination token in the response. You can use this pagination
        /// token to retrieve the next set of content moderation labels.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.GetContentModerationResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.GetContentModerationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.GetContentModerationResponse, GetREKContentModerationCmdlet>(Select) ??
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
            var request = new Amazon.Rekognition.Model.GetContentModerationRequest();
            
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
            var request = new Amazon.Rekognition.Model.GetContentModerationRequest();
            
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
        
        private Amazon.Rekognition.Model.GetContentModerationResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.GetContentModerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "GetContentModeration");
            try
            {
                #if DESKTOP
                return client.GetContentModeration(request);
                #elif CORECLR
                return client.GetContentModerationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Rekognition.ContentModerationAggregateBy AggregateBy { get; set; }
            public System.String JobId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Rekognition.ContentModerationSortBy SortBy { get; set; }
            public System.Func<Amazon.Rekognition.Model.GetContentModerationResponse, GetREKContentModerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
