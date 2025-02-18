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

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Starts asynchronous detection of text in a stored video.
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition Video can detect text in a video stored in an Amazon S3 bucket.
    /// Use <a>Video</a> to specify the bucket name and the filename of the video. <c>StartTextDetection</c>
    /// returns a job identifier (<c>JobId</c>) which you use to get the results of the operation.
    /// When text detection is finished, Amazon Rekognition Video publishes a completion status
    /// to the Amazon Simple Notification Service topic that you specify in <c>NotificationChannel</c>.
    /// </para><para>
    /// To get the results of the text detection operation, first check that the status value
    /// published to the Amazon SNS topic is <c>SUCCEEDED</c>. if so, call <a>GetTextDetection</a>
    /// and pass the job identifier (<c>JobId</c>) from the initial call to <c>StartTextDetection</c>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "REKTextDetection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition StartTextDetection API operation.", Operation = new[] {"StartTextDetection"}, SelectReturnType = typeof(Amazon.Rekognition.Model.StartTextDetectionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.StartTextDetectionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.StartTextDetectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartREKTextDetectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token used to identify the start request. If you use the same token with
        /// multiple <c>StartTextDetection</c> requests, the same <c>JobId</c> is returned. Use
        /// <c>ClientRequestToken</c> to prevent the same job from being accidentaly started more
        /// than once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>An identifier returned in the completion status published by your Amazon Simple Notification
        /// Service topic. For example, you can use <c>JobTag</c> to group related jobs and identify
        /// them in the completion notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobTag { get; set; }
        #endregion
        
        #region Parameter WordFilter_MinBoundingBoxHeight
        /// <summary>
        /// <para>
        /// <para>Sets the minimum height of the word bounding box. Words with bounding box heights
        /// lesser than this value will be excluded from the result. Value is relative to the
        /// video frame height.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_WordFilter_MinBoundingBoxHeight")]
        public System.Single? WordFilter_MinBoundingBoxHeight { get; set; }
        #endregion
        
        #region Parameter WordFilter_MinBoundingBoxWidth
        /// <summary>
        /// <para>
        /// <para>Sets the minimum width of the word bounding box. Words with bounding boxes widths
        /// lesser than this value will be excluded from the result. Value is relative to the
        /// video frame width.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_WordFilter_MinBoundingBoxWidth")]
        public System.Single? WordFilter_MinBoundingBoxWidth { get; set; }
        #endregion
        
        #region Parameter WordFilter_MinConfidence
        /// <summary>
        /// <para>
        /// <para>Sets the confidence of word detection. Words with detection confidence below this
        /// will be excluded from the result. Values should be between 0 and 100. The default
        /// MinConfidence is 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_WordFilter_MinConfidence")]
        public System.Single? WordFilter_MinConfidence { get; set; }
        #endregion
        
        #region Parameter Filters_RegionsOfInterest
        /// <summary>
        /// <para>
        /// <para>Filter focusing on a certain area of the frame. Uses a <c>BoundingBox</c> object to
        /// set the region of the screen.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Rekognition.Model.RegionOfInterest[] Filters_RegionsOfInterest { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that gives Amazon Rekognition publishing permissions to the
        /// Amazon SNS topic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationChannel_RoleArn { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_SNSTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic to which Amazon Rekognition posts the completion status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationChannel_SNSTopicArn { get; set; }
        #endregion
        
        #region Parameter Video
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Rekognition.Model.Video Video { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.StartTextDetectionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.StartTextDetectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKTextDetection (StartTextDetection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.StartTextDetectionResponse, StartREKTextDetectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Filters_RegionsOfInterest != null)
            {
                context.Filters_RegionsOfInterest = new List<Amazon.Rekognition.Model.RegionOfInterest>(this.Filters_RegionsOfInterest);
            }
            context.WordFilter_MinBoundingBoxHeight = this.WordFilter_MinBoundingBoxHeight;
            context.WordFilter_MinBoundingBoxWidth = this.WordFilter_MinBoundingBoxWidth;
            context.WordFilter_MinConfidence = this.WordFilter_MinConfidence;
            context.JobTag = this.JobTag;
            context.NotificationChannel_RoleArn = this.NotificationChannel_RoleArn;
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            context.Video = this.Video;
            #if MODULAR
            if (this.Video == null && ParameterWasBound(nameof(this.Video)))
            {
                WriteWarning("You are passing $null as a value for parameter Video which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Rekognition.Model.StartTextDetectionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Rekognition.Model.StartTextDetectionFilters();
            List<Amazon.Rekognition.Model.RegionOfInterest> requestFilters_filters_RegionsOfInterest = null;
            if (cmdletContext.Filters_RegionsOfInterest != null)
            {
                requestFilters_filters_RegionsOfInterest = cmdletContext.Filters_RegionsOfInterest;
            }
            if (requestFilters_filters_RegionsOfInterest != null)
            {
                request.Filters.RegionsOfInterest = requestFilters_filters_RegionsOfInterest;
                requestFiltersIsNull = false;
            }
            Amazon.Rekognition.Model.DetectionFilter requestFilters_filters_WordFilter = null;
            
             // populate WordFilter
            var requestFilters_filters_WordFilterIsNull = true;
            requestFilters_filters_WordFilter = new Amazon.Rekognition.Model.DetectionFilter();
            System.Single? requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight = null;
            if (cmdletContext.WordFilter_MinBoundingBoxHeight != null)
            {
                requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight = cmdletContext.WordFilter_MinBoundingBoxHeight.Value;
            }
            if (requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight != null)
            {
                requestFilters_filters_WordFilter.MinBoundingBoxHeight = requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight.Value;
                requestFilters_filters_WordFilterIsNull = false;
            }
            System.Single? requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth = null;
            if (cmdletContext.WordFilter_MinBoundingBoxWidth != null)
            {
                requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth = cmdletContext.WordFilter_MinBoundingBoxWidth.Value;
            }
            if (requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth != null)
            {
                requestFilters_filters_WordFilter.MinBoundingBoxWidth = requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth.Value;
                requestFilters_filters_WordFilterIsNull = false;
            }
            System.Single? requestFilters_filters_WordFilter_wordFilter_MinConfidence = null;
            if (cmdletContext.WordFilter_MinConfidence != null)
            {
                requestFilters_filters_WordFilter_wordFilter_MinConfidence = cmdletContext.WordFilter_MinConfidence.Value;
            }
            if (requestFilters_filters_WordFilter_wordFilter_MinConfidence != null)
            {
                requestFilters_filters_WordFilter.MinConfidence = requestFilters_filters_WordFilter_wordFilter_MinConfidence.Value;
                requestFilters_filters_WordFilterIsNull = false;
            }
             // determine if requestFilters_filters_WordFilter should be set to null
            if (requestFilters_filters_WordFilterIsNull)
            {
                requestFilters_filters_WordFilter = null;
            }
            if (requestFilters_filters_WordFilter != null)
            {
                request.Filters.WordFilter = requestFilters_filters_WordFilter;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTag = cmdletContext.JobTag;
            }
            
             // populate NotificationChannel
            var requestNotificationChannelIsNull = true;
            request.NotificationChannel = new Amazon.Rekognition.Model.NotificationChannel();
            System.String requestNotificationChannel_notificationChannel_RoleArn = null;
            if (cmdletContext.NotificationChannel_RoleArn != null)
            {
                requestNotificationChannel_notificationChannel_RoleArn = cmdletContext.NotificationChannel_RoleArn;
            }
            if (requestNotificationChannel_notificationChannel_RoleArn != null)
            {
                request.NotificationChannel.RoleArn = requestNotificationChannel_notificationChannel_RoleArn;
                requestNotificationChannelIsNull = false;
            }
            System.String requestNotificationChannel_notificationChannel_SNSTopicArn = null;
            if (cmdletContext.NotificationChannel_SNSTopicArn != null)
            {
                requestNotificationChannel_notificationChannel_SNSTopicArn = cmdletContext.NotificationChannel_SNSTopicArn;
            }
            if (requestNotificationChannel_notificationChannel_SNSTopicArn != null)
            {
                request.NotificationChannel.SNSTopicArn = requestNotificationChannel_notificationChannel_SNSTopicArn;
                requestNotificationChannelIsNull = false;
            }
             // determine if request.NotificationChannel should be set to null
            if (requestNotificationChannelIsNull)
            {
                request.NotificationChannel = null;
            }
            if (cmdletContext.Video != null)
            {
                request.Video = cmdletContext.Video;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.StartTextDetectionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartTextDetectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartTextDetection");
            try
            {
                return client.StartTextDetectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.Rekognition.Model.RegionOfInterest> Filters_RegionsOfInterest { get; set; }
            public System.Single? WordFilter_MinBoundingBoxHeight { get; set; }
            public System.Single? WordFilter_MinBoundingBoxWidth { get; set; }
            public System.Single? WordFilter_MinConfidence { get; set; }
            public System.String JobTag { get; set; }
            public System.String NotificationChannel_RoleArn { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public Amazon.Rekognition.Model.Video Video { get; set; }
            public System.Func<Amazon.Rekognition.Model.StartTextDetectionResponse, StartREKTextDetectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
