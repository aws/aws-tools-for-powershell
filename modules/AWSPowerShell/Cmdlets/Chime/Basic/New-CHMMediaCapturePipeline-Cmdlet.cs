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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Creates a media capture pipeline.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_media-pipelines-chime_CreateMediaCapturePipeline">CreateMediaCapturePipeline</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "CHMMediaCapturePipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.MediaCapturePipeline")]
    [AWSCmdlet("Calls the Amazon Chime CreateMediaCapturePipeline API operation.", Operation = new[] {"CreateMediaCapturePipeline"}, SelectReturnType = typeof(Amazon.Chime.Model.CreateMediaCapturePipelineResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.MediaCapturePipeline or Amazon.Chime.Model.CreateMediaCapturePipelineResponse",
        "This cmdlet returns an Amazon.Chime.Model.MediaCapturePipeline object.",
        "The service call response (type Amazon.Chime.Model.CreateMediaCapturePipelineResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by CreateMediaCapturePipeline in the Amazon Chime SDK Media Pipelines Namespace")]
    public partial class NewCHMMediaCapturePipelineCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SelectedVideoStreams_AttendeeId
        /// <summary>
        /// <para>
        /// <para>The attendee IDs of the streams selected for a media capture pipeline. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_AttendeeIds")]
        public System.String[] SelectedVideoStreams_AttendeeId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the client request. The token makes the API request idempotent.
        /// Use a different token for different media pipeline requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SelectedVideoStreams_ExternalUserId
        /// <summary>
        /// <para>
        /// <para>The external user IDs of the streams selected for a media capture pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_ExternalUserIds")]
        public System.String[] SelectedVideoStreams_ExternalUserId { get; set; }
        #endregion
        
        #region Parameter Audio_MuxType
        /// <summary>
        /// <para>
        /// <para>The MUX type of the audio artifact configuration object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_MuxType")]
        [AWSConstantClassSource("Amazon.Chime.AudioMuxType")]
        public Amazon.Chime.AudioMuxType Audio_MuxType { get; set; }
        #endregion
        
        #region Parameter Content_MuxType
        /// <summary>
        /// <para>
        /// <para>The MUX type of the artifact configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_MuxType")]
        [AWSConstantClassSource("Amazon.Chime.ContentMuxType")]
        public Amazon.Chime.ContentMuxType Content_MuxType { get; set; }
        #endregion
        
        #region Parameter Video_MuxType
        /// <summary>
        /// <para>
        /// <para>The MUX type of the video artifact configuration object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_MuxType")]
        [AWSConstantClassSource("Amazon.Chime.VideoMuxType")]
        public Amazon.Chime.VideoMuxType Video_MuxType { get; set; }
        #endregion
        
        #region Parameter SinkArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the sink type.</para>
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
        public System.String SinkArn { get; set; }
        #endregion
        
        #region Parameter SinkType
        /// <summary>
        /// <para>
        /// <para>Destination type to which the media artifacts are saved. You must use an S3 bucket.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Chime.MediaPipelineSinkType")]
        public Amazon.Chime.MediaPipelineSinkType SinkType { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>ARN of the source from which the media artifacts are captured.</para>
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
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>Source type from which the media artifacts will be captured. A Chime SDK Meeting is
        /// the only supported source.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Chime.MediaPipelineSourceType")]
        public Amazon.Chime.MediaPipelineSourceType SourceType { get; set; }
        #endregion
        
        #region Parameter Content_State
        /// <summary>
        /// <para>
        /// <para>Indicates whether the content artifact is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_State")]
        [AWSConstantClassSource("Amazon.Chime.ArtifactsState")]
        public Amazon.Chime.ArtifactsState Content_State { get; set; }
        #endregion
        
        #region Parameter Video_State
        /// <summary>
        /// <para>
        /// <para>Indicates whether the video artifact is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_State")]
        [AWSConstantClassSource("Amazon.Chime.ArtifactsState")]
        public Amazon.Chime.ArtifactsState Video_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MediaCapturePipeline'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.CreateMediaCapturePipelineResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.CreateMediaCapturePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MediaCapturePipeline";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMMediaCapturePipeline (CreateMediaCapturePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.CreateMediaCapturePipelineResponse, NewCHMMediaCapturePipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Audio_MuxType = this.Audio_MuxType;
            context.Content_MuxType = this.Content_MuxType;
            context.Content_State = this.Content_State;
            context.Video_MuxType = this.Video_MuxType;
            context.Video_State = this.Video_State;
            if (this.SelectedVideoStreams_AttendeeId != null)
            {
                context.SelectedVideoStreams_AttendeeId = new List<System.String>(this.SelectedVideoStreams_AttendeeId);
            }
            if (this.SelectedVideoStreams_ExternalUserId != null)
            {
                context.SelectedVideoStreams_ExternalUserId = new List<System.String>(this.SelectedVideoStreams_ExternalUserId);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.SinkArn = this.SinkArn;
            #if MODULAR
            if (this.SinkArn == null && ParameterWasBound(nameof(this.SinkArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SinkArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SinkType = this.SinkType;
            #if MODULAR
            if (this.SinkType == null && ParameterWasBound(nameof(this.SinkType)))
            {
                WriteWarning("You are passing $null as a value for parameter SinkType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceArn = this.SourceArn;
            #if MODULAR
            if (this.SourceArn == null && ParameterWasBound(nameof(this.SourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceType = this.SourceType;
            #if MODULAR
            if (this.SourceType == null && ParameterWasBound(nameof(this.SourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.CreateMediaCapturePipelineRequest();
            
            
             // populate ChimeSdkMeetingConfiguration
            var requestChimeSdkMeetingConfigurationIsNull = true;
            request.ChimeSdkMeetingConfiguration = new Amazon.Chime.Model.ChimeSdkMeetingConfiguration();
            Amazon.Chime.Model.SourceConfiguration requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration = null;
            
             // populate SourceConfiguration
            var requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfigurationIsNull = true;
            requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration = new Amazon.Chime.Model.SourceConfiguration();
            Amazon.Chime.Model.SelectedVideoStreams requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams = null;
            
             // populate SelectedVideoStreams
            var requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreamsIsNull = true;
            requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams = new Amazon.Chime.Model.SelectedVideoStreams();
            List<System.String> requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_AttendeeId = null;
            if (cmdletContext.SelectedVideoStreams_AttendeeId != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_AttendeeId = cmdletContext.SelectedVideoStreams_AttendeeId;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_AttendeeId != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams.AttendeeIds = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_AttendeeId;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreamsIsNull = false;
            }
            List<System.String> requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_ExternalUserId = null;
            if (cmdletContext.SelectedVideoStreams_ExternalUserId != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_ExternalUserId = cmdletContext.SelectedVideoStreams_ExternalUserId;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_ExternalUserId != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams.ExternalUserIds = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams_selectedVideoStreams_ExternalUserId;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreamsIsNull = false;
            }
             // determine if requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams should be set to null
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreamsIsNull)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams = null;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration.SelectedVideoStreams = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration_SelectedVideoStreams;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfigurationIsNull = false;
            }
             // determine if requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration should be set to null
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfigurationIsNull)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration = null;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration != null)
            {
                request.ChimeSdkMeetingConfiguration.SourceConfiguration = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_SourceConfiguration;
                requestChimeSdkMeetingConfigurationIsNull = false;
            }
            Amazon.Chime.Model.ArtifactsConfiguration requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration = null;
            
             // populate ArtifactsConfiguration
            var requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfigurationIsNull = true;
            requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration = new Amazon.Chime.Model.ArtifactsConfiguration();
            Amazon.Chime.Model.AudioArtifactsConfiguration requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio = null;
            
             // populate Audio
            var requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_AudioIsNull = true;
            requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio = new Amazon.Chime.Model.AudioArtifactsConfiguration();
            Amazon.Chime.AudioMuxType requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_audio_MuxType = null;
            if (cmdletContext.Audio_MuxType != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_audio_MuxType = cmdletContext.Audio_MuxType;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_audio_MuxType != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio.MuxType = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_audio_MuxType;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_AudioIsNull = false;
            }
             // determine if requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio should be set to null
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_AudioIsNull)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio = null;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration.Audio = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfigurationIsNull = false;
            }
            Amazon.Chime.Model.ContentArtifactsConfiguration requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content = null;
            
             // populate Content
            var requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_ContentIsNull = true;
            requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content = new Amazon.Chime.Model.ContentArtifactsConfiguration();
            Amazon.Chime.ContentMuxType requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_MuxType = null;
            if (cmdletContext.Content_MuxType != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_MuxType = cmdletContext.Content_MuxType;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_MuxType != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content.MuxType = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_MuxType;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_ContentIsNull = false;
            }
            Amazon.Chime.ArtifactsState requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_State = null;
            if (cmdletContext.Content_State != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_State = cmdletContext.Content_State;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_State != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content.State = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_content_State;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_ContentIsNull = false;
            }
             // determine if requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content should be set to null
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_ContentIsNull)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content = null;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration.Content = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Content;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfigurationIsNull = false;
            }
            Amazon.Chime.Model.VideoArtifactsConfiguration requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video = null;
            
             // populate Video
            var requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_VideoIsNull = true;
            requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video = new Amazon.Chime.Model.VideoArtifactsConfiguration();
            Amazon.Chime.VideoMuxType requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_MuxType = null;
            if (cmdletContext.Video_MuxType != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_MuxType = cmdletContext.Video_MuxType;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_MuxType != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video.MuxType = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_MuxType;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_VideoIsNull = false;
            }
            Amazon.Chime.ArtifactsState requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_State = null;
            if (cmdletContext.Video_State != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_State = cmdletContext.Video_State;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_State != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video.State = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_video_State;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_VideoIsNull = false;
            }
             // determine if requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video should be set to null
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_VideoIsNull)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video = null;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video != null)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration.Video = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration_Video;
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfigurationIsNull = false;
            }
             // determine if requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration should be set to null
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfigurationIsNull)
            {
                requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration = null;
            }
            if (requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration != null)
            {
                request.ChimeSdkMeetingConfiguration.ArtifactsConfiguration = requestChimeSdkMeetingConfiguration_chimeSdkMeetingConfiguration_ArtifactsConfiguration;
                requestChimeSdkMeetingConfigurationIsNull = false;
            }
             // determine if request.ChimeSdkMeetingConfiguration should be set to null
            if (requestChimeSdkMeetingConfigurationIsNull)
            {
                request.ChimeSdkMeetingConfiguration = null;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.SinkArn != null)
            {
                request.SinkArn = cmdletContext.SinkArn;
            }
            if (cmdletContext.SinkType != null)
            {
                request.SinkType = cmdletContext.SinkType;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
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
        
        private Amazon.Chime.Model.CreateMediaCapturePipelineResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.CreateMediaCapturePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "CreateMediaCapturePipeline");
            try
            {
                #if DESKTOP
                return client.CreateMediaCapturePipeline(request);
                #elif CORECLR
                return client.CreateMediaCapturePipelineAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Chime.AudioMuxType Audio_MuxType { get; set; }
            public Amazon.Chime.ContentMuxType Content_MuxType { get; set; }
            public Amazon.Chime.ArtifactsState Content_State { get; set; }
            public Amazon.Chime.VideoMuxType Video_MuxType { get; set; }
            public Amazon.Chime.ArtifactsState Video_State { get; set; }
            public List<System.String> SelectedVideoStreams_AttendeeId { get; set; }
            public List<System.String> SelectedVideoStreams_ExternalUserId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String SinkArn { get; set; }
            public Amazon.Chime.MediaPipelineSinkType SinkType { get; set; }
            public System.String SourceArn { get; set; }
            public Amazon.Chime.MediaPipelineSourceType SourceType { get; set; }
            public System.Func<Amazon.Chime.Model.CreateMediaCapturePipelineResponse, NewCHMMediaCapturePipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MediaCapturePipeline;
        }
        
    }
}
