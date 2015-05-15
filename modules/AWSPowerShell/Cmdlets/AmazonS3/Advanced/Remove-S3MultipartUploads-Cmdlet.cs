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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3.Model;
using Amazon.S3.Util;

using Amazon.PowerShell.Properties;
using Amazon.S3.Transfer;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Aborts multipart uploads.
    /// </summary>
    [Cmdlet("Remove", "S3MultipartUploads", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High, DefaultParameterSetName = RelativeParameterSetName)]
    [AWSCmdlet("Aborts the multipart uploads that were initiated before the specified date.")]
    public class RemoveS3MultipartUploadsCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        private const string AbsoluteParameterSetName = "Absolute";
        private const string RelativeParameterSetName = "Relative";

        /// <summary>
        /// The name of the bucket containing multipart uploads.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public String BucketName { get; set; }

        /// <summary>
        /// The date before which the multipart uploads were initiated.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = AbsoluteParameterSetName)]
        public DateTime InitiatedDate { get; set; }

        /// <summary>
        /// The number of days ago that the multipart uploads were initiated.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = RelativeParameterSetName)]
        public int DaysBefore { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "Remove-S3MultipartUploads"))
                return;

            DateTime initDate;
            if (string.Equals(this.ParameterSetName, AbsoluteParameterSetName, StringComparison.OrdinalIgnoreCase))
                initDate = InitiatedDate;
            else
                initDate = DateTime.Now - TimeSpan.FromDays(DaysBefore);

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName,
                InitiatedDate = initDate
            };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            CmdletOutput output = new CmdletOutput();
            using (var tu = new TransferUtility(Client ?? CreateClient(context.Credentials, context.Region)))
            {
                try
                {
                    tu.AbortMultipartUploads(cmdletContext.BucketName, cmdletContext.InitiatedDate);
                }
                catch (Exception e)
                {
                    output.ErrorResponse = e;
                }
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
            public DateTime InitiatedDate { get; set; }
        }
    }
}
