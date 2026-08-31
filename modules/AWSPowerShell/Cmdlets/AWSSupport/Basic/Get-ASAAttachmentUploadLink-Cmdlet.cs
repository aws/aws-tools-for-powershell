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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns one or more presigned upload URLs for uploading a large file attachment to
    /// a support case by using a multipart upload workflow. The maximum file size that you
    /// can upload with this workflow is 150 MB, and parts can be up to 100 MB each. Initiate
    /// a new upload by providing <c>fileName</c> and <c>fileSizeBytes</c>; the response returns
    /// a unique <c>uploadId</c>, the part size, the total number of parts, and a list of
    /// presigned upload URLs for the requested range of parts. A maximum of 10 upload URLs
    /// are returned per call. To retrieve more upload URLs for an upload that's already in
    /// progress, call <c>GetAttachmentUploadLinks</c> again with the existing <c>uploadId</c>
    /// and a new <c>uploadRange</c>.
    /// 
    ///  
    /// <para>
    /// Upload each part to its presigned URL by using HTTP <c>PUT</c> and capture the ETag
    /// from the response. After you upload all parts, call <a>CompleteAttachmentUpload</a>
    /// with the <c>uploadId</c> and the list of part indexes and ETags to finalize the upload.
    /// You can then attach the upload to a case by passing the <c>uploadId</c> in the <c>uploadIds</c>
    /// parameter of <a>CreateCase</a> or <a>AddCommunicationToCase</a>. To monitor progress
    /// before completion, call <a>DescribeAttachmentUploadStatus</a>.
    /// </para><note><ul><li><para>
    /// You must have an Amazon Web Services Business Support+, Amazon Web Services Enterprise
    /// Support, or Amazon Web Services Unified Operations plan to use the Amazon Web Services
    /// Support API. If you're in an Amazon Web Services Region that doesn't offer one of
    /// these Amazon Web Services Support plans, or if you haven't transitioned to one of
    /// these plans, you can use the Amazon Web Services Support API with a Business, Enterprise
    /// On-Ramp, or Enterprise Support plan.
    /// </para></li><li><para>
    /// If you call the Amazon Web Services Support API from an account that doesn't have
    /// an Amazon Web Services Business Support+, Amazon Web Services Enterprise Support,
    /// or Amazon Web Services Unified Operations plan, the <c>SubscriptionRequiredException</c>
    /// error message appears. For information about changing your support plan, see <a href="http://aws.amazon.com/premiumsupport/">Amazon
    /// Web Services Support</a>.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "ASAAttachmentUploadLink")]
    [OutputType("Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse")]
    [AWSCmdlet("Calls the AWS Support GetAttachmentUploadLinks API operation.", Operation = new[] {"GetAttachmentUploadLinks"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse))]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse",
        "This cmdlet returns an Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse object containing multiple properties."
    )]
    public partial class GetASAAttachmentUploadLinkCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Specifies whether to validate the request without actually generating upload URLs.
        /// When set to <c>true</c>, the request is validated but no URLs are returned, and the
        /// operation returns a <c>DryRunOperationException</c>. When omitted or set to <c>false</c>,
        /// the request runs normally.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter UploadRange_EndIndex
        /// <summary>
        /// <para>
        /// <para>The ending part index of the range, exclusive. The range is half-open: <c>startIndex</c>
        /// is inclusive and <c>endIndex</c> is exclusive. For example, a range with <c>startIndex</c>
        /// of 1 and <c>endIndex</c> of 4 requests URLs for parts 1, 2, and 3. The range size
        /// (<c>endIndex</c> - <c>startIndex</c>) must not exceed 10. If you omit <c>endIndex</c>,
        /// the service defaults to <c>startIndex</c> + 10, capped by the total number of parts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UploadRange_EndIndex { get; set; }
        #endregion
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>The name of the file to upload, including the file extension. This value is required
        /// when you initiate a new upload.</para>
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
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter FileSizeByte
        /// <summary>
        /// <para>
        /// <para>The total size of the file in bytes. The service uses this value to calculate the
        /// total number of parts and the size of each part. Required when you initiate a new
        /// upload (when <c>uploadId</c> isn't provided). Valid range: 1 to 157,286,400 bytes
        /// (approximately 150 MB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FileSizeBytes")]
        public System.Int64? FileSizeByte { get; set; }
        #endregion
        
        #region Parameter UploadRange_StartIndex
        /// <summary>
        /// <para>
        /// <para>The starting part index of the range, inclusive. Part indexes start at 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UploadRange_StartIndex { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of an in-progress multipart upload, returned by a previous call
        /// to <c>GetAttachmentUploadLinks</c>. Specify <c>uploadId</c> to retrieve additional
        /// presigned upload URLs for an upload that has already been initiated. Required when
        /// <c>fileSizeBytes</c> isn't provided. Length: 1 to 2,048 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse, GetASAAttachmentUploadLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.FileName = this.FileName;
            #if MODULAR
            if (this.FileName == null && ParameterWasBound(nameof(this.FileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSizeByte = this.FileSizeByte;
            context.UploadId = this.UploadId;
            context.UploadRange_EndIndex = this.UploadRange_EndIndex;
            context.UploadRange_StartIndex = this.UploadRange_StartIndex;
            
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
            var request = new Amazon.AWSSupport.Model.GetAttachmentUploadLinksRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
            }
            if (cmdletContext.FileSizeByte != null)
            {
                request.FileSizeBytes = cmdletContext.FileSizeByte.Value;
            }
            if (cmdletContext.UploadId != null)
            {
                request.UploadId = cmdletContext.UploadId;
            }
            
             // populate UploadRange
            var requestUploadRangeIsNull = true;
            request.UploadRange = new Amazon.AWSSupport.Model.UploadRange();
            System.Int32? requestUploadRange_uploadRange_EndIndex = null;
            if (cmdletContext.UploadRange_EndIndex != null)
            {
                requestUploadRange_uploadRange_EndIndex = cmdletContext.UploadRange_EndIndex.Value;
            }
            if (requestUploadRange_uploadRange_EndIndex != null)
            {
                request.UploadRange.EndIndex = requestUploadRange_uploadRange_EndIndex.Value;
                requestUploadRangeIsNull = false;
            }
            System.Int32? requestUploadRange_uploadRange_StartIndex = null;
            if (cmdletContext.UploadRange_StartIndex != null)
            {
                requestUploadRange_uploadRange_StartIndex = cmdletContext.UploadRange_StartIndex.Value;
            }
            if (requestUploadRange_uploadRange_StartIndex != null)
            {
                request.UploadRange.StartIndex = requestUploadRange_uploadRange_StartIndex.Value;
                requestUploadRangeIsNull = false;
            }
             // determine if request.UploadRange should be set to null
            if (requestUploadRangeIsNull)
            {
                request.UploadRange = null;
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
        
        private Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.GetAttachmentUploadLinksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "GetAttachmentUploadLinks");
            try
            {
                return client.GetAttachmentUploadLinksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String FileName { get; set; }
            public System.Int64? FileSizeByte { get; set; }
            public System.String UploadId { get; set; }
            public System.Int32? UploadRange_EndIndex { get; set; }
            public System.Int32? UploadRange_StartIndex { get; set; }
            public System.Func<Amazon.AWSSupport.Model.GetAttachmentUploadLinksResponse, GetASAAttachmentUploadLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
