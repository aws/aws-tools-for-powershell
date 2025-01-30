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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Starts asynchronous detection of segment detection in a stored video.
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition Video can detect segments in a video stored in an Amazon S3 bucket.
    /// Use <a>Video</a> to specify the bucket name and the filename of the video. <c>StartSegmentDetection</c>
    /// returns a job identifier (<c>JobId</c>) which you use to get the results of the operation.
    /// When segment detection is finished, Amazon Rekognition Video publishes a completion
    /// status to the Amazon Simple Notification Service topic that you specify in <c>NotificationChannel</c>.
    /// </para><para>
    /// You can use the <c>Filters</c> (<a>StartSegmentDetectionFilters</a>) input parameter
    /// to specify the minimum detection confidence returned in the response. Within <c>Filters</c>,
    /// use <c>ShotFilter</c> (<a>StartShotDetectionFilter</a>) to filter detected shots.
    /// Use <c>TechnicalCueFilter</c> (<a>StartTechnicalCueDetectionFilter</a>) to filter
    /// technical cues. 
    /// </para><para>
    /// To get the results of the segment detection operation, first check that the status
    /// value published to the Amazon SNS topic is <c>SUCCEEDED</c>. if so, call <a>GetSegmentDetection</a>
    /// and pass the job identifier (<c>JobId</c>) from the initial call to <c>StartSegmentDetection</c>.
    /// 
    /// </para><para>
    /// For more information, see Detecting video segments in stored video in the Amazon Rekognition
    /// Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "REKSegmentDetection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition StartSegmentDetection API operation.", Operation = new[] {"StartSegmentDetection"}, SelectReturnType = typeof(Amazon.Rekognition.Model.StartSegmentDetectionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.StartSegmentDetectionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.StartSegmentDetectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartREKSegmentDetectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token used to identify the start request. If you use the same token with
        /// multiple <c>StartSegmentDetection</c> requests, the same <c>JobId</c> is returned.
        /// Use <c>ClientRequestToken</c> to prevent the same job from being accidently started
        /// more than once. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>An identifier you specify that's returned in the completion notification that's published
        /// to your Amazon Simple Notification Service topic. For example, you can use <c>JobTag</c>
        /// to group related jobs and identify them in the completion notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobTag { get; set; }
        #endregion
        
        #region Parameter BlackFrame_MaxPixelThreshold
        /// <summary>
        /// <para>
        /// <para> A threshold used to determine the maximum luminance value for a pixel to be considered
        /// black. In a full color range video, luminance values range from 0-255. A pixel value
        /// of 0 is pure black, and the most strict filter. The maximum black pixel value is computed
        /// as follows: max_black_pixel_value = minimum_luminance + MaxPixelThreshold *luminance_range.
        /// </para><para>For example, for a full range video with BlackPixelThreshold = 0.1, max_black_pixel_value
        /// is 0 + 0.1 * (255-0) = 25.5.</para><para>The default value of MaxPixelThreshold is 0.2, which maps to a max_black_pixel_value
        /// of 51 for a full range video. You can lower this threshold to be more strict on black
        /// levels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_TechnicalCueFilter_BlackFrame_MaxPixelThreshold")]
        public System.Single? BlackFrame_MaxPixelThreshold { get; set; }
        #endregion
        
        #region Parameter BlackFrame_MinCoveragePercentage
        /// <summary>
        /// <para>
        /// <para> The minimum percentage of pixels in a frame that need to have a luminance below the
        /// max_black_pixel_value for a frame to be considered a black frame. Luminance is calculated
        /// using the BT.709 matrix. </para><para>The default value is 99, which means at least 99% of all pixels in the frame are black
        /// pixels as per the <c>MaxPixelThreshold</c> set. You can reduce this value to allow
        /// more noise on the black frame.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_TechnicalCueFilter_BlackFrame_MinCoveragePercentage")]
        public System.Single? BlackFrame_MinCoveragePercentage { get; set; }
        #endregion
        
        #region Parameter ShotFilter_MinSegmentConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence that Amazon Rekognition Video must have in order
        /// to return a detected segment. Confidence represents how certain Amazon Rekognition
        /// is that a segment is correctly identified. 0 is the lowest confidence. 100 is the
        /// highest confidence. Amazon Rekognition Video doesn't return any segments with a confidence
        /// level lower than this specified value.</para><para>If you don't specify <c>MinSegmentConfidence</c>, the <c>GetSegmentDetection</c> returns
        /// segments with confidence values greater than or equal to 50 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ShotFilter_MinSegmentConfidence")]
        public System.Single? ShotFilter_MinSegmentConfidence { get; set; }
        #endregion
        
        #region Parameter TechnicalCueFilter_MinSegmentConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence that Amazon Rekognition Video must have in order
        /// to return a detected segment. Confidence represents how certain Amazon Rekognition
        /// is that a segment is correctly identified. 0 is the lowest confidence. 100 is the
        /// highest confidence. Amazon Rekognition Video doesn't return any segments with a confidence
        /// level lower than this specified value.</para><para>If you don't specify <c>MinSegmentConfidence</c>, <c>GetSegmentDetection</c> returns
        /// segments with confidence values greater than or equal to 50 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_TechnicalCueFilter_MinSegmentConfidence")]
        public System.Single? TechnicalCueFilter_MinSegmentConfidence { get; set; }
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
        
        #region Parameter SegmentType
        /// <summary>
        /// <para>
        /// <para>An array of segment types to detect in the video. Valid values are TECHNICAL_CUE and
        /// SHOT.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SegmentTypes")]
        public System.String[] SegmentType { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.StartSegmentDetectionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.StartSegmentDetectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Video parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Video' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Video' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKSegmentDetection (StartSegmentDetection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.StartSegmentDetectionResponse, StartREKSegmentDetectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Video;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ShotFilter_MinSegmentConfidence = this.ShotFilter_MinSegmentConfidence;
            context.BlackFrame_MaxPixelThreshold = this.BlackFrame_MaxPixelThreshold;
            context.BlackFrame_MinCoveragePercentage = this.BlackFrame_MinCoveragePercentage;
            context.TechnicalCueFilter_MinSegmentConfidence = this.TechnicalCueFilter_MinSegmentConfidence;
            context.JobTag = this.JobTag;
            context.NotificationChannel_RoleArn = this.NotificationChannel_RoleArn;
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            if (this.SegmentType != null)
            {
                context.SegmentType = new List<System.String>(this.SegmentType);
            }
            #if MODULAR
            if (this.SegmentType == null && ParameterWasBound(nameof(this.SegmentType)))
            {
                WriteWarning("You are passing $null as a value for parameter SegmentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Rekognition.Model.StartSegmentDetectionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Rekognition.Model.StartSegmentDetectionFilters();
            Amazon.Rekognition.Model.StartShotDetectionFilter requestFilters_filters_ShotFilter = null;
            
             // populate ShotFilter
            var requestFilters_filters_ShotFilterIsNull = true;
            requestFilters_filters_ShotFilter = new Amazon.Rekognition.Model.StartShotDetectionFilter();
            System.Single? requestFilters_filters_ShotFilter_shotFilter_MinSegmentConfidence = null;
            if (cmdletContext.ShotFilter_MinSegmentConfidence != null)
            {
                requestFilters_filters_ShotFilter_shotFilter_MinSegmentConfidence = cmdletContext.ShotFilter_MinSegmentConfidence.Value;
            }
            if (requestFilters_filters_ShotFilter_shotFilter_MinSegmentConfidence != null)
            {
                requestFilters_filters_ShotFilter.MinSegmentConfidence = requestFilters_filters_ShotFilter_shotFilter_MinSegmentConfidence.Value;
                requestFilters_filters_ShotFilterIsNull = false;
            }
             // determine if requestFilters_filters_ShotFilter should be set to null
            if (requestFilters_filters_ShotFilterIsNull)
            {
                requestFilters_filters_ShotFilter = null;
            }
            if (requestFilters_filters_ShotFilter != null)
            {
                request.Filters.ShotFilter = requestFilters_filters_ShotFilter;
                requestFiltersIsNull = false;
            }
            Amazon.Rekognition.Model.StartTechnicalCueDetectionFilter requestFilters_filters_TechnicalCueFilter = null;
            
             // populate TechnicalCueFilter
            var requestFilters_filters_TechnicalCueFilterIsNull = true;
            requestFilters_filters_TechnicalCueFilter = new Amazon.Rekognition.Model.StartTechnicalCueDetectionFilter();
            System.Single? requestFilters_filters_TechnicalCueFilter_technicalCueFilter_MinSegmentConfidence = null;
            if (cmdletContext.TechnicalCueFilter_MinSegmentConfidence != null)
            {
                requestFilters_filters_TechnicalCueFilter_technicalCueFilter_MinSegmentConfidence = cmdletContext.TechnicalCueFilter_MinSegmentConfidence.Value;
            }
            if (requestFilters_filters_TechnicalCueFilter_technicalCueFilter_MinSegmentConfidence != null)
            {
                requestFilters_filters_TechnicalCueFilter.MinSegmentConfidence = requestFilters_filters_TechnicalCueFilter_technicalCueFilter_MinSegmentConfidence.Value;
                requestFilters_filters_TechnicalCueFilterIsNull = false;
            }
            Amazon.Rekognition.Model.BlackFrame requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame = null;
            
             // populate BlackFrame
            var requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrameIsNull = true;
            requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame = new Amazon.Rekognition.Model.BlackFrame();
            System.Single? requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MaxPixelThreshold = null;
            if (cmdletContext.BlackFrame_MaxPixelThreshold != null)
            {
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MaxPixelThreshold = cmdletContext.BlackFrame_MaxPixelThreshold.Value;
            }
            if (requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MaxPixelThreshold != null)
            {
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame.MaxPixelThreshold = requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MaxPixelThreshold.Value;
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrameIsNull = false;
            }
            System.Single? requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MinCoveragePercentage = null;
            if (cmdletContext.BlackFrame_MinCoveragePercentage != null)
            {
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MinCoveragePercentage = cmdletContext.BlackFrame_MinCoveragePercentage.Value;
            }
            if (requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MinCoveragePercentage != null)
            {
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame.MinCoveragePercentage = requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame_blackFrame_MinCoveragePercentage.Value;
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrameIsNull = false;
            }
             // determine if requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame should be set to null
            if (requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrameIsNull)
            {
                requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame = null;
            }
            if (requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame != null)
            {
                requestFilters_filters_TechnicalCueFilter.BlackFrame = requestFilters_filters_TechnicalCueFilter_filters_TechnicalCueFilter_BlackFrame;
                requestFilters_filters_TechnicalCueFilterIsNull = false;
            }
             // determine if requestFilters_filters_TechnicalCueFilter should be set to null
            if (requestFilters_filters_TechnicalCueFilterIsNull)
            {
                requestFilters_filters_TechnicalCueFilter = null;
            }
            if (requestFilters_filters_TechnicalCueFilter != null)
            {
                request.Filters.TechnicalCueFilter = requestFilters_filters_TechnicalCueFilter;
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
            if (cmdletContext.SegmentType != null)
            {
                request.SegmentTypes = cmdletContext.SegmentType;
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
        
        private Amazon.Rekognition.Model.StartSegmentDetectionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartSegmentDetectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartSegmentDetection");
            try
            {
                #if DESKTOP
                return client.StartSegmentDetection(request);
                #elif CORECLR
                return client.StartSegmentDetectionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Single? ShotFilter_MinSegmentConfidence { get; set; }
            public System.Single? BlackFrame_MaxPixelThreshold { get; set; }
            public System.Single? BlackFrame_MinCoveragePercentage { get; set; }
            public System.Single? TechnicalCueFilter_MinSegmentConfidence { get; set; }
            public System.String JobTag { get; set; }
            public System.String NotificationChannel_RoleArn { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public List<System.String> SegmentType { get; set; }
            public Amazon.Rekognition.Model.Video Video { get; set; }
            public System.Func<Amazon.Rekognition.Model.StartSegmentDetectionResponse, StartREKSegmentDetectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
