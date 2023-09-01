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
using Amazon.ChimeSDKMediaPipelines;
using Amazon.ChimeSDKMediaPipelines.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMP
{
    /// <summary>
    /// Creates a media insights pipeline.
    /// </summary>
    [Cmdlet("New", "CHMMPMediaInsightsPipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipeline")]
    [AWSCmdlet("Calls the Amazon Chime SDK Media Pipelines CreateMediaInsightsPipeline API operation.", Operation = new[] {"CreateMediaInsightsPipeline"}, SelectReturnType = typeof(Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipeline or Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse",
        "This cmdlet returns an Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipeline object.",
        "The service call response (type Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMMPMediaInsightsPipelineCmdlet : AmazonChimeSDKMediaPipelinesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the media insights pipeline request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter S3RecordingSinkRuntimeConfiguration_Destination
        /// <summary>
        /// <para>
        /// <para>The URI of the S3 bucket used as the sink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3RecordingSinkRuntimeConfiguration_Destination { get; set; }
        #endregion
        
        #region Parameter TimestampRange_EndTimestamp
        /// <summary>
        /// <para>
        /// <para>The ending timestamp for the specified range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_EndTimestamp")]
        public System.DateTime? TimestampRange_EndTimestamp { get; set; }
        #endregion
        
        #region Parameter FragmentSelector_FragmentSelectorType
        /// <summary>
        /// <para>
        /// <para>The origin of the timestamps to use, <code>Server</code> or <code>Producer</code>.
        /// For more information, see <a href="https://docs.aws.amazon.com/kinesisvideostreams/latest/dg/API_dataplane_StartSelector.html">StartSelectorType</a>
        /// in the <i>Amazon Kinesis Video Streams Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_FragmentSelectorType")]
        [AWSConstantClassSource("Amazon.ChimeSDKMediaPipelines.FragmentSelectorType")]
        public Amazon.ChimeSDKMediaPipelines.FragmentSelectorType FragmentSelector_FragmentSelectorType { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding
        /// <summary>
        /// <para>
        /// <para>Specifies the encoding of your input audio. Supported format: PCM (only signed 16-bit
        /// little-endian audio formats, which does not include WAV)</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/how-input.html#how-input-audio">Media
        /// formats</a> in the <i>Amazon Transcribe Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMediaPipelines.MediaEncoding")]
        public Amazon.ChimeSDKMediaPipelines.MediaEncoding KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding { get; set; }
        #endregion
        
        #region Parameter MediaInsightsPipelineConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the pipeline's configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MediaInsightsPipelineConfigurationArn { get; set; }
        #endregion
        
        #region Parameter MediaInsightsRuntimeMetadata
        /// <summary>
        /// <para>
        /// <para>The runtime metadata for the media insights pipeline. Consists of a key-value map
        /// of strings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable MediaInsightsRuntimeMetadata { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate
        /// <summary>
        /// <para>
        /// <para>The sample rate of the input audio (in hertz). Low-quality audio, such as telephone
        /// audio, is typically around 8,000 Hz. High-quality audio typically ranges from 16,000
        /// Hz to 48,000 Hz. Note that the sample rate you specify must match that of your audio.</para><para>Valid Range: Minimum value of 8000. Maximum value of 48000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate { get; set; }
        #endregion
        
        #region Parameter S3RecordingSinkRuntimeConfiguration_RecordingFileFormat
        /// <summary>
        /// <para>
        /// <para>The file format for the media files sent to the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMediaPipelines.RecordingFileFormat")]
        public Amazon.ChimeSDKMediaPipelines.RecordingFileFormat S3RecordingSinkRuntimeConfiguration_RecordingFileFormat { get; set; }
        #endregion
        
        #region Parameter TimestampRange_StartTimestamp
        /// <summary>
        /// <para>
        /// <para>The starting timestamp for the specified range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_StartTimestamp")]
        public System.DateTime? TimestampRange_StartTimestamp { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream
        /// <summary>
        /// <para>
        /// <para>The stream or streams to be recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisVideoStreamRecordingSourceRuntimeConfiguration_Streams")]
        public Amazon.ChimeSDKMediaPipelines.Model.RecordingStreamConfiguration[] KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamSourceRuntimeConfiguration_Stream
        /// <summary>
        /// <para>
        /// <para>The streams in the source runtime configuration of a Kinesis video stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisVideoStreamSourceRuntimeConfiguration_Streams")]
        public Amazon.ChimeSDKMediaPipelines.Model.StreamConfiguration[] KinesisVideoStreamSourceRuntimeConfiguration_Stream { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the media insights pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKMediaPipelines.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MediaInsightsPipeline'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MediaInsightsPipeline";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MediaInsightsPipelineConfigurationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MediaInsightsPipelineConfigurationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MediaInsightsPipelineConfigurationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MediaInsightsPipelineConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMMPMediaInsightsPipeline (CreateMediaInsightsPipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse, NewCHMMPMediaInsightsPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MediaInsightsPipelineConfigurationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.FragmentSelector_FragmentSelectorType = this.FragmentSelector_FragmentSelectorType;
            context.TimestampRange_EndTimestamp = this.TimestampRange_EndTimestamp;
            context.TimestampRange_StartTimestamp = this.TimestampRange_StartTimestamp;
            if (this.KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream != null)
            {
                context.KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream = new List<Amazon.ChimeSDKMediaPipelines.Model.RecordingStreamConfiguration>(this.KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream);
            }
            context.KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding = this.KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding;
            context.KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate = this.KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate;
            if (this.KinesisVideoStreamSourceRuntimeConfiguration_Stream != null)
            {
                context.KinesisVideoStreamSourceRuntimeConfiguration_Stream = new List<Amazon.ChimeSDKMediaPipelines.Model.StreamConfiguration>(this.KinesisVideoStreamSourceRuntimeConfiguration_Stream);
            }
            context.MediaInsightsPipelineConfigurationArn = this.MediaInsightsPipelineConfigurationArn;
            #if MODULAR
            if (this.MediaInsightsPipelineConfigurationArn == null && ParameterWasBound(nameof(this.MediaInsightsPipelineConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaInsightsPipelineConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MediaInsightsRuntimeMetadata != null)
            {
                context.MediaInsightsRuntimeMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.MediaInsightsRuntimeMetadata.Keys)
                {
                    context.MediaInsightsRuntimeMetadata.Add((String)hashKey, (String)(this.MediaInsightsRuntimeMetadata[hashKey]));
                }
            }
            context.S3RecordingSinkRuntimeConfiguration_Destination = this.S3RecordingSinkRuntimeConfiguration_Destination;
            context.S3RecordingSinkRuntimeConfiguration_RecordingFileFormat = this.S3RecordingSinkRuntimeConfiguration_RecordingFileFormat;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKMediaPipelines.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate KinesisVideoStreamRecordingSourceRuntimeConfiguration
            var requestKinesisVideoStreamRecordingSourceRuntimeConfigurationIsNull = true;
            request.KinesisVideoStreamRecordingSourceRuntimeConfiguration = new Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamRecordingSourceRuntimeConfiguration();
            List<Amazon.ChimeSDKMediaPipelines.Model.RecordingStreamConfiguration> requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream = null;
            if (cmdletContext.KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream = cmdletContext.KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream;
            }
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream != null)
            {
                request.KinesisVideoStreamRecordingSourceRuntimeConfiguration.Streams = requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream;
                requestKinesisVideoStreamRecordingSourceRuntimeConfigurationIsNull = false;
            }
            Amazon.ChimeSDKMediaPipelines.Model.FragmentSelector requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector = null;
            
             // populate FragmentSelector
            var requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelectorIsNull = true;
            requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector = new Amazon.ChimeSDKMediaPipelines.Model.FragmentSelector();
            Amazon.ChimeSDKMediaPipelines.FragmentSelectorType requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_fragmentSelector_FragmentSelectorType = null;
            if (cmdletContext.FragmentSelector_FragmentSelectorType != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_fragmentSelector_FragmentSelectorType = cmdletContext.FragmentSelector_FragmentSelectorType;
            }
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_fragmentSelector_FragmentSelectorType != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector.FragmentSelectorType = requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_fragmentSelector_FragmentSelectorType;
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelectorIsNull = false;
            }
            Amazon.ChimeSDKMediaPipelines.Model.TimestampRange requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange = null;
            
             // populate TimestampRange
            var requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRangeIsNull = true;
            requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange = new Amazon.ChimeSDKMediaPipelines.Model.TimestampRange();
            System.DateTime? requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_EndTimestamp = null;
            if (cmdletContext.TimestampRange_EndTimestamp != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_EndTimestamp = cmdletContext.TimestampRange_EndTimestamp.Value;
            }
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_EndTimestamp != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange.EndTimestamp = requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_EndTimestamp.Value;
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRangeIsNull = false;
            }
            System.DateTime? requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_StartTimestamp = null;
            if (cmdletContext.TimestampRange_StartTimestamp != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_StartTimestamp = cmdletContext.TimestampRange_StartTimestamp.Value;
            }
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_StartTimestamp != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange.StartTimestamp = requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange_timestampRange_StartTimestamp.Value;
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRangeIsNull = false;
            }
             // determine if requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange should be set to null
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRangeIsNull)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange = null;
            }
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange != null)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector.TimestampRange = requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector_TimestampRange;
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelectorIsNull = false;
            }
             // determine if requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector should be set to null
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelectorIsNull)
            {
                requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector = null;
            }
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector != null)
            {
                request.KinesisVideoStreamRecordingSourceRuntimeConfiguration.FragmentSelector = requestKinesisVideoStreamRecordingSourceRuntimeConfiguration_kinesisVideoStreamRecordingSourceRuntimeConfiguration_FragmentSelector;
                requestKinesisVideoStreamRecordingSourceRuntimeConfigurationIsNull = false;
            }
             // determine if request.KinesisVideoStreamRecordingSourceRuntimeConfiguration should be set to null
            if (requestKinesisVideoStreamRecordingSourceRuntimeConfigurationIsNull)
            {
                request.KinesisVideoStreamRecordingSourceRuntimeConfiguration = null;
            }
            
             // populate KinesisVideoStreamSourceRuntimeConfiguration
            var requestKinesisVideoStreamSourceRuntimeConfigurationIsNull = true;
            request.KinesisVideoStreamSourceRuntimeConfiguration = new Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamSourceRuntimeConfiguration();
            Amazon.ChimeSDKMediaPipelines.MediaEncoding requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding = null;
            if (cmdletContext.KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding != null)
            {
                requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding = cmdletContext.KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding;
            }
            if (requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding != null)
            {
                request.KinesisVideoStreamSourceRuntimeConfiguration.MediaEncoding = requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding;
                requestKinesisVideoStreamSourceRuntimeConfigurationIsNull = false;
            }
            System.Int32? requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate = null;
            if (cmdletContext.KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate != null)
            {
                requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate = cmdletContext.KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate.Value;
            }
            if (requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate != null)
            {
                request.KinesisVideoStreamSourceRuntimeConfiguration.MediaSampleRate = requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate.Value;
                requestKinesisVideoStreamSourceRuntimeConfigurationIsNull = false;
            }
            List<Amazon.ChimeSDKMediaPipelines.Model.StreamConfiguration> requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_Stream = null;
            if (cmdletContext.KinesisVideoStreamSourceRuntimeConfiguration_Stream != null)
            {
                requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_Stream = cmdletContext.KinesisVideoStreamSourceRuntimeConfiguration_Stream;
            }
            if (requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_Stream != null)
            {
                request.KinesisVideoStreamSourceRuntimeConfiguration.Streams = requestKinesisVideoStreamSourceRuntimeConfiguration_kinesisVideoStreamSourceRuntimeConfiguration_Stream;
                requestKinesisVideoStreamSourceRuntimeConfigurationIsNull = false;
            }
             // determine if request.KinesisVideoStreamSourceRuntimeConfiguration should be set to null
            if (requestKinesisVideoStreamSourceRuntimeConfigurationIsNull)
            {
                request.KinesisVideoStreamSourceRuntimeConfiguration = null;
            }
            if (cmdletContext.MediaInsightsPipelineConfigurationArn != null)
            {
                request.MediaInsightsPipelineConfigurationArn = cmdletContext.MediaInsightsPipelineConfigurationArn;
            }
            if (cmdletContext.MediaInsightsRuntimeMetadata != null)
            {
                request.MediaInsightsRuntimeMetadata = cmdletContext.MediaInsightsRuntimeMetadata;
            }
            
             // populate S3RecordingSinkRuntimeConfiguration
            var requestS3RecordingSinkRuntimeConfigurationIsNull = true;
            request.S3RecordingSinkRuntimeConfiguration = new Amazon.ChimeSDKMediaPipelines.Model.S3RecordingSinkRuntimeConfiguration();
            System.String requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_Destination = null;
            if (cmdletContext.S3RecordingSinkRuntimeConfiguration_Destination != null)
            {
                requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_Destination = cmdletContext.S3RecordingSinkRuntimeConfiguration_Destination;
            }
            if (requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_Destination != null)
            {
                request.S3RecordingSinkRuntimeConfiguration.Destination = requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_Destination;
                requestS3RecordingSinkRuntimeConfigurationIsNull = false;
            }
            Amazon.ChimeSDKMediaPipelines.RecordingFileFormat requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_RecordingFileFormat = null;
            if (cmdletContext.S3RecordingSinkRuntimeConfiguration_RecordingFileFormat != null)
            {
                requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_RecordingFileFormat = cmdletContext.S3RecordingSinkRuntimeConfiguration_RecordingFileFormat;
            }
            if (requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_RecordingFileFormat != null)
            {
                request.S3RecordingSinkRuntimeConfiguration.RecordingFileFormat = requestS3RecordingSinkRuntimeConfiguration_s3RecordingSinkRuntimeConfiguration_RecordingFileFormat;
                requestS3RecordingSinkRuntimeConfigurationIsNull = false;
            }
             // determine if request.S3RecordingSinkRuntimeConfiguration should be set to null
            if (requestS3RecordingSinkRuntimeConfigurationIsNull)
            {
                request.S3RecordingSinkRuntimeConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse CallAWSServiceOperation(IAmazonChimeSDKMediaPipelines client, Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Media Pipelines", "CreateMediaInsightsPipeline");
            try
            {
                #if DESKTOP
                return client.CreateMediaInsightsPipeline(request);
                #elif CORECLR
                return client.CreateMediaInsightsPipelineAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKMediaPipelines.FragmentSelectorType FragmentSelector_FragmentSelectorType { get; set; }
            public System.DateTime? TimestampRange_EndTimestamp { get; set; }
            public System.DateTime? TimestampRange_StartTimestamp { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.RecordingStreamConfiguration> KinesisVideoStreamRecordingSourceRuntimeConfiguration_Stream { get; set; }
            public Amazon.ChimeSDKMediaPipelines.MediaEncoding KinesisVideoStreamSourceRuntimeConfiguration_MediaEncoding { get; set; }
            public System.Int32? KinesisVideoStreamSourceRuntimeConfiguration_MediaSampleRate { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.StreamConfiguration> KinesisVideoStreamSourceRuntimeConfiguration_Stream { get; set; }
            public System.String MediaInsightsPipelineConfigurationArn { get; set; }
            public Dictionary<System.String, System.String> MediaInsightsRuntimeMetadata { get; set; }
            public System.String S3RecordingSinkRuntimeConfiguration_Destination { get; set; }
            public Amazon.ChimeSDKMediaPipelines.RecordingFileFormat S3RecordingSinkRuntimeConfiguration_RecordingFileFormat { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineResponse, NewCHMMPMediaInsightsPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MediaInsightsPipeline;
        }
        
    }
}
