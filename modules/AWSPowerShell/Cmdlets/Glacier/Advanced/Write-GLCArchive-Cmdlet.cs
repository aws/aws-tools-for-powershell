/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.PowerShell.Utils;
using Amazon.Glacier.Transfer;
using Amazon.Runtime;
using System.Collections.Generic;
using Amazon.Glacier;
using System.IO;

namespace Amazon.PowerShell.Cmdlets.GLC
{
    /// <summary>
    /// Output object carrying the file we uploaded, the corresponding archive id (needed for later retrieval) and
    /// the upload checksum.
    /// </summary>
    /// <remarks>
    /// We could use a PSObject wrapping the UploadResult and adding a note property for the filename, but the note
    /// property doesn't get displayed by default. Using a concrete class solves this problem.
    /// </remarks>
    public class FileUploadResult
    {
        internal FileUploadResult(string filePath, UploadResult result)
        {
            this.FilePath = filePath;
            this.ArchiveId = result.ArchiveId;
            this.Checksum = result.Checksum;
        }

        public string FilePath { get; }
        public string ArchiveId { get; }
        public string Checksum { get; }
    }

    /// <summary>
    /// <para>
    /// Uploads a single file, or collection of files in a folder hierarchy, to a vault in Amazon Glacier.
    /// </para>
    /// <para>
    /// The cmdlet will automatically attempt to use multipart upload to fulfill the request depending on the size of
    /// each file being uploaded. If a multipart upload is interrupted the cmdlet will attempt to abort the multipart
    /// upload on your behalf. Under certain circumstances (network outage, power failure, etc.) the cmdlet may not be
    /// able to abort the multipart upload.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "GLCArchive", DefaultParameterSetName = ParamSet_SingleFile, ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    [AWSCmdlet("Uploads one or more files from the local file system to an Amazon Glacier vault.",
        Operation = new[] { "UploadArchive", "InitiateMultipartUpload", "UploadMultipartPart", "CompleteMultipartUpload" }
    )]
    [AWSCmdletOutput("Amazon.PowerShell.Cmdlets.GLC.FileUploadResult",
        "The cmdlet returns one or more FileUploadResult instances specifying the source file path, archive ID (needed for later retrieval) and checksum of the uploaded artifact."
    )]
    public class WriteGLCArchiveCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {
        const string ParamSet_SingleFile = "UploadSingleFile";
        const string ParamSet_Folder = "UploadFolder";

        #region Parameter VaultName
        /// <summary>
        /// The name of the vault that will hold the uploaded content.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VaultName { get; set; }
        #endregion

        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// AWS account ID of the account that owns the vault. You can either specify an AWS account ID or optionally a single '-' (hyphen),
        /// in which case Amazon S3 Glacier uses the AWS account ID associated with the credentials used to sign the request. If you use an
        /// account ID, do not include any hyphens ('-') in the ID.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>-</b>'.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion

        #region Upload Single File Params

        #region Parameter File
        /// <summary>
        /// The full path to the local file to be uploaded.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_SingleFile, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FilePath { get; set; }
        #endregion

        #region Parameter Description
        /// <summary>
        /// Optional description to apply to the uploaded archive.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_SingleFile, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion

        #endregion

        #region Upload Folder Params

        #region Parameter Folder
        /// <summary>
        /// The full path to a local folder. All files in the folder will be uploaded to the
        /// specified vault. Files contained in sub-folders of the specified folder will only
        /// be uploaded if the -Recurse switch is specified.
        /// </summary>
        [Alias("Directory")]
        [Parameter(ParameterSetName = ParamSet_Folder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FolderPath { get; set; }
        #endregion

        #region Parameter Recurse
        /// <summary>
        /// If set, all sub-folders beneath the folder specified in -Folder will also be uploaded.
        /// Defaults off [false].
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_Folder, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Recurse { get; set; }
        #endregion

        #region Parameter SearchPattern
        /// <summary>
        /// Optional search pattern to control which files in the specified folder path are uploaded
        /// to the vault. By default all files are processed.
        /// </summary>
        [Alias("Pattern")]
        [Parameter(Position = 4, ParameterSetName = ParamSet_Folder, ValueFromPipelineByPropertyName = true)]
        public System.String SearchPattern { get; set; }
        #endregion

        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                VaultName = this.VaultName
            };

            if (this.ParameterSetName.Equals(ParamSet_Folder, StringComparison.Ordinal))
            {
                if (!ConfirmShouldProceed(this.Force.IsPresent, this.FolderPath, "Write-GLCArchive"))
                    return;

                context.FolderPath = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.FolderPath.Trim());
                context.Recurse = this.Recurse.IsPresent;
                context.SearchPattern = this.SearchPattern;
            }
            else
            {
                if (!ConfirmShouldProceed(this.Force.IsPresent, this.FilePath, "Write-GLCArchive"))
                    return;

                context.FilePath = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.FilePath.Trim());
                context.Description = this.Description;
            }

            if (this.ParameterWasBound("AccountId"))
            {
                context.AccountId = this.AccountId;
            }
            else
            {
                WriteVerbose("AccountId parameter unset, using default value of '-'");
                context.AccountId = "-";
            }

            Execute(context);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (string.IsNullOrEmpty(cmdletContext.FolderPath))
            {
                UploadFileToGlacier(cmdletContext);
            }
            else
            {
                UploadFolderToGlacier(cmdletContext);
            }

            return null;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        private void UploadFileToGlacier(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);

            var resultsList = new List<FileUploadResult>();

            Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon Glacier archive upload APIs");

            UploadSingleFile(client,
                             cmdletContext.VaultName,
                             cmdletContext.AccountId,
                             cmdletContext.FilePath,
                             cmdletContext.Description);
        }

        private void UploadFolderToGlacier(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);

            Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon Glacier archive upload APIs");

            var searchPattern = string.IsNullOrEmpty(cmdletContext.SearchPattern) ? "*.*" : cmdletContext.SearchPattern;
            var fileList = Directory.GetFiles(cmdletContext.FolderPath, searchPattern, cmdletContext.Recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            WriteVerbose(string.Format(@"Uploading {0} files from {1}", fileList.Length, Path.Combine(cmdletContext.FolderPath, searchPattern)));

            var filesCompleted = 0;
            foreach (var file in fileList)
            {
                UploadSingleFile(client,
                                 cmdletContext.VaultName,
                                 cmdletContext.AccountId,
                                 cmdletContext.FolderPath,
                                 file,
                                 filesCompleted,
                                 fileList.Length);
                filesCompleted++;
            }
        }

        private void UploadSingleFile(IAmazonGlacier client,
                                      string vaultName,
                                      string accountId,
                                      string filePath,
                                      string description)
        {
            using (var transferManager = new ArchiveTransferManager(client))
            {
                var runner = new ProgressRunner(this);
                var uploadOptions = new UploadOptions
                {
                    AccountId = accountId
                };

                var tracker = new UploadProgressTracker(runner, handler => uploadOptions.StreamTransferProgress += handler, filePath);

                var output = new CmdletOutput();
                runner.SafeRun(() =>
                {
#if DESKTOP
                    var result = transferManager.Upload(vaultName, description, filePath, uploadOptions);
#else
                    var result = transferManager.UploadAsync(vaultName, description, filePath, uploadOptions).GetAwaiter().GetResult();
#endif

                    output.PipelineOutput = new FileUploadResult(filePath, result);

                }, tracker, output);

                // write as we go so that any subsequent error doesn't cause the user to lose
                // the ids of archives we have successfully uploaded so far
                ProcessOutput(output);
            }
        }

        private void UploadSingleFile(IAmazonGlacier client,
                                      string vaultName,
                                      string accountId,
                                      string startingFolder,
                                      string filePath,
                                      int thisFileIndex,
                                      int allFilesCount)
        {
            using (var transferManager = new ArchiveTransferManager(client))
            {
                var runner = new ProgressRunner(this);
                var uploadOptions = new UploadOptions
                {
                    AccountId = accountId
                };

                var tracker = new UploadFolderProgressTracker(runner, handler => uploadOptions.StreamTransferProgress += handler, startingFolder, filePath, thisFileIndex, allFilesCount);

                var output = new CmdletOutput();
                runner.SafeRun(() =>
                {
#if DESKTOP
                    var result = transferManager.Upload(vaultName, "", filePath, uploadOptions);
#else
                    var result = transferManager.UploadAsync(vaultName, "", filePath, uploadOptions).GetAwaiter().GetResult();
#endif

                    output.PipelineOutput = new FileUploadResult(filePath, result);

                }, tracker, output);

                ProcessOutput(output);
            }
        }


        internal class CmdletContext : ExecutorContext
        {
            public String VaultName { get; set; }
            public String AccountId { get; set; }

            public String FilePath { get; set; }
            public String Description { get; set; }

            public String FolderPath { get; set; }
            public bool Recurse { get; set; }
            public string SearchPattern { get; set; }
        }

        #region Progress Trackers

        internal class UploadProgressTracker : ProgressTracker<StreamTransferProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _filePath;

            const string UploadingFileActivity = "Uploading";
            const string ProgressMsgFormat = "File {0}...{1}%";

            public override string Activity
            {
                get { return UploadingFileActivity; }
            }

            public UploadProgressTracker(ProgressRunner runner, Action<EventHandler<StreamTransferProgressArgs>> subscribe, string filePath)
                : base(runner, subscribe)
            {
                this._filePath = filePath;

                ReportProgress(0, ProgressMsgFormat, _filePath, 0);
            }

            public override void ReportProgress(StreamTransferProgressArgs args)
            {
                if (args.PercentDone != _currentPercent)
                {
                    _currentPercent = args.PercentDone;
                    ReportProgress(args.PercentDone, ProgressMsgFormat, _filePath, args.PercentDone);
                }
            }
        }

        internal class UploadFolderProgressTracker : ProgressTracker<StreamTransferProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _currentFilePath;
            readonly string _startingFolder;
            readonly int _completedSoFar;
            readonly int _totalNumberOfFiles;

            const string UploadingFolderActivity = "Uploading";
            private const string ProgressMsgFormat = "Uploaded {0} of {1} files from {2}, processing: {3}";

            public override string Activity
            {
                get { return UploadingFolderActivity; }
            }

            public UploadFolderProgressTracker(ProgressRunner runner,
                                               Action<EventHandler<StreamTransferProgressArgs>> subscribe,
                                               string startingFolder,
                                               string currentFilePath,
                                               int completedSoFar,
                                               int totalNumberOfFiles)
                : base(runner, subscribe)
            {
                this._startingFolder = startingFolder;
                this._currentFilePath = currentFilePath.Substring(_startingFolder.Length).TrimStart('\\');
                this._completedSoFar = completedSoFar;
                this._totalNumberOfFiles = totalNumberOfFiles;

                ReportProgress(0, ProgressMsgFormat, _completedSoFar, _totalNumberOfFiles, _startingFolder, _currentFilePath);
            }

            public override void ReportProgress(StreamTransferProgressArgs args)
            {
                if (args.PercentDone != _currentPercent)
                {
                    _currentPercent = args.PercentDone;

                    ReportProgress(_currentPercent,
                                   ProgressMsgFormat,
                                   _completedSoFar,
                                   _totalNumberOfFiles,
                                   _startingFolder,
                                   _currentFilePath);
                }
            }
        }

        #endregion
    }
}
