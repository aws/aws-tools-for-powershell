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
    /// When you create a job, Elastic Transcoder returns JSON data that includes the values
    /// that you specified plus information about the job that is created.
    /// 
    ///  
    /// <para>
    /// If you have specified more than one output for your jobs (for example, one output
    /// for the Kindle Fire and another output for the Apple iPhone 4s), you currently must
    /// use the Elastic Transcoder API to list the jobs (as opposed to the AWS Console).
    /// </para>
    /// </summary>
    [Cmdlet("New", "ETSJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticTranscoder.Model.Job")]
    [AWSCmdlet("Calls the Amazon Elastic Transcoder CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.ElasticTranscoder.Model.CreateJobResponse))]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Job or Amazon.ElasticTranscoder.Model.CreateJobResponse",
        "This cmdlet returns an Amazon.ElasticTranscoder.Model.Job object.",
        "The service call response (type Amazon.ElasticTranscoder.Model.CreateJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewETSJobCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AlbumArt_Artwork
        /// <summary>
        /// <para>
        /// <para>The file to be used as album art. There can be multiple artworks associated with an
        /// audio file, to a maximum of 20. Valid formats are <c>.jpg</c> and <c>.png</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_AlbumArt_Artwork")]
        public Amazon.ElasticTranscoder.Model.Artwork[] AlbumArt_Artwork { get; set; }
        #endregion
        
        #region Parameter Input_AspectRatio
        /// <summary>
        /// <para>
        /// <para> The aspect ratio of the input file. If you want Elastic Transcoder to automatically
        /// detect the aspect ratio of the input file, specify <c>auto</c>. If you want to specify
        /// the aspect ratio for the output file, enter one of the following values: </para><para><c>1:1</c>, <c>4:3</c>, <c>3:2</c>, <c>16:9</c></para><para> If you specify a value other than <c>auto</c>, Elastic Transcoder disables automatic
        /// detection of the aspect ratio. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_AspectRatio { get; set; }
        #endregion
        
        #region Parameter Captions_CaptionFormat
        /// <summary>
        /// <para>
        /// <para>The array of file formats for the output captions. If you leave this value blank,
        /// Elastic Transcoder returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_Captions_CaptionFormats")]
        public Amazon.ElasticTranscoder.Model.CaptionFormat[] Captions_CaptionFormat { get; set; }
        #endregion
        
        #region Parameter InputCaptions_CaptionSource
        /// <summary>
        /// <para>
        /// <para>Source files for the input sidecar captions used during the transcoding process. To
        /// omit all sidecar captions, leave <c>CaptionSources</c> blank.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputCaptions_CaptionSources")]
        public Amazon.ElasticTranscoder.Model.CaptionSource[] InputCaptions_CaptionSource { get; set; }
        #endregion
        
        #region Parameter Input_Container
        /// <summary>
        /// <para>
        /// <para>The container type for the input file. If you want Elastic Transcoder to automatically
        /// detect the container type of the input file, specify <c>auto</c>. If you want to specify
        /// the container type for the input file, enter one of the following values: </para><para><c>3gp</c>, <c>aac</c>, <c>asf</c>, <c>avi</c>, <c>divx</c>, <c>flv</c>, <c>m4a</c>,
        /// <c>mkv</c>, <c>mov</c>, <c>mp3</c>, <c>mp4</c>, <c>mpeg</c>, <c>mpeg-ps</c>, <c>mpeg-ts</c>,
        /// <c>mxf</c>, <c>ogg</c>, <c>vob</c>, <c>wav</c>, <c>webm</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Container { get; set; }
        #endregion
        
        #region Parameter TimeSpan_Duration
        /// <summary>
        /// <para>
        /// <para>The duration of the clip. The format can be either HH:mm:ss.SSS (maximum value: 23:59:59.999;
        /// SSS is thousandths of a second) or sssss.SSS (maximum value: 86399.999). If you don't
        /// specify a value, Elastic Transcoder creates an output file from StartTime to the end
        /// of the file.</para><para>If you specify a value longer than the duration of the input file, Elastic Transcoder
        /// transcodes the file and returns a warning message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_TimeSpan_Duration")]
        public System.String TimeSpan_Duration { get; set; }
        #endregion
        
        #region Parameter DetectedProperties_DurationMilli
        /// <summary>
        /// <para>
        /// <para>The detected duration of the input file, in milliseconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DetectedProperties_DurationMillis")]
        public System.Int64? DetectedProperties_DurationMilli { get; set; }
        #endregion
        
        #region Parameter DetectedProperties_FileSize
        /// <summary>
        /// <para>
        /// <para>The detected file size of the input file, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DetectedProperties_FileSize")]
        public System.Int64? DetectedProperties_FileSize { get; set; }
        #endregion
        
        #region Parameter DetectedProperties_FrameRate
        /// <summary>
        /// <para>
        /// <para>The detected frame rate of the input file, in frames per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DetectedProperties_FrameRate")]
        public System.String DetectedProperties_FrameRate { get; set; }
        #endregion
        
        #region Parameter Input_FrameRate
        /// <summary>
        /// <para>
        /// <para>The frame rate of the input file. If you want Elastic Transcoder to automatically
        /// detect the frame rate of the input file, specify <c>auto</c>. If you want to specify
        /// the frame rate for the input file, enter one of the following values: </para><para><c>10</c>, <c>15</c>, <c>23.97</c>, <c>24</c>, <c>25</c>, <c>29.97</c>, <c>30</c>,
        /// <c>60</c></para><para>If you specify a value other than <c>auto</c>, Elastic Transcoder disables automatic
        /// detection of the frame rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_FrameRate { get; set; }
        #endregion
        
        #region Parameter DetectedProperties_Height
        /// <summary>
        /// <para>
        /// <para>The detected height of the input file, in pixels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DetectedProperties_Height")]
        public System.Int32? DetectedProperties_Height { get; set; }
        #endregion
        
        #region Parameter InputEncryptionInitializationVector
        /// <summary>
        /// <para>
        /// <para>The series of random bits created by a random bit generator, unique for every encryption
        /// operation, that you used to encrypt your input files or that you want Elastic Transcoder
        /// to use to encrypt your output files. The initialization vector must be base64-encoded,
        /// and it must be exactly 16 bytes long before being base64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Encryption_InitializationVector")]
        public System.String InputEncryptionInitializationVector { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionInitializationVector
        /// <summary>
        /// <para>
        /// <para>The series of random bits created by a random bit generator, unique for every encryption
        /// operation, that you used to encrypt your input files or that you want Elastic Transcoder
        /// to use to encrypt your output files. The initialization vector must be base64-encoded,
        /// and it must be exactly 16 bytes long before being base64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_Encryption_InitializationVector")]
        public System.String OutputEncryptionInitializationVector { get; set; }
        #endregion
        
        #region Parameter ThumbnailEncryption_InitializationVector
        /// <summary>
        /// <para>
        /// <para>The series of random bits created by a random bit generator, unique for every encryption
        /// operation, that you used to encrypt your input files or that you want Elastic Transcoder
        /// to use to encrypt your output files. The initialization vector must be base64-encoded,
        /// and it must be exactly 16 bytes long before being base64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_ThumbnailEncryption_InitializationVector")]
        public System.String ThumbnailEncryption_InitializationVector { get; set; }
        #endregion
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>A section of the request body that provides information about the files that are being
        /// transcoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Inputs")]
        public Amazon.ElasticTranscoder.Model.JobInput[] Input { get; set; }
        #endregion
        
        #region Parameter Input_Interlaced
        /// <summary>
        /// <para>
        /// <para>Whether the input file is interlaced. If you want Elastic Transcoder to automatically
        /// detect whether the input file is interlaced, specify <c>auto</c>. If you want to specify
        /// whether the input file is interlaced, enter one of the following values:</para><para><c>true</c>, <c>false</c></para><para>If you specify a value other than <c>auto</c>, Elastic Transcoder disables automatic
        /// detection of interlacing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Interlaced { get; set; }
        #endregion
        
        #region Parameter InputEncryptionKey
        /// <summary>
        /// <para>
        /// <para>The data encryption key that you want Elastic Transcoder to use to encrypt your output
        /// file, or that was used to encrypt your input file. The key must be base64-encoded
        /// and it must be one of the following bit lengths before being base64-encoded:</para><para><c>128</c>, <c>192</c>, or <c>256</c>. </para><para>The key must also be encrypted by using the Amazon Key Management Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Encryption_Key")]
        public System.String InputEncryptionKey { get; set; }
        #endregion
        
        #region Parameter Input_Key
        /// <summary>
        /// <para>
        /// <para> The name of the file to transcode. Elsewhere in the body of the JSON block is the
        /// the ID of the pipeline to use for processing the job. The <c>InputBucket</c> object
        /// in that pipeline tells Elastic Transcoder which Amazon S3 bucket to get the file from.
        /// </para><para>If the file name includes a prefix, such as <c>cooking/lasagna.mpg</c>, include the
        /// prefix in the key. If the file isn't in the specified bucket, Elastic Transcoder returns
        /// an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Key { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKey
        /// <summary>
        /// <para>
        /// <para>The data encryption key that you want Elastic Transcoder to use to encrypt your output
        /// file, or that was used to encrypt your input file. The key must be base64-encoded
        /// and it must be one of the following bit lengths before being base64-encoded:</para><para><c>128</c>, <c>192</c>, or <c>256</c>. </para><para>The key must also be encrypted by using the Amazon Key Management Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_Encryption_Key")]
        public System.String OutputEncryptionKey { get; set; }
        #endregion
        
        #region Parameter Output_Key
        /// <summary>
        /// <para>
        /// <para> The name to assign to the transcoded file. Elastic Transcoder saves the file in the
        /// Amazon S3 bucket specified by the <c>OutputBucket</c> object in the pipeline that
        /// is specified by the pipeline ID. If a file with the specified name already exists
        /// in the output bucket, the job fails. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Output_Key { get; set; }
        #endregion
        
        #region Parameter ThumbnailEncryption_Key
        /// <summary>
        /// <para>
        /// <para>The data encryption key that you want Elastic Transcoder to use to encrypt your output
        /// file, or that was used to encrypt your input file. The key must be base64-encoded
        /// and it must be one of the following bit lengths before being base64-encoded:</para><para><c>128</c>, <c>192</c>, or <c>256</c>. </para><para>The key must also be encrypted by using the Amazon Key Management Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_ThumbnailEncryption_Key")]
        public System.String ThumbnailEncryption_Key { get; set; }
        #endregion
        
        #region Parameter InputEncryptionKeyMd5
        /// <summary>
        /// <para>
        /// <para>The MD5 digest of the key that you used to encrypt your input file, or that you want
        /// Elastic Transcoder to use to encrypt your output file. Elastic Transcoder uses the
        /// key digest as a checksum to make sure your key was not corrupted in transit. The key
        /// MD5 must be base64-encoded, and it must be exactly 16 bytes long before being base64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Encryption_KeyMd5")]
        public System.String InputEncryptionKeyMd5 { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKeyMd5
        /// <summary>
        /// <para>
        /// <para>The MD5 digest of the key that you used to encrypt your input file, or that you want
        /// Elastic Transcoder to use to encrypt your output file. Elastic Transcoder uses the
        /// key digest as a checksum to make sure your key was not corrupted in transit. The key
        /// MD5 must be base64-encoded, and it must be exactly 16 bytes long before being base64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_Encryption_KeyMd5")]
        public System.String OutputEncryptionKeyMd5 { get; set; }
        #endregion
        
        #region Parameter ThumbnailEncryption_KeyMd5
        /// <summary>
        /// <para>
        /// <para>The MD5 digest of the key that you used to encrypt your input file, or that you want
        /// Elastic Transcoder to use to encrypt your output file. Elastic Transcoder uses the
        /// key digest as a checksum to make sure your key was not corrupted in transit. The key
        /// MD5 must be base64-encoded, and it must be exactly 16 bytes long before being base64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_ThumbnailEncryption_KeyMd5")]
        public System.String ThumbnailEncryption_KeyMd5 { get; set; }
        #endregion
        
        #region Parameter InputCaptions_MergePolicy
        /// <summary>
        /// <para>
        /// <para>A policy that determines how Elastic Transcoder handles the existence of multiple
        /// captions.</para><ul><li><para><b>MergeOverride:</b> Elastic Transcoder transcodes both embedded and sidecar captions
        /// into outputs. If captions for a language are embedded in the input file and also appear
        /// in a sidecar file, Elastic Transcoder uses the sidecar captions and ignores the embedded
        /// captions for that language.</para></li><li><para><b>MergeRetain:</b> Elastic Transcoder transcodes both embedded and sidecar captions
        /// into outputs. If captions for a language are embedded in the input file and also appear
        /// in a sidecar file, Elastic Transcoder uses the embedded captions and ignores the sidecar
        /// captions for that language. If <c>CaptionSources</c> is empty, Elastic Transcoder
        /// omits all sidecar captions from the output files.</para></li><li><para><b>Override:</b> Elastic Transcoder transcodes only the sidecar captions that you
        /// specify in <c>CaptionSources</c>.</para></li></ul><para><c>MergePolicy</c> cannot be null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputCaptions_MergePolicy")]
        public System.String InputCaptions_MergePolicy { get; set; }
        #endregion
        
        #region Parameter AlbumArt_MergePolicy
        /// <summary>
        /// <para>
        /// <para>A policy that determines how Elastic Transcoder handles the existence of multiple
        /// album artwork files.</para><ul><li><para><c>Replace:</c> The specified album art replaces any existing album art.</para></li><li><para><c>Prepend:</c> The specified album art is placed in front of any existing album
        /// art.</para></li><li><para><c>Append:</c> The specified album art is placed after any existing album art.</para></li><li><para><c>Fallback:</c> If the original input file contains artwork, Elastic Transcoder
        /// uses that artwork for the output. If the original input does not contain artwork,
        /// Elastic Transcoder uses the specified album art file.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_AlbumArt_MergePolicy")]
        public System.String AlbumArt_MergePolicy { get; set; }
        #endregion
        
        #region Parameter InputEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The specific server-side encryption mode that you want Elastic Transcoder to use when
        /// decrypting your input files or encrypting your output files. Elastic Transcoder supports
        /// the following options:</para><ul><li><para><b>s3:</b> Amazon S3 creates and manages the keys used for encrypting your files.</para></li><li><para><b>s3-aws-kms:</b> Amazon S3 calls the Amazon Key Management Service, which creates
        /// and manages the keys that are used for encrypting your files. If you specify <c>s3-aws-kms</c>
        /// and you don't want to use the default key, you must add the AWS-KMS key that you want
        /// to use to your pipeline.</para></li><li><para><b>aes-cbc-pkcs7:</b> A padded cipher-block mode of operation originally used for
        /// HLS files.</para></li><li><para><b>aes-ctr:</b> AES Counter Mode.</para></li><li><para><b>aes-gcm:</b> AES Galois Counter Mode, a mode of operation that is an authenticated
        /// encryption format, meaning that a file, key, or initialization vector that has been
        /// tampered with fails the decryption process.</para></li></ul><para>For all three AES options, you must provide the following settings, which must be
        /// base64-encoded:</para><ul><li><para><b>Key</b></para></li><li><para><b>Key MD5</b></para></li><li><para><b>Initialization Vector</b></para></li></ul><important><para>For the AES modes, your private encryption keys and your unencrypted data are never
        /// stored by AWS; therefore, it is important that you safely manage your encryption keys.
        /// If you lose them, you won't be able to unencrypt your data.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Encryption_Mode")]
        public System.String InputEncryptionMode { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The specific server-side encryption mode that you want Elastic Transcoder to use when
        /// decrypting your input files or encrypting your output files. Elastic Transcoder supports
        /// the following options:</para><ul><li><para><b>s3:</b> Amazon S3 creates and manages the keys used for encrypting your files.</para></li><li><para><b>s3-aws-kms:</b> Amazon S3 calls the Amazon Key Management Service, which creates
        /// and manages the keys that are used for encrypting your files. If you specify <c>s3-aws-kms</c>
        /// and you don't want to use the default key, you must add the AWS-KMS key that you want
        /// to use to your pipeline.</para></li><li><para><b>aes-cbc-pkcs7:</b> A padded cipher-block mode of operation originally used for
        /// HLS files.</para></li><li><para><b>aes-ctr:</b> AES Counter Mode.</para></li><li><para><b>aes-gcm:</b> AES Galois Counter Mode, a mode of operation that is an authenticated
        /// encryption format, meaning that a file, key, or initialization vector that has been
        /// tampered with fails the decryption process.</para></li></ul><para>For all three AES options, you must provide the following settings, which must be
        /// base64-encoded:</para><ul><li><para><b>Key</b></para></li><li><para><b>Key MD5</b></para></li><li><para><b>Initialization Vector</b></para></li></ul><important><para>For the AES modes, your private encryption keys and your unencrypted data are never
        /// stored by AWS; therefore, it is important that you safely manage your encryption keys.
        /// If you lose them, you won't be able to unencrypt your data.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_Encryption_Mode")]
        public System.String OutputEncryptionMode { get; set; }
        #endregion
        
        #region Parameter ThumbnailEncryption_Mode
        /// <summary>
        /// <para>
        /// <para>The specific server-side encryption mode that you want Elastic Transcoder to use when
        /// decrypting your input files or encrypting your output files. Elastic Transcoder supports
        /// the following options:</para><ul><li><para><b>s3:</b> Amazon S3 creates and manages the keys used for encrypting your files.</para></li><li><para><b>s3-aws-kms:</b> Amazon S3 calls the Amazon Key Management Service, which creates
        /// and manages the keys that are used for encrypting your files. If you specify <c>s3-aws-kms</c>
        /// and you don't want to use the default key, you must add the AWS-KMS key that you want
        /// to use to your pipeline.</para></li><li><para><b>aes-cbc-pkcs7:</b> A padded cipher-block mode of operation originally used for
        /// HLS files.</para></li><li><para><b>aes-ctr:</b> AES Counter Mode.</para></li><li><para><b>aes-gcm:</b> AES Galois Counter Mode, a mode of operation that is an authenticated
        /// encryption format, meaning that a file, key, or initialization vector that has been
        /// tampered with fails the decryption process.</para></li></ul><para>For all three AES options, you must provide the following settings, which must be
        /// base64-encoded:</para><ul><li><para><b>Key</b></para></li><li><para><b>Key MD5</b></para></li><li><para><b>Initialization Vector</b></para></li></ul><important><para>For the AES modes, your private encryption keys and your unencrypted data are never
        /// stored by AWS; therefore, it is important that you safely manage your encryption keys.
        /// If you lose them, you won't be able to unencrypt your data.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_ThumbnailEncryption_Mode")]
        public System.String ThumbnailEncryption_Mode { get; set; }
        #endregion
        
        #region Parameter OutputKeyPrefix
        /// <summary>
        /// <para>
        /// <para>The value, if any, that you want Elastic Transcoder to prepend to the names of all
        /// files that this job creates, including output files, thumbnails, and playlists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputKeyPrefix { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para> A section of the request body that provides information about the transcoded (target)
        /// files. We recommend that you use the <c>Outputs</c> syntax instead of the <c>Output</c>
        /// syntax. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Outputs")]
        public Amazon.ElasticTranscoder.Model.CreateJobOutput[] Output { get; set; }
        #endregion
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The <c>Id</c> of the pipeline that you want Elastic Transcoder to use for transcoding.
        /// The pipeline determines several settings, including the Amazon S3 bucket from which
        /// Elastic Transcoder gets the files to transcode and the bucket into which Elastic Transcoder
        /// puts the transcoded files.</para>
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
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter Playlist
        /// <summary>
        /// <para>
        /// <para>If you specify a preset in <c>PresetId</c> for which the value of <c>Container</c>
        /// is fmp4 (Fragmented MP4) or ts (MPEG-TS), Playlists contains information about the
        /// master playlists that you want Elastic Transcoder to create.</para><para>The maximum number of master playlists in a job is 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Playlists")]
        public Amazon.ElasticTranscoder.Model.CreateJobPlaylist[] Playlist { get; set; }
        #endregion
        
        #region Parameter Output_PresetId
        /// <summary>
        /// <para>
        /// <para> The <c>Id</c> of the preset to use for this job. The preset determines the audio,
        /// video, and thumbnail settings that Elastic Transcoder uses for transcoding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Output_PresetId { get; set; }
        #endregion
        
        #region Parameter Input_Resolution
        /// <summary>
        /// <para>
        /// <para>This value must be <c>auto</c>, which causes Elastic Transcoder to automatically detect
        /// the resolution of the input file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Resolution { get; set; }
        #endregion
        
        #region Parameter Output_Rotate
        /// <summary>
        /// <para>
        /// <para> The number of degrees clockwise by which you want Elastic Transcoder to rotate the
        /// output relative to the input. Enter one of the following values: <c>auto</c>, <c>0</c>,
        /// <c>90</c>, <c>180</c>, <c>270</c>. The value <c>auto</c> generally works only if the
        /// file that you're transcoding contains rotation metadata. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Output_Rotate { get; set; }
        #endregion
        
        #region Parameter Output_SegmentDuration
        /// <summary>
        /// <para>
        /// <important><para>(Outputs in Fragmented MP4 or MPEG-TS format only.</para></important><para>If you specify a preset in <c>PresetId</c> for which the value of <c>Container</c>
        /// is <c>fmp4</c> (Fragmented MP4) or <c>ts</c> (MPEG-TS), <c>SegmentDuration</c> is
        /// the target maximum duration of each segment in seconds. For <c>HLSv3</c> format playlists,
        /// each media segment is stored in a separate <c>.ts</c> file. For <c>HLSv4</c> and <c>Smooth</c>
        /// playlists, all media segments for an output are stored in a single file. Each segment
        /// is approximately the length of the <c>SegmentDuration</c>, though individual segments
        /// might be shorter or longer.</para><para>The range of valid values is 1 to 60 seconds. If the duration of the video is not
        /// evenly divisible by <c>SegmentDuration</c>, the duration of the last segment is the
        /// remainder of total length/SegmentDuration.</para><para>Elastic Transcoder creates an output-specific playlist for each output <c>HLS</c>
        /// output that you specify in OutputKeys. To add an output to the master playlist for
        /// this job, include it in the <c>OutputKeys</c> of the associated playlist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Output_SegmentDuration { get; set; }
        #endregion
        
        #region Parameter TimeSpan_StartTime
        /// <summary>
        /// <para>
        /// <para>The place in the input file where you want a clip to start. The format can be either
        /// HH:mm:ss.SSS (maximum value: 23:59:59.999; SSS is thousandths of a second) or sssss.SSS
        /// (maximum value: 86399.999). If you don't specify a value, Elastic Transcoder starts
        /// at the beginning of the input file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_TimeSpan_StartTime")]
        public System.String TimeSpan_StartTime { get; set; }
        #endregion
        
        #region Parameter Output_ThumbnailPattern
        /// <summary>
        /// <para>
        /// <para>Whether you want Elastic Transcoder to create thumbnails for your videos and, if so,
        /// how you want Elastic Transcoder to name the files.</para><para>If you don't want Elastic Transcoder to create thumbnails, specify "".</para><para>If you do want Elastic Transcoder to create thumbnails, specify the information that
        /// you want to include in the file name for each thumbnail. You can specify the following
        /// values in any sequence:</para><ul><li><para><b><c>{count}</c> (Required)</b>: If you want to create thumbnails, you must include
        /// <c>{count}</c> in the <c>ThumbnailPattern</c> object. Wherever you specify <c>{count}</c>,
        /// Elastic Transcoder adds a five-digit sequence number (beginning with <b>00001</b>)
        /// to thumbnail file names. The number indicates where a given thumbnail appears in the
        /// sequence of thumbnails for a transcoded file. </para><important><para>If you specify a literal value and/or <c>{resolution}</c> but you omit <c>{count}</c>,
        /// Elastic Transcoder returns a validation error and does not create the job.</para></important></li><li><para><b>Literal values (Optional)</b>: You can specify literal values anywhere in the
        /// <c>ThumbnailPattern</c> object. For example, you can include them as a file name prefix
        /// or as a delimiter between <c>{resolution}</c> and <c>{count}</c>. </para></li><li><para><b><c>{resolution}</c> (Optional)</b>: If you want Elastic Transcoder to include
        /// the resolution in the file name, include <c>{resolution}</c> in the <c>ThumbnailPattern</c>
        /// object. </para></li></ul><para>When creating thumbnails, Elastic Transcoder automatically saves the files in the
        /// format (.jpg or .png) that appears in the preset that you specified in the <c>PresetID</c>
        /// value of <c>CreateJobOutput</c>. Elastic Transcoder also appends the applicable file
        /// name extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Output_ThumbnailPattern { get; set; }
        #endregion
        
        #region Parameter UserMetadata
        /// <summary>
        /// <para>
        /// <para>User-defined metadata that you want to associate with an Elastic Transcoder job. You
        /// specify metadata in <c>key/value</c> pairs, and you can add up to 10 <c>key/value</c>
        /// pairs per job. Elastic Transcoder does not guarantee that <c>key/value</c> pairs are
        /// returned in the same order in which you specify them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable UserMetadata { get; set; }
        #endregion
        
        #region Parameter Output_Watermark
        /// <summary>
        /// <para>
        /// <para>Information about the watermarks that you want Elastic Transcoder to add to the video
        /// during transcoding. You can specify up to four watermarks for each output. Settings
        /// for each watermark must be defined in the preset for the current output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_Watermarks")]
        public Amazon.ElasticTranscoder.Model.JobWatermark[] Output_Watermark { get; set; }
        #endregion
        
        #region Parameter DetectedProperties_Width
        /// <summary>
        /// <para>
        /// <para>The detected width of the input file, in pixels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_DetectedProperties_Width")]
        public System.Int32? DetectedProperties_Width { get; set; }
        #endregion
        
        #region Parameter Captions_CaptionSource
        /// <summary>
        /// <para>
        /// <para>Source files for the input sidecar captions used during the transcoding process. To
        /// omit all sidecar captions, leave <c>CaptionSources</c> blank.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated")]
        [Alias("Output_Captions_CaptionSources")]
        public Amazon.ElasticTranscoder.Model.CaptionSource[] Captions_CaptionSource { get; set; }
        #endregion
        
        #region Parameter Output_Composition
        /// <summary>
        /// <para>
        /// <para>You can create an output file that contains an excerpt from the input file. This excerpt,
        /// called a clip, can come from the beginning, middle, or end of the file. The Composition
        /// object contains settings for the clips that make up an output file. For the current
        /// release, you can only specify settings for a single clip per output file. The Composition
        /// object cannot be null.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated")]
        public Amazon.ElasticTranscoder.Model.Clip[] Output_Composition { get; set; }
        #endregion
        
        #region Parameter Captions_MergePolicy
        /// <summary>
        /// <para>
        /// <para>A policy that determines how Elastic Transcoder handles the existence of multiple
        /// captions.</para><ul><li><para><b>MergeOverride:</b> Elastic Transcoder transcodes both embedded and sidecar captions
        /// into outputs. If captions for a language are embedded in the input file and also appear
        /// in a sidecar file, Elastic Transcoder uses the sidecar captions and ignores the embedded
        /// captions for that language.</para></li><li><para><b>MergeRetain:</b> Elastic Transcoder transcodes both embedded and sidecar captions
        /// into outputs. If captions for a language are embedded in the input file and also appear
        /// in a sidecar file, Elastic Transcoder uses the embedded captions and ignores the sidecar
        /// captions for that language. If <c>CaptionSources</c> is empty, Elastic Transcoder
        /// omits all sidecar captions from the output files.</para></li><li><para><b>Override:</b> Elastic Transcoder transcodes only the sidecar captions that you
        /// specify in <c>CaptionSources</c>.</para></li></ul><para><c>MergePolicy</c> cannot be null.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated")]
        [Alias("Output_Captions_MergePolicy")]
        public System.String Captions_MergePolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Job'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticTranscoder.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.ElasticTranscoder.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Job";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ETSJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticTranscoder.Model.CreateJobResponse, NewETSJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Input_AspectRatio = this.Input_AspectRatio;
            context.Input_Container = this.Input_Container;
            context.DetectedProperties_DurationMilli = this.DetectedProperties_DurationMilli;
            context.DetectedProperties_FileSize = this.DetectedProperties_FileSize;
            context.DetectedProperties_FrameRate = this.DetectedProperties_FrameRate;
            context.DetectedProperties_Height = this.DetectedProperties_Height;
            context.DetectedProperties_Width = this.DetectedProperties_Width;
            context.InputEncryptionInitializationVector = this.InputEncryptionInitializationVector;
            context.InputEncryptionKey = this.InputEncryptionKey;
            context.InputEncryptionKeyMd5 = this.InputEncryptionKeyMd5;
            context.InputEncryptionMode = this.InputEncryptionMode;
            context.Input_FrameRate = this.Input_FrameRate;
            if (this.InputCaptions_CaptionSource != null)
            {
                context.InputCaptions_CaptionSource = new List<Amazon.ElasticTranscoder.Model.CaptionSource>(this.InputCaptions_CaptionSource);
            }
            context.InputCaptions_MergePolicy = this.InputCaptions_MergePolicy;
            context.Input_Interlaced = this.Input_Interlaced;
            context.Input_Key = this.Input_Key;
            context.Input_Resolution = this.Input_Resolution;
            context.TimeSpan_Duration = this.TimeSpan_Duration;
            context.TimeSpan_StartTime = this.TimeSpan_StartTime;
            if (this.Input != null)
            {
                context.Input = new List<Amazon.ElasticTranscoder.Model.JobInput>(this.Input);
            }
            if (this.AlbumArt_Artwork != null)
            {
                context.AlbumArt_Artwork = new List<Amazon.ElasticTranscoder.Model.Artwork>(this.AlbumArt_Artwork);
            }
            context.AlbumArt_MergePolicy = this.AlbumArt_MergePolicy;
            if (this.Captions_CaptionFormat != null)
            {
                context.Captions_CaptionFormat = new List<Amazon.ElasticTranscoder.Model.CaptionFormat>(this.Captions_CaptionFormat);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Captions_CaptionSource != null)
            {
                context.Captions_CaptionSource = new List<Amazon.ElasticTranscoder.Model.CaptionSource>(this.Captions_CaptionSource);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Captions_MergePolicy = this.Captions_MergePolicy;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Output_Composition != null)
            {
                context.Output_Composition = new List<Amazon.ElasticTranscoder.Model.Clip>(this.Output_Composition);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OutputEncryptionInitializationVector = this.OutputEncryptionInitializationVector;
            context.OutputEncryptionKey = this.OutputEncryptionKey;
            context.OutputEncryptionKeyMd5 = this.OutputEncryptionKeyMd5;
            context.OutputEncryptionMode = this.OutputEncryptionMode;
            context.Output_Key = this.Output_Key;
            context.Output_PresetId = this.Output_PresetId;
            context.Output_Rotate = this.Output_Rotate;
            context.Output_SegmentDuration = this.Output_SegmentDuration;
            context.ThumbnailEncryption_InitializationVector = this.ThumbnailEncryption_InitializationVector;
            context.ThumbnailEncryption_Key = this.ThumbnailEncryption_Key;
            context.ThumbnailEncryption_KeyMd5 = this.ThumbnailEncryption_KeyMd5;
            context.ThumbnailEncryption_Mode = this.ThumbnailEncryption_Mode;
            context.Output_ThumbnailPattern = this.Output_ThumbnailPattern;
            if (this.Output_Watermark != null)
            {
                context.Output_Watermark = new List<Amazon.ElasticTranscoder.Model.JobWatermark>(this.Output_Watermark);
            }
            context.OutputKeyPrefix = this.OutputKeyPrefix;
            if (this.Output != null)
            {
                context.Output = new List<Amazon.ElasticTranscoder.Model.CreateJobOutput>(this.Output);
            }
            context.PipelineId = this.PipelineId;
            #if MODULAR
            if (this.PipelineId == null && ParameterWasBound(nameof(this.PipelineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Playlist != null)
            {
                context.Playlist = new List<Amazon.ElasticTranscoder.Model.CreateJobPlaylist>(this.Playlist);
            }
            if (this.UserMetadata != null)
            {
                context.UserMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UserMetadata.Keys)
                {
                    context.UserMetadata.Add((String)hashKey, (System.String)(this.UserMetadata[hashKey]));
                }
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
            var request = new Amazon.ElasticTranscoder.Model.CreateJobRequest();
            
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.ElasticTranscoder.Model.JobInput();
            System.String requestInput_input_AspectRatio = null;
            if (cmdletContext.Input_AspectRatio != null)
            {
                requestInput_input_AspectRatio = cmdletContext.Input_AspectRatio;
            }
            if (requestInput_input_AspectRatio != null)
            {
                request.Input.AspectRatio = requestInput_input_AspectRatio;
                requestInputIsNull = false;
            }
            System.String requestInput_input_Container = null;
            if (cmdletContext.Input_Container != null)
            {
                requestInput_input_Container = cmdletContext.Input_Container;
            }
            if (requestInput_input_Container != null)
            {
                request.Input.Container = requestInput_input_Container;
                requestInputIsNull = false;
            }
            System.String requestInput_input_FrameRate = null;
            if (cmdletContext.Input_FrameRate != null)
            {
                requestInput_input_FrameRate = cmdletContext.Input_FrameRate;
            }
            if (requestInput_input_FrameRate != null)
            {
                request.Input.FrameRate = requestInput_input_FrameRate;
                requestInputIsNull = false;
            }
            System.String requestInput_input_Interlaced = null;
            if (cmdletContext.Input_Interlaced != null)
            {
                requestInput_input_Interlaced = cmdletContext.Input_Interlaced;
            }
            if (requestInput_input_Interlaced != null)
            {
                request.Input.Interlaced = requestInput_input_Interlaced;
                requestInputIsNull = false;
            }
            System.String requestInput_input_Key = null;
            if (cmdletContext.Input_Key != null)
            {
                requestInput_input_Key = cmdletContext.Input_Key;
            }
            if (requestInput_input_Key != null)
            {
                request.Input.Key = requestInput_input_Key;
                requestInputIsNull = false;
            }
            System.String requestInput_input_Resolution = null;
            if (cmdletContext.Input_Resolution != null)
            {
                requestInput_input_Resolution = cmdletContext.Input_Resolution;
            }
            if (requestInput_input_Resolution != null)
            {
                request.Input.Resolution = requestInput_input_Resolution;
                requestInputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.InputCaptions requestInput_input_InputCaptions = null;
            
             // populate InputCaptions
            var requestInput_input_InputCaptionsIsNull = true;
            requestInput_input_InputCaptions = new Amazon.ElasticTranscoder.Model.InputCaptions();
            List<Amazon.ElasticTranscoder.Model.CaptionSource> requestInput_input_InputCaptions_inputCaptions_CaptionSource = null;
            if (cmdletContext.InputCaptions_CaptionSource != null)
            {
                requestInput_input_InputCaptions_inputCaptions_CaptionSource = cmdletContext.InputCaptions_CaptionSource;
            }
            if (requestInput_input_InputCaptions_inputCaptions_CaptionSource != null)
            {
                requestInput_input_InputCaptions.CaptionSources = requestInput_input_InputCaptions_inputCaptions_CaptionSource;
                requestInput_input_InputCaptionsIsNull = false;
            }
            System.String requestInput_input_InputCaptions_inputCaptions_MergePolicy = null;
            if (cmdletContext.InputCaptions_MergePolicy != null)
            {
                requestInput_input_InputCaptions_inputCaptions_MergePolicy = cmdletContext.InputCaptions_MergePolicy;
            }
            if (requestInput_input_InputCaptions_inputCaptions_MergePolicy != null)
            {
                requestInput_input_InputCaptions.MergePolicy = requestInput_input_InputCaptions_inputCaptions_MergePolicy;
                requestInput_input_InputCaptionsIsNull = false;
            }
             // determine if requestInput_input_InputCaptions should be set to null
            if (requestInput_input_InputCaptionsIsNull)
            {
                requestInput_input_InputCaptions = null;
            }
            if (requestInput_input_InputCaptions != null)
            {
                request.Input.InputCaptions = requestInput_input_InputCaptions;
                requestInputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.TimeSpan requestInput_input_TimeSpan = null;
            
             // populate TimeSpan
            var requestInput_input_TimeSpanIsNull = true;
            requestInput_input_TimeSpan = new Amazon.ElasticTranscoder.Model.TimeSpan();
            System.String requestInput_input_TimeSpan_timeSpan_Duration = null;
            if (cmdletContext.TimeSpan_Duration != null)
            {
                requestInput_input_TimeSpan_timeSpan_Duration = cmdletContext.TimeSpan_Duration;
            }
            if (requestInput_input_TimeSpan_timeSpan_Duration != null)
            {
                requestInput_input_TimeSpan.Duration = requestInput_input_TimeSpan_timeSpan_Duration;
                requestInput_input_TimeSpanIsNull = false;
            }
            System.String requestInput_input_TimeSpan_timeSpan_StartTime = null;
            if (cmdletContext.TimeSpan_StartTime != null)
            {
                requestInput_input_TimeSpan_timeSpan_StartTime = cmdletContext.TimeSpan_StartTime;
            }
            if (requestInput_input_TimeSpan_timeSpan_StartTime != null)
            {
                requestInput_input_TimeSpan.StartTime = requestInput_input_TimeSpan_timeSpan_StartTime;
                requestInput_input_TimeSpanIsNull = false;
            }
             // determine if requestInput_input_TimeSpan should be set to null
            if (requestInput_input_TimeSpanIsNull)
            {
                requestInput_input_TimeSpan = null;
            }
            if (requestInput_input_TimeSpan != null)
            {
                request.Input.TimeSpan = requestInput_input_TimeSpan;
                requestInputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.Encryption requestInput_input_Encryption = null;
            
             // populate Encryption
            var requestInput_input_EncryptionIsNull = true;
            requestInput_input_Encryption = new Amazon.ElasticTranscoder.Model.Encryption();
            System.String requestInput_input_Encryption_inputEncryptionInitializationVector = null;
            if (cmdletContext.InputEncryptionInitializationVector != null)
            {
                requestInput_input_Encryption_inputEncryptionInitializationVector = cmdletContext.InputEncryptionInitializationVector;
            }
            if (requestInput_input_Encryption_inputEncryptionInitializationVector != null)
            {
                requestInput_input_Encryption.InitializationVector = requestInput_input_Encryption_inputEncryptionInitializationVector;
                requestInput_input_EncryptionIsNull = false;
            }
            System.String requestInput_input_Encryption_inputEncryptionKey = null;
            if (cmdletContext.InputEncryptionKey != null)
            {
                requestInput_input_Encryption_inputEncryptionKey = cmdletContext.InputEncryptionKey;
            }
            if (requestInput_input_Encryption_inputEncryptionKey != null)
            {
                requestInput_input_Encryption.Key = requestInput_input_Encryption_inputEncryptionKey;
                requestInput_input_EncryptionIsNull = false;
            }
            System.String requestInput_input_Encryption_inputEncryptionKeyMd5 = null;
            if (cmdletContext.InputEncryptionKeyMd5 != null)
            {
                requestInput_input_Encryption_inputEncryptionKeyMd5 = cmdletContext.InputEncryptionKeyMd5;
            }
            if (requestInput_input_Encryption_inputEncryptionKeyMd5 != null)
            {
                requestInput_input_Encryption.KeyMd5 = requestInput_input_Encryption_inputEncryptionKeyMd5;
                requestInput_input_EncryptionIsNull = false;
            }
            System.String requestInput_input_Encryption_inputEncryptionMode = null;
            if (cmdletContext.InputEncryptionMode != null)
            {
                requestInput_input_Encryption_inputEncryptionMode = cmdletContext.InputEncryptionMode;
            }
            if (requestInput_input_Encryption_inputEncryptionMode != null)
            {
                requestInput_input_Encryption.Mode = requestInput_input_Encryption_inputEncryptionMode;
                requestInput_input_EncryptionIsNull = false;
            }
             // determine if requestInput_input_Encryption should be set to null
            if (requestInput_input_EncryptionIsNull)
            {
                requestInput_input_Encryption = null;
            }
            if (requestInput_input_Encryption != null)
            {
                request.Input.Encryption = requestInput_input_Encryption;
                requestInputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.DetectedProperties requestInput_input_DetectedProperties = null;
            
             // populate DetectedProperties
            var requestInput_input_DetectedPropertiesIsNull = true;
            requestInput_input_DetectedProperties = new Amazon.ElasticTranscoder.Model.DetectedProperties();
            System.Int64? requestInput_input_DetectedProperties_detectedProperties_DurationMilli = null;
            if (cmdletContext.DetectedProperties_DurationMilli != null)
            {
                requestInput_input_DetectedProperties_detectedProperties_DurationMilli = cmdletContext.DetectedProperties_DurationMilli.Value;
            }
            if (requestInput_input_DetectedProperties_detectedProperties_DurationMilli != null)
            {
                requestInput_input_DetectedProperties.DurationMillis = requestInput_input_DetectedProperties_detectedProperties_DurationMilli.Value;
                requestInput_input_DetectedPropertiesIsNull = false;
            }
            System.Int64? requestInput_input_DetectedProperties_detectedProperties_FileSize = null;
            if (cmdletContext.DetectedProperties_FileSize != null)
            {
                requestInput_input_DetectedProperties_detectedProperties_FileSize = cmdletContext.DetectedProperties_FileSize.Value;
            }
            if (requestInput_input_DetectedProperties_detectedProperties_FileSize != null)
            {
                requestInput_input_DetectedProperties.FileSize = requestInput_input_DetectedProperties_detectedProperties_FileSize.Value;
                requestInput_input_DetectedPropertiesIsNull = false;
            }
            System.String requestInput_input_DetectedProperties_detectedProperties_FrameRate = null;
            if (cmdletContext.DetectedProperties_FrameRate != null)
            {
                requestInput_input_DetectedProperties_detectedProperties_FrameRate = cmdletContext.DetectedProperties_FrameRate;
            }
            if (requestInput_input_DetectedProperties_detectedProperties_FrameRate != null)
            {
                requestInput_input_DetectedProperties.FrameRate = requestInput_input_DetectedProperties_detectedProperties_FrameRate;
                requestInput_input_DetectedPropertiesIsNull = false;
            }
            System.Int32? requestInput_input_DetectedProperties_detectedProperties_Height = null;
            if (cmdletContext.DetectedProperties_Height != null)
            {
                requestInput_input_DetectedProperties_detectedProperties_Height = cmdletContext.DetectedProperties_Height.Value;
            }
            if (requestInput_input_DetectedProperties_detectedProperties_Height != null)
            {
                requestInput_input_DetectedProperties.Height = requestInput_input_DetectedProperties_detectedProperties_Height.Value;
                requestInput_input_DetectedPropertiesIsNull = false;
            }
            System.Int32? requestInput_input_DetectedProperties_detectedProperties_Width = null;
            if (cmdletContext.DetectedProperties_Width != null)
            {
                requestInput_input_DetectedProperties_detectedProperties_Width = cmdletContext.DetectedProperties_Width.Value;
            }
            if (requestInput_input_DetectedProperties_detectedProperties_Width != null)
            {
                requestInput_input_DetectedProperties.Width = requestInput_input_DetectedProperties_detectedProperties_Width.Value;
                requestInput_input_DetectedPropertiesIsNull = false;
            }
             // determine if requestInput_input_DetectedProperties should be set to null
            if (requestInput_input_DetectedPropertiesIsNull)
            {
                requestInput_input_DetectedProperties = null;
            }
            if (requestInput_input_DetectedProperties != null)
            {
                request.Input.DetectedProperties = requestInput_input_DetectedProperties;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.Input != null)
            {
                request.Inputs = cmdletContext.Input;
            }
            
             // populate Output
            var requestOutputIsNull = true;
            request.Output = new Amazon.ElasticTranscoder.Model.CreateJobOutput();
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<Amazon.ElasticTranscoder.Model.Clip> requestOutput_output_Composition = null;
            if (cmdletContext.Output_Composition != null)
            {
                requestOutput_output_Composition = cmdletContext.Output_Composition;
            }
            if (requestOutput_output_Composition != null)
            {
                request.Output.Composition = requestOutput_output_Composition;
                requestOutputIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestOutput_output_Key = null;
            if (cmdletContext.Output_Key != null)
            {
                requestOutput_output_Key = cmdletContext.Output_Key;
            }
            if (requestOutput_output_Key != null)
            {
                request.Output.Key = requestOutput_output_Key;
                requestOutputIsNull = false;
            }
            System.String requestOutput_output_PresetId = null;
            if (cmdletContext.Output_PresetId != null)
            {
                requestOutput_output_PresetId = cmdletContext.Output_PresetId;
            }
            if (requestOutput_output_PresetId != null)
            {
                request.Output.PresetId = requestOutput_output_PresetId;
                requestOutputIsNull = false;
            }
            System.String requestOutput_output_Rotate = null;
            if (cmdletContext.Output_Rotate != null)
            {
                requestOutput_output_Rotate = cmdletContext.Output_Rotate;
            }
            if (requestOutput_output_Rotate != null)
            {
                request.Output.Rotate = requestOutput_output_Rotate;
                requestOutputIsNull = false;
            }
            System.String requestOutput_output_SegmentDuration = null;
            if (cmdletContext.Output_SegmentDuration != null)
            {
                requestOutput_output_SegmentDuration = cmdletContext.Output_SegmentDuration;
            }
            if (requestOutput_output_SegmentDuration != null)
            {
                request.Output.SegmentDuration = requestOutput_output_SegmentDuration;
                requestOutputIsNull = false;
            }
            System.String requestOutput_output_ThumbnailPattern = null;
            if (cmdletContext.Output_ThumbnailPattern != null)
            {
                requestOutput_output_ThumbnailPattern = cmdletContext.Output_ThumbnailPattern;
            }
            if (requestOutput_output_ThumbnailPattern != null)
            {
                request.Output.ThumbnailPattern = requestOutput_output_ThumbnailPattern;
                requestOutputIsNull = false;
            }
            List<Amazon.ElasticTranscoder.Model.JobWatermark> requestOutput_output_Watermark = null;
            if (cmdletContext.Output_Watermark != null)
            {
                requestOutput_output_Watermark = cmdletContext.Output_Watermark;
            }
            if (requestOutput_output_Watermark != null)
            {
                request.Output.Watermarks = requestOutput_output_Watermark;
                requestOutputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.JobAlbumArt requestOutput_output_AlbumArt = null;
            
             // populate AlbumArt
            var requestOutput_output_AlbumArtIsNull = true;
            requestOutput_output_AlbumArt = new Amazon.ElasticTranscoder.Model.JobAlbumArt();
            List<Amazon.ElasticTranscoder.Model.Artwork> requestOutput_output_AlbumArt_albumArt_Artwork = null;
            if (cmdletContext.AlbumArt_Artwork != null)
            {
                requestOutput_output_AlbumArt_albumArt_Artwork = cmdletContext.AlbumArt_Artwork;
            }
            if (requestOutput_output_AlbumArt_albumArt_Artwork != null)
            {
                requestOutput_output_AlbumArt.Artwork = requestOutput_output_AlbumArt_albumArt_Artwork;
                requestOutput_output_AlbumArtIsNull = false;
            }
            System.String requestOutput_output_AlbumArt_albumArt_MergePolicy = null;
            if (cmdletContext.AlbumArt_MergePolicy != null)
            {
                requestOutput_output_AlbumArt_albumArt_MergePolicy = cmdletContext.AlbumArt_MergePolicy;
            }
            if (requestOutput_output_AlbumArt_albumArt_MergePolicy != null)
            {
                requestOutput_output_AlbumArt.MergePolicy = requestOutput_output_AlbumArt_albumArt_MergePolicy;
                requestOutput_output_AlbumArtIsNull = false;
            }
             // determine if requestOutput_output_AlbumArt should be set to null
            if (requestOutput_output_AlbumArtIsNull)
            {
                requestOutput_output_AlbumArt = null;
            }
            if (requestOutput_output_AlbumArt != null)
            {
                request.Output.AlbumArt = requestOutput_output_AlbumArt;
                requestOutputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.Captions requestOutput_output_Captions = null;
            
             // populate Captions
            var requestOutput_output_CaptionsIsNull = true;
            requestOutput_output_Captions = new Amazon.ElasticTranscoder.Model.Captions();
            List<Amazon.ElasticTranscoder.Model.CaptionFormat> requestOutput_output_Captions_captions_CaptionFormat = null;
            if (cmdletContext.Captions_CaptionFormat != null)
            {
                requestOutput_output_Captions_captions_CaptionFormat = cmdletContext.Captions_CaptionFormat;
            }
            if (requestOutput_output_Captions_captions_CaptionFormat != null)
            {
                requestOutput_output_Captions.CaptionFormats = requestOutput_output_Captions_captions_CaptionFormat;
                requestOutput_output_CaptionsIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            List<Amazon.ElasticTranscoder.Model.CaptionSource> requestOutput_output_Captions_captions_CaptionSource = null;
            if (cmdletContext.Captions_CaptionSource != null)
            {
                requestOutput_output_Captions_captions_CaptionSource = cmdletContext.Captions_CaptionSource;
            }
            if (requestOutput_output_Captions_captions_CaptionSource != null)
            {
                requestOutput_output_Captions.CaptionSources = requestOutput_output_Captions_captions_CaptionSource;
                requestOutput_output_CaptionsIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestOutput_output_Captions_captions_MergePolicy = null;
            if (cmdletContext.Captions_MergePolicy != null)
            {
                requestOutput_output_Captions_captions_MergePolicy = cmdletContext.Captions_MergePolicy;
            }
            if (requestOutput_output_Captions_captions_MergePolicy != null)
            {
                requestOutput_output_Captions.MergePolicy = requestOutput_output_Captions_captions_MergePolicy;
                requestOutput_output_CaptionsIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if requestOutput_output_Captions should be set to null
            if (requestOutput_output_CaptionsIsNull)
            {
                requestOutput_output_Captions = null;
            }
            if (requestOutput_output_Captions != null)
            {
                request.Output.Captions = requestOutput_output_Captions;
                requestOutputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.Encryption requestOutput_output_Encryption = null;
            
             // populate Encryption
            var requestOutput_output_EncryptionIsNull = true;
            requestOutput_output_Encryption = new Amazon.ElasticTranscoder.Model.Encryption();
            System.String requestOutput_output_Encryption_outputEncryptionInitializationVector = null;
            if (cmdletContext.OutputEncryptionInitializationVector != null)
            {
                requestOutput_output_Encryption_outputEncryptionInitializationVector = cmdletContext.OutputEncryptionInitializationVector;
            }
            if (requestOutput_output_Encryption_outputEncryptionInitializationVector != null)
            {
                requestOutput_output_Encryption.InitializationVector = requestOutput_output_Encryption_outputEncryptionInitializationVector;
                requestOutput_output_EncryptionIsNull = false;
            }
            System.String requestOutput_output_Encryption_outputEncryptionKey = null;
            if (cmdletContext.OutputEncryptionKey != null)
            {
                requestOutput_output_Encryption_outputEncryptionKey = cmdletContext.OutputEncryptionKey;
            }
            if (requestOutput_output_Encryption_outputEncryptionKey != null)
            {
                requestOutput_output_Encryption.Key = requestOutput_output_Encryption_outputEncryptionKey;
                requestOutput_output_EncryptionIsNull = false;
            }
            System.String requestOutput_output_Encryption_outputEncryptionKeyMd5 = null;
            if (cmdletContext.OutputEncryptionKeyMd5 != null)
            {
                requestOutput_output_Encryption_outputEncryptionKeyMd5 = cmdletContext.OutputEncryptionKeyMd5;
            }
            if (requestOutput_output_Encryption_outputEncryptionKeyMd5 != null)
            {
                requestOutput_output_Encryption.KeyMd5 = requestOutput_output_Encryption_outputEncryptionKeyMd5;
                requestOutput_output_EncryptionIsNull = false;
            }
            System.String requestOutput_output_Encryption_outputEncryptionMode = null;
            if (cmdletContext.OutputEncryptionMode != null)
            {
                requestOutput_output_Encryption_outputEncryptionMode = cmdletContext.OutputEncryptionMode;
            }
            if (requestOutput_output_Encryption_outputEncryptionMode != null)
            {
                requestOutput_output_Encryption.Mode = requestOutput_output_Encryption_outputEncryptionMode;
                requestOutput_output_EncryptionIsNull = false;
            }
             // determine if requestOutput_output_Encryption should be set to null
            if (requestOutput_output_EncryptionIsNull)
            {
                requestOutput_output_Encryption = null;
            }
            if (requestOutput_output_Encryption != null)
            {
                request.Output.Encryption = requestOutput_output_Encryption;
                requestOutputIsNull = false;
            }
            Amazon.ElasticTranscoder.Model.Encryption requestOutput_output_ThumbnailEncryption = null;
            
             // populate ThumbnailEncryption
            var requestOutput_output_ThumbnailEncryptionIsNull = true;
            requestOutput_output_ThumbnailEncryption = new Amazon.ElasticTranscoder.Model.Encryption();
            System.String requestOutput_output_ThumbnailEncryption_thumbnailEncryption_InitializationVector = null;
            if (cmdletContext.ThumbnailEncryption_InitializationVector != null)
            {
                requestOutput_output_ThumbnailEncryption_thumbnailEncryption_InitializationVector = cmdletContext.ThumbnailEncryption_InitializationVector;
            }
            if (requestOutput_output_ThumbnailEncryption_thumbnailEncryption_InitializationVector != null)
            {
                requestOutput_output_ThumbnailEncryption.InitializationVector = requestOutput_output_ThumbnailEncryption_thumbnailEncryption_InitializationVector;
                requestOutput_output_ThumbnailEncryptionIsNull = false;
            }
            System.String requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Key = null;
            if (cmdletContext.ThumbnailEncryption_Key != null)
            {
                requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Key = cmdletContext.ThumbnailEncryption_Key;
            }
            if (requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Key != null)
            {
                requestOutput_output_ThumbnailEncryption.Key = requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Key;
                requestOutput_output_ThumbnailEncryptionIsNull = false;
            }
            System.String requestOutput_output_ThumbnailEncryption_thumbnailEncryption_KeyMd5 = null;
            if (cmdletContext.ThumbnailEncryption_KeyMd5 != null)
            {
                requestOutput_output_ThumbnailEncryption_thumbnailEncryption_KeyMd5 = cmdletContext.ThumbnailEncryption_KeyMd5;
            }
            if (requestOutput_output_ThumbnailEncryption_thumbnailEncryption_KeyMd5 != null)
            {
                requestOutput_output_ThumbnailEncryption.KeyMd5 = requestOutput_output_ThumbnailEncryption_thumbnailEncryption_KeyMd5;
                requestOutput_output_ThumbnailEncryptionIsNull = false;
            }
            System.String requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Mode = null;
            if (cmdletContext.ThumbnailEncryption_Mode != null)
            {
                requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Mode = cmdletContext.ThumbnailEncryption_Mode;
            }
            if (requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Mode != null)
            {
                requestOutput_output_ThumbnailEncryption.Mode = requestOutput_output_ThumbnailEncryption_thumbnailEncryption_Mode;
                requestOutput_output_ThumbnailEncryptionIsNull = false;
            }
             // determine if requestOutput_output_ThumbnailEncryption should be set to null
            if (requestOutput_output_ThumbnailEncryptionIsNull)
            {
                requestOutput_output_ThumbnailEncryption = null;
            }
            if (requestOutput_output_ThumbnailEncryption != null)
            {
                request.Output.ThumbnailEncryption = requestOutput_output_ThumbnailEncryption;
                requestOutputIsNull = false;
            }
             // determine if request.Output should be set to null
            if (requestOutputIsNull)
            {
                request.Output = null;
            }
            if (cmdletContext.OutputKeyPrefix != null)
            {
                request.OutputKeyPrefix = cmdletContext.OutputKeyPrefix;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            if (cmdletContext.Playlist != null)
            {
                request.Playlists = cmdletContext.Playlist;
            }
            if (cmdletContext.UserMetadata != null)
            {
                request.UserMetadata = cmdletContext.UserMetadata;
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
        
        private Amazon.ElasticTranscoder.Model.CreateJobResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Transcoder", "CreateJob");
            try
            {
                return client.CreateJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Input_AspectRatio { get; set; }
            public System.String Input_Container { get; set; }
            public System.Int64? DetectedProperties_DurationMilli { get; set; }
            public System.Int64? DetectedProperties_FileSize { get; set; }
            public System.String DetectedProperties_FrameRate { get; set; }
            public System.Int32? DetectedProperties_Height { get; set; }
            public System.Int32? DetectedProperties_Width { get; set; }
            public System.String InputEncryptionInitializationVector { get; set; }
            public System.String InputEncryptionKey { get; set; }
            public System.String InputEncryptionKeyMd5 { get; set; }
            public System.String InputEncryptionMode { get; set; }
            public System.String Input_FrameRate { get; set; }
            public List<Amazon.ElasticTranscoder.Model.CaptionSource> InputCaptions_CaptionSource { get; set; }
            public System.String InputCaptions_MergePolicy { get; set; }
            public System.String Input_Interlaced { get; set; }
            public System.String Input_Key { get; set; }
            public System.String Input_Resolution { get; set; }
            public System.String TimeSpan_Duration { get; set; }
            public System.String TimeSpan_StartTime { get; set; }
            public List<Amazon.ElasticTranscoder.Model.JobInput> Input { get; set; }
            public List<Amazon.ElasticTranscoder.Model.Artwork> AlbumArt_Artwork { get; set; }
            public System.String AlbumArt_MergePolicy { get; set; }
            public List<Amazon.ElasticTranscoder.Model.CaptionFormat> Captions_CaptionFormat { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.ElasticTranscoder.Model.CaptionSource> Captions_CaptionSource { get; set; }
            [System.ObsoleteAttribute]
            public System.String Captions_MergePolicy { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.ElasticTranscoder.Model.Clip> Output_Composition { get; set; }
            public System.String OutputEncryptionInitializationVector { get; set; }
            public System.String OutputEncryptionKey { get; set; }
            public System.String OutputEncryptionKeyMd5 { get; set; }
            public System.String OutputEncryptionMode { get; set; }
            public System.String Output_Key { get; set; }
            public System.String Output_PresetId { get; set; }
            public System.String Output_Rotate { get; set; }
            public System.String Output_SegmentDuration { get; set; }
            public System.String ThumbnailEncryption_InitializationVector { get; set; }
            public System.String ThumbnailEncryption_Key { get; set; }
            public System.String ThumbnailEncryption_KeyMd5 { get; set; }
            public System.String ThumbnailEncryption_Mode { get; set; }
            public System.String Output_ThumbnailPattern { get; set; }
            public List<Amazon.ElasticTranscoder.Model.JobWatermark> Output_Watermark { get; set; }
            public System.String OutputKeyPrefix { get; set; }
            public List<Amazon.ElasticTranscoder.Model.CreateJobOutput> Output { get; set; }
            public System.String PipelineId { get; set; }
            public List<Amazon.ElasticTranscoder.Model.CreateJobPlaylist> Playlist { get; set; }
            public Dictionary<System.String, System.String> UserMetadata { get; set; }
            public System.Func<Amazon.ElasticTranscoder.Model.CreateJobResponse, NewETSJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Job;
        }
        
    }
}
