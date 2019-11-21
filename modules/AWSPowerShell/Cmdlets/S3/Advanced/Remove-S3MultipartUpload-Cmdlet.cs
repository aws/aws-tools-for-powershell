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
using Amazon.Runtime;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.S3.Transfer;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// This operation aborts multipart uploads.
    /// </para>
    /// <para>
    /// After a multipart upload is aborted, no additional parts can be uploaded using that upload ID. The storage consumed by any previously uploaded parts will be freed.
    /// If you are uploading large files, Write-S3Object cmdlet will use multipart upload to fulfill the request.
    /// If a multipart upload is interrupted, Write-S3Object cmdlet will attempt to abort the multipart upload.
    /// Under certain circumstances (network outage, power failure, etc.), Write-S3Object cmdlet will not be able to abort the multipart upload.
    /// In this case, in order to stop getting charged for the storage of uploaded parts,
    /// you should manually invoke the Remove-S3MultipartUploads to abort the incomplete multipart uploads.
    /// </para>
    /// <para>
    /// Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias <i>Remove-S3MultipartUploads</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "S3MultipartUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High, DefaultParameterSetName = RelativeParameterSetName)]
    [AWSCmdlet("Aborts the multipart uploads that were initiated before the specified date.", Operation = new[] { "AbortMultipartUpload" }, LegacyAlias = "Remove-S3MultipartUploads")]
    public class RemoveS3MultipartUploadCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        private const string AbsoluteParameterSetName = "Absolute";
        private const string RelativeParameterSetName = "Relative";

        #region Parameter BucketName
        /// <summary>
        /// The name of the bucket containing multipart uploads.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter InitiatedDate
        /// <summary>
        /// The date before which the multipart uploads were initiated.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = AbsoluteParameterSetName, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime InitiatedDate { get; set; }
        #endregion

        #region Parameter DaysBefore
        /// <summary>
        /// The number of days ago that the multipart uploads were initiated.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = RelativeParameterSetName, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32 DaysBefore { get; set; }
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

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "Remove-S3MultipartUploads"))
                return;

            DateTime initDate;
            if (string.Equals(this.ParameterSetName, AbsoluteParameterSetName, StringComparison.OrdinalIgnoreCase))
                initDate = InitiatedDate;
            else
                initDate = DateTime.Now - TimeSpan.FromDays(DaysBefore);

            var context = new CmdletContext
            {
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
            using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint)))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 abort multi-part upload APIs");
                try
                {
                    tu.AbortMultipartUploads(cmdletContext.BucketName, cmdletContext.InitiatedDate);
                }
                catch (AmazonServiceException exc)
                {
                    var webException = exc.InnerException as System.Net.WebException;
                    if (webException != null)
                    {
                        throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(Client.Config, webException.Message), webException);
                    }

                    throw;
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
