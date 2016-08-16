/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Downloads an S3 object, optionally including sub-objects, to a local file or folder location. Returns a
    /// FileInfo or DirectoryInfo instance to the downloaded file (or specified containing folder).
    /// </summary>
    [Cmdlet("Read", "S3Object", DefaultParameterSetName = "LocalFileParamSet")]
    [OutputType(new Type[] { typeof(System.IO.FileInfo), typeof(System.IO.DirectoryInfo) })]
    [AWSCmdlet("Downloads one or more objects from an S3 bucket to the local file system.")]
    [AWSCmdletOutput("System.IO.FileInfo instance if reading a single object or System.IO.DirectoryInfo instance for multi-object read.",
        "Returns a System.IO.FileInfo instance representing the local file if reading a single object or a System.IO.DirectoryInfo instance to the root parent folder if reading multiple objects."
    )]
    public class ReadS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ParamSet_ToLocalFile = "ToLocalFileParamSet";
        const string ParamSet_ToLocalFolder = "ToLocalFolderParamSet";

        // try and anticipate all the ways a user might mean 'get everything from root'
        readonly string[] rootIndicators = new string[] { "/", @"\", "*", "/*", @"\*" };

        #region Bucket Params

        #region Parameter BucketName
        /// <summary>
        /// Name of the bucket that holds the content to be downloaded
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion

        #endregion

        #region File Download Parameters

        #region Parameter Key
        /// <summary>
        /// The key that identifies the single object in S3.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_ToLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion

        #region Parameter File
        /// <summary>
        /// The full path to the local file that will be created.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ParamSet_ToLocalFile, Mandatory = true)]
        public System.String File { get; set; }
        #endregion

        #region Parameter Version
        /// <summary>
        /// If specified, the specific version of the S3 object is returned.
        /// </summary>
        [Parameter(Position = 3, ParameterSetName = ParamSet_ToLocalFile)]
        public System.String Version { get; set; }
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
        [Parameter(Position = 2, ParameterSetName = ParamSet_ToLocalFolder, Mandatory = true)]
        public System.String Folder { get; set; }
        #endregion

        #endregion

        #region Common Optional Parameters

        #region Parameter ModifiedSinceDate
        /// <summary>
        /// If specified, only  objects that have been modified since this date will be downloaded.
        /// </summary>
        [Parameter]
        public System.DateTime ModifiedSinceDate { get; set; }
        #endregion

        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// If specified, only objects that have not been modified since this date will be downloaded.
        /// </summary>
        [Parameter]
        public System.DateTime UnmodifiedSinceDate { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to decrypt the object.
        /// </summary>
        [Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        #endregion

        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }

        #endregion

        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  BucketName = this.BucketName
                              };

            if (this.ParameterSetName == ParamSet_ToLocalFile)
            {
                context.Key = AmazonS3Helper.CleanKey(this.Key);
                context.File = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.File);
            }
            else
            {
                context.OriginalKeyPrefix = this.KeyPrefix;
                context.KeyPrefix = rootIndicators.Contains<string>(this.KeyPrefix, StringComparer.OrdinalIgnoreCase) 
                    ? "/" : AmazonS3Helper.CleanKey(this.KeyPrefix);
                context.Folder = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.Folder);
            }

            context.Version = this.Version;

            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                UnmodifiedSinceDate = this.UnmodifiedSinceDate;

            if (ParameterWasBound("ServerSideEncryptionCustomerMethod"))
                context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;

            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            
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

            if (!string.IsNullOrEmpty(cmdletContext.Version))
                request.VersionId = cmdletContext.Version;
            if (cmdletContext.ModifiedSinceDate.HasValue)
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

            CmdletOutput output;

            using (var tu = new TransferUtility(Client ?? CreateClient(context.Credentials, context.Region)))
            {
                var runner = new ProgressRunner(this);
                var tracker = new DownloadFileProgressTracker(runner, handler => request.WriteObjectProgressEvent += handler, cmdletContext.Key);

                output = runner.SafeRun(() => tu.Download(request), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new FileInfo(cmdletContext.File);
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
                                  S3Directory = cmdletContext.KeyPrefix
                              };

            if (cmdletContext.ModifiedSinceDate.HasValue)
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;

            CmdletOutput output;

            using (var tu = new TransferUtility(Client ?? CreateClient(context.Credentials, context.Region)))
            {
                var runner = new ProgressRunner(this);
                var tracker = new DownloadFolderProgressTracker(runner, handler => request.DownloadedDirectoryProgressEvent += handler);

                output = runner.SafeRun(() => tu.DownloadDirectory(request), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new DirectoryInfo(cmdletContext.Folder);

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

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }

            public String Key { get; set; }
            public String File { get; set; }
            public string Version { get; set; }

            public String OriginalKeyPrefix { get; set; }
            public String KeyPrefix { get; set; }
            public String Folder { get; set; }

            public DateTime? ModifiedSinceDate { get; set; }
            public DateTime? UnmodifiedSinceDate { get; set; }

            public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public string ServerSideEncryptionCustomerProvidedKey { get; set; }
            public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
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
