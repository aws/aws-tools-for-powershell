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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The CreatePreset operation creates a preset with settings that you specify.
    /// 
    ///  <important><para>
    /// Elastic Transcoder checks the CreatePreset settings to ensure that they meet Elastic
    /// Transcoder requirements and to determine whether they comply with H.264 standards.
    /// If your settings are not valid for Elastic Transcoder, Elastic Transcoder returns
    /// an HTTP 400 response (<c>ValidationException</c>) and does not create the preset.
    /// If the settings are valid for Elastic Transcoder but aren't strictly compliant with
    /// the H.264 standard, Elastic Transcoder creates the preset and returns a warning message
    /// in the response. This helps you determine whether your settings comply with the H.264
    /// standard while giving you greater flexibility with respect to the video that Elastic
    /// Transcoder produces.
    /// </para></important><para>
    /// Elastic Transcoder uses the H.264 video-compression format. For more information,
    /// see the International Telecommunication Union publication <i>Recommendation ITU-T
    /// H.264: Advanced video coding for generic audiovisual services</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ETSPreset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticTranscoder.Model.CreatePresetResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Transcoder CreatePreset API operation.", Operation = new[] {"CreatePreset"}, SelectReturnType = typeof(Amazon.ElasticTranscoder.Model.CreatePresetResponse))]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.CreatePresetResponse",
        "This cmdlet returns an Amazon.ElasticTranscoder.Model.CreatePresetResponse object containing multiple properties."
    )]
    public partial class NewETSPresetCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Thumbnails_AspectRatio
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of thumbnails, we recommend that you
        /// use the values <c>MaxWidth</c>, <c>MaxHeight</c>, <c>SizingPolicy</c>, and <c>PaddingPolicy</c>
        /// instead of <c>Resolution</c> and <c>AspectRatio</c>. The two groups of settings are
        /// mutually exclusive. Do not use them together.</para></important><para>The aspect ratio of thumbnails. Valid values include:</para><para><c>auto</c>, <c>1:1</c>, <c>4:3</c>, <c>3:2</c>, <c>16:9</c></para><para>If you specify <c>auto</c>, Elastic Transcoder tries to preserve the aspect ratio
        /// of the video in the output file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_AspectRatio { get; set; }
        #endregion
        
        #region Parameter Video_AspectRatio
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of output videos, we recommend that
        /// you use the values <c>MaxWidth</c>, <c>MaxHeight</c>, <c>SizingPolicy</c>, <c>PaddingPolicy</c>,
        /// and <c>DisplayAspectRatio</c> instead of <c>Resolution</c> and <c>AspectRatio</c>.
        /// The two groups of settings are mutually exclusive. Do not use them together.</para></important><para>The display aspect ratio of the video in the output file. Valid values include:</para><para><c>auto</c>, <c>1:1</c>, <c>4:3</c>, <c>3:2</c>, <c>16:9</c></para><para>If you specify <c>auto</c>, Elastic Transcoder tries to preserve the aspect ratio
        /// of the input file.</para><para>If you specify an aspect ratio for the output file that differs from aspect ratio
        /// of the input file, Elastic Transcoder adds pillarboxing (black bars on the sides)
        /// or letterboxing (black bars on the top and bottom) to maintain the aspect ratio of
        /// the active region of the video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_AspectRatio { get; set; }
        #endregion
        
        #region Parameter Audio_AudioPackingMode
        /// <summary>
        /// <para>
        /// <para>The method of organizing audio channels and tracks. Use <c>Audio:Channels</c> to specify
        /// the number of channels in your output, and <c>Audio:AudioPackingMode</c> to specify
        /// the number of tracks and their relation to the channels. If you do not specify an
        /// <c>Audio:AudioPackingMode</c>, Elastic Transcoder uses <c>SingleTrack</c>.</para><para>The following values are valid:</para><para><c>SingleTrack</c>, <c>OneChannelPerTrack</c>, and <c>OneChannelPerTrackWithMosTo8Tracks</c></para><para>When you specify <c>SingleTrack</c>, Elastic Transcoder creates a single track for
        /// your output. The track can have up to eight channels. Use <c>SingleTrack</c> for all
        /// non-<c>mxf</c> containers.</para><para>The outputs of <c>SingleTrack</c> for a specific channel value and inputs are as follows:</para><ul><li><para><c>0</c><b> channels with any input:</b> Audio omitted from the output</para></li><li><para><c>1, 2, or auto </c><b>channels with no audio input:</b> Audio omitted from the
        /// output</para></li><li><para><c>1 </c><b>channel with any input with audio:</b> One track with one channel, downmixed
        /// if necessary</para></li><li><para><c>2 </c><b>channels with one track with one channel:</b> One track with two identical
        /// channels</para></li><li><para><c>2 or auto </c><b>channels with two tracks with one channel each:</b> One track
        /// with two channels</para></li><li><para><c>2 or auto </c><b>channels with one track with two channels:</b> One track with
        /// two channels</para></li><li><para><c>2 </c><b>channels with one track with multiple channels:</b> One track with two
        /// channels</para></li><li><para><c>auto </c><b>channels with one track with one channel:</b> One track with one
        /// channel</para></li><li><para><c>auto </c><b>channels with one track with multiple channels:</b> One track with
        /// multiple channels</para></li></ul><para>When you specify <c>OneChannelPerTrack</c>, Elastic Transcoder creates a new track
        /// for every channel in your output. Your output can have up to eight single-channel
        /// tracks.</para><para>The outputs of <c>OneChannelPerTrack</c> for a specific channel value and inputs are
        /// as follows:</para><ul><li><para><c>0 </c><b>channels with any input:</b> Audio omitted from the output</para></li><li><para><c>1, 2, or auto </c><b>channels with no audio input:</b> Audio omitted from the
        /// output</para></li><li><para><c>1 </c><b>channel with any input with audio:</b> One track with one channel, downmixed
        /// if necessary</para></li><li><para><c>2 </c><b>channels with one track with one channel:</b> Two tracks with one identical
        /// channel each</para></li><li><para><c>2 or auto </c><b>channels with two tracks with one channel each:</b> Two tracks
        /// with one channel each</para></li><li><para><c>2 or auto </c><b>channels with one track with two channels:</b> Two tracks with
        /// one channel each</para></li><li><para><c>2 </c><b>channels with one track with multiple channels:</b> Two tracks with
        /// one channel each</para></li><li><para><c>auto </c><b>channels with one track with one channel:</b> One track with one
        /// channel</para></li><li><para><c>auto </c><b>channels with one track with multiple channels:</b> Up to eight tracks
        /// with one channel each</para></li></ul><para>When you specify <c>OneChannelPerTrackWithMosTo8Tracks</c>, Elastic Transcoder creates
        /// eight single-channel tracks for your output. All tracks that do not contain audio
        /// data from an input channel are MOS, or Mit Out Sound, tracks.</para><para>The outputs of <c>OneChannelPerTrackWithMosTo8Tracks</c> for a specific channel value
        /// and inputs are as follows:</para><ul><li><para><c>0 </c><b>channels with any input:</b> Audio omitted from the output</para></li><li><para><c>1, 2, or auto </c><b>channels with no audio input:</b> Audio omitted from the
        /// output</para></li><li><para><c>1 </c><b>channel with any input with audio:</b> One track with one channel, downmixed
        /// if necessary, plus six MOS tracks</para></li><li><para><c>2 </c><b>channels with one track with one channel:</b> Two tracks with one identical
        /// channel each, plus six MOS tracks</para></li><li><para><c>2 or auto </c><b>channels with two tracks with one channel each:</b> Two tracks
        /// with one channel each, plus six MOS tracks</para></li><li><para><c>2 or auto </c><b>channels with one track with two channels:</b> Two tracks with
        /// one channel each, plus six MOS tracks</para></li><li><para><c>2 </c><b>channels with one track with multiple channels:</b> Two tracks with
        /// one channel each, plus six MOS tracks</para></li><li><para><c>auto </c><b>channels with one track with one channel:</b> One track with one
        /// channel, plus seven MOS tracks</para></li><li><para><c>auto </c><b>channels with one track with multiple channels:</b> Up to eight tracks
        /// with one channel each, plus MOS tracks until there are eight tracks in all</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Audio_AudioPackingMode { get; set; }
        #endregion
        
        #region Parameter CodecOptions_BitDepth
        /// <summary>
        /// <para>
        /// <para>You can only choose an audio bit depth when you specify <c>flac</c> or <c>pcm</c>
        /// for the value of Audio:Codec.</para><para>The bit depth of a sample is how many bits of information are included in the audio
        /// samples. The higher the bit depth, the better the audio, but the larger the file.</para><para>Valid values are <c>16</c> and <c>24</c>.</para><para>The most common bit depth is <c>24</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audio_CodecOptions_BitDepth")]
        public System.String CodecOptions_BitDepth { get; set; }
        #endregion
        
        #region Parameter CodecOptions_BitOrder
        /// <summary>
        /// <para>
        /// <para>You can only choose an audio bit order when you specify <c>pcm</c> for the value of
        /// Audio:Codec.</para><para>The order the bits of a PCM sample are stored in.</para><para>The supported value is <c>LittleEndian</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audio_CodecOptions_BitOrder")]
        public System.String CodecOptions_BitOrder { get; set; }
        #endregion
        
        #region Parameter Audio_BitRate
        /// <summary>
        /// <para>
        /// <para>The bit rate of the audio stream in the output file, in kilobits/second. Enter an
        /// integer between 64 and 320, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Audio_BitRate { get; set; }
        #endregion
        
        #region Parameter Video_BitRate
        /// <summary>
        /// <para>
        /// <para>The bit rate of the video stream in the output file, in kilobits/second. Valid values
        /// depend on the values of <c>Level</c> and <c>Profile</c>. If you specify <c>auto</c>,
        /// Elastic Transcoder uses the detected bit rate of the input source. If you specify
        /// a value other than <c>auto</c>, we recommend that you specify a value less than or
        /// equal to the maximum H.264-compliant value listed for your level and profile:</para><para><i>Level - Maximum video bit rate in kilobits/second (baseline and main Profile)
        /// : maximum video bit rate in kilobits/second (high Profile)</i></para><ul><li><para>1 - 64 : 80</para></li><li><para>1b - 128 : 160</para></li><li><para>1.1 - 192 : 240</para></li><li><para>1.2 - 384 : 480</para></li><li><para>1.3 - 768 : 960</para></li><li><para>2 - 2000 : 2500</para></li><li><para>3 - 10000 : 12500</para></li><li><para>3.1 - 14000 : 17500</para></li><li><para>3.2 - 20000 : 25000</para></li><li><para>4 - 20000 : 25000</para></li><li><para>4.1 - 50000 : 62500</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_BitRate { get; set; }
        #endregion
        
        #region Parameter Audio_Channel
        /// <summary>
        /// <para>
        /// <para>The number of audio channels in the output file. The following values are valid:</para><para><c>auto</c>, <c>0</c>, <c>1</c>, <c>2</c></para><para>One channel carries the information played by a single speaker. For example, a stereo
        /// track with two channels sends one channel to the left speaker, and the other channel
        /// to the right speaker. The output channels are organized into tracks. If you want Elastic
        /// Transcoder to automatically detect the number of audio channels in the input file
        /// and use that value for the output file, select <c>auto</c>.</para><para>The output of a specific channel value and inputs are as follows:</para><ul><li><para><c>auto</c><b> channel specified, with any input:</b> Pass through up to eight input
        /// channels.</para></li><li><para><c>0</c><b> channels specified, with any input:</b> Audio omitted from the output.</para></li><li><para><c>1</c><b> channel specified, with at least one input channel:</b> Mono sound.</para></li><li><para><c>2</c><b> channels specified, with any input:</b> Two identical mono channels
        /// or stereo. For more information about tracks, see <c>Audio:AudioPackingMode.</c></para></li></ul><para> For more information about how Elastic Transcoder organizes channels and tracks,
        /// see <c>Audio:AudioPackingMode</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audio_Channels")]
        public System.String Audio_Channel { get; set; }
        #endregion
        
        #region Parameter Audio_Codec
        /// <summary>
        /// <para>
        /// <para>The audio codec for the output file. Valid values include <c>aac</c>, <c>flac</c>,
        /// <c>mp2</c>, <c>mp3</c>, <c>pcm</c>, and <c>vorbis</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Audio_Codec { get; set; }
        #endregion
        
        #region Parameter Video_Codec
        /// <summary>
        /// <para>
        /// <para>The video codec for the output file. Valid values include <c>gif</c>, <c>H.264</c>,
        /// <c>mpeg2</c>, <c>vp8</c>, and <c>vp9</c>. You can only specify <c>vp8</c> and <c>vp9</c>
        /// when the container type is <c>webm</c>, <c>gif</c> when the container type is <c>gif</c>,
        /// and <c>mpeg2</c> when the container type is <c>mpg</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_Codec { get; set; }
        #endregion
        
        #region Parameter Video_CodecOption
        /// <summary>
        /// <para>
        /// <para><b>Profile (H.264/VP8/VP9 Only)</b></para><para>The H.264 profile that you want to use for the output file. Elastic Transcoder supports
        /// the following profiles:</para><ul><li><para><c>baseline</c>: The profile most commonly used for videoconferencing and for mobile
        /// applications.</para></li><li><para><c>main</c>: The profile used for standard-definition digital TV broadcasts.</para></li><li><para><c>high</c>: The profile used for high-definition digital TV broadcasts and for Blu-ray
        /// discs.</para></li></ul><para><b>Level (H.264 Only)</b></para><para>The H.264 level that you want to use for the output file. Elastic Transcoder supports
        /// the following levels:</para><para><c>1</c>, <c>1b</c>, <c>1.1</c>, <c>1.2</c>, <c>1.3</c>, <c>2</c>, <c>2.1</c>, <c>2.2</c>,
        /// <c>3</c>, <c>3.1</c>, <c>3.2</c>, <c>4</c>, <c>4.1</c></para><para><b>MaxReferenceFrames (H.264 Only)</b></para><para>Applicable only when the value of Video:Codec is H.264. The maximum number of previously
        /// decoded frames to use as a reference for decoding future frames. Valid values are
        /// integers 0 through 16, but we recommend that you not use a value greater than the
        /// following:</para><para><c>Min(Floor(Maximum decoded picture buffer in macroblocks * 256 / (Width in pixels
        /// * Height in pixels)), 16)</c></para><para>where <i>Width in pixels</i> and <i>Height in pixels</i> represent either MaxWidth
        /// and MaxHeight, or Resolution. <i>Maximum decoded picture buffer in macroblocks</i>
        /// depends on the value of the <c>Level</c> object. See the list below. (A macroblock
        /// is a block of pixels measuring 16x16.) </para><ul><li><para>1 - 396</para></li><li><para>1b - 396</para></li><li><para>1.1 - 900</para></li><li><para>1.2 - 2376</para></li><li><para>1.3 - 2376</para></li><li><para>2 - 2376</para></li><li><para>2.1 - 4752</para></li><li><para>2.2 - 8100</para></li><li><para>3 - 8100</para></li><li><para>3.1 - 18000</para></li><li><para>3.2 - 20480</para></li><li><para>4 - 32768</para></li><li><para>4.1 - 32768</para></li></ul><para><b>MaxBitRate (Optional, H.264/MPEG2/VP8/VP9 only)</b></para><para>The maximum number of bits per second in a video buffer; the size of the buffer is
        /// specified by <c>BufferSize</c>. Specify a value between 16 and 62,500. You can reduce
        /// the bandwidth required to stream a video by reducing the maximum bit rate, but this
        /// also reduces the quality of the video.</para><para><b>BufferSize (Optional, H.264/MPEG2/VP8/VP9 only)</b></para><para>The maximum number of bits in any x seconds of the output video. This window is commonly
        /// 10 seconds, the standard segment duration when you're using FMP4 or MPEG-TS for the
        /// container type of the output video. Specify an integer greater than 0. If you specify
        /// <c>MaxBitRate</c> and omit <c>BufferSize</c>, Elastic Transcoder sets <c>BufferSize</c>
        /// to 10 times the value of <c>MaxBitRate</c>.</para><para><b>InterlacedMode (Optional, H.264/MPEG2 Only)</b></para><para>The interlace mode for the output video.</para><para>Interlaced video is used to double the perceived frame rate for a video by interlacing
        /// two fields (one field on every other line, the other field on the other lines) so
        /// that the human eye registers multiple pictures per frame. Interlacing reduces the
        /// bandwidth required for transmitting a video, but can result in blurred images and
        /// flickering.</para><para>Valid values include <c>Progressive</c> (no interlacing, top to bottom), <c>TopFirst</c>
        /// (top field first), <c>BottomFirst</c> (bottom field first), and <c>Auto</c>.</para><para>If <c>InterlaceMode</c> is not specified, Elastic Transcoder uses <c>Progressive</c>
        /// for the output. If <c>Auto</c> is specified, Elastic Transcoder interlaces the output.</para><para><b>ColorSpaceConversionMode (Optional, H.264/MPEG2 Only)</b></para><para>The color space conversion Elastic Transcoder applies to the output video. Color spaces
        /// are the algorithms used by the computer to store information about how to render color.
        /// <c>Bt.601</c> is the standard for standard definition video, while <c>Bt.709</c> is
        /// the standard for high definition video.</para><para>Valid values include <c>None</c>, <c>Bt709toBt601</c>, <c>Bt601toBt709</c>, and <c>Auto</c>.</para><para>If you chose <c>Auto</c> for <c>ColorSpaceConversionMode</c> and your output is interlaced,
        /// your frame rate is one of <c>23.97</c>, <c>24</c>, <c>25</c>, <c>29.97</c>, <c>50</c>,
        /// or <c>60</c>, your <c>SegmentDuration</c> is null, and you are using one of the resolution
        /// changes from the list below, Elastic Transcoder applies the following color space
        /// conversions:</para><ul><li><para><i>Standard to HD, 720x480 to 1920x1080</i> - Elastic Transcoder applies <c>Bt601ToBt709</c></para></li><li><para><i>Standard to HD, 720x576 to 1920x1080</i> - Elastic Transcoder applies <c>Bt601ToBt709</c></para></li><li><para><i>HD to Standard, 1920x1080 to 720x480</i> - Elastic Transcoder applies <c>Bt709ToBt601</c></para></li><li><para><i>HD to Standard, 1920x1080 to 720x576</i> - Elastic Transcoder applies <c>Bt709ToBt601</c></para></li></ul><note><para>Elastic Transcoder may change the behavior of the <c>ColorspaceConversionMode</c><c>Auto</c> mode in the future. All outputs in a playlist must use the same <c>ColorSpaceConversionMode</c>.</para></note><para>If you do not specify a <c>ColorSpaceConversionMode</c>, Elastic Transcoder does not
        /// change the color space of a file. If you are unsure what <c>ColorSpaceConversionMode</c>
        /// was applied to your output file, you can check the <c>AppliedColorSpaceConversion</c>
        /// parameter included in your job response. If your job does not have an <c>AppliedColorSpaceConversion</c>
        /// in its response, no <c>ColorSpaceConversionMode</c> was applied.</para><para><b>ChromaSubsampling</b></para><para>The sampling pattern for the chroma (color) channels of the output video. Valid values
        /// include <c>yuv420p</c> and <c>yuv422p</c>.</para><para><c>yuv420p</c> samples the chroma information of every other horizontal and every
        /// other vertical line, <c>yuv422p</c> samples the color information of every horizontal
        /// line and every other vertical line.</para><para><b>LoopCount (Gif Only)</b></para><para>The number of times you want the output gif to loop. Valid values include <c>Infinite</c>
        /// and integers between <c>0</c> and <c>100</c>, inclusive.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Video_CodecOptions")]
        public System.Collections.Hashtable Video_CodecOption { get; set; }
        #endregion
        
        #region Parameter Container
        /// <summary>
        /// <para>
        /// <para>The container type for the output file. Valid values include <c>flac</c>, <c>flv</c>,
        /// <c>fmp4</c>, <c>gif</c>, <c>mp3</c>, <c>mp4</c>, <c>mpg</c>, <c>mxf</c>, <c>oga</c>,
        /// <c>ogg</c>, <c>ts</c>, and <c>webm</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Container { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the preset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Video_DisplayAspectRatio
        /// <summary>
        /// <para>
        /// <para>The value that Elastic Transcoder adds to the metadata in the output file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_DisplayAspectRatio { get; set; }
        #endregion
        
        #region Parameter Video_FixedGOP
        /// <summary>
        /// <para>
        /// <para>Applicable only when the value of Video:Codec is one of <c>H.264</c>, <c>MPEG2</c>,
        /// or <c>VP8</c>.</para><para>Whether to use a fixed value for <c>FixedGOP</c>. Valid values are <c>true</c> and
        /// <c>false</c>:</para><ul><li><para><c>true</c>: Elastic Transcoder uses the value of <c>KeyframesMaxDist</c> for the
        /// distance between key frames (the number of frames in a group of pictures, or GOP).</para></li><li><para><c>false</c>: The distance between key frames can vary.</para></li></ul><important><para><c>FixedGOP</c> must be set to <c>true</c> for <c>fmp4</c> containers.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_FixedGOP { get; set; }
        #endregion
        
        #region Parameter Thumbnails_Format
        /// <summary>
        /// <para>
        /// <para>The format of thumbnails, if any. Valid values are <c>jpg</c> and <c>png</c>. </para><para>You specify whether you want Elastic Transcoder to create thumbnails when you create
        /// a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_Format { get; set; }
        #endregion
        
        #region Parameter Video_FrameRate
        /// <summary>
        /// <para>
        /// <para>The frames per second for the video stream in the output file. Valid values include:</para><para><c>auto</c>, <c>10</c>, <c>15</c>, <c>23.97</c>, <c>24</c>, <c>25</c>, <c>29.97</c>,
        /// <c>30</c>, <c>60</c></para><para>If you specify <c>auto</c>, Elastic Transcoder uses the detected frame rate of the
        /// input source. If you specify a frame rate, we recommend that you perform the following
        /// calculation:</para><para><c>Frame rate = maximum recommended decoding speed in luma samples/second / (width
        /// in pixels * height in pixels)</c></para><para>where:</para><ul><li><para><i>width in pixels</i> and <i>height in pixels</i> represent the Resolution of the
        /// output video.</para></li><li><para><i>maximum recommended decoding speed in Luma samples/second</i> is less than or
        /// equal to the maximum value listed in the following table, based on the value that
        /// you specified for Level.</para></li></ul><para>The maximum recommended decoding speed in Luma samples/second for each level is described
        /// in the following list (<i>Level - Decoding speed</i>):</para><ul><li><para>1 - 380160</para></li><li><para>1b - 380160</para></li><li><para>1.1 - 76800</para></li><li><para>1.2 - 1536000</para></li><li><para>1.3 - 3041280</para></li><li><para>2 - 3041280</para></li><li><para>2.1 - 5068800</para></li><li><para>2.2 - 5184000</para></li><li><para>3 - 10368000</para></li><li><para>3.1 - 27648000</para></li><li><para>3.2 - 55296000</para></li><li><para>4 - 62914560</para></li><li><para>4.1 - 62914560</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_FrameRate { get; set; }
        #endregion
        
        #region Parameter Thumbnails_Interval
        /// <summary>
        /// <para>
        /// <para>The approximate number of seconds between thumbnails. Specify an integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_Interval { get; set; }
        #endregion
        
        #region Parameter Video_KeyframesMaxDist
        /// <summary>
        /// <para>
        /// <para>Applicable only when the value of Video:Codec is one of <c>H.264</c>, <c>MPEG2</c>,
        /// or <c>VP8</c>.</para><para>The maximum number of frames between key frames. Key frames are fully encoded frames;
        /// the frames between key frames are encoded based, in part, on the content of the key
        /// frames. The value is an integer formatted as a string; valid values are between 1
        /// (every frame is a key frame) and 100000, inclusive. A higher value results in higher
        /// compression but may also discernibly decrease video quality.</para><para>For <c>Smooth</c> outputs, the <c>FrameRate</c> must have a constant ratio to the
        /// <c>KeyframesMaxDist</c>. This allows <c>Smooth</c> playlists to switch between different
        /// quality levels while the file is being played.</para><para>For example, an input file can have a <c>FrameRate</c> of 30 with a <c>KeyframesMaxDist</c>
        /// of 90. The output file then needs to have a ratio of 1:3. Valid outputs would have
        /// <c>FrameRate</c> of 30, 25, and 10, and <c>KeyframesMaxDist</c> of 90, 75, and 30,
        /// respectively.</para><para>Alternately, this can be achieved by setting <c>FrameRate</c> to auto and having the
        /// same values for <c>MaxFrameRate</c> and <c>KeyframesMaxDist</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_KeyframesMaxDist { get; set; }
        #endregion
        
        #region Parameter Video_MaxFrameRate
        /// <summary>
        /// <para>
        /// <para>If you specify <c>auto</c> for <c>FrameRate</c>, Elastic Transcoder uses the frame
        /// rate of the input video for the frame rate of the output video. Specify the maximum
        /// frame rate that you want Elastic Transcoder to use when the frame rate of the input
        /// video is greater than the desired maximum frame rate of the output video. Valid values
        /// include: <c>10</c>, <c>15</c>, <c>23.97</c>, <c>24</c>, <c>25</c>, <c>29.97</c>, <c>30</c>,
        /// <c>60</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_MaxFrameRate { get; set; }
        #endregion
        
        #region Parameter Thumbnails_MaxHeight
        /// <summary>
        /// <para>
        /// <para>The maximum height of thumbnails in pixels. If you specify auto, Elastic Transcoder
        /// uses 1080 (Full HD) as the default value. If you specify a numeric value, enter an
        /// even integer between 32 and 3072.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_MaxHeight { get; set; }
        #endregion
        
        #region Parameter Video_MaxHeight
        /// <summary>
        /// <para>
        /// <para>The maximum height of the output video in pixels. If you specify <c>auto</c>, Elastic
        /// Transcoder uses 1080 (Full HD) as the default value. If you specify a numeric value,
        /// enter an even integer between 96 and 3072.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_MaxHeight { get; set; }
        #endregion
        
        #region Parameter Thumbnails_MaxWidth
        /// <summary>
        /// <para>
        /// <para>The maximum width of thumbnails in pixels. If you specify auto, Elastic Transcoder
        /// uses 1920 (Full HD) as the default value. If you specify a numeric value, enter an
        /// even integer between 32 and 4096.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_MaxWidth { get; set; }
        #endregion
        
        #region Parameter Video_MaxWidth
        /// <summary>
        /// <para>
        /// <para> The maximum width of the output video in pixels. If you specify <c>auto</c>, Elastic
        /// Transcoder uses 1920 (Full HD) as the default value. If you specify a numeric value,
        /// enter an even integer between 128 and 4096. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_MaxWidth { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the preset. We recommend that the name be unique within the AWS account,
        /// but uniqueness is not enforced.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Thumbnails_PaddingPolicy
        /// <summary>
        /// <para>
        /// <para>When you set <c>PaddingPolicy</c> to <c>Pad</c>, Elastic Transcoder may add black
        /// bars to the top and bottom and/or left and right sides of thumbnails to make the total
        /// size of the thumbnails match the values that you specified for thumbnail <c>MaxWidth</c>
        /// and <c>MaxHeight</c> settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_PaddingPolicy { get; set; }
        #endregion
        
        #region Parameter Video_PaddingPolicy
        /// <summary>
        /// <para>
        /// <para>When you set <c>PaddingPolicy</c> to <c>Pad</c>, Elastic Transcoder may add black
        /// bars to the top and bottom and/or left and right sides of the output video to make
        /// the total size of the output video match the values that you specified for <c>MaxWidth</c>
        /// and <c>MaxHeight</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_PaddingPolicy { get; set; }
        #endregion
        
        #region Parameter CodecOptions_Profile
        /// <summary>
        /// <para>
        /// <para>You can only choose an audio profile when you specify AAC for the value of Audio:Codec.</para><para>Specify the AAC profile for the output file. Elastic Transcoder supports the following
        /// profiles:</para><ul><li><para><c>auto</c>: If you specify <c>auto</c>, Elastic Transcoder selects the profile based
        /// on the bit rate selected for the output file.</para></li><li><para><c>AAC-LC</c>: The most common AAC profile. Use for bit rates larger than 64 kbps.</para></li><li><para><c>HE-AAC</c>: Not supported on some older players and devices. Use for bit rates
        /// between 40 and 80 kbps.</para></li><li><para><c>HE-AACv2</c>: Not supported on some players and devices. Use for bit rates less
        /// than 48 kbps.</para></li></ul><para>All outputs in a <c>Smooth</c> playlist must have the same value for <c>Profile</c>.</para><note><para>If you created any presets before AAC profiles were added, Elastic Transcoder automatically
        /// updated your presets to use AAC-LC. You can change the value as required.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audio_CodecOptions_Profile")]
        public System.String CodecOptions_Profile { get; set; }
        #endregion
        
        #region Parameter Thumbnails_Resolution
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of thumbnails, we recommend that you
        /// use the values <c>MaxWidth</c>, <c>MaxHeight</c>, <c>SizingPolicy</c>, and <c>PaddingPolicy</c>
        /// instead of <c>Resolution</c> and <c>AspectRatio</c>. The two groups of settings are
        /// mutually exclusive. Do not use them together.</para></important><para>The width and height of thumbnail files in pixels. Specify a value in the format <c><i>width</i></c> x <c><i>height</i></c> where both values are even integers. The
        /// values cannot exceed the width and height that you specified in the <c>Video:Resolution</c>
        /// object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_Resolution { get; set; }
        #endregion
        
        #region Parameter Video_Resolution
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of output videos, we recommend that
        /// you use the values <c>MaxWidth</c>, <c>MaxHeight</c>, <c>SizingPolicy</c>, <c>PaddingPolicy</c>,
        /// and <c>DisplayAspectRatio</c> instead of <c>Resolution</c> and <c>AspectRatio</c>.
        /// The two groups of settings are mutually exclusive. Do not use them together.</para></important><para>The width and height of the video in the output file, in pixels. Valid values are
        /// <c>auto</c> and <i>width</i> x <i>height</i>:</para><ul><li><para><c>auto</c>: Elastic Transcoder attempts to preserve the width and height of the
        /// input file, subject to the following rules.</para></li><li><para><c><i>width</i> x <i>height</i></c>: The width and height of the output video in
        /// pixels.</para></li></ul><para>Note the following about specifying the width and height:</para><ul><li><para>The width must be an even integer between 128 and 4096, inclusive.</para></li><li><para>The height must be an even integer between 96 and 3072, inclusive.</para></li><li><para>If you specify a resolution that is less than the resolution of the input file, Elastic
        /// Transcoder rescales the output file to the lower resolution.</para></li><li><para>If you specify a resolution that is greater than the resolution of the input file,
        /// Elastic Transcoder rescales the output to the higher resolution.</para></li><li><para>We recommend that you specify a resolution for which the product of width and height
        /// is less than or equal to the applicable value in the following list (<i>List - Max
        /// width x height value</i>):</para><ul><li><para>1 - 25344</para></li><li><para>1b - 25344</para></li><li><para>1.1 - 101376</para></li><li><para>1.2 - 101376</para></li><li><para>1.3 - 101376</para></li><li><para>2 - 101376</para></li><li><para>2.1 - 202752</para></li><li><para>2.2 - 404720</para></li><li><para>3 - 404720</para></li><li><para>3.1 - 921600</para></li><li><para>3.2 - 1310720</para></li><li><para>4 - 2097152</para></li><li><para>4.1 - 2097152</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_Resolution { get; set; }
        #endregion
        
        #region Parameter Audio_SampleRate
        /// <summary>
        /// <para>
        /// <para>The sample rate of the audio stream in the output file, in Hertz. Valid values include:</para><para><c>auto</c>, <c>22050</c>, <c>32000</c>, <c>44100</c>, <c>48000</c>, <c>96000</c></para><para>If you specify <c>auto</c>, Elastic Transcoder automatically detects the sample rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Audio_SampleRate { get; set; }
        #endregion
        
        #region Parameter CodecOptions_Signed
        /// <summary>
        /// <para>
        /// <para>You can only choose whether an audio sample is signed when you specify <c>pcm</c>
        /// for the value of Audio:Codec.</para><para>Whether audio samples are represented with negative and positive numbers (signed)
        /// or only positive numbers (unsigned).</para><para>The supported value is <c>Signed</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audio_CodecOptions_Signed")]
        public System.String CodecOptions_Signed { get; set; }
        #endregion
        
        #region Parameter Thumbnails_SizingPolicy
        /// <summary>
        /// <para>
        /// <para>Specify one of the following values to control scaling of thumbnails:</para><ul><li><para><c>Fit</c>: Elastic Transcoder scales thumbnails so they match the value that you
        /// specified in thumbnail MaxWidth or MaxHeight settings without exceeding the other
        /// value. </para></li><li><para><c>Fill</c>: Elastic Transcoder scales thumbnails so they match the value that you
        /// specified in thumbnail <c>MaxWidth</c> or <c>MaxHeight</c> settings and matches or
        /// exceeds the other value. Elastic Transcoder centers the image in thumbnails and then
        /// crops in the dimension (if any) that exceeds the maximum value.</para></li><li><para><c>Stretch</c>: Elastic Transcoder stretches thumbnails to match the values that
        /// you specified for thumbnail <c>MaxWidth</c> and <c>MaxHeight</c> settings. If the
        /// relative proportions of the input video and thumbnails are different, the thumbnails
        /// will be distorted.</para></li><li><para><c>Keep</c>: Elastic Transcoder does not scale thumbnails. If either dimension of
        /// the input video exceeds the values that you specified for thumbnail <c>MaxWidth</c>
        /// and <c>MaxHeight</c> settings, Elastic Transcoder crops the thumbnails.</para></li><li><para><c>ShrinkToFit</c>: Elastic Transcoder scales thumbnails down so that their dimensions
        /// match the values that you specified for at least one of thumbnail <c>MaxWidth</c>
        /// and <c>MaxHeight</c> without exceeding either value. If you specify this option, Elastic
        /// Transcoder does not scale thumbnails up.</para></li><li><para><c>ShrinkToFill</c>: Elastic Transcoder scales thumbnails down so that their dimensions
        /// match the values that you specified for at least one of <c>MaxWidth</c> and <c>MaxHeight</c>
        /// without dropping below either value. If you specify this option, Elastic Transcoder
        /// does not scale thumbnails up.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Thumbnails_SizingPolicy { get; set; }
        #endregion
        
        #region Parameter Video_SizingPolicy
        /// <summary>
        /// <para>
        /// <para>Specify one of the following values to control scaling of the output video:</para><ul><li><para><c>Fit</c>: Elastic Transcoder scales the output video so it matches the value that
        /// you specified in either <c>MaxWidth</c> or <c>MaxHeight</c> without exceeding the
        /// other value.</para></li><li><para><c>Fill</c>: Elastic Transcoder scales the output video so it matches the value that
        /// you specified in either <c>MaxWidth</c> or <c>MaxHeight</c> and matches or exceeds
        /// the other value. Elastic Transcoder centers the output video and then crops it in
        /// the dimension (if any) that exceeds the maximum value.</para></li><li><para><c>Stretch</c>: Elastic Transcoder stretches the output video to match the values
        /// that you specified for <c>MaxWidth</c> and <c>MaxHeight</c>. If the relative proportions
        /// of the input video and the output video are different, the output video will be distorted.</para></li><li><para><c>Keep</c>: Elastic Transcoder does not scale the output video. If either dimension
        /// of the input video exceeds the values that you specified for <c>MaxWidth</c> and <c>MaxHeight</c>,
        /// Elastic Transcoder crops the output video.</para></li><li><para><c>ShrinkToFit</c>: Elastic Transcoder scales the output video down so that its dimensions
        /// match the values that you specified for at least one of <c>MaxWidth</c> and <c>MaxHeight</c>
        /// without exceeding either value. If you specify this option, Elastic Transcoder does
        /// not scale the video up.</para></li><li><para><c>ShrinkToFill</c>: Elastic Transcoder scales the output video down so that its
        /// dimensions match the values that you specified for at least one of <c>MaxWidth</c>
        /// and <c>MaxHeight</c> without dropping below either value. If you specify this option,
        /// Elastic Transcoder does not scale the video up.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Video_SizingPolicy { get; set; }
        #endregion
        
        #region Parameter Video_Watermark
        /// <summary>
        /// <para>
        /// <para>Settings for the size, location, and opacity of graphics that you want Elastic Transcoder
        /// to overlay over videos that are transcoded using this preset. You can specify settings
        /// for up to four watermarks. Watermarks appear in the specified size and location, and
        /// with the specified opacity for the duration of the transcoded video.</para><para>Watermarks can be in .png or .jpg format. If you want to display a watermark that
        /// is not rectangular, use the .png format, which supports transparency.</para><para>When you create a job that uses this preset, you specify the .png or .jpg graphics
        /// that you want Elastic Transcoder to include in the transcoded videos. You can specify
        /// fewer graphics in the job than you specify watermark settings in the preset, which
        /// allows you to use the same preset for up to four watermarks that have different dimensions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Video_Watermarks")]
        public Amazon.ElasticTranscoder.Model.PresetWatermark[] Video_Watermark { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticTranscoder.Model.CreatePresetResponse).
        /// Specifying the name of a property of type Amazon.ElasticTranscoder.Model.CreatePresetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ETSPreset (CreatePreset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticTranscoder.Model.CreatePresetResponse, NewETSPresetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Audio_AudioPackingMode = this.Audio_AudioPackingMode;
            context.Audio_BitRate = this.Audio_BitRate;
            context.Audio_Channel = this.Audio_Channel;
            context.Audio_Codec = this.Audio_Codec;
            context.CodecOptions_BitDepth = this.CodecOptions_BitDepth;
            context.CodecOptions_BitOrder = this.CodecOptions_BitOrder;
            context.CodecOptions_Profile = this.CodecOptions_Profile;
            context.CodecOptions_Signed = this.CodecOptions_Signed;
            context.Audio_SampleRate = this.Audio_SampleRate;
            context.Container = this.Container;
            #if MODULAR
            if (this.Container == null && ParameterWasBound(nameof(this.Container)))
            {
                WriteWarning("You are passing $null as a value for parameter Container which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Thumbnails_AspectRatio = this.Thumbnails_AspectRatio;
            context.Thumbnails_Format = this.Thumbnails_Format;
            context.Thumbnails_Interval = this.Thumbnails_Interval;
            context.Thumbnails_MaxHeight = this.Thumbnails_MaxHeight;
            context.Thumbnails_MaxWidth = this.Thumbnails_MaxWidth;
            context.Thumbnails_PaddingPolicy = this.Thumbnails_PaddingPolicy;
            context.Thumbnails_Resolution = this.Thumbnails_Resolution;
            context.Thumbnails_SizingPolicy = this.Thumbnails_SizingPolicy;
            context.Video_AspectRatio = this.Video_AspectRatio;
            context.Video_BitRate = this.Video_BitRate;
            context.Video_Codec = this.Video_Codec;
            if (this.Video_CodecOption != null)
            {
                context.Video_CodecOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Video_CodecOption.Keys)
                {
                    context.Video_CodecOption.Add((String)hashKey, (System.String)(this.Video_CodecOption[hashKey]));
                }
            }
            context.Video_DisplayAspectRatio = this.Video_DisplayAspectRatio;
            context.Video_FixedGOP = this.Video_FixedGOP;
            context.Video_FrameRate = this.Video_FrameRate;
            context.Video_KeyframesMaxDist = this.Video_KeyframesMaxDist;
            context.Video_MaxFrameRate = this.Video_MaxFrameRate;
            context.Video_MaxHeight = this.Video_MaxHeight;
            context.Video_MaxWidth = this.Video_MaxWidth;
            context.Video_PaddingPolicy = this.Video_PaddingPolicy;
            context.Video_Resolution = this.Video_Resolution;
            context.Video_SizingPolicy = this.Video_SizingPolicy;
            if (this.Video_Watermark != null)
            {
                context.Video_Watermark = new List<Amazon.ElasticTranscoder.Model.PresetWatermark>(this.Video_Watermark);
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
            var request = new Amazon.ElasticTranscoder.Model.CreatePresetRequest();
            
            
             // populate Audio
            var requestAudioIsNull = true;
            request.Audio = new Amazon.ElasticTranscoder.Model.AudioParameters();
            System.String requestAudio_audio_AudioPackingMode = null;
            if (cmdletContext.Audio_AudioPackingMode != null)
            {
                requestAudio_audio_AudioPackingMode = cmdletContext.Audio_AudioPackingMode;
            }
            if (requestAudio_audio_AudioPackingMode != null)
            {
                request.Audio.AudioPackingMode = requestAudio_audio_AudioPackingMode;
                requestAudioIsNull = false;
            }
            System.String requestAudio_audio_BitRate = null;
            if (cmdletContext.Audio_BitRate != null)
            {
                requestAudio_audio_BitRate = cmdletContext.Audio_BitRate;
            }
            if (requestAudio_audio_BitRate != null)
            {
                request.Audio.BitRate = requestAudio_audio_BitRate;
                requestAudioIsNull = false;
            }
            System.String requestAudio_audio_Channel = null;
            if (cmdletContext.Audio_Channel != null)
            {
                requestAudio_audio_Channel = cmdletContext.Audio_Channel;
            }
            if (requestAudio_audio_Channel != null)
            {
                request.Audio.Channels = requestAudio_audio_Channel;
                requestAudioIsNull = false;
            }
            System.String requestAudio_audio_Codec = null;
            if (cmdletContext.Audio_Codec != null)
            {
                requestAudio_audio_Codec = cmdletContext.Audio_Codec;
            }
            if (requestAudio_audio_Codec != null)
            {
                request.Audio.Codec = requestAudio_audio_Codec;
                requestAudioIsNull = false;
            }
            System.String requestAudio_audio_SampleRate = null;
            if (cmdletContext.Audio_SampleRate != null)
            {
                requestAudio_audio_SampleRate = cmdletContext.Audio_SampleRate;
            }
            if (requestAudio_audio_SampleRate != null)
            {
                request.Audio.SampleRate = requestAudio_audio_SampleRate;
                requestAudioIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.AudioCodecOptions requestAudio_audio_CodecOptions = null;
            
             // populate CodecOptions
            var requestAudio_audio_CodecOptionsIsNull = true;
            requestAudio_audio_CodecOptions = new Amazon.ElasticTranscoder.Model.AudioCodecOptions();
            System.String requestAudio_audio_CodecOptions_codecOptions_BitDepth = null;
            if (cmdletContext.CodecOptions_BitDepth != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_BitDepth = cmdletContext.CodecOptions_BitDepth;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_BitDepth != null)
            {
                requestAudio_audio_CodecOptions.BitDepth = requestAudio_audio_CodecOptions_codecOptions_BitDepth;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
            System.String requestAudio_audio_CodecOptions_codecOptions_BitOrder = null;
            if (cmdletContext.CodecOptions_BitOrder != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_BitOrder = cmdletContext.CodecOptions_BitOrder;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_BitOrder != null)
            {
                requestAudio_audio_CodecOptions.BitOrder = requestAudio_audio_CodecOptions_codecOptions_BitOrder;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
            System.String requestAudio_audio_CodecOptions_codecOptions_Profile = null;
            if (cmdletContext.CodecOptions_Profile != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_Profile = cmdletContext.CodecOptions_Profile;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_Profile != null)
            {
                requestAudio_audio_CodecOptions.Profile = requestAudio_audio_CodecOptions_codecOptions_Profile;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
            System.String requestAudio_audio_CodecOptions_codecOptions_Signed = null;
            if (cmdletContext.CodecOptions_Signed != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_Signed = cmdletContext.CodecOptions_Signed;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_Signed != null)
            {
                requestAudio_audio_CodecOptions.Signed = requestAudio_audio_CodecOptions_codecOptions_Signed;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
             // determine if requestAudio_audio_CodecOptions should be set to null
            if (requestAudio_audio_CodecOptionsIsNull)
            {
                requestAudio_audio_CodecOptions = null;
            }
            if (requestAudio_audio_CodecOptions != null)
            {
                request.Audio.CodecOptions = requestAudio_audio_CodecOptions;
                requestAudioIsNull = false;
            }
             // determine if request.Audio should be set to null
            if (requestAudioIsNull)
            {
                request.Audio = null;
            }
            if (cmdletContext.Container != null)
            {
                request.Container = cmdletContext.Container;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Thumbnails
            var requestThumbnailsIsNull = true;
            request.Thumbnails = new Amazon.ElasticTranscoder.Model.Thumbnails();
            System.String requestThumbnails_thumbnails_AspectRatio = null;
            if (cmdletContext.Thumbnails_AspectRatio != null)
            {
                requestThumbnails_thumbnails_AspectRatio = cmdletContext.Thumbnails_AspectRatio;
            }
            if (requestThumbnails_thumbnails_AspectRatio != null)
            {
                request.Thumbnails.AspectRatio = requestThumbnails_thumbnails_AspectRatio;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_Format = null;
            if (cmdletContext.Thumbnails_Format != null)
            {
                requestThumbnails_thumbnails_Format = cmdletContext.Thumbnails_Format;
            }
            if (requestThumbnails_thumbnails_Format != null)
            {
                request.Thumbnails.Format = requestThumbnails_thumbnails_Format;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_Interval = null;
            if (cmdletContext.Thumbnails_Interval != null)
            {
                requestThumbnails_thumbnails_Interval = cmdletContext.Thumbnails_Interval;
            }
            if (requestThumbnails_thumbnails_Interval != null)
            {
                request.Thumbnails.Interval = requestThumbnails_thumbnails_Interval;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_MaxHeight = null;
            if (cmdletContext.Thumbnails_MaxHeight != null)
            {
                requestThumbnails_thumbnails_MaxHeight = cmdletContext.Thumbnails_MaxHeight;
            }
            if (requestThumbnails_thumbnails_MaxHeight != null)
            {
                request.Thumbnails.MaxHeight = requestThumbnails_thumbnails_MaxHeight;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_MaxWidth = null;
            if (cmdletContext.Thumbnails_MaxWidth != null)
            {
                requestThumbnails_thumbnails_MaxWidth = cmdletContext.Thumbnails_MaxWidth;
            }
            if (requestThumbnails_thumbnails_MaxWidth != null)
            {
                request.Thumbnails.MaxWidth = requestThumbnails_thumbnails_MaxWidth;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_PaddingPolicy = null;
            if (cmdletContext.Thumbnails_PaddingPolicy != null)
            {
                requestThumbnails_thumbnails_PaddingPolicy = cmdletContext.Thumbnails_PaddingPolicy;
            }
            if (requestThumbnails_thumbnails_PaddingPolicy != null)
            {
                request.Thumbnails.PaddingPolicy = requestThumbnails_thumbnails_PaddingPolicy;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_Resolution = null;
            if (cmdletContext.Thumbnails_Resolution != null)
            {
                requestThumbnails_thumbnails_Resolution = cmdletContext.Thumbnails_Resolution;
            }
            if (requestThumbnails_thumbnails_Resolution != null)
            {
                request.Thumbnails.Resolution = requestThumbnails_thumbnails_Resolution;
                requestThumbnailsIsNull = false;
            }
            System.String requestThumbnails_thumbnails_SizingPolicy = null;
            if (cmdletContext.Thumbnails_SizingPolicy != null)
            {
                requestThumbnails_thumbnails_SizingPolicy = cmdletContext.Thumbnails_SizingPolicy;
            }
            if (requestThumbnails_thumbnails_SizingPolicy != null)
            {
                request.Thumbnails.SizingPolicy = requestThumbnails_thumbnails_SizingPolicy;
                requestThumbnailsIsNull = false;
            }
             // determine if request.Thumbnails should be set to null
            if (requestThumbnailsIsNull)
            {
                request.Thumbnails = null;
            }
            
             // populate Video
            var requestVideoIsNull = true;
            request.Video = new Amazon.ElasticTranscoder.Model.VideoParameters();
            System.String requestVideo_video_AspectRatio = null;
            if (cmdletContext.Video_AspectRatio != null)
            {
                requestVideo_video_AspectRatio = cmdletContext.Video_AspectRatio;
            }
            if (requestVideo_video_AspectRatio != null)
            {
                request.Video.AspectRatio = requestVideo_video_AspectRatio;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_BitRate = null;
            if (cmdletContext.Video_BitRate != null)
            {
                requestVideo_video_BitRate = cmdletContext.Video_BitRate;
            }
            if (requestVideo_video_BitRate != null)
            {
                request.Video.BitRate = requestVideo_video_BitRate;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_Codec = null;
            if (cmdletContext.Video_Codec != null)
            {
                requestVideo_video_Codec = cmdletContext.Video_Codec;
            }
            if (requestVideo_video_Codec != null)
            {
                request.Video.Codec = requestVideo_video_Codec;
                requestVideoIsNull = false;
            }
            Dictionary<System.String, System.String> requestVideo_video_CodecOption = null;
            if (cmdletContext.Video_CodecOption != null)
            {
                requestVideo_video_CodecOption = cmdletContext.Video_CodecOption;
            }
            if (requestVideo_video_CodecOption != null)
            {
                request.Video.CodecOptions = requestVideo_video_CodecOption;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_DisplayAspectRatio = null;
            if (cmdletContext.Video_DisplayAspectRatio != null)
            {
                requestVideo_video_DisplayAspectRatio = cmdletContext.Video_DisplayAspectRatio;
            }
            if (requestVideo_video_DisplayAspectRatio != null)
            {
                request.Video.DisplayAspectRatio = requestVideo_video_DisplayAspectRatio;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_FixedGOP = null;
            if (cmdletContext.Video_FixedGOP != null)
            {
                requestVideo_video_FixedGOP = cmdletContext.Video_FixedGOP;
            }
            if (requestVideo_video_FixedGOP != null)
            {
                request.Video.FixedGOP = requestVideo_video_FixedGOP;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_FrameRate = null;
            if (cmdletContext.Video_FrameRate != null)
            {
                requestVideo_video_FrameRate = cmdletContext.Video_FrameRate;
            }
            if (requestVideo_video_FrameRate != null)
            {
                request.Video.FrameRate = requestVideo_video_FrameRate;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_KeyframesMaxDist = null;
            if (cmdletContext.Video_KeyframesMaxDist != null)
            {
                requestVideo_video_KeyframesMaxDist = cmdletContext.Video_KeyframesMaxDist;
            }
            if (requestVideo_video_KeyframesMaxDist != null)
            {
                request.Video.KeyframesMaxDist = requestVideo_video_KeyframesMaxDist;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_MaxFrameRate = null;
            if (cmdletContext.Video_MaxFrameRate != null)
            {
                requestVideo_video_MaxFrameRate = cmdletContext.Video_MaxFrameRate;
            }
            if (requestVideo_video_MaxFrameRate != null)
            {
                request.Video.MaxFrameRate = requestVideo_video_MaxFrameRate;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_MaxHeight = null;
            if (cmdletContext.Video_MaxHeight != null)
            {
                requestVideo_video_MaxHeight = cmdletContext.Video_MaxHeight;
            }
            if (requestVideo_video_MaxHeight != null)
            {
                request.Video.MaxHeight = requestVideo_video_MaxHeight;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_MaxWidth = null;
            if (cmdletContext.Video_MaxWidth != null)
            {
                requestVideo_video_MaxWidth = cmdletContext.Video_MaxWidth;
            }
            if (requestVideo_video_MaxWidth != null)
            {
                request.Video.MaxWidth = requestVideo_video_MaxWidth;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_PaddingPolicy = null;
            if (cmdletContext.Video_PaddingPolicy != null)
            {
                requestVideo_video_PaddingPolicy = cmdletContext.Video_PaddingPolicy;
            }
            if (requestVideo_video_PaddingPolicy != null)
            {
                request.Video.PaddingPolicy = requestVideo_video_PaddingPolicy;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_Resolution = null;
            if (cmdletContext.Video_Resolution != null)
            {
                requestVideo_video_Resolution = cmdletContext.Video_Resolution;
            }
            if (requestVideo_video_Resolution != null)
            {
                request.Video.Resolution = requestVideo_video_Resolution;
                requestVideoIsNull = false;
            }
            System.String requestVideo_video_SizingPolicy = null;
            if (cmdletContext.Video_SizingPolicy != null)
            {
                requestVideo_video_SizingPolicy = cmdletContext.Video_SizingPolicy;
            }
            if (requestVideo_video_SizingPolicy != null)
            {
                request.Video.SizingPolicy = requestVideo_video_SizingPolicy;
                requestVideoIsNull = false;
            }
            List<Amazon.ElasticTranscoder.Model.PresetWatermark> requestVideo_video_Watermark = null;
            if (cmdletContext.Video_Watermark != null)
            {
                requestVideo_video_Watermark = cmdletContext.Video_Watermark;
            }
            if (requestVideo_video_Watermark != null)
            {
                request.Video.Watermarks = requestVideo_video_Watermark;
                requestVideoIsNull = false;
            }
             // determine if request.Video should be set to null
            if (requestVideoIsNull)
            {
                request.Video = null;
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
        
        private Amazon.ElasticTranscoder.Model.CreatePresetResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.CreatePresetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Transcoder", "CreatePreset");
            try
            {
                return client.CreatePresetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Audio_AudioPackingMode { get; set; }
            public System.String Audio_BitRate { get; set; }
            public System.String Audio_Channel { get; set; }
            public System.String Audio_Codec { get; set; }
            public System.String CodecOptions_BitDepth { get; set; }
            public System.String CodecOptions_BitOrder { get; set; }
            public System.String CodecOptions_Profile { get; set; }
            public System.String CodecOptions_Signed { get; set; }
            public System.String Audio_SampleRate { get; set; }
            public System.String Container { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Thumbnails_AspectRatio { get; set; }
            public System.String Thumbnails_Format { get; set; }
            public System.String Thumbnails_Interval { get; set; }
            public System.String Thumbnails_MaxHeight { get; set; }
            public System.String Thumbnails_MaxWidth { get; set; }
            public System.String Thumbnails_PaddingPolicy { get; set; }
            public System.String Thumbnails_Resolution { get; set; }
            public System.String Thumbnails_SizingPolicy { get; set; }
            public System.String Video_AspectRatio { get; set; }
            public System.String Video_BitRate { get; set; }
            public System.String Video_Codec { get; set; }
            public Dictionary<System.String, System.String> Video_CodecOption { get; set; }
            public System.String Video_DisplayAspectRatio { get; set; }
            public System.String Video_FixedGOP { get; set; }
            public System.String Video_FrameRate { get; set; }
            public System.String Video_KeyframesMaxDist { get; set; }
            public System.String Video_MaxFrameRate { get; set; }
            public System.String Video_MaxHeight { get; set; }
            public System.String Video_MaxWidth { get; set; }
            public System.String Video_PaddingPolicy { get; set; }
            public System.String Video_Resolution { get; set; }
            public System.String Video_SizingPolicy { get; set; }
            public List<Amazon.ElasticTranscoder.Model.PresetWatermark> Video_Watermark { get; set; }
            public System.Func<Amazon.ElasticTranscoder.Model.CreatePresetResponse, NewETSPresetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
