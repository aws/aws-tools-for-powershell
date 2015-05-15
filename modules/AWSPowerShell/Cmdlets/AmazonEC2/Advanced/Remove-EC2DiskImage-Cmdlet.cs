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
using System.Collections.Generic;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.EC2.Import;
using Amazon.PowerShell.Properties;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Deletes the image file artifacts associated with a VM image or volume import to Amazon EC2.
    /// The artifacts to be deleted can be specified using either the conversion task ID, the URL to the import manifest file 
    /// in Amazon S3 or the bucket name and key prefix of the artifact objects (the prefix is output by the Import-EC2Instance 
    /// and Import-EC2Volume cmdlets if errors occur during upload of the image artifacts).
    /// </summary>
    [Cmdlet("Remove", "EC2DiskImage", DefaultParameterSetName = ParamSet_FromTaskId, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [AWSCmdlet("Deletes the image file artifacts associated with a VM image or volume import to Amazon EC2.")]
    [AWSClientCmdlet("Amazon Elastic Compute Cloud", "EC2", "2014-06-15")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class RemoveEC2DiskImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// The default parameter set for the cmdlet determines the artifacts to
        /// be deleted using the ConversionTask returned from the import request.
        /// </summary>
        protected const string ParamSet_FromTaskId = "FromTaskIdParameterSet";

        /// <summary>
        /// Determines the artifacts to be deleted by inspecting the presigned url to
        /// the import manifest file that was created when import was requested.
        /// </summary>
        protected const string ParamSet_FromManifestUrl = "FromManifestUrlParameterSet";

        /// <summary>
        /// Determines the artifacts to be deleted by inspecting the S3 object key to the 
        /// the import manifest file that was created when import was requested.
        /// </summary>
        protected const string ParamSet_FromManifestFileKey = "FromManifestFileKeyParameterSet";

        protected const string ProgressActivityMsgFormat = "Deleting import artifacts: {0}";

        protected string CurrentProgressActivity;

        /// <summary>
        /// <para>
        /// One or more conversion task IDs of tasks that are no longer active. This option cannot
        /// be used to delete the artifacts if the task is active unless you specify the -IgnoreActiveTask
        /// switch.
        /// </para>
        /// <para>
        /// You can pipe a ConversionTask object, output by the Import-EC2Instance or Import-EC2Volume cmdlets, 
        /// to this cmdlet to supply this parameter.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_FromTaskId)]
		[Alias("TaskId")]
        public string[] ConversionTaskId { get; set; }

        /// <summary>
        /// Delete the uploaded disk image despite having an active task. Using this option may cause 
        /// active tasks to fail. Use this option at your own risk.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_FromTaskId)]
        public SwitchParameter IgnoreActiveTask { get; set; }

        /// <summary>
        /// One or more presigned URLs to import manifest file(s) created during the import process. 
        /// This option can be used to delete the uploaded disk image even if one or more active 
        /// conversion tasks still reference the manifest (no check is made on conversion task status).
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_FromManifestUrl)]
        public string[] ManifestUrl { get; set; }

        /// <summary>
        /// The name of the Amazon S3 bucket that contains the manifest and image file artifacts. 
        /// This option, along with KeyPrefix, can be used to delete the uploaded disk image 
        /// even if one or more active conversion tasks still reference the artifacts  (no check is 
        /// made on conversion task status).
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_FromManifestFileKey)]
        public string BucketName { get; set; }

        /// <summary>
        /// One or more Amazon S3 object keys to import manifest file(s) created during the import process. 
        /// This option can be used to delete the uploaded disk image even if one or more active 
        /// conversion tasks still reference the manifest (no check is made on conversion task status).
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_FromManifestFileKey)]
        public string[] ManifestFileKey { get; set; }

        /// <summary>
        /// <para>
        /// If set, the image artifacts are deleted without further prompting for confirmation.
        /// If not set, you are prompted for confirmation before the command runs.
        /// </para>
        /// <para>
        /// Note that if using conversion task IDs to identify the artifacts, you must also
        /// use the -IgnoreActiveTask switch to delete artifacts for in-progress tasks.
        /// </para>
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var output = Execute(CreateContext()) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            if (this.ParameterSetName.Equals(ParamSet_FromTaskId))
                RemoveArtifactsViaTaskIDs(context);
            else if (this.ParameterSetName.Equals(ParamSet_FromManifestUrl))
                RemoveArtifactsUsingManifestUrls(context);
            else 
                RemoveArtifactUsingBucketAndManifestKey(context);

            return null;
        }

        void RemoveArtifactsViaTaskIDs(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConversionTaskId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2DiskImage")) 
                return;

            foreach (var task in cmdletContext.TaskIDs)
            {
                try
                {
                    CurrentProgressActivity = string.Format(ProgressActivityMsgFormat,
                                                            string.Format("task {0}", task));

                    ImportCleanup.DeleteImageArtifacts(context.Credentials,
                                                       context.Region,
                                                       task,
                                                       cmdletContext.IgnoreActiveTask,
                                                       UpdateProgress);
                }
                finally
                {
                    this.WriteProgressCompleteRecord(CurrentProgressActivity, "Completed");
                }
            }
        }

        void RemoveArtifactsUsingManifestUrls(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ManifestUrl", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2DiskImage"))
                return;

            foreach (var manifestUrl in cmdletContext.ManifestUrls)
            {
                try
                {
                    CurrentProgressActivity = string.Format(ProgressActivityMsgFormat,
                                                            string.Format("manifest {0}", manifestUrl));

                    ImportCleanup.DeleteImageArtifacts(context.Credentials,
                                                       context.Region,
                                                       manifestUrl,
                                                       UpdateProgress);
                }
                finally
                {
                    this.WriteProgressCompleteRecord(CurrentProgressActivity, "Completed");
                }
            }
        }

        void RemoveArtifactUsingBucketAndManifestKey(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ManifestFileKey", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2DiskImage"))
                return;

            foreach (var fileKey in cmdletContext.ManifestFileKeys)
            {
                try
                {
                    CurrentProgressActivity = string.Format(ProgressActivityMsgFormat,
                                                            string.Format("bucket {0}, manifest file {1}",
                                                                          cmdletContext.BucketName, fileKey));

                    var keyPrefixEnd = fileKey.LastIndexOf('/');
                    ImportCleanup.DeleteImageArtifacts(context.Credentials,
                                                       context.Region,
                                                       cmdletContext.BucketName,
                                                       fileKey.Substring(0, keyPrefixEnd),
                                                       UpdateProgress);
                }
                finally
                {
                    this.WriteProgressCompleteRecord(CurrentProgressActivity, "Completed");
                }
            }
        }

        protected void UpdateProgress(string message, int? percentComplete = null)
        {
            WriteProgressRecord(CurrentProgressActivity, message, percentComplete);
        }

        public ExecutorContext CreateContext()
        {
            var context = new CmdletContext
            {
                Credentials = this.CurrentCredentials,
                Region = this.Region,
                IgnoreActiveTask = this.IgnoreActiveTask.IsPresent,
                BucketName = this.BucketName,
                Force = this.Force.IsPresent
            };

            if (this.ConversionTaskId != null)
                context.TaskIDs = new List<string>(this.ConversionTaskId);
            if (this.ManifestUrl != null)
                context.ManifestUrls = new List<string>(this.ManifestUrl);
            if (this.ManifestFileKey != null)
                context.ManifestFileKeys = new List<string>(this.ManifestFileKey);

            return context;
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public List<string> TaskIDs { get; set; }
            public bool IgnoreActiveTask { get; set; }

            public List<string> ManifestUrls { get; set; }

            public string BucketName { get; set; }
            public List<string> ManifestFileKeys { get; set; } 

            public bool Force { get; set; }
        }
    }
}
