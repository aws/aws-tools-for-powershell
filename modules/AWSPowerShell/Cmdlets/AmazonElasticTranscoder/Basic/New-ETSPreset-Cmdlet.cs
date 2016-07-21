/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The CreatePreset operation creates a preset with settings that you specify.
    /// 
    ///  <important>Elastic Transcoder checks the CreatePreset settings to ensure that they
    /// meet Elastic Transcoder requirements and to determine whether they comply with H.264
    /// standards. If your settings are not valid for Elastic Transcoder, Elastic Transcoder
    /// returns an HTTP 400 response (<code>ValidationException</code>) and does not create
    /// the preset. If the settings are valid for Elastic Transcoder but aren't strictly compliant
    /// with the H.264 standard, Elastic Transcoder creates the preset and returns a warning
    /// message in the response. This helps you determine whether your settings comply with
    /// the H.264 standard while giving you greater flexibility with respect to the video
    /// that Elastic Transcoder produces.</important><para>
    /// Elastic Transcoder uses the H.264 video-compression format. For more information,
    /// see the International Telecommunication Union publication <i>Recommendation ITU-T
    /// H.264: Advanced video coding for generic audiovisual services</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ETSPreset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticTranscoder.Model.CreatePresetResponse")]
    [AWSCmdlet("Invokes the CreatePreset operation against Amazon Elastic Transcoder.", Operation = new[] {"CreatePreset"})]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.CreatePresetResponse",
        "This cmdlet returns a Amazon.ElasticTranscoder.Model.CreatePresetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewETSPresetCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        #region Parameter Thumbnails_AspectRatio
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of thumbnails, we recommend that you
        /// use the values <code>MaxWidth</code>, <code>MaxHeight</code>, <code>SizingPolicy</code>,
        /// and <code>PaddingPolicy</code> instead of <code>Resolution</code> and <code>AspectRatio</code>.
        /// The two groups of settings are mutually exclusive. Do not use them together.</para></important><para>The aspect ratio of thumbnails. Valid values include:</para><para><code>auto</code>, <code>1:1</code>, <code>4:3</code>, <code>3:2</code>, <code>16:9</code></para><para>If you specify <code>auto</code>, Elastic Transcoder tries to preserve the aspect
        /// ratio of the video in the output file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_AspectRatio { get; set; }
        #endregion
        
        #region Parameter Video_AspectRatio
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of output videos, we recommend that
        /// you use the values <code>MaxWidth</code>, <code>MaxHeight</code>, <code>SizingPolicy</code>,
        /// <code>PaddingPolicy</code>, and <code>DisplayAspectRatio</code> instead of <code>Resolution</code>
        /// and <code>AspectRatio</code>. The two groups of settings are mutually exclusive. Do
        /// not use them together.</para></important><para>The display aspect ratio of the video in the output file. Valid values include:</para><para><code>auto</code>, <code>1:1</code>, <code>4:3</code>, <code>3:2</code>, <code>16:9</code></para><para>If you specify <code>auto</code>, Elastic Transcoder tries to preserve the aspect
        /// ratio of the input file.</para><para>If you specify an aspect ratio for the output file that differs from aspect ratio
        /// of the input file, Elastic Transcoder adds pillarboxing (black bars on the sides)
        /// or letterboxing (black bars on the top and bottom) to maintain the aspect ratio of
        /// the active region of the video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_AspectRatio { get; set; }
        #endregion
        
        #region Parameter Audio_AudioPackingMode
        /// <summary>
        /// <para>
        /// <para>The method of organizing audio channels and tracks. Use <code>Audio:Channels</code>
        /// to specify the number of channels in your output, and <code>Audio:AudioPackingMode</code>
        /// to specify the number of tracks and their relation to the channels. If you do not
        /// specify an <code>Audio:AudioPackingMode</code>, Elastic Transcoder uses <code>SingleTrack</code>.</para><para>The following values are valid:</para><para><code>SingleTrack</code>, <code>OneChannelPerTrack</code>, and <code>OneChannelPerTrackWithMosTo8Tracks</code></para><para>When you specify <code>SingleTrack</code>, Elastic Transcoder creates a single track
        /// for your output. The track can have up to eight channels. Use <code>SingleTrack</code>
        /// for all non-<code>mxf</code> containers.</para><para>The outputs of <code>SingleTrack</code> for a specific channel value and inputs are
        /// as follows:</para><ul><li><code>0</code><b> channels with any input:</b> Audio omitted from the output</li><li><code>1, 2, or auto </code><b>channels with no audio input:</b> Audio omitted
        /// from the output</li><li><code>1 </code><b>channel with any input with audio:</b>
        /// One track with one channel, downmixed if necessary</li><li><code>2 </code><b>channels
        /// with one track with one channel:</b> One track with two identical channels</li><li><code>2
        /// or auto </code><b>channels with two tracks with one channel each:</b> One track with
        /// two channels</li><li><code>2 or auto </code><b>channels with one track with two
        /// channels:</b> One track with two channels</li><li><code>2 </code><b>channels with
        /// one track with multiple channels:</b> One track with two channels</li><li><code>auto
        /// </code><b>channels with one track with one channel:</b> One track with one channel</li><li><code>auto </code><b>channels with one track with multiple channels:</b> One
        /// track with multiple channels</li></ul><para>When you specify <code>OneChannelPerTrack</code>, Elastic Transcoder creates a new
        /// track for every channel in your output. Your output can have up to eight single-channel
        /// tracks.</para><para>The outputs of <code>OneChannelPerTrack</code> for a specific channel value and inputs
        /// are as follows:</para><ul><li><code>0 </code><b>channels with any input:</b> Audio omitted from the output</li><li><code>1, 2, or auto </code><b>channels with no audio input:</b> Audio omitted
        /// from the output</li><li><code>1 </code><b>channel with any input with audio:</b>
        /// One track with one channel, downmixed if necessary</li><li><code>2 </code><b>channels
        /// with one track with one channel:</b> Two tracks with one identical channel each</li><li><code>2 or auto </code><b>channels with two tracks with one channel each:</b>
        /// Two tracks with one channel each</li><li><code>2 or auto </code><b>channels with
        /// one track with two channels:</b> Two tracks with one channel each</li><li><code>2
        /// </code><b>channels with one track with multiple channels:</b> Two tracks with one
        /// channel each</li><li><code>auto </code><b>channels with one track with one channel:</b>
        /// One track with one channel</li><li><code>auto </code><b>channels with one track
        /// with multiple channels:</b> Up to eight tracks with one channel each</li></ul><para>When you specify <code>OneChannelPerTrackWithMosTo8Tracks</code>, Elastic Transcoder
        /// creates eight single-channel tracks for your output. All tracks that do not contain
        /// audio data from an input channel are MOS, or Mit Out Sound, tracks.</para><para>The outputs of <code>OneChannelPerTrackWithMosTo8Tracks</code> for a specific channel
        /// value and inputs are as follows:</para><ul><li><code>0 </code><b>channels with any input:</b> Audio omitted from the output</li><li><code>1, 2, or auto </code><b>channels with no audio input:</b> Audio omitted
        /// from the output</li><li><code>1 </code><b>channel with any input with audio:</b>
        /// One track with one channel, downmixed if necessary, plus six MOS tracks</li><li><code>2
        /// </code><b>channels with one track with one channel:</b> Two tracks with one identical
        /// channel each, plus six MOS tracks</li><li><code>2 or auto </code><b>channels with
        /// two tracks with one channel each:</b> Two tracks with one channel each, plus six MOS
        /// tracks</li><li><code>2 or auto </code><b>channels with one track with two channels:</b>
        /// Two tracks with one channel each, plus six MOS tracks</li><li><code>2 </code><b>channels
        /// with one track with multiple channels:</b> Two tracks with one channel each, plus
        /// six MOS tracks</li><li><code>auto </code><b>channels with one track with one channel:</b>
        /// One track with one channel, plus seven MOS tracks</li><li><code>auto </code><b>channels
        /// with one track with multiple channels:</b> Up to eight tracks with one channel each,
        /// plus MOS tracks until there are eight tracks in all</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Audio_AudioPackingMode { get; set; }
        #endregion
        
        #region Parameter CodecOptions_BitDepth
        /// <summary>
        /// <para>
        /// <para>You can only choose an audio bit depth when you specify <code>flac</code> or <code>pcm</code>
        /// for the value of Audio:Codec.</para><para>The bit depth of a sample is how many bits of information are included in the audio
        /// samples. The higher the bit depth, the better the audio, but the larger the file.</para><para>Valid values are <code>16</code> and <code>24</code>.</para><para>The most common bit depth is <code>24</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Audio_CodecOptions_BitDepth")]
        public System.String CodecOptions_BitDepth { get; set; }
        #endregion
        
        #region Parameter CodecOptions_BitOrder
        /// <summary>
        /// <para>
        /// <para>You can only choose an audio bit order when you specify <code>pcm</code> for the value
        /// of Audio:Codec.</para><para>The order the bits of a PCM sample are stored in.</para><para>The supported value is <code>LittleEndian</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String Audio_BitRate { get; set; }
        #endregion
        
        #region Parameter Video_BitRate
        /// <summary>
        /// <para>
        /// <para>The bit rate of the video stream in the output file, in kilobits/second. Valid values
        /// depend on the values of <code>Level</code> and <code>Profile</code>. If you specify
        /// <code>auto</code>, Elastic Transcoder uses the detected bit rate of the input source.
        /// If you specify a value other than <code>auto</code>, we recommend that you specify
        /// a value less than or equal to the maximum H.264-compliant value listed for your level
        /// and profile:</para><para><i>Level - Maximum video bit rate in kilobits/second (baseline and main Profile)
        /// : maximum video bit rate in kilobits/second (high Profile)</i></para><ul><li>1 - 64 : 80</li><li>1b - 128 : 160</li><li>1.1 - 192 : 240</li><li>1.2
        /// - 384 : 480</li><li>1.3 - 768 : 960</li><li>2 - 2000 : 2500</li><li>3 - 10000 :
        /// 12500</li><li>3.1 - 14000 : 17500</li><li>3.2 - 20000 : 25000</li><li>4 - 20000
        /// : 25000</li><li>4.1 - 50000 : 62500</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_BitRate { get; set; }
        #endregion
        
        #region Parameter Audio_Channel
        /// <summary>
        /// <para>
        /// <para>The number of audio channels in the output file. The following values are valid:</para><para><code>auto</code>, <code>0</code>, <code>1</code>, <code>2</code></para><para>One channel carries the information played by a single speaker. For example, a stereo
        /// track with two channels sends one channel to the left speaker, and the other channel
        /// to the right speaker. The output channels are organized into tracks. If you want Elastic
        /// Transcoder to automatically detect the number of audio channels in the input file
        /// and use that value for the output file, select <code>auto</code>.</para><para>The output of a specific channel value and inputs are as follows:</para><ul><li><code>auto</code><b> channel specified, with any input:</b> Pass through
        /// up to eight input channels.</li><li><code>0</code><b> channels specified, with any
        /// input:</b> Audio omitted from the output.</li><li><code>1</code><b> channel specified,
        /// with at least one input channel:</b> Mono sound.</li><li><code>2</code><b> channels
        /// specified, with any input:</b> Two identical mono channels or stereo. For more information
        /// about tracks, see <code>Audio:AudioPackingMode.</code></li></ul><para> For more information about how Elastic Transcoder organizes channels and tracks,
        /// see <code>Audio:AudioPackingMode</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Audio_Channels")]
        public System.String Audio_Channel { get; set; }
        #endregion
        
        #region Parameter Audio_Codec
        /// <summary>
        /// <para>
        /// <para>The audio codec for the output file. Valid values include <code>aac</code>, <code>flac</code>,
        /// <code>mp2</code>, <code>mp3</code>, <code>pcm</code>, and <code>vorbis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Audio_Codec { get; set; }
        #endregion
        
        #region Parameter Video_Codec
        /// <summary>
        /// <para>
        /// <para>The video codec for the output file. Valid values include <code>gif</code>, <code>H.264</code>,
        /// <code>mpeg2</code>, and <code>vp8</code>. You can only specify <code>vp8</code> when
        /// the container type is <code>webm</code>, <code>gif</code> when the container type
        /// is <code>gif</code>, and <code>mpeg2</code> when the container type is <code>mpg</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_Codec { get; set; }
        #endregion
        
        #region Parameter Video_CodecOption
        /// <summary>
        /// <para>
        /// <para><b>Profile (H.264/VP8 Only)</b></para><para>The H.264 profile that you want to use for the output file. Elastic Transcoder supports
        /// the following profiles:</para><ul><li><code>baseline</code>: The profile most commonly used for videoconferencing
        /// and for mobile applications.</li><li><code>main</code>: The profile used for standard-definition
        /// digital TV broadcasts.</li><li><code>high</code>: The profile used for high-definition
        /// digital TV broadcasts and for Blu-ray discs.</li></ul><para><b>Level (H.264 Only)</b></para><para>The H.264 level that you want to use for the output file. Elastic Transcoder supports
        /// the following levels:</para><para><code>1</code>, <code>1b</code>, <code>1.1</code>, <code>1.2</code>, <code>1.3</code>,
        /// <code>2</code>, <code>2.1</code>, <code>2.2</code>, <code>3</code>, <code>3.1</code>,
        /// <code>3.2</code>, <code>4</code>, <code>4.1</code></para><para><b>MaxReferenceFrames (H.264 Only)</b></para><para>Applicable only when the value of Video:Codec is H.264. The maximum number of previously
        /// decoded frames to use as a reference for decoding future frames. Valid values are
        /// integers 0 through 16, but we recommend that you not use a value greater than the
        /// following:</para><para><code>Min(Floor(Maximum decoded picture buffer in macroblocks * 256 / (Width in pixels
        /// * Height in pixels)), 16)</code></para><para>where <i>Width in pixels</i> and <i>Height in pixels</i> represent either MaxWidth
        /// and MaxHeight, or Resolution. <i>Maximum decoded picture buffer in macroblocks</i>
        /// depends on the value of the <code>Level</code> object. See the list below. (A macroblock
        /// is a block of pixels measuring 16x16.) </para><ul><li>1 - 396</li><li>1b - 396</li><li>1.1 - 900</li><li>1.2 - 2376</li><li>1.3
        /// - 2376</li><li>2 - 2376</li><li>2.1 - 4752</li><li>2.2 - 8100</li><li>3 - 8100</li><li>3.1 - 18000</li><li>3.2 - 20480</li><li>4 - 32768</li><li>4.1 - 32768</li></ul><para><b>MaxBitRate (Optional, H.264/MPEG2/VP8 only)</b></para><para>The maximum number of bits per second in a video buffer; the size of the buffer is
        /// specified by <code>BufferSize</code>. Specify a value between 16 and 62,500. You can
        /// reduce the bandwidth required to stream a video by reducing the maximum bit rate,
        /// but this also reduces the quality of the video.</para><para><b>BufferSize (Optional, H.264/MPEG2/VP8 only)</b></para><para>The maximum number of bits in any x seconds of the output video. This window is commonly
        /// 10 seconds, the standard segment duration when you're using FMP4 or MPEG-TS for the
        /// container type of the output video. Specify an integer greater than 0. If you specify
        /// <code>MaxBitRate</code> and omit <code>BufferSize</code>, Elastic Transcoder sets
        /// <code>BufferSize</code> to 10 times the value of <code>MaxBitRate</code>.</para><para><b>InterlacedMode (Optional, H.264/MPEG2 Only)</b></para><para>The interlace mode for the output video.</para><para>Interlaced video is used to double the perceived frame rate for a video by interlacing
        /// two fields (one field on every other line, the other field on the other lines) so
        /// that the human eye registers multiple pictures per frame. Interlacing reduces the
        /// bandwidth required for transmitting a video, but can result in blurred images and
        /// flickering.</para><para>Valid values include <code>Progressive</code> (no interlacing, top to bottom), <code>TopFirst</code>
        /// (top field first), <code>BottomFirst</code> (bottom field first), and <code>Auto</code>.</para><para>If <code>InterlaceMode</code> is not specified, Elastic Transcoder uses <code>Progressive</code>
        /// for the output. If <code>Auto</code> is specified, Elastic Transcoder interlaces the
        /// output.</para><para><b>ColorSpaceConversionMode (Optional, H.264/MPEG2 Only)</b></para><para>The color space conversion Elastic Transcoder applies to the output video. Color spaces
        /// are the algorithms used by the computer to store information about how to render color.
        /// <code>Bt.601</code> is the standard for standard definition video, while <code>Bt.709</code>
        /// is the standard for high definition video.</para><para>Valid values include <code>None</code>, <code>Bt709toBt601</code>, <code>Bt601toBt709</code>,
        /// and <code>Auto</code>.</para><para>If you chose <code>Auto</code> for <code>ColorSpaceConversionMode</code> and your
        /// output is interlaced, your frame rate is one of <code>23.97</code>, <code>24</code>,
        /// <code>25</code>, <code>29.97</code>, <code>50</code>, or <code>60</code>, your <code>SegmentDuration</code>
        /// is null, and you are using one of the resolution changes from the list below, Elastic
        /// Transcoder applies the following color space conversions:</para><ul><li><i>Standard to HD, 720x480 to 1920x1080</i> - Elastic Transcoder applies
        /// <code>Bt601ToBt709</code></li><li><i>Standard to HD, 720x576 to 1920x1080</i> - Elastic
        /// Transcoder applies <code>Bt601ToBt709</code></li><li><i>HD to Standard, 1920x1080
        /// to 720x480</i> - Elastic Transcoder applies <code>Bt709ToBt601</code></li><li><i>HD
        /// to Standard, 1920x1080 to 720x576</i> - Elastic Transcoder applies <code>Bt709ToBt601</code></li></ul><note>Elastic Transcoder may change the behavior of the <code>ColorspaceConversionMode</code><code>Auto</code> mode in the future. All outputs in a playlist must use the same
        /// <code>ColorSpaceConversionMode</code>.</note><para>If you do not specify a <code>ColorSpaceConversionMode</code>, Elastic Transcoder
        /// does not change the color space of a file. If you are unsure what <code>ColorSpaceConversionMode</code>
        /// was applied to your output file, you can check the <code>AppliedColorSpaceConversion</code>
        /// parameter included in your job response. If your job does not have an <code>AppliedColorSpaceConversion</code>
        /// in its response, no <code>ColorSpaceConversionMode</code> was applied.</para><para><b>ChromaSubsampling</b></para><para>The sampling pattern for the chroma (color) channels of the output video. Valid values
        /// include <code>yuv420p</code> and <code>yuv422p</code>.</para><para><code>yuv420p</code> samples the chroma information of every other horizontal and
        /// every other vertical line, <code>yuv422p</code> samples the color information of every
        /// horizontal line and every other vertical line.</para><para><b>LoopCount (Gif Only)</b></para><para>The number of times you want the output gif to loop. Valid values include <code>Infinite</code>
        /// and integers between <code>0</code> and <code>100</code>, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Video_CodecOptions")]
        public System.Collections.Hashtable Video_CodecOption { get; set; }
        #endregion
        
        #region Parameter Container
        /// <summary>
        /// <para>
        /// <para>The container type for the output file. Valid values include <code>flac</code>, <code>flv</code>,
        /// <code>fmp4</code>, <code>gif</code>, <code>mp3</code>, <code>mp4</code>, <code>mpg</code>,
        /// <code>mxf</code>, <code>oga</code>, <code>ogg</code>, <code>ts</code>, and <code>webm</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Container { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the preset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Video_DisplayAspectRatio
        /// <summary>
        /// <para>
        /// <para>The value that Elastic Transcoder adds to the metadata in the output file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_DisplayAspectRatio { get; set; }
        #endregion
        
        #region Parameter Video_FixedGOP
        /// <summary>
        /// <para>
        /// <para>Applicable only when the value of Video:Codec is one of <code>H.264</code>, <code>MPEG2</code>,
        /// or <code>VP8</code>.</para><para>Whether to use a fixed value for <code>FixedGOP</code>. Valid values are <code>true</code>
        /// and <code>false</code>:</para><ul><li><code>true</code>: Elastic Transcoder uses the value of <code>KeyframesMaxDist</code>
        /// for the distance between key frames (the number of frames in a group of pictures,
        /// or GOP).</li><li><code>false</code>: The distance between key frames can vary.</li></ul><important><para><code>FixedGOP</code> must be set to <code>true</code> for <code>fmp4</code> containers.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_FixedGOP { get; set; }
        #endregion
        
        #region Parameter Thumbnails_Format
        /// <summary>
        /// <para>
        /// <para>The format of thumbnails, if any. Valid values are <code>jpg</code> and <code>png</code>.
        /// </para><para>You specify whether you want Elastic Transcoder to create thumbnails when you create
        /// a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_Format { get; set; }
        #endregion
        
        #region Parameter Video_FrameRate
        /// <summary>
        /// <para>
        /// <para>The frames per second for the video stream in the output file. Valid values include:</para><para><code>auto</code>, <code>10</code>, <code>15</code>, <code>23.97</code>, <code>24</code>,
        /// <code>25</code>, <code>29.97</code>, <code>30</code>, <code>60</code></para><para>If you specify <code>auto</code>, Elastic Transcoder uses the detected frame rate
        /// of the input source. If you specify a frame rate, we recommend that you perform the
        /// following calculation:</para><para><code>Frame rate = maximum recommended decoding speed in luma samples/second / (width
        /// in pixels * height in pixels)</code></para><para>where:</para><ul><li><i>width in pixels</i> and <i>height in pixels</i> represent the Resolution
        /// of the output video.</li><li><i>maximum recommended decoding speed in Luma samples/second</i>
        /// is less than or equal to the maximum value listed in the following table, based on
        /// the value that you specified for Level.</li></ul><para>The maximum recommended decoding speed in Luma samples/second for each level is described
        /// in the following list (<i>Level - Decoding speed</i>):</para><ul><li>1 - 380160</li><li>1b - 380160</li><li>1.1 - 76800</li><li>1.2 - 1536000</li><li>1.3 - 3041280</li><li>2 - 3041280</li><li>2.1 - 5068800</li><li>2.2 - 5184000</li><li>3 - 10368000</li><li>3.1 - 27648000</li><li>3.2 - 55296000</li><li>4 - 62914560</li><li>4.1 - 62914560</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_FrameRate { get; set; }
        #endregion
        
        #region Parameter Thumbnails_Interval
        /// <summary>
        /// <para>
        /// <para>The approximate number of seconds between thumbnails. Specify an integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_Interval { get; set; }
        #endregion
        
        #region Parameter Video_KeyframesMaxDist
        /// <summary>
        /// <para>
        /// <para>Applicable only when the value of Video:Codec is one of <code>H.264</code>, <code>MPEG2</code>,
        /// or <code>VP8</code>.</para><para>The maximum number of frames between key frames. Key frames are fully encoded frames;
        /// the frames between key frames are encoded based, in part, on the content of the key
        /// frames. The value is an integer formatted as a string; valid values are between 1
        /// (every frame is a key frame) and 100000, inclusive. A higher value results in higher
        /// compression but may also discernibly decrease video quality.</para><para>For <code>Smooth</code> outputs, the <code>FrameRate</code> must have a constant ratio
        /// to the <code>KeyframesMaxDist</code>. This allows <code>Smooth</code> playlists to
        /// switch between different quality levels while the file is being played.</para><para>For example, an input file can have a <code>FrameRate</code> of 30 with a <code>KeyframesMaxDist</code>
        /// of 90. The output file then needs to have a ratio of 1:3. Valid outputs would have
        /// <code>FrameRate</code> of 30, 25, and 10, and <code>KeyframesMaxDist</code> of 90,
        /// 75, and 30, respectively.</para><para>Alternately, this can be achieved by setting <code>FrameRate</code> to auto and having
        /// the same values for <code>MaxFrameRate</code> and <code>KeyframesMaxDist</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_KeyframesMaxDist { get; set; }
        #endregion
        
        #region Parameter Video_MaxFrameRate
        /// <summary>
        /// <para>
        /// <para>If you specify <code>auto</code> for <code>FrameRate</code>, Elastic Transcoder uses
        /// the frame rate of the input video for the frame rate of the output video. Specify
        /// the maximum frame rate that you want Elastic Transcoder to use when the frame rate
        /// of the input video is greater than the desired maximum frame rate of the output video.
        /// Valid values include: <code>10</code>, <code>15</code>, <code>23.97</code>, <code>24</code>,
        /// <code>25</code>, <code>29.97</code>, <code>30</code>, <code>60</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_MaxFrameRate { get; set; }
        #endregion
        
        #region Parameter Thumbnails_MaxHeight
        /// <summary>
        /// <para>
        /// <para>The maximum height of thumbnails in pixels. If you specify auto, Elastic Transcoder
        /// uses 1080 (Full HD) as the default value. If you specify a numeric value, enter an
        /// even integer between 32 and 3072. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_MaxHeight { get; set; }
        #endregion
        
        #region Parameter Video_MaxHeight
        /// <summary>
        /// <para>
        /// <para>The maximum height of the output video in pixels. If you specify <code>auto</code>,
        /// Elastic Transcoder uses 1080 (Full HD) as the default value. If you specify a numeric
        /// value, enter an even integer between 96 and 3072.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_MaxHeight { get; set; }
        #endregion
        
        #region Parameter Thumbnails_MaxWidth
        /// <summary>
        /// <para>
        /// <para>The maximum width of thumbnails in pixels. If you specify auto, Elastic Transcoder
        /// uses 1920 (Full HD) as the default value. If you specify a numeric value, enter an
        /// even integer between 32 and 4096. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_MaxWidth { get; set; }
        #endregion
        
        #region Parameter Video_MaxWidth
        /// <summary>
        /// <para>
        /// <para> The maximum width of the output video in pixels. If you specify <code>auto</code>,
        /// Elastic Transcoder uses 1920 (Full HD) as the default value. If you specify a numeric
        /// value, enter an even integer between 128 and 4096. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_MaxWidth { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the preset. We recommend that the name be unique within the AWS account,
        /// but uniqueness is not enforced.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Thumbnails_PaddingPolicy
        /// <summary>
        /// <para>
        /// <para>When you set <code>PaddingPolicy</code> to <code>Pad</code>, Elastic Transcoder may
        /// add black bars to the top and bottom and/or left and right sides of thumbnails to
        /// make the total size of the thumbnails match the values that you specified for thumbnail
        /// <code>MaxWidth</code> and <code>MaxHeight</code> settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_PaddingPolicy { get; set; }
        #endregion
        
        #region Parameter Video_PaddingPolicy
        /// <summary>
        /// <para>
        /// <para>When you set <code>PaddingPolicy</code> to <code>Pad</code>, Elastic Transcoder may
        /// add black bars to the top and bottom and/or left and right sides of the output video
        /// to make the total size of the output video match the values that you specified for
        /// <code>MaxWidth</code> and <code>MaxHeight</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_PaddingPolicy { get; set; }
        #endregion
        
        #region Parameter CodecOptions_Profile
        /// <summary>
        /// <para>
        /// <para>You can only choose an audio profile when you specify AAC for the value of Audio:Codec.</para><para>Specify the AAC profile for the output file. Elastic Transcoder supports the following
        /// profiles:</para><ul><li><code>auto</code>: If you specify <code>auto</code>, Elastic Transcoder
        /// will select the profile based on the bit rate selected for the output file.</li><li><code>AAC-LC</code>:
        /// The most common AAC profile. Use for bit rates larger than 64 kbps.</li><li><code>HE-AAC</code>:
        /// Not supported on some older players and devices. Use for bit rates between 40 and
        /// 80 kbps.</li><li><code>HE-AACv2</code>: Not supported on some players and devices.
        /// Use for bit rates less than 48 kbps.</li></ul><para>All outputs in a <code>Smooth</code> playlist must have the same value for <code>Profile</code>.</para><note><para>If you created any presets before AAC profiles were added, Elastic Transcoder automatically
        /// updated your presets to use AAC-LC. You can change the value as required.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Audio_CodecOptions_Profile")]
        public System.String CodecOptions_Profile { get; set; }
        #endregion
        
        #region Parameter Thumbnails_Resolution
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of thumbnails, we recommend that you
        /// use the values <code>MaxWidth</code>, <code>MaxHeight</code>, <code>SizingPolicy</code>,
        /// and <code>PaddingPolicy</code> instead of <code>Resolution</code> and <code>AspectRatio</code>.
        /// The two groups of settings are mutually exclusive. Do not use them together.</para></important><para>The width and height of thumbnail files in pixels. Specify a value in the format <code><i>width</i></code>
        /// x <code><i>height</i></code> where both values are even integers. The values cannot
        /// exceed the width and height that you specified in the <code>Video:Resolution</code>
        /// object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_Resolution { get; set; }
        #endregion
        
        #region Parameter Video_Resolution
        /// <summary>
        /// <para>
        /// <important><para>To better control resolution and aspect ratio of output videos, we recommend that
        /// you use the values <code>MaxWidth</code>, <code>MaxHeight</code>, <code>SizingPolicy</code>,
        /// <code>PaddingPolicy</code>, and <code>DisplayAspectRatio</code> instead of <code>Resolution</code>
        /// and <code>AspectRatio</code>. The two groups of settings are mutually exclusive. Do
        /// not use them together.</para></important><para>The width and height of the video in the output file, in pixels. Valid values are
        /// <code>auto</code> and <i>width</i> x <i>height</i>:</para><ul><li><code>auto</code>: Elastic Transcoder attempts to preserve the width and
        /// height of the input file, subject to the following rules.</li><li><code><i>width</i>
        /// x <i>height</i></code>: The width and height of the output video in pixels.</li></ul><para>Note the following about specifying the width and height:</para><ul><li>The width must be an even integer between 128 and 4096, inclusive.</li><li>The height must be an even integer between 96 and 3072, inclusive.</li><li>If
        /// you specify a resolution that is less than the resolution of the input file, Elastic
        /// Transcoder rescales the output file to the lower resolution.</li><li>If you specify
        /// a resolution that is greater than the resolution of the input file, Elastic Transcoder
        /// rescales the output to the higher resolution.</li><li>We recommend that you specify
        /// a resolution for which the product of width and height is less than or equal to the
        /// applicable value in the following list (<i>List - Max width x height value</i>):</li><ul><li>1 - 25344</li><li>1b - 25344</li><li>1.1 - 101376</li><li>1.2 - 101376</li><li>1.3 - 101376</li><li>2 - 101376</li><li>2.1 - 202752</li><li>2.2 - 404720</li><li>3 - 404720</li><li>3.1 - 921600</li><li>3.2 - 1310720</li><li>4 - 2097152</li><li>4.1 - 2097152</li></ul></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Video_Resolution { get; set; }
        #endregion
        
        #region Parameter Audio_SampleRate
        /// <summary>
        /// <para>
        /// <para>The sample rate of the audio stream in the output file, in Hertz. Valid values include:</para><para><code>auto</code>, <code>22050</code>, <code>32000</code>, <code>44100</code>, <code>48000</code>,
        /// <code>96000</code></para><para>If you specify <code>auto</code>, Elastic Transcoder automatically detects the sample
        /// rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Audio_SampleRate { get; set; }
        #endregion
        
        #region Parameter CodecOptions_Signed
        /// <summary>
        /// <para>
        /// <para>You can only choose whether an audio sample is signed when you specify <code>pcm</code>
        /// for the value of Audio:Codec.</para><para>Whether audio samples are represented with negative and positive numbers (signed)
        /// or only positive numbers (unsigned).</para><para>The supported value is <code>Signed</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Audio_CodecOptions_Signed")]
        public System.String CodecOptions_Signed { get; set; }
        #endregion
        
        #region Parameter Thumbnails_SizingPolicy
        /// <summary>
        /// <para>
        /// <para>Specify one of the following values to control scaling of thumbnails:</para><para><ul><li><code>Fit</code>: Elastic Transcoder scales thumbnails so they match the
        /// value that you specified in thumbnail MaxWidth or MaxHeight settings without exceeding
        /// the other value. </li><li><code>Fill</code>: Elastic Transcoder scales thumbnails
        /// so they match the value that you specified in thumbnail <code>MaxWidth</code> or <code>MaxHeight</code>
        /// settings and matches or exceeds the other value. Elastic Transcoder centers the image
        /// in thumbnails and then crops in the dimension (if any) that exceeds the maximum value.</li><li><code>Stretch</code>: Elastic Transcoder stretches thumbnails to match the values
        /// that you specified for thumbnail <code>MaxWidth</code> and <code>MaxHeight</code>
        /// settings. If the relative proportions of the input video and thumbnails are different,
        /// the thumbnails will be distorted.</li><li><code>Keep</code>: Elastic Transcoder does
        /// not scale thumbnails. If either dimension of the input video exceeds the values that
        /// you specified for thumbnail <code>MaxWidth</code> and <code>MaxHeight</code> settings,
        /// Elastic Transcoder crops the thumbnails.</li><li><code>ShrinkToFit</code>: Elastic
        /// Transcoder scales thumbnails down so that their dimensions match the values that you
        /// specified for at least one of thumbnail <code>MaxWidth</code> and <code>MaxHeight</code>
        /// without exceeding either value. If you specify this option, Elastic Transcoder does
        /// not scale thumbnails up.</li><li><code>ShrinkToFill</code>: Elastic Transcoder scales
        /// thumbnails down so that their dimensions match the values that you specified for at
        /// least one of <code>MaxWidth</code> and <code>MaxHeight</code> without dropping below
        /// either value. If you specify this option, Elastic Transcoder does not scale thumbnails
        /// up.</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Thumbnails_SizingPolicy { get; set; }
        #endregion
        
        #region Parameter Video_SizingPolicy
        /// <summary>
        /// <para>
        /// <para>Specify one of the following values to control scaling of the output video:</para><para><ul><li><code>Fit</code>: Elastic Transcoder scales the output video so it matches
        /// the value that you specified in either <code>MaxWidth</code> or <code>MaxHeight</code>
        /// without exceeding the other value.</li><li><code>Fill</code>: Elastic Transcoder
        /// scales the output video so it matches the value that you specified in either <code>MaxWidth</code>
        /// or <code>MaxHeight</code> and matches or exceeds the other value. Elastic Transcoder
        /// centers the output video and then crops it in the dimension (if any) that exceeds
        /// the maximum value.</li><li><code>Stretch</code>: Elastic Transcoder stretches the
        /// output video to match the values that you specified for <code>MaxWidth</code> and
        /// <code>MaxHeight</code>. If the relative proportions of the input video and the output
        /// video are different, the output video will be distorted.</li><li><code>Keep</code>:
        /// Elastic Transcoder does not scale the output video. If either dimension of the input
        /// video exceeds the values that you specified for <code>MaxWidth</code> and <code>MaxHeight</code>,
        /// Elastic Transcoder crops the output video.</li><li><code>ShrinkToFit</code>: Elastic
        /// Transcoder scales the output video down so that its dimensions match the values that
        /// you specified for at least one of <code>MaxWidth</code> and <code>MaxHeight</code>
        /// without exceeding either value. If you specify this option, Elastic Transcoder does
        /// not scale the video up.</li><li><code>ShrinkToFill</code>: Elastic Transcoder scales
        /// the output video down so that its dimensions match the values that you specified for
        /// at least one of <code>MaxWidth</code> and <code>MaxHeight</code> without dropping
        /// below either value. If you specify this option, Elastic Transcoder does not scale
        /// the video up.</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// allows you to use the same preset for up to four watermarks that have different dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Video_Watermarks")]
        public Amazon.ElasticTranscoder.Model.PresetWatermark[] Video_Watermark { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ETSPreset (CreatePreset)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Audio_AudioPackingMode = this.Audio_AudioPackingMode;
            context.Audio_BitRate = this.Audio_BitRate;
            context.Audio_Channels = this.Audio_Channel;
            context.Audio_Codec = this.Audio_Codec;
            context.Audio_CodecOptions_BitDepth = this.CodecOptions_BitDepth;
            context.Audio_CodecOptions_BitOrder = this.CodecOptions_BitOrder;
            context.Audio_CodecOptions_Profile = this.CodecOptions_Profile;
            context.Audio_CodecOptions_Signed = this.CodecOptions_Signed;
            context.Audio_SampleRate = this.Audio_SampleRate;
            context.Container = this.Container;
            context.Description = this.Description;
            context.Name = this.Name;
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
                context.Video_CodecOptions = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Video_CodecOption.Keys)
                {
                    context.Video_CodecOptions.Add((String)hashKey, (String)(this.Video_CodecOption[hashKey]));
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
                context.Video_Watermarks = new List<Amazon.ElasticTranscoder.Model.PresetWatermark>(this.Video_Watermark);
            }
            
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
            bool requestAudioIsNull = true;
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
            if (cmdletContext.Audio_Channels != null)
            {
                requestAudio_audio_Channel = cmdletContext.Audio_Channels;
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
            bool requestAudio_audio_CodecOptionsIsNull = true;
            requestAudio_audio_CodecOptions = new Amazon.ElasticTranscoder.Model.AudioCodecOptions();
            System.String requestAudio_audio_CodecOptions_codecOptions_BitDepth = null;
            if (cmdletContext.Audio_CodecOptions_BitDepth != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_BitDepth = cmdletContext.Audio_CodecOptions_BitDepth;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_BitDepth != null)
            {
                requestAudio_audio_CodecOptions.BitDepth = requestAudio_audio_CodecOptions_codecOptions_BitDepth;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
            System.String requestAudio_audio_CodecOptions_codecOptions_BitOrder = null;
            if (cmdletContext.Audio_CodecOptions_BitOrder != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_BitOrder = cmdletContext.Audio_CodecOptions_BitOrder;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_BitOrder != null)
            {
                requestAudio_audio_CodecOptions.BitOrder = requestAudio_audio_CodecOptions_codecOptions_BitOrder;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
            System.String requestAudio_audio_CodecOptions_codecOptions_Profile = null;
            if (cmdletContext.Audio_CodecOptions_Profile != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_Profile = cmdletContext.Audio_CodecOptions_Profile;
            }
            if (requestAudio_audio_CodecOptions_codecOptions_Profile != null)
            {
                requestAudio_audio_CodecOptions.Profile = requestAudio_audio_CodecOptions_codecOptions_Profile;
                requestAudio_audio_CodecOptionsIsNull = false;
            }
            System.String requestAudio_audio_CodecOptions_codecOptions_Signed = null;
            if (cmdletContext.Audio_CodecOptions_Signed != null)
            {
                requestAudio_audio_CodecOptions_codecOptions_Signed = cmdletContext.Audio_CodecOptions_Signed;
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
            bool requestThumbnailsIsNull = true;
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
            bool requestVideoIsNull = true;
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
            if (cmdletContext.Video_CodecOptions != null)
            {
                requestVideo_video_CodecOption = cmdletContext.Video_CodecOptions;
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
            if (cmdletContext.Video_Watermarks != null)
            {
                requestVideo_video_Watermark = cmdletContext.Video_Watermarks;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.ElasticTranscoder.Model.CreatePresetResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.CreatePresetRequest request)
        {
            return client.CreatePreset(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Audio_AudioPackingMode { get; set; }
            public System.String Audio_BitRate { get; set; }
            public System.String Audio_Channels { get; set; }
            public System.String Audio_Codec { get; set; }
            public System.String Audio_CodecOptions_BitDepth { get; set; }
            public System.String Audio_CodecOptions_BitOrder { get; set; }
            public System.String Audio_CodecOptions_Profile { get; set; }
            public System.String Audio_CodecOptions_Signed { get; set; }
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
            public Dictionary<System.String, System.String> Video_CodecOptions { get; set; }
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
            public List<Amazon.ElasticTranscoder.Model.PresetWatermark> Video_Watermarks { get; set; }
        }
        
    }
}
