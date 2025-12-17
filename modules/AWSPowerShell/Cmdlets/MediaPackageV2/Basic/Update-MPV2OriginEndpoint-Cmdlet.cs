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
using Amazon.MediaPackageV2;
using Amazon.MediaPackageV2.Model;

namespace Amazon.PowerShell.Cmdlets.MPV2
{
    /// <summary>
    /// Update the specified origin endpoint. Edit the packaging preferences on an endpoint
    /// to optimize the viewing experience. You can't edit the name of the endpoint.
    /// 
    ///  
    /// <para>
    /// Any edits you make that impact the video output may not be reflected for a few minutes.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MPV2OriginEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage v2 UpdateOriginEndpoint API operation.", Operation = new[] {"UpdateOriginEndpoint"}, SelectReturnType = typeof(Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse",
        "This cmdlet returns an Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse object containing multiple properties."
    )]
    public partial class UpdateMPV2OriginEndpointCmdlet : AmazonMediaPackageV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Segment_Encryption_SpekeKeyProvider_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the certificate that you imported to AWS Certificate Manager to add content
        /// key encryption to this endpoint. For this feature to work, your DRM key provider must
        /// support content key encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Segment_Encryption_SpekeKeyProvider_CertificateArn { get; set; }
        #endregion
        
        #region Parameter ChannelGroupName
        /// <summary>
        /// <para>
        /// <para>The name that describes the channel group. The name is the primary identifier for
        /// the channel group, and must be unique for your account in the AWS Region.</para>
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
        public System.String ChannelGroupName { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name that describes the channel. The name is the primary identifier for the channel,
        /// and must be unique for your account in the AWS Region and channel group. </para>
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
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter EncryptionMethod_CmafEncryptionMethod
        /// <summary>
        /// <para>
        /// <para>The encryption method to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_EncryptionMethod_CmafEncryptionMethod")]
        [AWSConstantClassSource("Amazon.MediaPackageV2.CmafEncryptionMethod")]
        public Amazon.MediaPackageV2.CmafEncryptionMethod EncryptionMethod_CmafEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter Encryption_CmafExcludeSegmentDrmMetadata
        /// <summary>
        /// <para>
        /// <para>Excludes SEIG and SGPD boxes from segment metadata in CMAF containers.</para><para>When set to <c>true</c>, MediaPackage omits these DRM metadata boxes from CMAF segments,
        /// which can improve compatibility with certain devices and players that don't support
        /// these boxes.</para><para>Important considerations:</para><ul><li><para>This setting only affects CMAF container formats</para></li><li><para>Key rotation can still be handled through media playlist signaling</para></li><li><para>PSSH and TENC boxes remain unaffected</para></li><li><para>Default behavior is preserved when this setting is disabled</para></li></ul><para>Valid values: <c>true</c> | <c>false</c></para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_CmafExcludeSegmentDrmMetadata")]
        public System.Boolean? Encryption_CmafExcludeSegmentDrmMetadata { get; set; }
        #endregion
        
        #region Parameter Encryption_ConstantInitializationVector
        /// <summary>
        /// <para>
        /// <para>A 128-bit, 16-byte hex value represented by a 32-character string, used in conjunction
        /// with the key for encrypting content. If you don't specify a value, then MediaPackage
        /// creates the constant initialization vector (IV).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_ConstantInitializationVector")]
        public System.String Encryption_ConstantInitializationVector { get; set; }
        #endregion
        
        #region Parameter ContainerType
        /// <summary>
        /// <para>
        /// <para>The type of container attached to this origin endpoint. A container type is a file
        /// format that encapsulates one or more media streams, such as audio and video, into
        /// a single file. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MediaPackageV2.ContainerType")]
        public Amazon.MediaPackageV2.ContainerType ContainerType { get; set; }
        #endregion
        
        #region Parameter DashManifest
        /// <summary>
        /// <para>
        /// <para>A DASH manifest configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashManifests")]
        public Amazon.MediaPackageV2.Model.CreateDashManifestConfiguration[] DashManifest { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Any descriptive information that you want to add to the origin endpoint for future
        /// identification purposes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_DrmSystem
        /// <summary>
        /// <para>
        /// <para>The DRM solution provider you're using to protect your content during distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_SpekeKeyProvider_DrmSystems")]
        public System.String[] SpekeKeyProvider_DrmSystem { get; set; }
        #endregion
        
        #region Parameter ForceEndpointErrorConfiguration_EndpointErrorCondition
        /// <summary>
        /// <para>
        /// <para>The failover conditions for the endpoint. The options are:</para><ul><li><para><c>STALE_MANIFEST</c> - The manifest stalled and there are no new segments or parts.</para></li><li><para><c>INCOMPLETE_MANIFEST</c> - There is a gap in the manifest.</para></li><li><para><c>MISSING_DRM_KEY</c> - Key rotation is enabled but we're unable to fetch the key
        /// for the current key period.</para></li><li><para><c>SLATE_INPUT</c> - The segments which contain slate content are considered to be
        /// missing content.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ForceEndpointErrorConfiguration_EndpointErrorConditions")]
        public System.String[] ForceEndpointErrorConfiguration_EndpointErrorCondition { get; set; }
        #endregion
        
        #region Parameter HlsManifest
        /// <summary>
        /// <para>
        /// <para>An HTTP live streaming (HLS) manifest configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HlsManifests")]
        public Amazon.MediaPackageV2.Model.CreateHlsManifestConfiguration[] HlsManifest { get; set; }
        #endregion
        
        #region Parameter Segment_IncludeIframeOnlyStream
        /// <summary>
        /// <para>
        /// <para>When selected, the stream set includes an additional I-frame only stream, along with
        /// the other tracks. If false, this extra stream is not included. MediaPackage generates
        /// an I-frame only stream from the first rendition in the manifest. The service inserts
        /// EXT-I-FRAMES-ONLY tags in the output manifest, and then generates and includes an
        /// I-frames only playlist in the stream. This playlist permits player functionality like
        /// fast forward and rewind.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_IncludeIframeOnlyStreams")]
        public System.Boolean? Segment_IncludeIframeOnlyStream { get; set; }
        #endregion
        
        #region Parameter EncryptionMethod_IsmEncryptionMethod
        /// <summary>
        /// <para>
        /// <para>The encryption method used for Microsoft Smooth Streaming (MSS) content. This specifies
        /// how the MSS segments are encrypted to protect the content during delivery to client
        /// players.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_EncryptionMethod_IsmEncryptionMethod")]
        [AWSConstantClassSource("Amazon.MediaPackageV2.IsmEncryptionMethod")]
        public Amazon.MediaPackageV2.IsmEncryptionMethod EncryptionMethod_IsmEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter Encryption_KeyRotationIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The frequency (in seconds) of key changes for live workflows, in which content is
        /// streamed real time. The service retrieves content keys before the live content begins
        /// streaming, and then retrieves them as needed over the lifetime of the workflow. By
        /// default, key rotation is set to 300 seconds (5 minutes), the minimum rotation interval,
        /// which is equivalent to setting it to 300. If you don't enter an interval, content
        /// keys aren't rotated.</para><para>The following example setting causes the service to rotate keys every thirty minutes:
        /// <c>1800</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_KeyRotationIntervalSeconds")]
        public System.Int32? Encryption_KeyRotationIntervalSecond { get; set; }
        #endregion
        
        #region Parameter LowLatencyHlsManifest
        /// <summary>
        /// <para>
        /// <para>A low-latency HLS manifest configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LowLatencyHlsManifests")]
        public Amazon.MediaPackageV2.Model.CreateLowLatencyHlsManifestConfiguration[] LowLatencyHlsManifest { get; set; }
        #endregion
        
        #region Parameter MssManifest
        /// <summary>
        /// <para>
        /// <para>A list of Microsoft Smooth Streaming (MSS) manifest configurations to update for the
        /// origin endpoint. This replaces the existing MSS manifest configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MssManifests")]
        public Amazon.MediaPackageV2.Model.CreateMssManifestConfiguration[] MssManifest { get; set; }
        #endregion
        
        #region Parameter OriginEndpointName
        /// <summary>
        /// <para>
        /// <para>The name that describes the origin endpoint. The name is the primary identifier for
        /// the origin endpoint, and and must be unique for your account in the AWS Region and
        /// channel. </para>
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
        public System.String OriginEndpointName { get; set; }
        #endregion
        
        #region Parameter EncryptionContractConfiguration_PresetSpeke20Audio
        /// <summary>
        /// <para>
        /// <para>A collection of audio encryption presets.</para><para>Value description: </para><ul><li><para>PRESET-AUDIO-1 - Use one content key to encrypt all of the audio tracks in your stream.</para></li><li><para>PRESET-AUDIO-2 - Use one content key to encrypt all of the stereo audio tracks and
        /// one content key to encrypt all of the multichannel audio tracks.</para></li><li><para>PRESET-AUDIO-3 - Use one content key to encrypt all of the stereo audio tracks, one
        /// content key to encrypt all of the multichannel audio tracks with 3 to 6 channels,
        /// and one content key to encrypt all of the multichannel audio tracks with more than
        /// 6 channels.</para></li><li><para>SHARED - Use the same content key for all of the audio and video tracks in your stream.</para></li><li><para>UNENCRYPTED - Don't encrypt any of the audio tracks in your stream.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Audio")]
        [AWSConstantClassSource("Amazon.MediaPackageV2.PresetSpeke20Audio")]
        public Amazon.MediaPackageV2.PresetSpeke20Audio EncryptionContractConfiguration_PresetSpeke20Audio { get; set; }
        #endregion
        
        #region Parameter EncryptionContractConfiguration_PresetSpeke20Video
        /// <summary>
        /// <para>
        /// <para>A collection of video encryption presets.</para><para>Value description: </para><ul><li><para>PRESET-VIDEO-1 - Use one content key to encrypt all of the video tracks in your stream.</para></li><li><para>PRESET-VIDEO-2 - Use one content key to encrypt all of the SD video tracks and one
        /// content key for all HD and higher resolutions video tracks.</para></li><li><para>PRESET-VIDEO-3 - Use one content key to encrypt all of the SD video tracks, one content
        /// key for HD video tracks and one content key for all UHD video tracks.</para></li><li><para>PRESET-VIDEO-4 - Use one content key to encrypt all of the SD video tracks, one content
        /// key for HD video tracks, one content key for all UHD1 video tracks and one content
        /// key for all UHD2 video tracks.</para></li><li><para>PRESET-VIDEO-5 - Use one content key to encrypt all of the SD video tracks, one content
        /// key for HD1 video tracks, one content key for HD2 video tracks, one content key for
        /// all UHD1 video tracks and one content key for all UHD2 video tracks.</para></li><li><para>PRESET-VIDEO-6 - Use one content key to encrypt all of the SD video tracks, one content
        /// key for HD1 video tracks, one content key for HD2 video tracks and one content key
        /// for all UHD video tracks.</para></li><li><para>PRESET-VIDEO-7 - Use one content key to encrypt all of the SD+HD1 video tracks, one
        /// content key for HD2 video tracks and one content key for all UHD video tracks.</para></li><li><para>PRESET-VIDEO-8 - Use one content key to encrypt all of the SD+HD1 video tracks, one
        /// content key for HD2 video tracks, one content key for all UHD1 video tracks and one
        /// content key for all UHD2 video tracks.</para></li><li><para>SHARED - Use the same content key for all of the video and audio tracks in your stream.</para></li><li><para>UNENCRYPTED - Don't encrypt any of the video tracks in your stream.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Video")]
        [AWSConstantClassSource("Amazon.MediaPackageV2.PresetSpeke20Video")]
        public Amazon.MediaPackageV2.PresetSpeke20Video EncryptionContractConfiguration_PresetSpeke20Video { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_ResourceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the content. The service sends this to the key server to
        /// identify the current endpoint. How unique you make this depends on how fine-grained
        /// you want access controls to be. The service does not permit you to use the same ID
        /// for two simultaneous encryption processes. The resource ID is also known as the content
        /// ID.</para><para>The following example shows a resource ID: <c>MovieNight20171126093045</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_SpekeKeyProvider_ResourceId")]
        public System.String SpekeKeyProvider_ResourceId { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role granted by the key provider that provides access to the key
        /// provider API. This role must have a trust policy that allows MediaPackage to assume
        /// the role, and it must have a sufficient permissions policy to allow access to the
        /// specific key retrieval URL. Get this from your DRM solution provider.</para><para>Valid format: <c>arn:aws:iam::{accountID}:role/{name}</c>. The following example shows
        /// a role ARN: <c>arn:aws:iam::444455556666:role/SpekeAccess</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_SpekeKeyProvider_RoleArn")]
        public System.String SpekeKeyProvider_RoleArn { get; set; }
        #endregion
        
        #region Parameter Scte_ScteFilter
        /// <summary>
        /// <para>
        /// <para>The SCTE-35 message types that you want to be treated as ad markers in the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Scte_ScteFilter")]
        public System.String[] Scte_ScteFilter { get; set; }
        #endregion
        
        #region Parameter Scte_ScteInSegment
        /// <summary>
        /// <para>
        /// <para>Controls whether SCTE-35 messages are included in segment files.</para><ul><li><para>None – SCTE-35 messages are not included in segments (default)</para></li><li><para>All – SCTE-35 messages are embedded in segment data</para></li></ul><para> For DASH manifests, when set to <c>All</c>, an <c>InbandEventStream</c> tag signals
        /// that SCTE messages are present in segments. This setting works independently of manifest
        /// ad markers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Scte_ScteInSegments")]
        [AWSConstantClassSource("Amazon.MediaPackageV2.ScteInSegments")]
        public Amazon.MediaPackageV2.ScteInSegments Scte_ScteInSegment { get; set; }
        #endregion
        
        #region Parameter Segment_SegmentDurationSecond
        /// <summary>
        /// <para>
        /// <para>The duration (in seconds) of each segment. Enter a value equal to, or a multiple of,
        /// the input segment duration. If the value that you enter is different from the input
        /// segment duration, MediaPackage rounds segments to the nearest multiple of the input
        /// segment duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_SegmentDurationSeconds")]
        public System.Int32? Segment_SegmentDurationSecond { get; set; }
        #endregion
        
        #region Parameter Segment_SegmentName
        /// <summary>
        /// <para>
        /// <para>The name that describes the segment. The name is the base name of the segment used
        /// in all content manifests inside of the endpoint. You can't use spaces in the name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Segment_SegmentName { get; set; }
        #endregion
        
        #region Parameter StartoverWindowSecond
        /// <summary>
        /// <para>
        /// <para>The size of the window (in seconds) to create a window of the live stream that's available
        /// for on-demand viewing. Viewers can start-over or catch-up on content that falls within
        /// the window. The maximum startover window is 1,209,600 seconds (14 days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartoverWindowSeconds")]
        public System.Int32? StartoverWindowSecond { get; set; }
        #endregion
        
        #region Parameter EncryptionMethod_TsEncryptionMethod
        /// <summary>
        /// <para>
        /// <para>The encryption method to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_EncryptionMethod_TsEncryptionMethod")]
        [AWSConstantClassSource("Amazon.MediaPackageV2.TsEncryptionMethod")]
        public Amazon.MediaPackageV2.TsEncryptionMethod EncryptionMethod_TsEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter Segment_TsIncludeDvbSubtitle
        /// <summary>
        /// <para>
        /// <para>By default, MediaPackage excludes all digital video broadcasting (DVB) subtitles from
        /// the output. When selected, MediaPackage passes through DVB subtitles into the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_TsIncludeDvbSubtitles")]
        public System.Boolean? Segment_TsIncludeDvbSubtitle { get; set; }
        #endregion
        
        #region Parameter Segment_TsUseAudioRenditionGroup
        /// <summary>
        /// <para>
        /// <para>When selected, MediaPackage bundles all audio tracks in a rendition group. All other
        /// tracks in the stream can be used with any audio rendition from the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Segment_TsUseAudioRenditionGroup { get; set; }
        #endregion
        
        #region Parameter SpekeKeyProvider_Url
        /// <summary>
        /// <para>
        /// <para>The URL of the API Gateway proxy that you set up to talk to your key server. The API
        /// Gateway proxy must reside in the same AWS Region as MediaPackage and must start with
        /// https://.</para><para>The following example shows a URL: <c>https://1wm2dx1f33.execute-api.us-west-2.amazonaws.com/SpekeSample/copyProtection</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Segment_Encryption_SpekeKeyProvider_Url")]
        public System.String SpekeKeyProvider_Url { get; set; }
        #endregion
        
        #region Parameter ETag
        /// <summary>
        /// <para>
        /// <para>The expected current Entity Tag (ETag) for the resource. If the specified ETag does
        /// not match the resource's current entity tag, the update request will be rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ETag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OriginEndpointName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OriginEndpointName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OriginEndpointName' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MPV2OriginEndpoint (UpdateOriginEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse, UpdateMPV2OriginEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OriginEndpointName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelGroupName = this.ChannelGroupName;
            #if MODULAR
            if (this.ChannelGroupName == null && ParameterWasBound(nameof(this.ChannelGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContainerType = this.ContainerType;
            #if MODULAR
            if (this.ContainerType == null && ParameterWasBound(nameof(this.ContainerType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DashManifest != null)
            {
                context.DashManifest = new List<Amazon.MediaPackageV2.Model.CreateDashManifestConfiguration>(this.DashManifest);
            }
            context.Description = this.Description;
            context.ETag = this.ETag;
            if (this.ForceEndpointErrorConfiguration_EndpointErrorCondition != null)
            {
                context.ForceEndpointErrorConfiguration_EndpointErrorCondition = new List<System.String>(this.ForceEndpointErrorConfiguration_EndpointErrorCondition);
            }
            if (this.HlsManifest != null)
            {
                context.HlsManifest = new List<Amazon.MediaPackageV2.Model.CreateHlsManifestConfiguration>(this.HlsManifest);
            }
            if (this.LowLatencyHlsManifest != null)
            {
                context.LowLatencyHlsManifest = new List<Amazon.MediaPackageV2.Model.CreateLowLatencyHlsManifestConfiguration>(this.LowLatencyHlsManifest);
            }
            if (this.MssManifest != null)
            {
                context.MssManifest = new List<Amazon.MediaPackageV2.Model.CreateMssManifestConfiguration>(this.MssManifest);
            }
            context.OriginEndpointName = this.OriginEndpointName;
            #if MODULAR
            if (this.OriginEndpointName == null && ParameterWasBound(nameof(this.OriginEndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginEndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Encryption_CmafExcludeSegmentDrmMetadata = this.Encryption_CmafExcludeSegmentDrmMetadata;
            context.Encryption_ConstantInitializationVector = this.Encryption_ConstantInitializationVector;
            context.EncryptionMethod_CmafEncryptionMethod = this.EncryptionMethod_CmafEncryptionMethod;
            context.EncryptionMethod_IsmEncryptionMethod = this.EncryptionMethod_IsmEncryptionMethod;
            context.EncryptionMethod_TsEncryptionMethod = this.EncryptionMethod_TsEncryptionMethod;
            context.Encryption_KeyRotationIntervalSecond = this.Encryption_KeyRotationIntervalSecond;
            context.Segment_Encryption_SpekeKeyProvider_CertificateArn = this.Segment_Encryption_SpekeKeyProvider_CertificateArn;
            if (this.SpekeKeyProvider_DrmSystem != null)
            {
                context.SpekeKeyProvider_DrmSystem = new List<System.String>(this.SpekeKeyProvider_DrmSystem);
            }
            context.EncryptionContractConfiguration_PresetSpeke20Audio = this.EncryptionContractConfiguration_PresetSpeke20Audio;
            context.EncryptionContractConfiguration_PresetSpeke20Video = this.EncryptionContractConfiguration_PresetSpeke20Video;
            context.SpekeKeyProvider_ResourceId = this.SpekeKeyProvider_ResourceId;
            context.SpekeKeyProvider_RoleArn = this.SpekeKeyProvider_RoleArn;
            context.SpekeKeyProvider_Url = this.SpekeKeyProvider_Url;
            context.Segment_IncludeIframeOnlyStream = this.Segment_IncludeIframeOnlyStream;
            if (this.Scte_ScteFilter != null)
            {
                context.Scte_ScteFilter = new List<System.String>(this.Scte_ScteFilter);
            }
            context.Scte_ScteInSegment = this.Scte_ScteInSegment;
            context.Segment_SegmentDurationSecond = this.Segment_SegmentDurationSecond;
            context.Segment_SegmentName = this.Segment_SegmentName;
            context.Segment_TsIncludeDvbSubtitle = this.Segment_TsIncludeDvbSubtitle;
            context.Segment_TsUseAudioRenditionGroup = this.Segment_TsUseAudioRenditionGroup;
            context.StartoverWindowSecond = this.StartoverWindowSecond;
            
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
            var request = new Amazon.MediaPackageV2.Model.UpdateOriginEndpointRequest();
            
            if (cmdletContext.ChannelGroupName != null)
            {
                request.ChannelGroupName = cmdletContext.ChannelGroupName;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ContainerType != null)
            {
                request.ContainerType = cmdletContext.ContainerType;
            }
            if (cmdletContext.DashManifest != null)
            {
                request.DashManifests = cmdletContext.DashManifest;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ETag != null)
            {
                request.ETag = cmdletContext.ETag;
            }
            
             // populate ForceEndpointErrorConfiguration
            var requestForceEndpointErrorConfigurationIsNull = true;
            request.ForceEndpointErrorConfiguration = new Amazon.MediaPackageV2.Model.ForceEndpointErrorConfiguration();
            List<System.String> requestForceEndpointErrorConfiguration_forceEndpointErrorConfiguration_EndpointErrorCondition = null;
            if (cmdletContext.ForceEndpointErrorConfiguration_EndpointErrorCondition != null)
            {
                requestForceEndpointErrorConfiguration_forceEndpointErrorConfiguration_EndpointErrorCondition = cmdletContext.ForceEndpointErrorConfiguration_EndpointErrorCondition;
            }
            if (requestForceEndpointErrorConfiguration_forceEndpointErrorConfiguration_EndpointErrorCondition != null)
            {
                request.ForceEndpointErrorConfiguration.EndpointErrorConditions = requestForceEndpointErrorConfiguration_forceEndpointErrorConfiguration_EndpointErrorCondition;
                requestForceEndpointErrorConfigurationIsNull = false;
            }
             // determine if request.ForceEndpointErrorConfiguration should be set to null
            if (requestForceEndpointErrorConfigurationIsNull)
            {
                request.ForceEndpointErrorConfiguration = null;
            }
            if (cmdletContext.HlsManifest != null)
            {
                request.HlsManifests = cmdletContext.HlsManifest;
            }
            if (cmdletContext.LowLatencyHlsManifest != null)
            {
                request.LowLatencyHlsManifests = cmdletContext.LowLatencyHlsManifest;
            }
            if (cmdletContext.MssManifest != null)
            {
                request.MssManifests = cmdletContext.MssManifest;
            }
            if (cmdletContext.OriginEndpointName != null)
            {
                request.OriginEndpointName = cmdletContext.OriginEndpointName;
            }
            
             // populate Segment
            var requestSegmentIsNull = true;
            request.Segment = new Amazon.MediaPackageV2.Model.Segment();
            System.Boolean? requestSegment_segment_IncludeIframeOnlyStream = null;
            if (cmdletContext.Segment_IncludeIframeOnlyStream != null)
            {
                requestSegment_segment_IncludeIframeOnlyStream = cmdletContext.Segment_IncludeIframeOnlyStream.Value;
            }
            if (requestSegment_segment_IncludeIframeOnlyStream != null)
            {
                request.Segment.IncludeIframeOnlyStreams = requestSegment_segment_IncludeIframeOnlyStream.Value;
                requestSegmentIsNull = false;
            }
            System.Int32? requestSegment_segment_SegmentDurationSecond = null;
            if (cmdletContext.Segment_SegmentDurationSecond != null)
            {
                requestSegment_segment_SegmentDurationSecond = cmdletContext.Segment_SegmentDurationSecond.Value;
            }
            if (requestSegment_segment_SegmentDurationSecond != null)
            {
                request.Segment.SegmentDurationSeconds = requestSegment_segment_SegmentDurationSecond.Value;
                requestSegmentIsNull = false;
            }
            System.String requestSegment_segment_SegmentName = null;
            if (cmdletContext.Segment_SegmentName != null)
            {
                requestSegment_segment_SegmentName = cmdletContext.Segment_SegmentName;
            }
            if (requestSegment_segment_SegmentName != null)
            {
                request.Segment.SegmentName = requestSegment_segment_SegmentName;
                requestSegmentIsNull = false;
            }
            System.Boolean? requestSegment_segment_TsIncludeDvbSubtitle = null;
            if (cmdletContext.Segment_TsIncludeDvbSubtitle != null)
            {
                requestSegment_segment_TsIncludeDvbSubtitle = cmdletContext.Segment_TsIncludeDvbSubtitle.Value;
            }
            if (requestSegment_segment_TsIncludeDvbSubtitle != null)
            {
                request.Segment.TsIncludeDvbSubtitles = requestSegment_segment_TsIncludeDvbSubtitle.Value;
                requestSegmentIsNull = false;
            }
            System.Boolean? requestSegment_segment_TsUseAudioRenditionGroup = null;
            if (cmdletContext.Segment_TsUseAudioRenditionGroup != null)
            {
                requestSegment_segment_TsUseAudioRenditionGroup = cmdletContext.Segment_TsUseAudioRenditionGroup.Value;
            }
            if (requestSegment_segment_TsUseAudioRenditionGroup != null)
            {
                request.Segment.TsUseAudioRenditionGroup = requestSegment_segment_TsUseAudioRenditionGroup.Value;
                requestSegmentIsNull = false;
            }
            Amazon.MediaPackageV2.Model.Scte requestSegment_segment_Scte = null;
            
             // populate Scte
            var requestSegment_segment_ScteIsNull = true;
            requestSegment_segment_Scte = new Amazon.MediaPackageV2.Model.Scte();
            List<System.String> requestSegment_segment_Scte_scte_ScteFilter = null;
            if (cmdletContext.Scte_ScteFilter != null)
            {
                requestSegment_segment_Scte_scte_ScteFilter = cmdletContext.Scte_ScteFilter;
            }
            if (requestSegment_segment_Scte_scte_ScteFilter != null)
            {
                requestSegment_segment_Scte.ScteFilter = requestSegment_segment_Scte_scte_ScteFilter;
                requestSegment_segment_ScteIsNull = false;
            }
            Amazon.MediaPackageV2.ScteInSegments requestSegment_segment_Scte_scte_ScteInSegment = null;
            if (cmdletContext.Scte_ScteInSegment != null)
            {
                requestSegment_segment_Scte_scte_ScteInSegment = cmdletContext.Scte_ScteInSegment;
            }
            if (requestSegment_segment_Scte_scte_ScteInSegment != null)
            {
                requestSegment_segment_Scte.ScteInSegments = requestSegment_segment_Scte_scte_ScteInSegment;
                requestSegment_segment_ScteIsNull = false;
            }
             // determine if requestSegment_segment_Scte should be set to null
            if (requestSegment_segment_ScteIsNull)
            {
                requestSegment_segment_Scte = null;
            }
            if (requestSegment_segment_Scte != null)
            {
                request.Segment.Scte = requestSegment_segment_Scte;
                requestSegmentIsNull = false;
            }
            Amazon.MediaPackageV2.Model.Encryption requestSegment_segment_Encryption = null;
            
             // populate Encryption
            var requestSegment_segment_EncryptionIsNull = true;
            requestSegment_segment_Encryption = new Amazon.MediaPackageV2.Model.Encryption();
            System.Boolean? requestSegment_segment_Encryption_encryption_CmafExcludeSegmentDrmMetadata = null;
            if (cmdletContext.Encryption_CmafExcludeSegmentDrmMetadata != null)
            {
                requestSegment_segment_Encryption_encryption_CmafExcludeSegmentDrmMetadata = cmdletContext.Encryption_CmafExcludeSegmentDrmMetadata.Value;
            }
            if (requestSegment_segment_Encryption_encryption_CmafExcludeSegmentDrmMetadata != null)
            {
                requestSegment_segment_Encryption.CmafExcludeSegmentDrmMetadata = requestSegment_segment_Encryption_encryption_CmafExcludeSegmentDrmMetadata.Value;
                requestSegment_segment_EncryptionIsNull = false;
            }
            System.String requestSegment_segment_Encryption_encryption_ConstantInitializationVector = null;
            if (cmdletContext.Encryption_ConstantInitializationVector != null)
            {
                requestSegment_segment_Encryption_encryption_ConstantInitializationVector = cmdletContext.Encryption_ConstantInitializationVector;
            }
            if (requestSegment_segment_Encryption_encryption_ConstantInitializationVector != null)
            {
                requestSegment_segment_Encryption.ConstantInitializationVector = requestSegment_segment_Encryption_encryption_ConstantInitializationVector;
                requestSegment_segment_EncryptionIsNull = false;
            }
            System.Int32? requestSegment_segment_Encryption_encryption_KeyRotationIntervalSecond = null;
            if (cmdletContext.Encryption_KeyRotationIntervalSecond != null)
            {
                requestSegment_segment_Encryption_encryption_KeyRotationIntervalSecond = cmdletContext.Encryption_KeyRotationIntervalSecond.Value;
            }
            if (requestSegment_segment_Encryption_encryption_KeyRotationIntervalSecond != null)
            {
                requestSegment_segment_Encryption.KeyRotationIntervalSeconds = requestSegment_segment_Encryption_encryption_KeyRotationIntervalSecond.Value;
                requestSegment_segment_EncryptionIsNull = false;
            }
            Amazon.MediaPackageV2.Model.EncryptionMethod requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod = null;
            
             // populate EncryptionMethod
            var requestSegment_segment_Encryption_segment_Encryption_EncryptionMethodIsNull = true;
            requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod = new Amazon.MediaPackageV2.Model.EncryptionMethod();
            Amazon.MediaPackageV2.CmafEncryptionMethod requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_CmafEncryptionMethod = null;
            if (cmdletContext.EncryptionMethod_CmafEncryptionMethod != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_CmafEncryptionMethod = cmdletContext.EncryptionMethod_CmafEncryptionMethod;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_CmafEncryptionMethod != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod.CmafEncryptionMethod = requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_CmafEncryptionMethod;
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethodIsNull = false;
            }
            Amazon.MediaPackageV2.IsmEncryptionMethod requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_IsmEncryptionMethod = null;
            if (cmdletContext.EncryptionMethod_IsmEncryptionMethod != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_IsmEncryptionMethod = cmdletContext.EncryptionMethod_IsmEncryptionMethod;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_IsmEncryptionMethod != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod.IsmEncryptionMethod = requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_IsmEncryptionMethod;
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethodIsNull = false;
            }
            Amazon.MediaPackageV2.TsEncryptionMethod requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_TsEncryptionMethod = null;
            if (cmdletContext.EncryptionMethod_TsEncryptionMethod != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_TsEncryptionMethod = cmdletContext.EncryptionMethod_TsEncryptionMethod;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_TsEncryptionMethod != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod.TsEncryptionMethod = requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod_encryptionMethod_TsEncryptionMethod;
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethodIsNull = false;
            }
             // determine if requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod should be set to null
            if (requestSegment_segment_Encryption_segment_Encryption_EncryptionMethodIsNull)
            {
                requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod = null;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod != null)
            {
                requestSegment_segment_Encryption.EncryptionMethod = requestSegment_segment_Encryption_segment_Encryption_EncryptionMethod;
                requestSegment_segment_EncryptionIsNull = false;
            }
            Amazon.MediaPackageV2.Model.SpekeKeyProvider requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider = null;
            
             // populate SpekeKeyProvider
            var requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = true;
            requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider = new Amazon.MediaPackageV2.Model.SpekeKeyProvider();
            System.String requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_CertificateArn = null;
            if (cmdletContext.Segment_Encryption_SpekeKeyProvider_CertificateArn != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_CertificateArn = cmdletContext.Segment_Encryption_SpekeKeyProvider_CertificateArn;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_CertificateArn != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider.CertificateArn = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_CertificateArn;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = false;
            }
            List<System.String> requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_DrmSystem = null;
            if (cmdletContext.SpekeKeyProvider_DrmSystem != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_DrmSystem = cmdletContext.SpekeKeyProvider_DrmSystem;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_DrmSystem != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider.DrmSystems = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_DrmSystem;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = false;
            }
            System.String requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId = null;
            if (cmdletContext.SpekeKeyProvider_ResourceId != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId = cmdletContext.SpekeKeyProvider_ResourceId;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider.ResourceId = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_ResourceId;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = false;
            }
            System.String requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn = null;
            if (cmdletContext.SpekeKeyProvider_RoleArn != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn = cmdletContext.SpekeKeyProvider_RoleArn;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider.RoleArn = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_RoleArn;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = false;
            }
            System.String requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_Url = null;
            if (cmdletContext.SpekeKeyProvider_Url != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_Url = cmdletContext.SpekeKeyProvider_Url;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_Url != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider.Url = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_spekeKeyProvider_Url;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = false;
            }
            Amazon.MediaPackageV2.Model.EncryptionContractConfiguration requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration = null;
            
             // populate EncryptionContractConfiguration
            var requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfigurationIsNull = true;
            requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration = new Amazon.MediaPackageV2.Model.EncryptionContractConfiguration();
            Amazon.MediaPackageV2.PresetSpeke20Audio requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Audio = null;
            if (cmdletContext.EncryptionContractConfiguration_PresetSpeke20Audio != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Audio = cmdletContext.EncryptionContractConfiguration_PresetSpeke20Audio;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Audio != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration.PresetSpeke20Audio = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Audio;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfigurationIsNull = false;
            }
            Amazon.MediaPackageV2.PresetSpeke20Video requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Video = null;
            if (cmdletContext.EncryptionContractConfiguration_PresetSpeke20Video != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Video = cmdletContext.EncryptionContractConfiguration_PresetSpeke20Video;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Video != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration.PresetSpeke20Video = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_encryptionContractConfiguration_PresetSpeke20Video;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfigurationIsNull = false;
            }
             // determine if requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration should be set to null
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfigurationIsNull)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration = null;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration != null)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider.EncryptionContractConfiguration = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider_segment_Encryption_SpekeKeyProvider_EncryptionContractConfiguration;
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull = false;
            }
             // determine if requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider should be set to null
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProviderIsNull)
            {
                requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider = null;
            }
            if (requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider != null)
            {
                requestSegment_segment_Encryption.SpekeKeyProvider = requestSegment_segment_Encryption_segment_Encryption_SpekeKeyProvider;
                requestSegment_segment_EncryptionIsNull = false;
            }
             // determine if requestSegment_segment_Encryption should be set to null
            if (requestSegment_segment_EncryptionIsNull)
            {
                requestSegment_segment_Encryption = null;
            }
            if (requestSegment_segment_Encryption != null)
            {
                request.Segment.Encryption = requestSegment_segment_Encryption;
                requestSegmentIsNull = false;
            }
             // determine if request.Segment should be set to null
            if (requestSegmentIsNull)
            {
                request.Segment = null;
            }
            if (cmdletContext.StartoverWindowSecond != null)
            {
                request.StartoverWindowSeconds = cmdletContext.StartoverWindowSecond.Value;
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
        
        private Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse CallAWSServiceOperation(IAmazonMediaPackageV2 client, Amazon.MediaPackageV2.Model.UpdateOriginEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage v2", "UpdateOriginEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateOriginEndpoint(request);
                #elif CORECLR
                return client.UpdateOriginEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelGroupName { get; set; }
            public System.String ChannelName { get; set; }
            public Amazon.MediaPackageV2.ContainerType ContainerType { get; set; }
            public List<Amazon.MediaPackageV2.Model.CreateDashManifestConfiguration> DashManifest { get; set; }
            public System.String Description { get; set; }
            public System.String ETag { get; set; }
            public List<System.String> ForceEndpointErrorConfiguration_EndpointErrorCondition { get; set; }
            public List<Amazon.MediaPackageV2.Model.CreateHlsManifestConfiguration> HlsManifest { get; set; }
            public List<Amazon.MediaPackageV2.Model.CreateLowLatencyHlsManifestConfiguration> LowLatencyHlsManifest { get; set; }
            public List<Amazon.MediaPackageV2.Model.CreateMssManifestConfiguration> MssManifest { get; set; }
            public System.String OriginEndpointName { get; set; }
            public System.Boolean? Encryption_CmafExcludeSegmentDrmMetadata { get; set; }
            public System.String Encryption_ConstantInitializationVector { get; set; }
            public Amazon.MediaPackageV2.CmafEncryptionMethod EncryptionMethod_CmafEncryptionMethod { get; set; }
            public Amazon.MediaPackageV2.IsmEncryptionMethod EncryptionMethod_IsmEncryptionMethod { get; set; }
            public Amazon.MediaPackageV2.TsEncryptionMethod EncryptionMethod_TsEncryptionMethod { get; set; }
            public System.Int32? Encryption_KeyRotationIntervalSecond { get; set; }
            public System.String Segment_Encryption_SpekeKeyProvider_CertificateArn { get; set; }
            public List<System.String> SpekeKeyProvider_DrmSystem { get; set; }
            public Amazon.MediaPackageV2.PresetSpeke20Audio EncryptionContractConfiguration_PresetSpeke20Audio { get; set; }
            public Amazon.MediaPackageV2.PresetSpeke20Video EncryptionContractConfiguration_PresetSpeke20Video { get; set; }
            public System.String SpekeKeyProvider_ResourceId { get; set; }
            public System.String SpekeKeyProvider_RoleArn { get; set; }
            public System.String SpekeKeyProvider_Url { get; set; }
            public System.Boolean? Segment_IncludeIframeOnlyStream { get; set; }
            public List<System.String> Scte_ScteFilter { get; set; }
            public Amazon.MediaPackageV2.ScteInSegments Scte_ScteInSegment { get; set; }
            public System.Int32? Segment_SegmentDurationSecond { get; set; }
            public System.String Segment_SegmentName { get; set; }
            public System.Boolean? Segment_TsIncludeDvbSubtitle { get; set; }
            public System.Boolean? Segment_TsUseAudioRenditionGroup { get; set; }
            public System.Int32? StartoverWindowSecond { get; set; }
            public System.Func<Amazon.MediaPackageV2.Model.UpdateOriginEndpointResponse, UpdateMPV2OriginEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
