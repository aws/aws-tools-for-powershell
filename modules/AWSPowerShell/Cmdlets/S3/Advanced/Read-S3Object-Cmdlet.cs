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
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.IO;
using Amazon.PowerShell.Utils;
using System.Threading;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// Downloads an S3 object, optionally including sub-objects, to a local file or folder location. Returns a
    /// FileInfo or DirectoryInfo instance to the downloaded file or the containing folder.
    /// </para>
    /// <para>
    /// Note that you can pipe an Amazon.S3.Model.S3Object instance to this cmdlet and its members will be used to
    /// satisfy the BucketName, Key and optionally VersionId (if an S3ObjectVersion instance is supplied), parameters.
    /// </para>
    /// <para>
    /// When -UseMultipartDownload is specified, the cmdlet uses the SDK's multipart parallel download APIs for
    /// improved performance on large objects and returns TransferUtilityDownloadResponse or
    /// TransferUtilityDownloadDirectoryResponse.
    /// </para>
    /// </summary>
    [Cmdlet("Read", "S3Object", DefaultParameterSetName = ParamSet_ToLocalFile)]
    [OutputType(typeof(System.IO.FileInfo))]
    [OutputType(typeof(System.IO.DirectoryInfo))]
    [OutputType(typeof(TransferUtilityDownloadResponse))]
    [OutputType(typeof(TransferUtilityDownloadDirectoryResponse))]
    [AWSCmdlet("Downloads one or more objects from an S3 bucket to the local file system.", Operation = new[] { "GetObject" })]
    [AWSCmdletOutput("System.IO.FileInfo or System.IO.DirectoryInfo or Amazon.S3.Transfer.TransferUtilityDownloadResponse or Amazon.S3.Transfer.TransferUtilityDownloadDirectoryResponse",
        "Returns FileInfo/DirectoryInfo by default, or TransferUtilityDownloadResponse/TransferUtilityDownloadDirectoryResponse when -UseMultipartDownload is specified."
    )]
    public class ReadS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ParamSet_ToLocalFile = "DownloadFile";
        const string ParamSet_ToLocalFolder = "DownloadFolder";
        const string ParamSet_FromS3Object = "FromS3ObjectToFileOrFolder"; 

        // try and anticipate all the ways a user might mean 'get everything from root'
        internal static readonly string[] rootIndicators = new string[] { "/", @"\", "*", "/*", @"\*" };
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #region Bucket Params

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// Name of the bucket that holds the content to be downloaded.
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c> <i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c> <i>amzn-s3-demo-bucket</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Object Lambda access points</b> - When you use this action with an Object Lambda
        /// access point, you must direct requests to the Object Lambda access point hostname.
        /// The Object Lambda access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-object-lambda.<i>Region</i>.amazonaws.com.
        /// </para>
        ///  <note> 
        /// <para>
        /// Access points and Object Lambda access points are not supported by directory buckets.
        /// </para>
        ///  </note> 
        /// <para>
        ///  <b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #endregion

        #region File Download Parameters

        #region Parameter Key
        /// <summary>
        /// The key that identifies the single object in S3.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_ToLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Key { get; set; }
        #endregion

        #region Parameter File
        /// <summary>
        /// The full path to the local file that will be created.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ParamSet_ToLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter(ParameterSets = new[] { ParamSet_ToLocalFile })]
        public System.String File { get; set; }
        #endregion

        #region Parameter Version
        /// <summary>
        /// If specified, the specific version of the S3 object is returned.
        /// </summary>
        [Alias("Version")]
        [Parameter(Position = 3, ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion


        #endregion

        #region Folder Download Parameters

        #region Parameter KeyPrefix
        /// <summary>
        /// <para>
        /// The key prefix that identifies the set of S3 objects to be downloaded. The
        /// key structure is preserved as the folder hierarchy under the destination folder.
        /// </para>
        /// <para>
        /// To indicate that all content in the bucket is to be downloaded, values of 
        /// '/', '\', '*', '/*' or '\*' may be used for this parameter.
        /// </summary>
        [Alias("Prefix")]
        [Parameter(Position = 1, ParameterSetName = ParamSet_ToLocalFolder, ValueFromPipelineByPropertyName = true)]
        public System.String KeyPrefix { get; set; }
        #endregion

        #region Parameter Folder
        /// <summary>
        /// The full path to a local folder; all downloaded content will be placed under this folder,
        /// with subfolders maintaining the S3 object key hierarchies.
        /// </summary>
        [Alias("Directory")]
        [Parameter(Position = 2, ParameterSetName = ParamSet_ToLocalFolder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter(ParameterSets = new[] { ParamSet_ToLocalFolder })]
        public System.String Folder { get; set; }
        #endregion

        #region Parameter DisableSlashCorrection
        /// <summary>
        /// By default if KeyPrefix doesn't have a trailing '/' then a '/' is appended to mimic a virtual S3 directory. If the 
        /// KeyPrefix is not meant to be S3 virtual directory set DisableSlashCorrection to true to disable the behavior 
        /// for adding a trailing '/' to the KeyPrefix value.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFolder, ValueFromPipelineByPropertyName = true)]
        public bool DisableSlashCorrection { get; set; }
        #endregion

        #endregion

        #region S3Object Download Parameters

        #region Parameter S3Object
        /// <summary>
        /// <para>
        /// Amazon.S3.Model.S3Object instance containing the bucketname and key of the object to download. 
        /// If the supplied object is an Amazon.S3.Model.S3ObjectVersion instance (derived from S3Object), 
        /// the version of the object to download will be inferred automatically. 
        /// </para>
        /// <para>
        /// The object identified by the supplied S3Object can be downloaded to a specific file (by supplying 
        /// a value for the -File parameter) or to a folder (specified using the -Folder parameter). When 
        /// downloading to a folder, the object key is used as the filename. Note that object keys that are not 
        /// valid filenames for the host system could cause an exception to be thrown.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipeline=true, ParameterSetName=ParamSet_FromS3Object, Mandatory=true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public S3Object S3Object { get; set; }
        #endregion

        #endregion

        #region Common Optional Parameters

        #region Parameter ModifiedSinceDate
        /// <summary>
        /// If specified, only  objects that have been modified since this date will be downloaded.
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime ModifiedSinceDate { get; set; }
        #endregion

        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// If specified, only objects that have not been modified since this date will be downloaded.
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime UnmodifiedSinceDate { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to decrypt the object.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter ChecksumMode
        /// <summary>
        /// This must be enabled to retrieve the checksum. In addition, if you enable <code>ChecksumMode</code> 
        /// and the object is KMS encrypted, you must have permission to the <code>kms:Decrypt</code> action
        /// for the request to succeed.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumMode")]
        public ChecksumMode ChecksumMode { get; set; }
        #endregion

        #endregion

        #region Multipart Download Parameters

        #region Parameter UseMultipartDownload
        /// <summary>
        /// <para>
        /// Enables multipart parallel download for significantly improved performance on large S3 objects.
        /// When specified, the cmdlet uses the AWS SDK for .NET's multipart download engine. For large objects,
        /// the download is automatically split into parts (default 8 MB per part), multiple parts are downloaded
        /// concurrently using parallel requests to S3, and downloaded parts are written directly to the file
        /// as they arrive.
        /// <b>Pipeline output changes when this switch is used:</b> The cmdlet
        /// returns <c>Amazon.S3.Transfer.TransferUtilityDownloadResponse</c> (single file) or
        /// <c>Amazon.S3.Transfer.TransferUtilityDownloadDirectoryResponse</c> (folder). These response
        /// objects provide access to download metadata including ETag, checksums, version ID, storage class,
        /// encryption information, and other S3 object properties.
        /// </para>
        /// <para>
        /// Without this switch, the cmdlet uses the legacy default single-stream download path and returns
        /// <c>FileInfo</c>/<c>DirectoryInfo</c>.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseMultipartDownload { get; set; }
        #endregion

        #region Parameter MultipartDownloadType
        /// <summary>
        /// <para>
        /// Specifies the multipart download strategy. Requires <c>-UseMultipartDownload</c>.
        /// </para>
        /// <para>
        /// <b>PART</b> (default): Downloads using the object's original multipart upload part boundaries.
        /// This is more efficient for objects that were uploaded using multipart upload, as it downloads each
        /// original part in parallel. For objects uploaded via a single PUT operation, the SDK sees only
        /// one part, so the download uses a single stream with no parallelization benefit.
        /// The <c>-PartSize</c> parameter is ignored in PART mode.
        /// </para>
        /// <para>
        /// <b>RANGE</b>: Downloads using HTTP byte-range requests with a configurable part size (see
        /// <c>-PartSize</c>). This works for all objects regardless of how they were uploaded and
        /// provides parallel downloads even for objects uploaded via a single PUT operation.
        /// </para>
        /// <para>
        /// <b>When to use PART vs RANGE:</b> Use <b>RANGE</b> when the object's upload method is unknown, 
        /// when you need specific part sizes, or when downloading objects that were uploaded as a single part. 
        /// Use <b>PART</b> (default) when you know the object was uploaded using multipart upload and want optimal performance.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Transfer.MultipartDownloadType? MultipartDownloadType { get; set; }
        #endregion

        #region Parameter PartSize
        /// <summary>
        /// <para>
        /// Specifies the size of each part for multipart download when using RANGE mode. Requires
        /// <c>-UseMultipartDownload</c>. This parameter is ignored when using the default PART mode.
        /// </para>
        /// <para>
        /// When not specified, the SDK uses a default part size of 8 MB.
        /// </para>
        /// <para>You can specify the part size in one of two ways:</para>
        /// <ul>
        /// <li><para>The part size in bytes. For example, <c>8388608</c>.</para></li>
        /// <li><para>The part size with a size suffix. You can use bytes, KB, MB, GB. For example,
        /// <c>8MB</c>, <c>"64 MB"</c>, <c>1GB</c>.</para></li>
        /// </ul>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        public FileSize PartSize { get; set; }
        #endregion

        #region Parameter ConcurrentServiceRequest
        /// <summary>
        /// <para>
        /// Specifies the maximum number of parallel HTTP connections used to download parts simultaneously. 
        /// The default value is 10.
        /// Requires <c>-UseMultipartDownload</c>.
        /// </para>
        /// <para>
        /// This property sets <c>TransferUtilityConfig.ConcurrentServiceRequests</c> on the underlying
        /// SDK TransferUtility. The value must be a positive integer.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConcurrentServiceRequests")]
        public System.Int32? ConcurrentServiceRequest { get; set; }
        #endregion

        #region Parameter DownloadFilesConcurrently
        /// <summary>
        /// <para>
        /// When specified, downloads multiple files in parallel within a directory download operation.
        /// By default, files in a directory download are downloaded sequentially (one at a time).
        /// </para>
        /// <para>
        /// This parameter works with both the legacy single-stream download path and the multipart
        /// download path.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFolder, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter DownloadFilesConcurrently { get; set; }
        #endregion

        #region Parameter FailurePolicy
        /// <summary>
        /// <para>
        /// Controls whether a directory download operation aborts on the first file failure or continues
        /// downloading the remaining files. The default is <c>AbortOnFailure</c>.
        /// </para>
        /// <para>
        /// <b>AbortOnFailure</b> (default): The directory download stops as soon as any individual file
        /// download fails. Files that completed successfully before the failure remain on disk.
        /// </para>
        /// <para>
        /// <b>ContinueOnFailure</b>: The directory download continues even when individual file downloads
        /// fail. When used with <c>-UseMultipartDownload</c>, the returned
        /// <c>TransferUtilityDownloadDirectoryResponse</c> includes <c>ObjectsFailed</c> count, a
        /// <c>Result</c> property (<c>Success</c>, <c>PartialSuccess</c>, or <c>Failure</c>), and an
        /// <c>Errors</c> collection with details about each failed download.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFolder, ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Transfer.FailurePolicy? FailurePolicy { get; set; }
        #endregion

        #endregion

        #region Parameter EnableLegacyKeyCleaning
        /// <summary>
        /// Specifies whether to use legacy key cleaning behavior for S3 key names. When this switch is present,
        /// the cmdlet will clean key names by removing leading spaces, forward slashes (/), and backslashes (\),
        /// converting all backslashes to forward slashes, and removing trailing spaces. When not specified,
        /// the legacy key cleaning is disabled.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter EnableLegacyKeyCleaning { get; set; }
        #endregion

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            switch (this.ParameterSetName)
            {
                case ParamSet_ToLocalFile:
                    {

                        context.Key = this.Key;
                        if (this.EnableLegacyKeyCleaning.IsPresent)
                        {
                            context.Key = AmazonS3Helper.CleanKey(this.Key);
                            base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Key, context.Key);
                        }
                        context.File = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.File);
                        context.VersionId = this.VersionId;
                    }
                    break;

                case ParamSet_ToLocalFolder:
                    {
                        context.OriginalKeyPrefix = this.KeyPrefix;
                        context.KeyPrefix = rootIndicators.Contains<string>(this.KeyPrefix, StringComparer.OrdinalIgnoreCase)
                            ? "/" : this.EnableLegacyKeyCleaning.IsPresent ? AmazonS3Helper.CleanKey(this.KeyPrefix) : this.KeyPrefix;
                        base.UserAgentAddition = this.EnableLegacyKeyCleaning.IsPresent ? AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.KeyPrefix, context.KeyPrefix) : base.UserAgentAddition;
                        context.Folder = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.Folder);
                        context.DisableSlashCorrection = this.DisableSlashCorrection;
                    }
                    break;

                case ParamSet_FromS3Object:
                    {
                        context.BucketName = this.S3Object.BucketName;
                        context.Key = this.S3Object.Key;
                        var s3ObjectVersion = this.S3Object as S3ObjectVersion;
                        context.VersionId = s3ObjectVersion == null ? null : s3ObjectVersion.VersionId;

                        if (this.ParameterWasBound("File"))
                        {
                            context.File = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.File);
                        }
                        else
                        {
                            var path = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.Folder);
                            context.File = Path.Combine(path, S3Object.Key);
                        }
                    }
                    break;
            }

            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                context.UnmodifiedSinceDate = this.UnmodifiedSinceDate;

            if (ParameterWasBound("ServerSideEncryptionCustomerMethod"))
                context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;

            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;

            if (ParameterWasBound("ChecksumMode"))
                context.ChecksumMode = this.ChecksumMode;

            // Multipart download parameters
            context.UseMultipartDownload = this.UseMultipartDownload.IsPresent;

            if (ParameterWasBound("MultipartDownloadType"))
                context.MultipartDownloadType = this.MultipartDownloadType;
            if (this.PartSize != null)
                context.PartSize = this.PartSize.FileSizeInBytes;
            if (this.ConcurrentServiceRequest.HasValue)
                context.ConcurrentServiceRequests = this.ConcurrentServiceRequest.Value;
            context.DownloadFilesConcurrently = this.DownloadFilesConcurrently.IsPresent;
            if (ParameterWasBound("FailurePolicy"))
                context.FailurePolicy = this.FailurePolicy;

            // Validate multipart-only parameters require -UseMultipartDownload
            if (!context.UseMultipartDownload)
            {
                if (context.MultipartDownloadType.HasValue)
                    throw new ArgumentException("-MultipartDownloadType requires -UseMultipartDownload.");
                if (context.PartSize.HasValue)
                    throw new ArgumentException("-PartSize requires -UseMultipartDownload.");
                if (context.ConcurrentServiceRequests.HasValue)
                    throw new ArgumentException("-ConcurrentServiceRequest requires -UseMultipartDownload.");
            }

            // Range validation
            if (context.ConcurrentServiceRequests.HasValue && context.ConcurrentServiceRequests.Value <= 0)
                throw new ArgumentOutOfRangeException("ConcurrentServiceRequest",
                    "ConcurrentServiceRequest should be set to a positive integer value.");
            if (context.PartSize.HasValue && context.PartSize.Value <= 0)
                throw new ArgumentOutOfRangeException("PartSize",
                    "PartSize should be set to a positive value.");

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (!string.IsNullOrEmpty(cmdletContext.File))
                return DownloadFileFromS3(cmdletContext);
            else
                return DownloadFolderFromS3(cmdletContext);
        }

        CmdletOutput DownloadFileFromS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadRequest
            {
                BucketName = cmdletContext.BucketName,
                FilePath = cmdletContext.File,
                Key = cmdletContext.Key
            };

            if (!string.IsNullOrEmpty(cmdletContext.VersionId))
                request.VersionId = cmdletContext.VersionId;
            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            request.ChecksumMode = cmdletContext.ChecksumMode;

            CmdletOutput output;

            using (var tu = CreateTransferUtility(cmdletContext))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object download APIs");

                var runner = new ProgressRunner(this);
                var tracker = new DownloadFileProgressTracker(runner, handler => request.WriteObjectProgressEvent += handler, cmdletContext.Key);

                if (cmdletContext.UseMultipartDownload)
                {
                    if (cmdletContext.MultipartDownloadType.HasValue)
                        request.MultipartDownloadType = cmdletContext.MultipartDownloadType.Value;
                    if (cmdletContext.PartSize.HasValue)
                        request.PartSize = cmdletContext.PartSize.Value;

                    TransferUtilityDownloadResponse response = null;
                    output = runner.SafeRun(() =>
                    {
                        response = tu.DownloadWithResponseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
                    }, tracker);
                    if (output.ErrorResponse == null)
                    {
                        WriteVerboseDownloadResponse(response, cmdletContext.File);
                        output.PipelineOutput = response;
                    }
                }
                else
                {
                    output = runner.SafeRun(() => tu.DownloadAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult(), tracker);
                    if (output.ErrorResponse == null)
                        output.PipelineOutput = new FileInfo(cmdletContext.File);
                }
            }
            return output;
        }

        CmdletOutput DownloadFolderFromS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadDirectoryRequest
            {
                BucketName = cmdletContext.BucketName,
                LocalDirectory = cmdletContext.Folder,
                S3Directory = cmdletContext.KeyPrefix,
                DisableSlashCorrection = cmdletContext.DisableSlashCorrection
            };

            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }

            // DownloadFilesConcurrently and FailurePolicy apply to both legacy and multipart paths
            if (cmdletContext.DownloadFilesConcurrently)
                request.DownloadFilesConcurrently = true;
            if (cmdletContext.FailurePolicy.HasValue)
                request.FailurePolicy = cmdletContext.FailurePolicy.Value;

            CmdletOutput output;

            using (var tu = CreateTransferUtility(cmdletContext))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object download APIs");

                var runner = new ProgressRunner(this);
                var tracker = new DownloadFolderProgressTracker(runner, handler => request.DownloadedDirectoryProgressEvent += handler);

                if (cmdletContext.UseMultipartDownload)
                {
                    TransferUtilityDownloadDirectoryResponse dirResponse = null;
                    output = runner.SafeRun(() =>
                    {
                        dirResponse = tu.DownloadDirectoryWithResponseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
                    }, tracker);
                    if (output.ErrorResponse == null)
                    {
                        WriteVerboseDirectoryDownloadResponse(dirResponse, cmdletContext.Folder);
                        output.PipelineOutput = dirResponse;
                    }
                }
                else
                {
                    output = runner.SafeRun(() => tu.DownloadDirectoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult(), tracker);
                    if (output.ErrorResponse == null)
                        output.PipelineOutput = new DirectoryInfo(cmdletContext.Folder);
                }

                WriteVerbose(string.Format("Downloaded {0} object(s) from bucket '{1}' with keyprefix '{2}' to '{3}'",
                                           tracker.DownloadedCount,
                                           cmdletContext.BucketName,
                                           cmdletContext.OriginalKeyPrefix,
                                           cmdletContext.Folder));
            }

            return output;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region Helper Methods

        private TransferUtility CreateTransferUtility(CmdletContext cmdletContext)
        {
            if (cmdletContext.UseMultipartDownload)
            {
                var config = new TransferUtilityConfig();
                if (cmdletContext.ConcurrentServiceRequests.HasValue)
                    config.ConcurrentServiceRequests = cmdletContext.ConcurrentServiceRequests.Value;
                return new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint), config);
            }
            return new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint));
        }

        #endregion

        #region Verbose Response Helpers

        private void WriteVerboseDownloadResponse(TransferUtilityDownloadResponse response, string localFilePath)
        {
            if (response == null) return;
            // File path and size
            try
            {
                var fileInfo = new FileInfo(localFilePath);
                if (fileInfo.Exists)
                    WriteVerbose($"Downloaded file: {fileInfo.FullName} ({fileInfo.Length:N0} bytes)");
                else
                    WriteVerbose($"Downloaded file: {localFilePath}");
            }
            catch (IOException)
            {
                WriteVerbose($"Downloaded file: {localFilePath}");
            }
            catch (UnauthorizedAccessException)
            {
                WriteVerbose($"Downloaded file: {localFilePath}");
            }
            // S3 metadata
            WriteVerbose($"ETag: {response.ETag}, VersionId: {response.VersionId}, LastModified: {response.LastModified}");
            if (response.PartsCount.HasValue)
                WriteVerbose($"PartsCount: {response.PartsCount}");
            if (response.ChecksumType != null)
                WriteVerbose($"ChecksumType: {response.ChecksumType}");
            if (!string.IsNullOrEmpty(response.ChecksumCRC32))
                WriteVerbose($"ChecksumCRC32: {response.ChecksumCRC32}");
            if (!string.IsNullOrEmpty(response.ChecksumCRC32C))
                WriteVerbose($"ChecksumCRC32C: {response.ChecksumCRC32C}");
            if (!string.IsNullOrEmpty(response.ChecksumCRC64NVME))
                WriteVerbose($"ChecksumCRC64NVME: {response.ChecksumCRC64NVME}");
            if (!string.IsNullOrEmpty(response.ChecksumSHA1))
                WriteVerbose($"ChecksumSHA1: {response.ChecksumSHA1}");
            if (!string.IsNullOrEmpty(response.ChecksumSHA256))
                WriteVerbose($"ChecksumSHA256: {response.ChecksumSHA256}");
        }

        private void WriteVerboseDirectoryDownloadResponse(TransferUtilityDownloadDirectoryResponse response, string localFolder)
        {
            if (response == null) return;
            WriteVerbose($"Download folder: {localFolder}");
            WriteVerbose($"ObjectsDownloaded: {response.ObjectsDownloaded}, ObjectsFailed: {response.ObjectsFailed}, Result: {response.Result}");
            if (response.ObjectsFailed > 0)
            {
                WriteWarning($"{response.ObjectsFailed} object(s) failed to download.");
                if (response.Errors != null)
                {
                    foreach (var error in response.Errors)
                    {
                        WriteWarning($"  Download error: {error.Message}");
                    }
                }
            }
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }

            public String Key { get; set; }
            public String File { get; set; }
            public string VersionId { get; set; }

            public String OriginalKeyPrefix { get; set; }
            public String KeyPrefix { get; set; }
            public String Folder { get; set; }
            public DateTime? ModifiedSinceDate { get; set; }
            public DateTime? UnmodifiedSinceDate { get; set; }

            public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public string ServerSideEncryptionCustomerProvidedKey { get; set; }
            public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public ChecksumMode ChecksumMode { get; set; }

            public bool DisableSlashCorrection { get; set; }

            // Multipart download properties
            public bool UseMultipartDownload { get; set; }
            public MultipartDownloadType? MultipartDownloadType { get; set; }
            public long? PartSize { get; set; }
            public int? ConcurrentServiceRequests { get; set; }
            public bool DownloadFilesConcurrently { get; set; }
            public FailurePolicy? FailurePolicy { get; set; }
        }

        internal class DownloadFileProgressTracker : ProgressTracker<WriteObjectProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _key;
            const string DownloadingFileActivity = "Downloading";
            const string ProgressMsgFormat = "File {0}...{1}%";

            public override string Activity
            {
                get { return DownloadingFileActivity; }
            }

            public DownloadFileProgressTracker(ProgressRunner runner, Action<EventHandler<WriteObjectProgressArgs>> subscribe, string key)
                : base(runner, subscribe)
            {
                this._key = key;

                ReportProgress(0, ProgressMsgFormat, _key, 0);
            }

            public override void ReportProgress(WriteObjectProgressArgs args)
            {
                if (args.PercentDone != _currentPercent)
                {
                    _currentPercent = args.PercentDone;
                    ReportProgress(args.PercentDone, ProgressMsgFormat, _key, args.PercentDone);
                }                
            }
        }

        internal class DownloadFolderProgressTracker : ProgressTracker<DownloadDirectoryProgressArgs>
        {
            int _fileDownloadCount = 0;
            string _currentFile = string.Empty;
            const string DownloadingFolderActivity = "Downloading";

            public override string Activity
            {
                get { return DownloadingFolderActivity; }
            }

            public DownloadFolderProgressTracker(ProgressRunner runner, Action<EventHandler<DownloadDirectoryProgressArgs>> subscribe)
                : base(runner, subscribe)
            {
                ReportProgress(0, "Downloading files...");
            }

            public int DownloadedCount { get { return _fileDownloadCount; } }

            public override void ReportProgress(DownloadDirectoryProgressArgs args)
            {
                if (string.Compare(_currentFile, args.CurrentFile, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _currentFile = args.CurrentFile;
                    _fileDownloadCount = args.NumberOfFilesDownloaded;
                    ReportProgress(args.NumberOfFilesDownloaded, args.TotalNumberOfFiles, "Downloaded {0} files, current file {1}", args.NumberOfFilesDownloaded, args.CurrentFile);
                }
            }
        }

    }
}
