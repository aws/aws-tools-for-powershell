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
    /// Starts asynchronous detection of labels in a stored video.
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition Video can detect labels in a video. Labels are instances of real-world
    /// entities. This includes objects like flower, tree, and table; events like wedding,
    /// graduation, and birthday party; concepts like landscape, evening, and nature; and
    /// activities like a person getting out of a car or a person skiing.
    /// </para><para>
    /// The video must be stored in an Amazon S3 bucket. Use <a>Video</a> to specify the bucket
    /// name and the filename of the video. <c>StartLabelDetection</c> returns a job identifier
    /// (<c>JobId</c>) which you use to get the results of the operation. When label detection
    /// is finished, Amazon Rekognition Video publishes a completion status to the Amazon
    /// Simple Notification Service topic that you specify in <c>NotificationChannel</c>.
    /// </para><para>
    /// To get the results of the label detection operation, first check that the status value
    /// published to the Amazon SNS topic is <c>SUCCEEDED</c>. If so, call <a>GetLabelDetection</a>
    /// and pass the job identifier (<c>JobId</c>) from the initial call to <c>StartLabelDetection</c>.
    /// </para><para><i>Optional Parameters</i></para><para><c>StartLabelDetection</c> has the <c>GENERAL_LABELS</c> Feature applied by default.
    /// This feature allows you to provide filtering criteria to the <c>Settings</c> parameter.
    /// You can filter with sets of individual labels or with label categories. You can specify
    /// inclusive filters, exclusive filters, or a combination of inclusive and exclusive
    /// filters. For more information on filtering, see <a href="https://docs.aws.amazon.com/rekognition/latest/dg/labels-detecting-labels-video.html">Detecting
    /// labels in a video</a>.
    /// </para><para>
    /// You can specify <c>MinConfidence</c> to control the confidence threshold for the labels
    /// returned. The default is 50.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "REKLabelDetection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition StartLabelDetection API operation.", Operation = new[] {"StartLabelDetection"}, SelectReturnType = typeof(Amazon.Rekognition.Model.StartLabelDetectionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.StartLabelDetectionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.StartLabelDetectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartREKLabelDetectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token used to identify the start request. If you use the same token with
        /// multiple <c>StartLabelDetection</c> requests, the same <c>JobId</c> is returned. Use
        /// <c>ClientRequestToken</c> to prevent the same job from being accidently started more
        /// than once. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>The features to return after video analysis. You can specify that GENERAL_LABELS are
        /// returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Features")]
        public System.String[] Feature { get; set; }
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
        
        #region Parameter GeneralLabels_LabelCategoryExclusionFilter
        /// <summary>
        /// <para>
        /// <para>The label categories that should be excluded from the return from DetectLabels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelCategoryExclusionFilters")]
        public System.String[] GeneralLabels_LabelCategoryExclusionFilter { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelCategoryInclusionFilter
        /// <summary>
        /// <para>
        /// <para>The label categories that should be included in the return from DetectLabels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelCategoryInclusionFilters")]
        public System.String[] GeneralLabels_LabelCategoryInclusionFilter { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelExclusionFilter
        /// <summary>
        /// <para>
        /// <para>The labels that should be excluded from the return from DetectLabels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelExclusionFilters")]
        public System.String[] GeneralLabels_LabelExclusionFilter { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelInclusionFilter
        /// <summary>
        /// <para>
        /// <para>The labels that should be included in the return from DetectLabels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelInclusionFilters")]
        public System.String[] GeneralLabels_LabelInclusionFilter { get; set; }
        #endregion
        
        #region Parameter MinConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence that Amazon Rekognition Video must have in order
        /// to return a detected label. Confidence represents how certain Amazon Rekognition is
        /// that a label is correctly identified.0 is the lowest confidence. 100 is the highest
        /// confidence. Amazon Rekognition Video doesn't return any labels with a confidence level
        /// lower than this specified value.</para><para>If you don't specify <c>MinConfidence</c>, the operation returns labels and bounding
        /// boxes (if detected) with confidence values greater than or equal to 50 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? MinConfidence { get; set; }
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
        /// <para>The video in which you want to detect labels. The video must be stored in an Amazon
        /// S3 bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Rekognition.Model.Video Video { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.StartLabelDetectionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.StartLabelDetectionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKLabelDetection (StartLabelDetection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.StartLabelDetectionResponse, StartREKLabelDetectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Feature != null)
            {
                context.Feature = new List<System.String>(this.Feature);
            }
            context.JobTag = this.JobTag;
            context.MinConfidence = this.MinConfidence;
            context.NotificationChannel_RoleArn = this.NotificationChannel_RoleArn;
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            if (this.GeneralLabels_LabelCategoryExclusionFilter != null)
            {
                context.GeneralLabels_LabelCategoryExclusionFilter = new List<System.String>(this.GeneralLabels_LabelCategoryExclusionFilter);
            }
            if (this.GeneralLabels_LabelCategoryInclusionFilter != null)
            {
                context.GeneralLabels_LabelCategoryInclusionFilter = new List<System.String>(this.GeneralLabels_LabelCategoryInclusionFilter);
            }
            if (this.GeneralLabels_LabelExclusionFilter != null)
            {
                context.GeneralLabels_LabelExclusionFilter = new List<System.String>(this.GeneralLabels_LabelExclusionFilter);
            }
            if (this.GeneralLabels_LabelInclusionFilter != null)
            {
                context.GeneralLabels_LabelInclusionFilter = new List<System.String>(this.GeneralLabels_LabelInclusionFilter);
            }
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
            var request = new Amazon.Rekognition.Model.StartLabelDetectionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Feature != null)
            {
                request.Features = cmdletContext.Feature;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTag = cmdletContext.JobTag;
            }
            if (cmdletContext.MinConfidence != null)
            {
                request.MinConfidence = cmdletContext.MinConfidence.Value;
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
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.Rekognition.Model.LabelDetectionSettings();
            Amazon.Rekognition.Model.GeneralLabelsSettings requestSettings_settings_GeneralLabels = null;
            
             // populate GeneralLabels
            var requestSettings_settings_GeneralLabelsIsNull = true;
            requestSettings_settings_GeneralLabels = new Amazon.Rekognition.Model.GeneralLabelsSettings();
            List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter = null;
            if (cmdletContext.GeneralLabels_LabelCategoryExclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter = cmdletContext.GeneralLabels_LabelCategoryExclusionFilter;
            }
            if (requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels.LabelCategoryExclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter;
                requestSettings_settings_GeneralLabelsIsNull = false;
            }
            List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter = null;
            if (cmdletContext.GeneralLabels_LabelCategoryInclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter = cmdletContext.GeneralLabels_LabelCategoryInclusionFilter;
            }
            if (requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels.LabelCategoryInclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter;
                requestSettings_settings_GeneralLabelsIsNull = false;
            }
            List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter = null;
            if (cmdletContext.GeneralLabels_LabelExclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter = cmdletContext.GeneralLabels_LabelExclusionFilter;
            }
            if (requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels.LabelExclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter;
                requestSettings_settings_GeneralLabelsIsNull = false;
            }
            List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter = null;
            if (cmdletContext.GeneralLabels_LabelInclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter = cmdletContext.GeneralLabels_LabelInclusionFilter;
            }
            if (requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter != null)
            {
                requestSettings_settings_GeneralLabels.LabelInclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter;
                requestSettings_settings_GeneralLabelsIsNull = false;
            }
             // determine if requestSettings_settings_GeneralLabels should be set to null
            if (requestSettings_settings_GeneralLabelsIsNull)
            {
                requestSettings_settings_GeneralLabels = null;
            }
            if (requestSettings_settings_GeneralLabels != null)
            {
                request.Settings.GeneralLabels = requestSettings_settings_GeneralLabels;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.Rekognition.Model.StartLabelDetectionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartLabelDetectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartLabelDetection");
            try
            {
                #if DESKTOP
                return client.StartLabelDetection(request);
                #elif CORECLR
                return client.StartLabelDetectionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Feature { get; set; }
            public System.String JobTag { get; set; }
            public System.Single? MinConfidence { get; set; }
            public System.String NotificationChannel_RoleArn { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public List<System.String> GeneralLabels_LabelCategoryExclusionFilter { get; set; }
            public List<System.String> GeneralLabels_LabelCategoryInclusionFilter { get; set; }
            public List<System.String> GeneralLabels_LabelExclusionFilter { get; set; }
            public List<System.String> GeneralLabels_LabelInclusionFilter { get; set; }
            public Amazon.Rekognition.Model.Video Video { get; set; }
            public System.Func<Amazon.Rekognition.Model.StartLabelDetectionResponse, StartREKLabelDetectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
