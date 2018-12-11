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
    /// <para>
    /// Downloads the output of a completed job and stores it in a file.
    /// </para>
    /// </summary>
    [Cmdlet("Read", "GLCJobOutput", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = false)]
    [AWSCmdlet("Downloads the output from a job that was previously submitted to Amazon Glacier and has now completed, signalling that the job output (archive or inventory content) is ready for retrieval."
            + " The archive or inventory content in the job output is written into a user-specified file.",
        Operation = new[] { "GetJobOutput" }
    )]
    [AWSCmdletOutput("None",
        "This cmdlet does not return any output. " +
        "The service responses for the APIs used to download the job output can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]    public class ReadGLCOutputCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {

        #region Parameter VaultName
        /// <summary>
        /// The name of the vault that will hold the uploaded content.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
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

        #region Parameter JobId
        /// <summary>
        /// The ID of the previously submitted job that has completed, signalling that the output
        /// of the job is ready to be retrieved.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string JobId { get; set; }
        #endregion

        #region Parameter File
        /// <summary>
        /// The full path to the local file that will contain the archive contents.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public System.String FilePath { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                VaultName = this.VaultName,
                FilePath = this.FilePath,
                JobId = this.JobId
            };

            if (this.ParameterWasBound("AccountId"))
            {
                context.AccountId = this.AccountId;
            }
            else
            {
                WriteVerbose("AccountId parameter unset, using default value of '-'");
                context.AccountId = "-";
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var client = Client ?? CreateClient(context.Credentials, context.Region);

            Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "GetJobOutput");

            using (var transferManager = new ArchiveTransferManager(client))
            {
                var runner = new ProgressRunner(this);
                var downloadOptions = new DownloadOptions
                {
                    AccountId = cmdletContext.AccountId
                };

                var tracker = new DownloadProgressTracker(runner, handler => downloadOptions.StreamTransferProgress += handler, cmdletContext.FilePath);

                var output = runner.SafeRun(() =>
                {
#if DESKTOP
                    transferManager.DownloadJob(cmdletContext.VaultName, cmdletContext.JobId, cmdletContext.FilePath, downloadOptions);
#else
                    transferManager.DownloadJobAsync(cmdletContext.VaultName, cmdletContext.JobId, cmdletContext.FilePath, downloadOptions).Wait();
#endif

                }, tracker);

                return output;
            }
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String VaultName { get; set; }
            public String AccountId { get; set; }
            public String JobId { get; set; }
            public String FilePath { get; set; }
        }

        #region Progress Trackers

        internal class DownloadProgressTracker : ProgressTracker<StreamTransferProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _filePath;

            const string DownloadingFileActivity = "Downloading";
            const string ProgressMsgFormat = "File {0}...{1}%";

            public override string Activity
            {
                get { return DownloadingFileActivity; }
            }

            public DownloadProgressTracker(ProgressRunner runner, Action<EventHandler<StreamTransferProgressArgs>> subscribe, string filePath)
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
        #endregion
    }
}
